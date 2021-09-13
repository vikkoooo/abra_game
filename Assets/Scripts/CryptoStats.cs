using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CryptoStats : MonoBehaviour
{
    // For displaying in the UI
    private string playerAddress = "0x";
    public Text playerAddressInput;
    public Text ethBalance;
    public Text vccBalance;

    // For using the blockchain
    
    
    void Start()
    {
        if (CryptoMenu.playerAddress != null)
        {
            playerAddress = CryptoMenu.playerAddress.ToString();
        }
        playerAddressInput.text = playerAddress;
        
        
        // Get eth balance
        
        
        // Get vcc balance
    }
    
    

}
