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

public class CryptoStats : MonoBehaviour
{
	// For displaying in the UI
	public Text playerAddressInput;
	public Text ethBalance;
	public Text fspellBalance;

	// For using the blockchain
	private string playerAddress = "0x0000000000000000000000000000000000000000";
	private string nodeUrl = "https://ropsten.infura.io/v3/b20de574b50245bcb9f1d79b91385941";
	private string contractAddress = "0x8796398c1d97d3c69a93178b62668524e0Cd57fB";

	void Start()
	{
		if (CryptoMenu.playerAddress != String.Empty)
		{
			playerAddress = CryptoMenu.playerAddress;
		}
		playerAddressInput.text = playerAddress;

		// Get eth balance
		StartCoroutine(GetEtherBalance());

		// Get vcc balance
		StartCoroutine(GetFspellBalance());
	}

	public IEnumerator GetEtherBalance()
	{
		// Make eth balance request
		var request = new EthGetBalanceUnityRequest(nodeUrl);

		// Make the call
		yield return request.SendRequest(playerAddress, BlockParameter.CreateLatest());

		// Convert from wei
		var balance = UnitConversion.Convert.FromWei(request.Result.Value);
		
		// Display result
		ethBalance.text = balance.ToString();
	}

	public IEnumerator GetFspellBalance()
	{
		// Make Query request
		var request = new QueryUnityRequest<BalanceOfFunction, BalanceOfOutputDTO>(nodeUrl, playerAddress);

		// Includes parameters in the call if needed, in this case we need to include what owner we wanna check
		var message = new BalanceOfFunction(){Owner = playerAddress};

		// Make the call to the contract
		yield return request.Query(message, contractAddress);
		
		// Display result
		fspellBalance.text = request.Result.Balance.ToString();
	}

}