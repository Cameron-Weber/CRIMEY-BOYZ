using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MLAPI;
using MLAPI.NetworkedVar;
using MLAPI.Messaging;

public class NetworkedDespawn : NetworkedBehaviour {

    public float lifeSpan = 5;
    float lifeTimer;

    public float timeToSpawn = 2;
    float spawnTimer;

    private BoxCollider2D bc2d;
    private Color spriteColour;
    private Rigidbody2D rb2d;

    public SpriteRenderer[] platformSprites;
    //SpriteRenderer platformSprite


    void Awake() {
        //For this script -1 timer means that it is not running (set to 0 to start the countdown)
        lifeTimer = -1f;
        spawnTimer = -1f;

        //Init the object as non simulated
        bc2d = gameObject.GetComponent<BoxCollider2D>();
        //bc2d.enabled = false;

        platformSprites = gameObject.GetComponentsInChildren<SpriteRenderer>();

        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.simulated = false;

        changeColourOfChildren(new Color(0.3f, 1, 0.3f, 0f));

    }

    // Update is called once per frame
    void Update() {

        if(spawnTimer < 0 && lifeTimer < 0) {
            if(GetComponent<NetworkedObject>().IsSpawned) {
                spawnTimer = 0;
            }
        }

        //if the platform is starting to spawn
        if (spawnTimer >= 0) {
            spawnTimer += Time.deltaTime;

            changeColourOfChildren(new Color(0.3f, 1, 0.3f, spawnTimer / timeToSpawn));

            if (spawnTimer >= timeToSpawn) {
                concreteSpawn();
            }
        }

        if (lifeTimer >= 0) {
            lifeTimer += Time.deltaTime;

            if (lifeTimer > lifeSpan / 2) {

                changeColourOfChildren(new Color(1, 0, 0, 1 - lifeTimer / (lifeSpan)));

            }

            if (lifeTimer > lifeSpan) {
                if (IsServer) {
                    gameObject.GetComponent<NetworkedObject>().UnSpawn();
                    Destroy(gameObject);
                }
            }
        }
    }

    protected void concreteSpawn() {
        changeColourOfChildren(Color.white);
        bc2d.enabled = true;
        rb2d.simulated = true;
        spawnTimer = -1;
        lifeTimer = 0;

        if (NetworkingManager.Singleton.IsServer || NetworkingManager.Singleton.IsHost) {
            SessionManager.Singleton.dataRecorder.RecordInteraction("PlatformSpawn", SessionManager.Singleton.tabletPlayer, transform.position.x, transform.position.y, null);
        }
    }

    public void changeColourOfChildren(Color colour) {
        foreach (SpriteRenderer s in platformSprites) {
            s.color = colour;
        }
    }

}
