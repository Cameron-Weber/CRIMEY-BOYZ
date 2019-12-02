using UnityEngine;

//Testing non-networked Fling-able scene objects
public class Flingable : Draggable {

    //how many world units this can be dragged
    public float maxDistance = 3;

    private Rigidbody2D rb2d;

    private Vector2 initialPos;

    // Start is called before the first frame update
    new void Start() {
        //TODO: Check ux-yness of this - will this mess with initial object placement?
        initialPos = gameObject.transform.position;
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    override protected void Update() {

        //call superclass methods
        base.Update();

        Vector2 currentPos = gameObject.transform.position;

        Debug.Log((currentPos - initialPos).magnitude);

        if (currentPos != initialPos) {
            if (!isActive) {
                float distance = (currentPos - initialPos).magnitude;
                if (distance > maxDistance) {
                    //then let go at max speed
                    fling((currentPos - initialPos).normalized * maxDistance);
                }

                fling(currentPos);
                //it has been let go - let go proportionate to distance.

            }
        }
    }

    /// <summary>
    /// Accelerates the object in a specified direction
    /// </summary>
    /// <param name="position"> The direction that the object will be 'flung' in </param>
    private void fling(Vector2 position) {
        //rapidly accelerates based on input
        SetIsActive(false);
        rb2d.AddForce(position, ForceMode2D.Impulse);

        Vector2 currentPos = gameObject.transform.position;



    }
}
