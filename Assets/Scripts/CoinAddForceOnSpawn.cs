using UnityEngine;

/*
 * This script is so that the coin that spawns "jumps" like an explosion
 * This is attached to the prefabs
 */
public class CoinAddForceOnSpawn : MonoBehaviour
{
	// How the coins will move when spawned
	private float minX = -2f; // It can jump a little bit to the left
	private float maxX = 10f; // But mostly to the right
	private float minY = 1f; // How low can it spawn on the vertical axis
	private float maxY = 6f; // How high can it spawn on the vertical axis

	private void Start()
	{
		// Grabs the Rigidbody of the object this script is attached to 
		// Then it adds force to that rigid body
		this.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)),
			ForceMode2D.Impulse);
	}
}