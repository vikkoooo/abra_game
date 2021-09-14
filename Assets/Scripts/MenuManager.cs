using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * Super simple menu manager script that selects new scene by calling the methods
 */
public class MenuManager : MonoBehaviour
{

	public void Menu()
	{
		SceneManager.LoadScene("Menu");
	}

	public void YouWin()
	{
		SceneManager.LoadScene("YouWin");
	}
	
	public void YouWinCrypto()
	{
		SceneManager.LoadScene("YouWinCrypto");
	}
	
	public void GameOver()
	{
		SceneManager.LoadScene("GameOver");
	}
	
	public void Level1()
	{
		SceneManager.LoadScene("Level_1");
	}

	public void Level2()
	{
		SceneManager.LoadScene("Level_2");
	}

	public void CryptoLogin()
	{
		SceneManager.LoadScene("CryptoLogin");
	}

	public void LevelChooser()
	{
		SceneManager.LoadScene("LevelChooser");
	}

	public void Level1_Crypto()
	{
		SceneManager.LoadScene("Level_1_Crypto");
	}


}
