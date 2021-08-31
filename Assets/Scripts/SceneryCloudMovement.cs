using UnityEngine;

/*
 * This script is attached to a cloud prefab to make the cloud move
 */
public class SceneryCloudMovement : MonoBehaviour
{
    // Cloud movement speed and positions to make it "loop"
    private float speed = 5f;
    private float minX = -11f;
    private float maxX = 150f;
    private float y;

    private void Start()
    {
        y = this.transform.position.y; // This gets the y position of the spawned cloud. We dont change this.
    }
    
    private void Update()
    {
        this.transform.Translate(Vector2.left * speed * Time.deltaTime);
        
        // When cloud is out of the map on the left side it resets it to the right side
        if (this.transform.position.x < minX)
        {
            this.transform.position = new Vector2(maxX, y);
        }
    }
}
