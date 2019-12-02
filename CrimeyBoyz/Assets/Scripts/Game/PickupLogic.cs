using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLogic : MonoBehaviour
{
    int initialLayer;
    Color initialColour;
    Rigidbody2D rb2d;  
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.simulated = true;
        initialLayer = gameObject.layer;
        initialColour = gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetActiveBehaviour() {
        StartCoroutine(delayActiveBehaviour());
    }

    IEnumerator delayActiveBehaviour() {
        yield return new WaitForSeconds(0.15f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        gameObject.GetComponent<Damageable>().activate(true);
        gameObject.layer = 1;
    }

    public void SetInactiveBehaviour() {
        gameObject.GetComponent<SpriteRenderer>().color = initialColour;
        gameObject.GetComponent<Damageable>().activate(false);
        gameObject.layer = initialLayer;
    }

    
    private void OnCollisionStay2D(Collision2D collision)
    {
        //8 = ground
        if (collision.collider.gameObject.tag != "Player") {
            SetInactiveBehaviour();
        }
    }

}
