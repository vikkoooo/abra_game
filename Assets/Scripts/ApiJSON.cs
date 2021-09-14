// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

using Newtonsoft.Json;

/*
 * Class is auto converted from json to c# using
 * https://json2csharp.com/json-to-csharp
 */

public class UsdCoin
{
	public float usd { get; set; }
}

public class Tether
{
	public float usd { get; set; }
}

public class Xsushi
{
	public float usd { get; set; }
}

public class Weth
{
	public float usd { get; set; }
}

public class Olympus
{
	public float usd { get; set; }
}

public class YearnFinance
{
	public float usd { get; set; }
}

public class StakedEther
{
	public float usd { get; set; }
}

public class MagicInternetMoney
{
	public float usd { get; set; }
}

public class ApiJSON
{
	[JsonProperty("usd-coin")] public UsdCoin UsdCoin { get; set; }
	public Tether tether { get; set; }
	public Xsushi xsushi { get; set; }
	public Weth weth { get; set; }
	public Olympus olympus { get; set; }

	[JsonProperty("yearn-finance")] public YearnFinance YearnFinance { get; set; }

	[JsonProperty("staked-ether")] public StakedEther StakedEther { get; set; }

	[JsonProperty("magic-internet-money")] public MagicInternetMoney MagicInternetMoney { get; set; }
}