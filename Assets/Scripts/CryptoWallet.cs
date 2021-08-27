using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptoWallet : MonoBehaviour
{
    private int gold = 0;
    private int eth = 0;
    
    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.CompareTag("Gold"))
        {
            gold++;
            Destroy(collison.gameObject);
        }
        else if (collison.CompareTag("ETH"))
        {
            eth++;
            Destroy(collison.gameObject);
        }
        
    }
}
