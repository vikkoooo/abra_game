using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPackage : MonoBehaviour
{
    public Button closed_button;
    public Image closed_img;
    public Image opened_img;
    public Text rewards_text;
    public Text rewards_amount;
    
    
    // Start is called before the first frame update
    void Start()
    {
        closed_button.enabled = true;
        closed_img.enabled = true;
        opened_img.enabled = false;
        rewards_text.enabled = false;
        rewards_amount.enabled = false;
    }

    public void AttemptOpenPackage()
    {
        rewards_amount.text = PlayerStats.dollarValue.ToString();
        
        closed_button.enabled = false;
        closed_img.enabled = false;
        opened_img.enabled = true;
        rewards_text.enabled = true;
        rewards_amount.enabled = true;
    }
    
}
