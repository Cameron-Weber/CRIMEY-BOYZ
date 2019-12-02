using UnityEngine;
using MLAPI;
using MLAPI.NetworkedVar;

//Controller for the MoneyBag object
public class moneyBag : NetworkedBehaviour {

    public GameObject buttonPrompt;

    void Start() {
        if(!IsServer) {
            transform.parent.GetComponent<Rigidbody2D>().simulated = false;
        }
    }

    /// <summary>
    /// Checks if a player is ready to pick up the money bag
    /// </summary>
    /// <param name="col"> The object a money bag is currently colliding with </param>
    private void OnTriggerStay2D(Collider2D col) {
        //If the object being collided with is a player
        if (col.gameObject.GetComponent<player>()) {
            player gamer = col.gameObject.GetComponent<player>();
            //If that player presses the x button
            if (gamer.getButtonDown("X")) {
                //Pick up the money bag
                gamer.setLoaded(transform.parent.gameObject);
                //buttonPrompt.GetComponent<SpriteRenderer>().enabled = false;
                buttonPrompt.gameObject.SetActive(false);
                //Debug.Log("Money bag picked up");
                //Destroy(transform.parent.gameObject);
                //Destroy(gameObject);
            }
        }

    }

}
