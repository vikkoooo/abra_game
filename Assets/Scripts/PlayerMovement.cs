using System;
using UnityEngine;

/*
 * This class is used to give the player:
 * Movement horizontal
 * Jump function
 * Player flip according to direction
 * Wobble function to simulate walking
 * 
 * It is attached to the player
 */

public class PlayerMovement : MonoBehaviour
{
	// Basic movement
	private float movementSpeed = 15f;

	// Jumping
	private float jumpHeight = 9f;
	private bool isGrounded;
	private int n_jumps;

	// Wobble and flip function
	public Transform wizard;
	private bool isWalking;
	private bool wobbleDirection;
	private int wobbleX = 1;
	private float z = 4f;
	private float t = 0.3f;

	// Flip the player on start
	private void Start()
	{
		this.transform.localScale = new Vector3(-1, 1, 1);
	}

	// Update is called once per frame
	private void Update()
	{
		Move(); // Constantly check for movement inputs
		Jump(); // Constantly check for jump

		// This part of the code is for the wobble and making the dude turn around
		// Turn right
		if (Input.GetAxisRaw("Horizontal") > 0)
		{
			transform.localScale = new Vector3(-1, 1, 1); // Makes the dude turn right when walking right
			isWalking = true;
		}
		// Turn left
		else if (Input.GetAxisRaw("Horizontal") < 0)
		{
			transform.localScale = new Vector3(1, 1, 1); // Makes the dude turn left when walking left
			isWalking = true;
		}
		// Standing still
		else
		{
			// To reset the wobble when we stop walking, making the wizard stand with both feet on ground
			wizard.transform.rotation = Quaternion.identity; // .identity means "no rotation"
			isWalking = false;
		}
	}

	// To avoid different wobble speed depending on framerate
	private void FixedUpdate()
	{
		// As long as we are walking, call wobble function
		if (isWalking == true)
		{
			Wobble();
		}
	}

	// Basic movement
	private void Move()
	{
		Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0);
		this.transform.position += horizontal * Time.deltaTime * movementSpeed;
	}

	// Constantly check if the player is standing on the ground 
	private void OnCollisionStay2D(Collision2D collidedObject)
	{
		if (collidedObject.collider.CompareTag("Ground"))
		{
			isGrounded = true;
		}
	}

	private void OnCollisionExit2D(Collision2D collidedObject)
	{
		if (collidedObject.collider.CompareTag("Ground"))
		{
			isGrounded = false;
		}
	}

	// Jump script 
	private void Jump()
	{
		if (Input.GetButtonDown("Jump") && isGrounded == true)
		{
			n_jumps = 1;
			this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
		}

		// Secondary jump (half the jumpHeight)
		else if (Input.GetButtonDown("Jump") && n_jumps == 1)
		{
			n_jumps = 0;
			this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpHeight / 2), ForceMode2D.Impulse);
		}
	}

	// Wobble function
	private void Wobble()
	{
		if (wobbleX == 1)
		{
			// This causes the wizard to rotate to the left, until the end point z = 4 with speed t = 0.025f
			wizard.transform.rotation = Quaternion.Lerp(wizard.transform.rotation, Quaternion.Euler(0, 0, z), t);

			// When z value is reached, we flip wobbleX to make the wizard start rotating on the other direction
			if (wizard.transform.rotation == Quaternion.Euler(0, 0, z))
			{
				wobbleX = -1;
			}
		}

		else if (wobbleX == -1)
		{
			// Makes the wizard rotate to the right, until end point z with speed t.
			wizard.transform.rotation = Quaternion.Lerp(wizard.transform.rotation, Quaternion.Euler(0, 0, -z), t);

			// When z is reached
			if (wizard.transform.rotation == Quaternion.Euler(0, 0, -z))
			{
				wobbleX = 1;
			}
		}
	}
}