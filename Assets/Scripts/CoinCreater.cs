using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCreater : MonoBehaviour
{
    // Coin
    public GameObject coin;
    
    // Creating 
    private int n_coins = 50;

    private float minX = -0.2f;
    private float maxX = 148f;
    private float minY = -0.2f;
    private float maxY = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        // Create coins
        CreateCoins(n_coins);
    }

    
    private void CreateCoins(int n_coins)
    {
        for (int i = 0; i < n_coins; i++)
        {
            
            GameObject newCoin = Instantiate(coin);
            newCoin.transform.parent = this.transform;
            
            // Set new position of the cloud
            newCoin.transform.position = RandomizePosition();
        }
    }

    private Vector2 RandomizePosition()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        return new Vector2(x, y);
    }
}
