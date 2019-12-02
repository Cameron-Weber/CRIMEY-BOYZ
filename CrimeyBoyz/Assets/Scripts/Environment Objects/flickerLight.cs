using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI.NetworkedVar;

public class flickerLight : MonoBehaviour
{
    //flickers 2D lights by changing their scale

    public float scaleChange = 0.1f;
    public float timeToFlicker = 0.25f;

    NetworkedVar<float> nwScaleChange = new NetworkedVar<float>();
    NetworkedVar<float> nwTimeToFlicker = new NetworkedVar<float>();

    float timer = 0;
    Vector3 origScale;

    // Start is called before the first frame update
    void Start()
    {
        nwScaleChange.Value = scaleChange;
        nwTimeToFlicker.Value = timeToFlicker;
        origScale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > nwTimeToFlicker.Value) {
            gameObject.transform.localScale += (origScale * nwScaleChange.Value);
            //invert scaleChange
            nwScaleChange.Value = nwScaleChange.Value * -1;

            timer = 0;
        }
    }
}
