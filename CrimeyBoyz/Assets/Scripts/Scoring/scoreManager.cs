using System.Collections.Generic;
using UnityEngine;

//Controls the scoreboard
public class scoreManager : MonoBehaviour {

    private GameManager gm;
    private moneyDistribution md;
    public GameObject scoreboard;
    
    void Start() {
        //gm = GetComponent<GameManager>();
        //md = scoreboard.GetComponent<moneyDistribution>();
    }

    /// <summary>
    /// Opens the share menu for players to see who they can share money with
    /// </summary>
    /// <param name="loadedPlayer"> The player who has all the money </param>
    /// <param name="inElevator"> A list of all players in the elevator </param>
    //public void openShareMenu(player loadedPlayer, List<player> inElevator) {
        //md.boardMove(true, loadedPlayer, inElevator);
    //}
}
