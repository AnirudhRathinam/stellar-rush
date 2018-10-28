using UnityEngine;
using System.Collections;

public class GUIControl : MonoBehaviour {

	public static int checkTouch = 0;
	public static int displayMsg = 0;

	public GUITexture msgBox, closeButton, alien;
	public GUIText title, objective, remaining, reward;

	public static int currentMoney, currentScore;
	public GUIText guiScore, guiCash;

	// Use this for initialization
	void Start () 
	{
		Screen.sleepTimeout = (int)SleepTimeout.NeverSleep;
		currentMoney = 0;
		currentScore = 0;
		guiScore.text = "0 m";
		guiCash.text = "0 g$";
	}
	
	// Update is called once per frame
	void Update () 
	{
		guiScore.text = currentScore + " m";
		guiCash.text = currentMoney + " g";
		if(displayMsg == 1)
		{
			msgBox.guiTexture.enabled = true;
			closeButton.guiTexture.enabled = true;
			alien.guiTexture.enabled = true;
			
			title.guiText.enabled = true;
			objective.guiText.enabled = true;
			remaining.guiText.enabled = true;
			reward.guiText.enabled = true;
			checkTouch = 1;
		}
		else if (displayMsg == 0)
		{
			msgBox.guiTexture.enabled = false;
			closeButton.guiTexture.enabled = false;
			alien.guiTexture.enabled = false;
			
			title.guiText.enabled = false;
			objective.guiText.enabled = false;
			remaining.guiText.enabled = false;
			reward.guiText.enabled = false;
		}
	}
}
