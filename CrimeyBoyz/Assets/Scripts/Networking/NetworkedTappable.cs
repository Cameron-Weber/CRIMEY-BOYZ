using MLAPI;
using MLAPI.NetworkedVar;
using UnityEngine;

//Add to an object to enable it being tapped / click (Works with both mouse or finger depending on device)
//If this instance of the object is the network owner, will detect being tapped and set itself as "active" when clicked and no "active" when not clicked
public class NetworkedTappable :  NetworkedBehaviour {

    public delegate void OnActiveChangedCallback (bool isActive); //Callback for when isActive status changes

    public OnActiveChangedCallback onActiveCallback;

    private NetworkedVar<bool> isActive = new NetworkedVar<bool>(); //Synced between the server and client


    //Initiate networked var
    private void Awake() {

        isActive.Settings.WritePermission = NetworkedVarPermission.OwnerOnly; //Owner is the only entity that can change the active status of this object
        isActive.OnValueChanged = UpdateActiveStatus;

    }
    

    private void Update()
    {
       

    }

    /// <summary>
    /// Callback function for when the synced var is changed. Called on all clients (including the server)
    /// </summary>
    /// <param name="previous"> Previous state of the object </param>
    /// <param name="updated"> Updated state of the object </param>
    private void UpdateActiveStatus(bool previous, bool updated) {
        onActiveCallback?.Invoke(updated); //Call the delegate if it has been specified

    }


    /// <summary>
    /// Activate the object when tapped (owner only)
    /// </summary>
    protected void OnMouseDown() {

        Debug.Log("tap");

        if (IsOwner) {
            isActive.Value = true;
        }
    }

    /// <summary>
    /// Deactivate the object when mouse release (owner only)
    /// </summary>
    protected void OnMouseUp() {
        if (IsOwner) {
            isActive.Value = false;
        }
    }

}
