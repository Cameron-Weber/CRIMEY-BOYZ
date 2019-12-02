using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.NetworkedVar;

public class SyncObjectScale : NetworkedBehaviour {

    private NetworkedVar<Vector3> syncedScale = new NetworkedVar<Vector3>();

    private bool scaleSynced = true;

    // Start is called before the first frame update
    void Start() {

        syncedScale.Settings.WritePermission = NetworkedVarPermission.OwnerOnly;
        syncedScale.Settings.SendTickrate = 4;
        syncedScale.OnValueChanged += OnScaleSchanged;

        if (IsOwner) {
            scaleSynced = false;
        }
    }

    // Update is called once per frame
    void Update() {
        if(!scaleSynced) {
            if(IsOwner && NetworkedObject.IsSpawned) {
                syncedScale.Value = transform.localScale;
                scaleSynced = true;
            }
        }
    }

    private void OnScaleSchanged(Vector3 previous, Vector3 updated) {
        if(!IsOwner) {
            transform.localScale = updated;
        }
    }


}
