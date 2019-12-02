using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manages the "Lobby" section in the main menu
//Initialises lobby prefabs based on current build
//Will initialise prefabs as children of the attached GameObject
public class LobbyController : MonoBehaviour {

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Variables ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    public GameObject gameLobbyPrefab;
    public GameObject controllerLobbyPrefab;

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Behavioural ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    private void Awake() {
        AddBuildPrefabs();
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Helper Functions ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    /// <summary>
    /// Initialise lobby prefabs based on current build
    /// </summary>
    private void AddBuildPrefabs() {

#if DECO3801_GAME_BUILD && !DECO3801_MISSIONCONTROL_BUILD
        GameObject lobby = Instantiate(gameLobbyPrefab);

        lobby.transform.SetParent(transform, false);
        lobby.transform.SetSiblingIndex(0);
#else
        GameObject lobby = Instantiate(controllerLobbyPrefab);

        lobby.transform.SetParent(transform, false);
        lobby.transform.SetSiblingIndex(0);
#endif
    }
}
