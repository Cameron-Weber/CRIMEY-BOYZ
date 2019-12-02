using UnityEngine;

//Player collision checking. (Is a given player on the ground / against a wall?)
public class collCheck : MonoBehaviour {
    private float Distx, Disty, Posx, Posy;
    private float boxSize = 0.01f;
    private LayerMask groundLayer;
    private float distSoftener = 0.8f;
    private BoxCollider2D bc;
    // Start is called before the first frame update
    void Start() {
        groundLayer = LayerMask.GetMask("Ground");
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update() {
        Distx = bc.size.x/2;
        Disty = bc.size.y/2;
        Posx = transform.position.x;
        Posy = transform.position.y;
    }

    /// <summary>
    /// Get if the player is grounded
    /// </summary>
    /// <returns>
    /// True if the player is grounded, false if otherwise
    /// </returns>
    public bool isGrounded() {
        return Physics2D.OverlapArea(new Vector2(Posx - distSoftener * Distx, Posy - Disty - boxSize),
            new Vector2(Posx + distSoftener * Distx, Posy), groundLayer);
    }

    /// <summary>
    /// Get if a player is on the left wall
    /// </summary>
    /// <returns>
    /// Returns true if the player is on the left wall, false if otherwise
    /// </returns>
    public bool wallLeft() {
        return Physics2D.OverlapArea(new Vector2(Posx - Distx - boxSize, Posy + distSoftener * Disty),
            new Vector2(Posx - Distx, Posy - distSoftener * Disty), groundLayer);
    }

    /// <summary>
    /// Get if a player is on the right wall
    /// </summary>
    /// <returns>
    /// Returns true if a player is on the right wall, false if otherwise
    /// </returns>
    public bool wallRight() {
        return Physics2D.OverlapArea(new Vector2(Posx + Distx + boxSize, Posy + distSoftener * Disty),
            new Vector2(Posx + Distx, Posy - distSoftener * Disty), groundLayer);
    }

}
