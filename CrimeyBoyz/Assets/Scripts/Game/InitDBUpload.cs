using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class InitDBUpload : MonoBehaviour {

    public GameObject loadingWheel;

    private bool waitingForDbResponse;

    // Start is called before the first frame update
    void Start() {
        if(NetworkingManager.Singleton.IsHost || NetworkingManager.Singleton.IsServer) {
            StartDbUpload();
        }
    }

    // Update is called once per frame
    void Update() {
        if (waitingForDbResponse) {
            DbResponse response = DbConnection.Singleton.GetResponse();
            if (response != null) {
                waitingForDbResponse = false;
                SetLoading(false);
                Debug.Log("response received");
                Debug.Log(response.state);
                Debug.Log(response.message);
            }
        }
    }

    public void StartDbUpload() {
        if (waitingForDbResponse) {
            Debug.LogWarning("Tried to start db upload when already waiting for upload");
            return;
        }

        //dataCollectedText.text = SessionManager.Singleton.dataRecorder.ToJSON();
        DbConnection.Singleton.SaveSessionData(SessionManager.Singleton.dataRecorder);
        waitingForDbResponse = true;
        SetLoading(true);
    }

    private void SetLoading(bool isLoading) {
        //retryUploadButton.gameObject.SetActive(!isLoading);
        loadingWheel.SetActive(isLoading);
    }

}
