using UnityEngine;

/*
 * This script is attached to the bullet prefab and will trigger when collided with Enemy
 */
public class PlayerBullet : MonoBehaviour
{
	private float speed = 20f; // Bullet speed
	private int damage = 25; // Bullet damage

	private void Start()
	{
		// Gets the rigidbody of the bullet and adds force to it as soon as it spawns
		this.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
	}

	private void OnTriggerEnter2D(Collider2D collidedObject)
	{
		// Checks if the bullet collided with the enemy
		if (collidedObject.CompareTag("Enemy"))
		{
			// Access public method "TakeDamage()" in EnemyStats class
			collidedObject.GetComponent<EnemyStats>().TakeDamage(damage);

			// Destroy the bullet
			Destroy(gameObject);
		}
	}
}