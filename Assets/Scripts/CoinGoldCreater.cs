using UnityEngine;

/*
 * This script creates coins on a randomized position set by intervals
 */
public class CoinGoldCreater : MonoBehaviour
{
	public GameObject coin; // Coin to create
	private int n_coins = 50; // How many?

	// At what range in the map should they be spawned
	private float minX = -0.2f;
	private float maxX = 148f;
	private float minY = -0.2f;
	private float maxY = 0f;

	private void Start()
	{
		CreateCoins(n_coins); // Create coins
	}

	private void CreateCoins(int n_coins)
	{
		for (int i = 0; i < n_coins; i++)
		{
			GameObject newCoin = Instantiate(coin); // Create new coin
			newCoin.transform.parent = this.transform; // Pack it together with the thing this script is attached to
			newCoin.transform.position = RandomizePosition(); // Set new position of the coin
		}
	}

	private Vector2 RandomizePosition()
	{
		float x = Random.Range(minX, maxX);
		float y = Random.Range(minY, maxY);

		return new Vector2(x, y);
	}
}