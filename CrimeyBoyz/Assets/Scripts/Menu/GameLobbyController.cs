using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MLAPI.SceneManagement;
using MLAPI;
using CrimeyBoyz.GameState;

//Manages the game lobby, including waiting for the setup and joining of players
//Designed to be attached to the GameLobby prefab
//Designed to start connecting / hosting when enabled
//Stopping the ConnectionController when hitting the "Back" button is controlled by MenuController.cs
public class GameLobbyController : MonoBehaviour {

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Variables ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    public Button startGameButton;
    public bool bypassPlayerLogin = false; //Set to override the "Start" button and start the game without the tablet connected
    public MissionControlStatusController missionControlController;
    public GameObject mainGameLobby;
    public GameObject tilesGroup;
    public GameObject characterSelectionTilePrefab;

    private bool lobbyEnabled = false;
    private List<CharacterSelectionController> characterTiles;
    private ConnectionState lastConnectionState;

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Behavioural ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void OnEnable() {
        //startGameButton.interactable = overrideStartButton ? true : false;

        ConnectionManager.Singleton.isServer = true;
        ConnectionManager.Singleton.retryUponFailure = true;

        ConnectionManager.Singleton.InitiateConnection();
        SessionManager.Singleton.StartListeningForControllers(bypassPlayerLogin);

        characterTiles = new List<CharacterSelectionController>();
        CharacterSelectionController[] found = tilesGroup.GetComponentsInChildren<CharacterSelectionController>();
        for(int i = 0; i < found.Length; i++) {
            characterTiles.Add(found[i]);
        }

        SessionManager.Singleton.PlayerStateChangedCallback += UpdateTiles;

        lobbyEnabled = bypassPlayerLogin;
        UpdateTiles();
        SetVisibleObjects();
    }

    /// <summary>
    /// Update the connection status each frame
    /// </summary>
    private void Update() {

        ConnectionState current = ConnectionManager.Singleton.GetState();

        if (!lobbyEnabled) {
            if(current != lastConnectionState) {
                missionControlController.UpdateMissionControlStatus();
                lastConnectionState = current;
                SetVisibleObjects();
            }

            if(current == ConnectionState.CONNECTED && SessionManager.Singleton.IsNetworkedGameStateReady()) {
                missionControlController.UpdateMissionControlStatus();
                StartCoroutine(DelayedMenuSwitch(true, 0.5f));
            }

        } else {
            if(current != ConnectionState.CONNECTED && !bypassPlayerLogin) {
                lobbyEnabled = false;
                SessionManager.Singleton.ResetUnassignedControllers();
                missionControlController.UpdateMissionControlStatus();
                SetVisibleObjects();
            }
        }
    }

    private void OnDestroy() {
        SessionManager.Singleton.PlayerStateChangedCallback -= UpdateTiles;
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Public Functions ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    public void ExitLobby() {
        ConnectionManager.Singleton.CloseConnection();
        SessionManager.Singleton.ResetUnassignedControllers();
        MenuController.Singleton.OpenMainMenu();
    }


    /// <summary>
    /// Moves to the game scene and begins the game.
    /// Should only be called when the game is ready to be begin
    /// </summary>
    public void StartGame() {

        if(!NetworkingManager.Singleton.IsHost && !NetworkingManager.Singleton.IsServer) {
            Debug.LogError("Tried to start the game without the server running...");
            return;
        }

        if (CanStartGame()) {
            SessionManager.Singleton.setWinCon();
            SessionManager.Singleton.LoadNextFloor();

        } else {
            Debug.LogWarning("Tried to start the game when not connected");
        }
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Helper Functions ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    IEnumerator DelayedMenuSwitch(bool lobbyEnabled, float delay) {
        yield return new WaitForSeconds(delay);
        this.lobbyEnabled = lobbyEnabled;
        SetVisibleObjects();
    }

    private void SetVisibleObjects() {
        missionControlController.gameObject.SetActive(!lobbyEnabled);
        mainGameLobby.SetActive(lobbyEnabled);
    }

    private bool CanStartGame() {
        if(bypassPlayerLogin) {
            return true;
        }

        if(ConnectionManager.Singleton.GetState() != ConnectionState.CONNECTED) {
            return false;
        }

        if(!SessionManager.Singleton.IsNetworkedGameStateReady()) {
            return false;
        }

        //Check all players have controllers assigned
        Dictionary<int, PlayerInfo> players = SessionManager.Singleton.networkedGameState.GetAllPlayers();

        if(players == null || players.Count < 3) {
            return false;
        }

        foreach (KeyValuePair<int, PlayerInfo> player in players) {
            if(player.Value.assignedController < 0) {
                return false;
            }
        }

        return true;
    }

    private void UpdateTiles() {
        int numTiles = 0;
        if(!SessionManager.Singleton.IsNetworkedGameStateReady()) {
            numTiles = 3;
        } else {
            numTiles = SessionManager.Singleton.networkedGameState.PlayerCount();
        }
        if(numTiles < 3) {
            numTiles = 3;
        }

        //Check if new tiles need to be added
        for(int i = 0; i < numTiles; i++) {
            if(characterTiles.Count <= i) {
                GameObject newTile = Instantiate(characterSelectionTilePrefab, tilesGroup.transform);
                newTile.transform.SetSiblingIndex(i);
                characterTiles.Add(newTile.GetComponent<CharacterSelectionController>());
            }
        }

        bool invalid = true;
        while (invalid) {
            invalid = false;
            for (int i = 0; i < numTiles; i++) {
                if (characterTiles[i].GetPlayerNumber() != i + 1) {
                    characterTiles[i].SetPlayerNumber(i + 1);
                    invalid = true;
                }

                if(characterTiles[i].transform.GetSiblingIndex() != i) {
                    characterTiles[i].transform.SetSiblingIndex(i);
                    invalid = true;
                }
            }
        }


        //Cleanup
        while (characterTiles.Count > numTiles) {
            GameObject temp = characterTiles[numTiles].gameObject;
            characterTiles.RemoveAt(numTiles);
            Destroy(temp);
        }

        startGameButton.interactable = CanStartGame();
    }
}
