using UnityEngine;

//Script added to hostile objects to kill players that collide with it.
//Must be used on an object with a BoxCollider component with isTrigger = false;
public class Damageable : MonoBehaviour {

    public string causeOfDeath = "Damageable";

    bool isActive = true;

    private void Start()
    {
    }

    /// <summary>
    /// Kills a player if they come into contact with this object
    /// </summary>
    /// <param name="collision"> The object that has collided with the damageable </param>
    protected void OnCollisionEnter2D(Collision2D collision) {
        
        player gamer = collision.gameObject.GetComponent<player>();
        if (gamer != null && isActive) {
            gamer.killPlayer(causeOfDeath);
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision) {
        player gamer = collision.gameObject.GetComponent<player>();
        if (gamer != null && isActive)
        {
            gamer.killPlayer(causeOfDeath);
        }
        

    }

    public void activate(bool shouldActivate) {
        isActive = shouldActivate;
    }

    protected bool getActiveStatus() {
        return isActive;
    }

}
