using UnityEngine;

/*
 * This class looks for collisions in currencies, and stores it to display balance
 */

public class OLDCryptoWallet : MonoBehaviour
{
    public GameObject player;
    private int gold = 0;
    private int mim = 0;
    
    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.CompareTag("Gold"))
        {
            gold++;
            player.GetComponent<OLDPlayerHealthManaPower>().IncreaseMana(1);
            Destroy(collison.gameObject);
        }
        else if (collison.CompareTag("MIM"))
        {
            mim++;
            player.GetComponent<OLDPlayerHealthManaPower>().IncreaseHP(10);
            player.GetComponent<OLDPlayerHealthManaPower>().IncreaseMana(1);
            Destroy(collison.gameObject);
        }
        
    }
}
