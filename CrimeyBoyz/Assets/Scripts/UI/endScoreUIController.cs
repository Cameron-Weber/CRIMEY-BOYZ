using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class endScoreUIController : MonoBehaviour
{
    public GameObject score;
    public GameObject pname;
    SpriteRenderer sprite;
    public GameObject pPlace;

    private void Awake() {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    public void setPlace(int place) {

        string output = place.ToString();

        switch (place)
        {
            case 1:
                output += "st";
                break;
            case 2:
                output += "nd";
                break;
            case 3:
                output += "rd";
                break;
            default:
                output += "th";
                break;
        }
       
        pPlace.GetComponent<TextMeshPro>().text = output;
    }

    public GameObject getScore() { return score; }

    public SpriteRenderer getSprite() { return sprite; }

    public GameObject getPName() { return pname; }

    public void setColours(int pNum) {

            Color32[] playerColours = {
            new Color32(240, 65, 65, 255),
            new Color32(58, 107, 242, 255),
            new Color32(237, 223, 69, 255),
            new Color32(110, 219, 88, 255),
            new Color32(247, 125, 2, 255)
        };

        getScore().GetComponent<TextMeshPro>().color = playerColours[pNum - 1];
        getPName().GetComponent<TextMeshPro>().color = playerColours[pNum - 1];
    }
}
