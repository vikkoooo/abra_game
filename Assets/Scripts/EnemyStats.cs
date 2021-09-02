using UnityEngine;

/*
 * Script is keeping enemy health and also spawns some random crypto when they die
 * This script is attached to enemy prefabs
 */
public class EnemyStats : MonoBehaviour
{
	// How much health does the monsters have?
	private int health = 100;

	// Array of coins that the monsters can spawn
	public GameObject[] crypto;
	private int n_coins = 25; // How many coins does the monster spawn?

	// Position range for the coins spawned by monster
	private int minX = -2;
	private int maxX = 2;
	private int minY = 1;
	private int maxY = 3;

	// Must be public because bullet will talk to this script when bullet collides with the enemy
	public void TakeDamage(int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
		Destroy(gameObject); // Remove the enemy
		SpawnCrypto(); // Spawn some rewards for the player
	}

	private void SpawnCrypto()
	{
		for (int i = 0; i < n_coins; i++)
		{
			int cryptoType = Random.Range(0, crypto.Length);
			GameObject newCrypto = Instantiate(crypto[cryptoType]);
			Vector3 offset = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY));
			
			// Sets position of the spawned crypto with offset from the monster
			newCrypto.transform.position = this.transform.position + offset;
		}
	}
}