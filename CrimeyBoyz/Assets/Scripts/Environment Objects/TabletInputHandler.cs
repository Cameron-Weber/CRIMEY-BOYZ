using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletInputHandler : MonoBehaviour
{

    Camera thisCamera;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Load Tablet");
        thisCamera = this.gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            //Vector2 touchPos = 

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Ray touchRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            //RaycastHit2D hit;

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                //touch on
                //handle collisions
                {

                    // Do something with the object that was hit by the raycast.
                }

            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                //touch on
            }
            

            if (Input.GetTouch(0).phase == TouchPhase.Moved) {
                //move
            }

        }
    }


}
