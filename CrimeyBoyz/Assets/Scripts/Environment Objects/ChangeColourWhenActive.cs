using UnityEngine;

//Attach to an object to change its quad's colour when active (Tappable Objects only)
public class ChangeColourWhenActive : MonoBehaviour {

    //Set the callback function to run when tapped on
    void Start() {
        NetworkedTappable script = gameObject.GetComponent<NetworkedTappable>();

        if(script != null) {
            script.onActiveCallback = OnActiveChanged;
        } else {
            Debug.LogWarning("ChangeColourWhenActive must be on an object with a NetworkedTappable component");
        }
    }

    /// <summary>
    /// Callback for when isActive changes (Gameobject is tapped / clicked). 
    /// This is where animation / behaviour should be run (Will be run on all instances of this object)
    /// </summary>
    /// <param name="isActive"> Value for if the object is active or not </param>
    private void OnActiveChanged(bool isActive) {
        if(isActive) {
            gameObject.GetComponentsInChildren<SpriteRenderer>()[0].color = Color.red;
        } else {
            gameObject.GetComponentsInChildren<SpriteRenderer>()[0].color = Color.white;
        }
    }
}
