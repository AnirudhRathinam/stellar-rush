using UnityEngine;
using System.Collections;

public class EndGameGUI : MonoBehaviour 
{
	public GUITexture[] inGameTexture, endGameTexture;
	public GUITexture theEnd;
	public GUIText[] inGameText, endGameText;
	public GameObject darkScreen, ninja;
	public static int gameOverCheck = 0, missionCheck = 0;
	public GUIText distCount, turretCount, rockCount, goldCount, bonusMissionCount, totalGold, totalScore, hiScore, bonusMissionText;
	int sum, myScore, enemiesKilled, turretsKilled, rocksKilled, mySum, totalKill;
	public static int prefCash, myCash;


	// Use this for initialization
	void Start () 
	{
		gameOverCheck = 0;
		missionCheck = 0;
		foreach(GUIText myText in endGameText)
		{
			myText.enabled = false;
		}
		foreach(GUITexture myTexture in endGameTexture)
		{
			myTexture.enabled = false;
		}
		theEnd.enabled = false;
		//Player prefs for player's net money
		prefCash = PlayerPrefs.GetInt("myMoney");
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(1f);
		GameOver();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(gameOverCheck == 1)
		{
			StartCoroutine(Wait());
		}
		mySum = SlashScript.autoCount + SlashScript.bombCount + SlashScript.samCount + SlashScript.flameCount;
		totalKill = mySum + SlashScript.rockCount;
		//PlayerPrefs for achievements do you even slash, I come in peace
		if(GUIControl.currentScore >= 3000 && totalKill == 0)
		{
			PlayerPrefs.SetInt("ach05", 10);
		}
		if(GUIControl.currentScore >= 9000 && totalKill == 0)
		{
			PlayerPrefs.SetInt("ach05", 10);
			PlayerPrefs.SetInt("ach06", 10);
		}

	}

	void GameOver()
	{
		ninja.gameObject.SetActive(false);
		distCount.text = GUIControl.currentScore + " m";
		sum = SlashScript.autoCount + SlashScript.bombCount + SlashScript.samCount + SlashScript.flameCount;
		enemiesKilled = sum + SlashScript.rockCount;
		turretsKilled = sum;
		rocksKilled = SlashScript.rockCount;
		sum = sum * 10;
		turretCount.text = sum + "";
		rockCount.text = SlashScript.rockCount * 15 + "";
		goldCount.text = GUIControl.currentMoney + " g";
		if(missionCheck != 0)
		{
			myCash = GUIControl.currentMoney + MissionControl.cash;
			bonusMissionText.text = "Bonus mission completed (yes):";
			bonusMissionCount.text = MissionControl.cash + " g";
		}
		else if(missionCheck == 0)
		{
			myCash = GUIControl.currentMoney;
			bonusMissionText.text = "Bonus mission completed (no):";
			bonusMissionCount.text = "0 g";
		}
		totalGold.text = myCash + " g";
		myScore = GUIControl.currentScore + sum + (SlashScript.rockCount*15);
		totalScore.text = myScore + "";

		PlayerPrefs.SetInt("healthLevel", 0);

		//Player prefs for achievements (Self defence)
		if(turretsKilled >= 100)
		{
			PlayerPrefs.SetInt("ach10", 10);
		}
		//Playerprefs for achievements i love explosions, killing spree, god of destruction
		if(enemiesKilled >= 50)
		{
			PlayerPrefs.SetInt("ach03", 10);
		}
		if(enemiesKilled >= 100)
		{
			PlayerPrefs.SetInt("ach03", 10);
			PlayerPrefs.SetInt("ach09", 10);
		}
		if(enemiesKilled >= 400)
		{
			PlayerPrefs.SetInt("ach03", 10);
			PlayerPrefs.SetInt("ach09", 10);
			PlayerPrefs.SetInt("ach15", 10);
		}
		//PlayerPrefs for achievement pro gamer
		if(GUIControl.currentScore <= 10)
		{
			PlayerPrefs.SetInt("ach04", 10);
		}



		//Setting player prefs for high score
		if(myScore > PlayerPrefs.GetInt("highScore"))
		{
			PlayerPrefs.SetInt("highScore", myScore);
		}
		hiScore.text = PlayerPrefs.GetInt("highScore") + "";
		//Setting player prefs for maximum cash
		if(myCash > PlayerPrefs.GetInt("maxCash"))
		{
			PlayerPrefs.SetInt("maxCash",myCash);
		}
		//Setting prefs for max enemies killed
		if(enemiesKilled > PlayerPrefs.GetInt("enemyKillCount"))
		{
			PlayerPrefs.SetInt("enemyKillCount", enemiesKilled);
		}
		//Setting prefs for max turrets killed
		if(turretsKilled > PlayerPrefs.GetInt("turretKillCount"))
		{
			PlayerPrefs.SetInt("turretKillCount", turretsKilled);
		}
		//Setting prefs for max rocks destroyed
		if(rocksKilled > PlayerPrefs.GetInt("rockKillCount"))
		{
			PlayerPrefs.SetInt("rockKillCount", rocksKilled);
		}
		//Setting prefs for max distance travelled
		if(GUIControl.currentScore > PlayerPrefs.GetInt("maxDist"))
		{
			PlayerPrefs.SetInt("maxDist", GUIControl.currentScore);
		}




		darkScreen.renderer.enabled = true;
		theEnd.enabled = true;
		foreach(GUIText myText in inGameText)
		{
			myText.enabled = false;
		}
		foreach(GUIText myText in endGameText)
		{
			myText.enabled = true;
		}
		foreach(GUITexture myTexture in inGameTexture)
		{
			myTexture.enabled = false;
		}
		foreach(GUITexture myTexture in endGameTexture)
		{
			myTexture.enabled = true;
		}
	}
}