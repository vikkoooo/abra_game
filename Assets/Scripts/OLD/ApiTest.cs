using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class ApiTest : MonoBehaviour
{

	private string url =
		"https://api.coingecko.com/api/v3/simple/price?ids=magic-internet-money%2Cweth%2Colympus%2Cstaked-ether%2Cusd-coin%2Ctether%2Cxsushi%2Cyearn-finance&vs_currencies=usd";

	public float mim_price;
	public float weth_price;
	public float ohm_price;
	public float steth_price;
	public float usdc_price;
	public float usdt_price;
	public float xsushi_price;
	public float yfi_price;
	
	
	public void GetPriceFeed()
	{
		StartCoroutine(RequestPrices());
		
		
	}
	
	IEnumerator RequestPrices()
	{
	 string url =
		"https://api.coingecko.com/api/v3/simple/price?ids=magic-internet-money%2Cweth%2Colympus%2Cstaked-ether%2Cusd-coin%2Ctether%2Cxsushi%2Cyearn-finance&vs_currencies=usd";

		UnityWebRequest request = UnityWebRequest.Get(url);
		yield return request.SendWebRequest();

		if (request.isNetworkError || request.isHttpError)
		{
			Debug.Log("Error getting price feed");
		}

		else
		{
			var price = JsonConvert.DeserializeObject<ApiJSON>(request.downloadHandler.text);
			mim_price = price.MagicInternetMoney.usd;
			weth_price = price.weth.usd;
			ohm_price = price.olympus.usd;
			steth_price = price.StakedEther.usd;
			usdc_price = price.UsdCoin.usd;
			usdt_price = price.tether.usd;
			xsushi_price = price.xsushi.usd;
			yfi_price = price.YearnFinance.usd;
			
			Debug.Log("mim_price: " + mim_price);
			Debug.Log("weth_price: " + weth_price);
			Debug.Log("ohm_price: " + ohm_price);
		}
	}
	

}
