using UnityEngine;
using UnityEngine.UI;

/*
 * This script is attached to Crypto login menu, to fetch playerAddress. 
 */

public class CryptoMenu : MonoBehaviour
{
    public static string playerAddress;
    public InputField input;

    private void Start()
    {
        playerAddress = "";
    }

    public void SetPlayerAddress()
    {
        playerAddress = input.text;
    }    
}
