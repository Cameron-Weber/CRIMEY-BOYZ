using UnityEngine;

//Attach to an object to change its gravity when active (Tappable Objects only)
//Assumed rigidbody2D is already set to dynamic;
public class ChangeGravityWhenActive : MonoBehaviour {

    public float initialGravity = 0f;
    public float gravityWhenActive = 5f;
    public bool resetWhenNotActive = false; //set to true to revert the gravity back to the initialGravity when not active

    //Set the callback function to run when tapped on
    void Start() {
        NetworkedTappable script = gameObject.GetComponent<NetworkedTappable>();

        if (script != null) {
            script.onActiveCallback = OnActiveChanged;
        } else {
            Debug.LogWarning("ChangeGravityWhenActive must be on an object with a NetworkedTappable component");
        }

        gameObject.GetComponent<Rigidbody2D>().gravityScale = initialGravity;
    }

    /// <summary>
    /// Callback for when isActive changes (Gameobject is tapped / clicked). 
    /// This is where animation / behaviour should be run (Will be run on all instances of this object)
    /// </summary>
    /// <param name="isActive"> bool for if the object is active </param>
    private void OnActiveChanged(bool isActive) {

        if (isActive) {
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = gravityWhenActive;
        } else {
            if(resetWhenNotActive) {
                gameObject.GetComponent<Rigidbody2D>().gravityScale = initialGravity;
            }
        }
    }
}
