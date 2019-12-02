using UnityEngine;

//Auto scrolling component for the laser
public class AutoScroll : MonoBehaviour {

    public Vector2 startPosition;
    public Vector2 endPosition;
    public bool returnWhenAtEnd = false;

    public bool makeStartPositionThis = false;

    //public GameObject myCamera;
    private FollowPlayers myCameraComponent;

    //time before the laser starts scrolling
    public float startWaitTime = 5.0f;
    public float scrollTime = 30.0f;

    public float maxSpeed = 1f;

    int translateDirection = 1;

    //minX, minY, maxX, maxY;
    Vector4 bounds;
    float functionInput;


    // Start is called before the first frame update
    void Start() {
        if (makeStartPositionThis) {
            
        }
        else
        {
            gameObject.transform.position = startPosition;
        }

        functionInput = 0;
    }

    // Update is called once per frame
    void Update() {
        //FUNCTION:
        //Quadratic function.used to determine death laser position.

        float prevFunctionInput = functionInput;

        functionInput += Time.deltaTime;
        float translateDistance = laserScrollSpeedFunction(functionInput)
                                                        - laserScrollSpeedFunction(prevFunctionInput);

        if (functionInput >= startWaitTime) {

            if (translateDirection > 0)
            {
                if (gameObject.transform.position.x < endPosition.x)
                {
                    handleTranslation(translateDistance);
                }
                else {
                    handleLoop();
                }
            }
            else {
                if (gameObject.transform.position.x > endPosition.x)
                {
                    handleTranslation(translateDistance);
                }
                else {
                    handleLoop();
                }
            }
        }

    }

    void handleLoop() {
        if (returnWhenAtEnd)
        {
            functionInput = 0;
            Vector2 temp = endPosition;
            endPosition = startPosition;
            startPosition = temp;
            
            translateDirection *= -1;
        }
    }

    void handleTranslation(float translateDistance) {

        if (Mathf.Abs(translateDistance) > maxSpeed)
        {
            translateDistance = maxSpeed;
        }
        
        gameObject.transform.Translate(new Vector2(translateDistance, 0));
    }

    /// <summary>
    /// Method to get the speed that the death laser should be moving at
    /// </summary>
    /// <param name="input"> Input for laser speed. Increases over time </param>
    /// <returns>
    /// A float containing the new speed for the laser
    /// </returns>
    float laserScrollSpeedFunction(float input) {
        //A quadratic function that returns a value with respect to time.
        //Returns an x coordinate for the function y = ax^n

        float exponent = 1.8f;
        float distance = endPosition.x - startPosition.x;


        float result = (distance / Mathf.Pow(scrollTime, exponent)) * Mathf.Pow(input, exponent);


        return result;
    }

}
