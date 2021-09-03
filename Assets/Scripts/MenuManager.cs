using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

	public void Menu()
	{
		SceneManager.LoadScene("Menu");
	}
	
	public void StartFirstLevel()
	{
		Level1();
	}

	public void StartCurrentLevel()
	{
		Level1();
	}
	
	public void YouWin()
	{
		SceneManager.LoadScene("YouWin");
	}
	
	public void GameOver()
	{
		SceneManager.LoadScene("GameOver");
	}
	
	public void Level1()
	{
		SceneManager.LoadScene("Level_1");
	}








}
