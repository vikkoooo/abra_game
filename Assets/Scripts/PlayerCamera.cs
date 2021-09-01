using UnityEngine;

/*
 * This script is attached on main camera to follow the player around
 */
public class PlayerCamera : MonoBehaviour
{
	public GameObject player; // Camera follows around the player

	// Offset camera
	private float x = -2f;
	private float y = 0f;
	private float z = -10f;

	// Update is called once per frame
	void LateUpdate()
	{
		// Update camera position with the player position.
		if (player.transform.position.x > x)
		{
			this.transform.position = new Vector3(player.transform.position.x - x, y, z);
		}
	}
}