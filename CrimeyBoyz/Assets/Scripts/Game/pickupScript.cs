using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.NetworkedVar;

public class pickupScript : NetworkedBehaviour {

    public GameObject buttonPrompt;

    void Start()
    {
        if (!IsServer)
        {
            transform.parent.GetComponent<Rigidbody2D>().simulated = false;
        }
    }

    /// <summary>
    /// Checks if a player is ready to pick up the money bag
    /// </summary>
    /// <param name="col"> The object a money bag is currently colliding with </param>
    private void OnTriggerStay2D(Collider2D col)
    {
        //If the object being collided with is a player
        if (col.gameObject.GetComponent<player>())
        {
            player gamer = col.gameObject.GetComponent<player>();
            //If that player presses the x button
            if (gamer.getButtonDown("X"))
            {

                gamer.setLoaded(transform.parent.gameObject);
                buttonPrompt.SetActive(false);
            }
        }

    }

}