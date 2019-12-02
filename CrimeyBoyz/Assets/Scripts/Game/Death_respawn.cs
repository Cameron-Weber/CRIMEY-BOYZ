using UnityEngine;

//[Obsolete]
//Initial implementation for death and respawning. Moved to Player script
public class Death_respawn : MonoBehaviour {
    
    bool IsDead;
    public bool IsPlayer;
    float RespawnTimer = 0;
    public float RespawnTimerLimit = 1;

    // Start is called before the first frame update
    void Start() {
        IsDead = false;
    }

    // Update is called once per frame
    void Update() {
        if (IsDead) {
            RespawnTimer += Time.deltaTime;
        }

        if (IsPlayer && IsDead && RespawnTimer > RespawnTimerLimit) {

        }
    }

    /// <summary>
    /// Kill the player by destroying their gameobject
    /// </summary>
    public void KillPlayer() {
        //kills the current gameObject
        Destroy(gameObject);
    }
}
