using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionControlStatusController : MonoBehaviour {

    public Text statusText;
    public Image border;



    public void UpdateMissionControlStatus() {

        ConnectionState state = ConnectionManager.Singleton.GetState();

        if (state == ConnectionState.CONNECTED) {
            border.color = Color.green;
            statusText.text = "Connected!";

        } else if (state == ConnectionState.LISTENING) {
            border.color = Color.yellow;
            statusText.text = "Please press \"Play\" on mission control";

        } else if (state == ConnectionState.SEARCHING) {
            border.color = Color.yellow;
            statusText.text = "Searching for a game";

        } else if (state == ConnectionState.CONNECTING) {
            border.color = Color.yellow;
            statusText.text = "Connecting to the game";

        } else if (state == ConnectionState.DENIED) {
            border.color = Color.red;
            statusText.text = "Connecting failed, will retry soon";

        } else if (state == ConnectionState.DISCONNECTED) {
            border.color = Color.red;
            statusText.text = "Disconnected from game, will retry soon";

        } else if (state == ConnectionState.STOPPED) {
            border.color = Color.red;
            statusText.text = "Stopped, Timed out?";

        } else {
            border.color = new Color(255, 128, 0);
            statusText.text = "Unexpected: ¯\\_(ツ)_/¯";
            Debug.LogWarning("Unexpected connection state while in mission control status");
        }
    }
}
