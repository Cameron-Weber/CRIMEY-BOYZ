using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StashTextUIController : MonoBehaviour
{

    //Small controller for the stash display

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().sortingOrder = 6;
        gameObject.GetComponent<MeshRenderer>().sortingLayerName = "UI";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void writeToStash(int value) {
        if (value <= 0)
        {
            darken();
            value = 0;
        }
        else {
            brighten();
        }

        string newText = value.ToString();
        gameObject.GetComponent<TextMeshPro>().text = newText;
    }

    //darkens the stash indicator background
    public void darken() {
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.gray;
    }

    //brightens the stash indicator background
    public void brighten() {
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }
    
}
