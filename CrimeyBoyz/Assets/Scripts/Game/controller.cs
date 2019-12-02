using System.Collections.Generic;
using UnityEngine;

//[Obsolete]
//Initial testing of detecting gamepad inputs.
public class controller : MonoBehaviour {
    public GameObject playerPrefab;

    private Dictionary<int, player> players = new Dictionary<int, player>();
    private List<int> unusedControllers = new List<int> { 1, 2, 3, 4 };
    private string waitingPlayer;
    // Start is called before the first frame update
    void Start() {
        //TODO//
        //Adds a player to the game. Placeholder until this is implemented
        waitingPlayer = "Chad";
        Debug.Log(waitingPlayer + ", press 'a' on your controller");
    }

    // Update is called once per frame
    void Update() {
        //Check if a recently added player needs a controller
        newPlayerCheck();

        //Test add players
        if (Input.GetKeyDown("1")) {
            if (waitingPlayer.Length == 0) {
                addPlayer("Doif");
            }
        }
    }

    /// <summary>
    /// Adds a player to the game
    /// </summary>
    /// <param name="name"> The name of the player being added </param>
    void addPlayer(string name) {
        waitingPlayer = name;
        Debug.Log(waitingPlayer + ", press 'a' on your controller");
    }

    /// <summary>
    /// Checks if a new player has a controller assigned
    /// </summary>
    void newPlayerCheck() {
        if (waitingPlayer.Length > 0) {
            foreach (int controllerNum in unusedControllers) {
                if (Input.GetButton("A" + controllerNum)) {
                    addController(controllerNum);
                    break;
                }
            }
        }
    }

    /// <summary>
    /// Adds a controller to a new player
    /// </summary>
    /// <param name="controllerNum"> The number of the controller being added </param>
    void addController(int controllerNum) {
        GameObject newPlayer = Instantiate(playerPrefab);
        players.Add(controllerNum, newPlayer.GetComponent<player>());
        players[controllerNum].setName(waitingPlayer);
        players[controllerNum].setController(controllerNum);
        waitingPlayer = "";
        unusedControllers.Remove(controllerNum);
        Debug.Log(players[controllerNum].getName() + " is using controller number " + controllerNum);
    }
}
