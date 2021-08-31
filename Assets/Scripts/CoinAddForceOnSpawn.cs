using UnityEngine;
/*
 * This script is so that the coin that spawns "jumps" like an explosion
 * This is attached to the prefabs
 */
public class CoinAddForceOnSpawn : MonoBehaviour
{
    private Rigidbody2D coin; // We need to have a Rigidbody on the thing this is attached to
    
    private float xMin = -2f; // It can jump a little bit to the left
    private float xMax = 8f; // But mostly to the right
    private float yMin = 1f; // How low can it spawn on the vertical axis
    private float yMax = 6f; // How high can it spawn on the vertical axis

    private void Start()
    {
	    // Grab the Rigidbody of the object that this script is attached to
        coin = GetComponent<Rigidbody2D>(); 
        
        // Add force to the rigid body
        coin.AddForce(new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax)), ForceMode2D.Impulse);
    }
}
