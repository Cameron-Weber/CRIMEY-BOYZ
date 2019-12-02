using UnityEngine.EventSystems;
using UnityEngine;

//Attach to a game object for it to change to the currently "selected" item when the mouse hovers over it.
public class SelectOnMouseOver : MonoBehaviour, IPointerEnterHandler {


    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Defines ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Variables ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    private EventSystem eventSystem; //Current event system, used to set the currently selected object

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Behavioural ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void Start() {

        eventSystem = EventSystem.current;
    }

    public void OnPointerEnter(PointerEventData eventData) {

        eventSystem.SetSelectedGameObject(transform.gameObject);
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Public Functions ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Helper Functions ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
}
