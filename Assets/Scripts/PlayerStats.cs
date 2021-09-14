using System;
using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

/*
 * This class looks for collisions in currencies, and stores it to display balance.
 * It also keeps track of player health, mana and ultimate power. 
 */

public class PlayerStats : MonoBehaviour
{
	public static float dollarValue;
	
	// Currency balance
	private int gold;
	private float mim;
	private float weth;
	private float ohm;
	private float steth;
	private float usdc;
	private float usdt;
	private float xsushi;
	private float yfi;
	
	// USD value for 1 token, hard coded pre values in case of api failure
	private float mimValue = 1.009f;
	private float wethValue = 3961.104f;
	private float ohmValue = 320.206f;
	private float stethValue = 3938.608f;
	private float usdcValue = 1.001f;
	private float usdtValue = 1.003f;
	private float xsushiValue = 15.704f;
	private float yfiValue = 39076.101f;
	private string url =
		"https://api.coingecko.com/api/v3/simple/price?ids=magic-internet-money%2Cweth%2Colympus%2Cstaked-ether%2Cusd-coin%2Ctether%2Cxsushi%2Cyearn-finance&vs_currencies=usd";

	
	// Text field to update values and dollar values
	public GameObject goldText;
	public GameObject mimText;
	public GameObject wethText;
	public GameObject ohmText;
	public GameObject stethText;
	public GameObject usdcText;
	public GameObject usdtText;
	public GameObject xsushiText;
	public GameObject yfiText;

	// Player settings
	// Health
	public Slider healthSlider;
	private int maxHealth = 100;
	private int currentHealth;
	private int healthMultiplier = 10;

	// Mana
	public Slider manaSlider;
	private int maxMana = 10;
	private int currentMana;
	private int manaMultiplier = 10;

	// Ultimate power
	public GameObject leverageText;
	public GameObject mimCoin;
	private int multiplier = 4; // How many coins do we want to spawn? Multiplies with leverage

	// Position range for the coins spawned by ultimate
	private float minX = -5f;
	private float maxX = 5f;
	private float minY = 2f;
	private float maxY = 8f;

	private void Start()
	{
		// Set dollar value to zero
		dollarValue = 0;
		
		// Set health
		currentHealth = maxHealth; // Player starts at 100 % hp 
		healthSlider.maxValue = currentHealth; // Give instructions to slider how big it needs to be
		healthSlider.value = currentHealth; // Update slider with current health

		// Set mana
		currentMana = 0;
		manaSlider.maxValue = maxMana;
		manaSlider.value = currentMana;
		leverageText.GetComponent<Text>().text = currentMana.ToString() + "x";

		// Get price feeds 
		StartCoroutine(RequestPrices());
	}
	
