using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptoWallet : MonoBehaviour
{
    public GameObject player;
    private int gold = 0;
    private int MIM = 0;
    
    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.CompareTag("Gold"))
        {
            gold++;
            player.GetComponent<PlayerHealthManaPower>().IncreaseMana(1);
            Destroy(collison.gameObject);
        }
        else if (collison.CompareTag("MIM"))
        {
            MIM++;
            player.GetComponent<PlayerHealthManaPower>().IncreaseHP(10);
            player.GetComponent<PlayerHealthManaPower>().IncreaseMana(1);
            Destroy(collison.gameObject);
        }
        
    }
}
