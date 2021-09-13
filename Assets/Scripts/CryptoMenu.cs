using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