	IEnumerator RequestPrices()
	{
		UnityWebRequest request = UnityWebRequest.Get(url);
		yield return request.SendWebRequest();

		// Code recently depreciated
		// if (request.isNetworkError || request.isHttpError)
		if (request.result == UnityWebRequest.Result.ConnectionError) 
		{
			Debug.Log("Error getting price feed");
		}

		else
		{
			var price = JsonConvert.DeserializeObject<ApiJSON>(request.downloadHandler.text);
			mimValue = price.MagicInternetMoney.usd;
			wethValue = price.weth.usd;
			ohmValue = price.olympus.usd;
			stethValue = price.StakedEther.usd;
			usdcValue = price.UsdCoin.usd;
			usdtValue = price.tether.usd;
			xsushiValue = price.xsushi.usd;
			yfiValue = price.YearnFinance.usd;
			
			Debug.Log("Success loading new prices from coingecko api");
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q)) // Check for ultimate call (keyboard Q)
		{
			CastUltimate(currentMana);
		}
	}

	private void LateUpdate()
	{
		goldText.GetComponent<Text>().text = gold.ToString();
		mimText.GetComponent<Text>().text = UpdateBalance(mim, mimValue);
		wethText.GetComponent<Text>().text = UpdateBalance(weth, wethValue);

		ohmText.GetComponent<Text>().text = UpdateBalance(ohm, ohmValue);
		stethText.GetComponent<Text>().text = UpdateBalance(steth, stethValue);
		usdcText.GetComponent<Text>().text = UpdateBalance(usdc, usdcValue);
		
		usdtText.GetComponent<Text>().text = UpdateBalance(usdt, usdtValue);
		xsushiText.GetComponent<Text>().text = UpdateBalance(xsushi, xsushiValue);
		yfiText.GetComponent<Text>().text = UpdateBalance(yfi, yfiValue);
	}

	private String UpdateBalance(float n, float value)
	{
		return n + "  =  " + (n * value) + "  USD";
	}
	
	private void OnTriggerEnter2D(Collider2D collidedObject)
	{
		// Checks which object we collided with using tags
		// Gold gives us mana
		if (collidedObject.CompareTag("Gold"))
		{
			gold++;
			IncreaseMana();
			Destroy(collidedObject.gameObject); // Remove the object we collided with
		}
		// Goal makes us win
		else if (collidedObject.CompareTag("Goal"))
		{
			// Store dollar value collected by the player on the current level, for usage in the 
			// rewards system displayed on the YouWin scene
			dollarValue = mim * mimValue + weth * wethValue + ohm * ohmValue + steth * stethValue + usdc * usdcValue + 
			              usdt * usdtValue + xsushi * xsushiValue + yfi * yfiValue;
			
			if (SceneManager.GetActiveScene().name == "Level_1_Crypto")
			{
				GetComponent<MenuManager>().YouWinCrypto();
			}
			else if (SceneManager.GetActiveScene().name == "Level_1")
			{
				GetComponent<MenuManager>().YouWin();
			}
			else if (SceneManager.GetActiveScene().name == "Level_2")
			{
				GetComponent<MenuManager>().YouWin();
			}
			else
			{
				Debug.Log("Something wrong with scene names");
			}
		}
		// MIM gives us HP
		else if (collidedObject.CompareTag("MIM"))
		{
			mim += 1000;
			IncreaseHp();
			Destroy(collidedObject.gameObject);
		}
		// Enemies hurt us
		else if (collidedObject.CompareTag("Enemy"))
		{
			TakeDamage();
		}
		// Other tokens add to balance
		else if (collidedObject.CompareTag("OHM"))
		{
			ohm += 3f;
			Destroy(collidedObject.gameObject);
		}
		else if (collidedObject.CompareTag("STETH"))
		{
			steth += 0.1f;
			Destroy(collidedObject.gameObject);
		}
		else if (collidedObject.CompareTag("USDC"))
		{
			usdc += 1000;
			Destroy(collidedObject.gameObject);
		}
		else if (collidedObject.CompareTag("USDT"))
		{
			usdt += 1000;
			Destroy(collidedObject.gameObject);
		}
		else if (collidedObject.CompareTag("WETH"))
		{
			weth += 0.1f;
			Destroy(collidedObject.gameObject);
		}
		else if (collidedObject.CompareTag("xSUSHI"))
		{
			xsushi += 50f;
			Destroy(collidedObject.gameObject);
		}
		else if (collidedObject.CompareTag("YFI"))
		{
			yfi += 0.03f;
			Destroy(collidedObject.gameObject);
		}
	}

	private void IncreaseHp()
	{
		// To make it dynamic. How large / small increase is set up in settings
		int hp = maxHealth / healthMultiplier * 2;

		// Set new health
		if (currentHealth < maxHealth)
		{
			currentHealth += hp;
			healthSlider.value = currentHealth;
		}

		// Check that we didnt overhealth. If we did, reset it to max. 
		if (currentHealth > maxHealth)
		{
			currentHealth = maxHealth;
			healthSlider.value = currentHealth;
		}
	}

	private void IncreaseMana()
	{
		int mana = maxMana / manaMultiplier;

		if (currentMana < maxMana)
		{
			currentMana += mana;
			manaSlider.value = currentMana;
			leverageText.GetComponent<Text>().text = currentMana.ToString() + "x";
		}
	}

	private void TakeDamage()
	{
		int damage = maxHealth / healthMultiplier;

		currentHealth -= damage;
		healthSlider.value = currentHealth;

		// If dieded
		if (currentHealth <= 0)
		{
			GetComponent<MenuManager>().GameOver();
		}
	}
	
	private void CastUltimate(int leverage)
	{
		currentMana = 0; // Reset the mana
		manaSlider.value = currentMana;
		leverageText.GetComponent<Text>().text = currentMana.ToString() + "x"; // Reset leverage textfield

		for (int i = 0; i < leverage * multiplier; i++)
		{
			GameObject newMim = Instantiate(mimCoin);
			Vector3 offset = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY));
			
			// Sets position of the spawned MIM with offset from the player
			newMim.transform.position = this.transform.position + offset;
		}
	}
}