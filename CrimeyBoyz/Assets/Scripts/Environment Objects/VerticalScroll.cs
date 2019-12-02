using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour
{
    float cameraBound;
    public float time = 10;
    public float speed = 1;
    //float timer = 0;
    Vector2 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        cameraBound = Camera.main.orthographicSize * 2;
        initialPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector2(0, - speedOverTime()) * Time.deltaTime * speed);
        
        if (gameObject.transform.position.y < initialPos.y - cameraBound * 1.5) {
            gameObject.transform.position = new Vector2(initialPos.x, initialPos.y + cameraBound * 1.5f);
        }
        
        
    }

    float speedOverTime() {
        return cameraBound * 1.5f / time;
    }
}
