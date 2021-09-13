using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.ABI.Model;
using Nethereum.Contracts;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.Extensions;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Hex.HexTypes;
using Nethereum.JsonRpc.UnityClient;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.RPC.Fee1559Suggestions;
using Nethereum.RPC.TransactionManagers;
using Nethereum.Signer;
using Nethereum.StandardTokenEIP20.ContractDefinition;
using Nethereum.Util;
using Nethereum.Web3.Accounts;
using UnityEngine;
using UnityEngine.UI;

public class OpenPackage : MonoBehaviour
{
    public Button closed_button;
    public Image closed_img;
    public Image opened_img;
    public Text rewards_text;
    public Text rewards_amount;
    
    // For using the blockchain
    private string nodeUrl = "https://ropsten.infura.io/v3/b20de574b50245bcb9f1d79b91385941";

    // This should be encrypted if going live
    private string privateKey = "0607ccf3d08feaa10f409d38e80e9e001a940d70a64f372ad55dbfa3aead4756"; 
    private int chainId = (int) Chain.Ropsten; // We are using the ropsten network
	
    private string contractCreatorAddress = "0x1Fec3D2d3E908d32CA8592515274671dE8b4F289";
    private string contractAddress = "0x8796398c1d97d3c69a93178b62668524e0Cd57fB";
    
    
    void Start()
    {
        closed_button.enabled = true;
        closed_img.enabled = true;
        opened_img.enabled = false;
        rewards_text.enabled = false;
        rewards_amount.enabled = false;
    }

    public void OpenPackageGold()
    {
        rewards_amount.text = PlayerStats.dollarValue.ToString();
        
        closed_button.enabled = false;
        closed_img.enabled = false;
        opened_img.enabled = true;
        rewards_text.enabled = true;
        rewards_amount.enabled = true;
    }
    
    public void OpenPackageCrypto()
    {
        closed_button.enabled = false;
        closed_img.enabled = false;
        opened_img.enabled = true;
        rewards_text.enabled = true;
        
        // Fake spell rewards are dollar rewards but only 100th of it, rounded up to nearest int
        float rewards = PlayerStats.dollarValue / 100;
        int fspellRewards = RoundUp(rewards);

        rewards_amount.text = fspellRewards.ToString();
        rewards_amount.enabled = true;

        // Send rewards on the blockchain
        StartCoroutine(SendRewards(fspellRewards));
    }

    private int RoundUp(float value)
    {
        int roundUp = (int) Math.Ceiling(value);
        return roundUp;
    }
    
    public IEnumerator SendRewards(int amount)
    {
        // Since we are going to change the state of the blockchain we need to send a signed transaction
        var request = new TransactionSignedUnityRequest(nodeUrl, privateKey, chainId);
        request.UseLegacyAsDefault = true; // Currently only legacy gas control is supported for unity
		
        // Include our function call
        var message = new TransferFunction()
            {FromAddress = contractCreatorAddress, Recipient = CryptoMenu.playerAddress, Amount = amount};
		
        // Make the call
        yield return request.SignAndSendTransaction(message, contractAddress);
		
        Debug.Log("txn hash: " + request.Result);
    }
    
}
