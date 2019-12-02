using UnityEngine;

//Testing non-networked Touchable scene objects (Actived on touch)
public class Touchable : MonoBehaviour {
    //Abstract class for an object that is able to be clicked by a mouse (or touched)

    //TO ENABLE PHYSICS: Simply change the gravity parameter in the attached Rigidbody to 1. Easy!

    // Start is called before the first frame update
    protected bool isActive = false;


    protected void Start() {
        Debug.Log("LOAD");
    }

    // Update is called once per frame
    protected void Update() {

    }

    /// <summary>
    /// Getter/setter for isActive 
    /// </summary>
    /// <param name="set"> The value to set isActive to </param>
    /// <returns></returns>
    public bool SetIsActive(bool set) {
        isActive = set;

        if (isActive) {
            gameObject.GetComponentsInChildren<Renderer>()[0].material.SetColor("_Color", Color.green);
            //gameObject.GetComponentsInChildren<Renderer>()[0].material.color = Color.green;
        } else {
            //gameObject.GetComponentsInChildren<Renderer>()[0].material.color = Color.white;
            gameObject.GetComponentsInChildren<Renderer>()[0].material.SetColor("_Color", Color.white);
        }

        return isActive;
    }

    /// <summary>
    /// Sets the touchable object to be active
    /// </summary>
    protected void ReactToMouse() {
        SetIsActive(true);
    }

    /// <summary>
    /// Checks if the touchable has been clicked or touched
    /// </summary>
    protected void OnMouseDown() {
        ReactToMouse();
    }

    /// <summary>
    /// Checks if the player's finger or mouse has been lifted up from the touchable
    /// Deactivates if the touchable is untouched
    /// </summary>
    protected void OnMouseUp() {
        SetIsActive(false);
    }


}
