using UnityEngine;

//Simple script that rotates itself every frame
public class LoadingCircle : MonoBehaviour {

    private RectTransform me;

    public float rotationSpeed = 1f; //# rotations per second

    void Start() {
        me = GetComponent<RectTransform>();
    }

    void Update() {
        me.Rotate(0f, 0f, rotationSpeed * 360f * Time.deltaTime);
    }
}
