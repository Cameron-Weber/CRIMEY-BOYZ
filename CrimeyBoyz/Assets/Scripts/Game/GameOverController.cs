using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Main controller for the "GameOver" Scene
public class GameOverController : MonoBehaviour {

    public Button mainMenuButton;
    public Text dataCollectedText;
    public GameObject loadingWheel;
    public Button retryUploadButton;


    private bool waitingForDbResponse;


    void Start() {
        StartDbUpload();
    }

    void Update() {
        //Return to main menu if the connection with the tablet is lost
        if (ConnectionManager.Singleton != null) {
            if (ConnectionManager.Singleton.GetState() == ConnectionState.DISCONNECTED) {
                Debug.Log("Stopping game due to disconnection");
                SessionManager.Singleton.ReturnToMainMenu();
            }
        }

        if(waitingForDbResponse) {
            DbResponse response = DbConnection.Singleton.GetResponse();
            if(response != null) {
                waitingForDbResponse = false;
                SetLoading(false);
                Debug.Log("response received");
                Debug.Log(response.state);
                Debug.Log(response.message);
            }
        }
    }

    public void GoToMainMenu() {
        SessionManager.Singleton.ReturnToMainMenu();
    }

    public void StartDbUpload() {
        if(waitingForDbResponse) {
            Debug.LogWarning("Tried to start db upload when already waiting for upload");
            return;
        }

        dataCollectedText.text = SessionManager.Singleton.dataRecorder.ToJSON();
        DbConnection.Singleton.SaveSessionData(SessionManager.Singleton.dataRecorder);
        waitingForDbResponse = true;
        SetLoading(true);
    }

    private void SetLoading(bool isLoading) {
        retryUploadButton.gameObject.SetActive(!isLoading);
        loadingWheel.SetActive(isLoading);
    }
}
