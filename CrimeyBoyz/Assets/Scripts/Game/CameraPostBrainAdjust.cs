using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraPostBrainAdjust : MonoBehaviour
{

    //Vector2 cameraPos;
    //CinemachineBrain cinebrain;
    public GameObject laser;
    public FollowPlayers playerTracker;
    public GameObject endElevator;

    float orthographicWidth;

    // Start is called before the first frame update
    void Start()
    {
        //cameraPos = Camera.main.transform.position;
        //cinebrain = Camera.main.GetComponent<CinemachineBrain>();
        orthographicWidth = Camera.main.orthographicSize * Camera.main.pixelWidth / Camera.main.pixelHeight;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTracker.transform.position.x < laser.transform.position.x + orthographicWidth &&
            playerTracker.transform.position.x < endElevator.transform.position.x) {
            
            playerTracker.transform.Translate(
                new Vector2(laser.transform.position.x - playerTracker.transform.position.x + orthographicWidth,0));
        }
    }
}
