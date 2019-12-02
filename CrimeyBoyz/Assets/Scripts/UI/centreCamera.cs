using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class centreCamera : MonoBehaviour {

    //private GameObject mainCamera;
    Color initialColour;
    bool isBeingTouched = false;

    DragToChangePosition changePosController;

    private bool isMissionControl = false;

    // Start is called before the first frame update
    void Start() {
        UpdateIsMissionControl();

        initialColour = gameObject.GetComponent<SpriteRenderer>().color;
        //mainCamera = Camera.main.gameObject;

        gameObject.SetActive(isMissionControl);

        DragToChangePosition[] results = Resources.FindObjectsOfTypeAll<DragToChangePosition>();
        if (results.Length > 0) {
            changePosController = results[0];
        }

    }

    public bool getTouched() {
        return isBeingTouched;
    }

    protected void OnMouseDown() {
        //mainCamera.GetComponent<DragToChangePosition>().resetCameraPosition();
        isBeingTouched = true;
        changePosController.resetCameraPosition();
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }

    protected void OnMouseUp() {
        gameObject.GetComponent<SpriteRenderer>().color = initialColour;
        isBeingTouched = false;
    }

    private void UpdateIsMissionControl() {
        if (NetworkingManager.Singleton.LocalClientId == ConnectionManager.Singleton.GetMissionControlID()) {
            isMissionControl = true;
        } else {
            isMissionControl = false;
        }
        //Debug.Log("Is Mission Control: " + isMissionControl.ToString());
    }
}
