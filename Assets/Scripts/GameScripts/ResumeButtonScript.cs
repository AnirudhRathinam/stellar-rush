using UnityEngine;
using System.Collections;

public class ResumeButtonScript : MonoBehaviour {

	public Texture2D texDefault;
	public Texture2D texSelect;

	public GUITexture pauseTitle, pauseButton, quitGame, bonusObj;
	public GameObject darkLayer, ninja;

	public Transform player;
	Vector3 tPlayer;
	float playerX;
	public static int resume = 0;

	public static int callRes = 0;

	
	// Use this for initialization
	void Start () 
	{
		guiTexture.texture = texDefault;
		GUIControl.checkTouch =0;
		playerX = player.position.x;
		callRes = 0;
	}

	void Resume()
	{
		guiTexture.texture = texDefault;
		GUIControl.checkTouch = 0;
		//Load required level
		darkLayer.renderer.enabled = false;
		pauseTitle.enabled = false;
		pauseButton.enabled = true;
		quitGame.enabled = false;
		guiTexture.enabled = false;
		bonusObj.enabled = false;
		PauseButtonScript.isPaused = 0;
		PauseButtonScript.phoneBack = 0;
		Time.timeScale = 1;
		PauseButtonScript.checker = 0;
		ninja.gameObject.SetActive(true);
	}


	void Update ()
	{

		if(callRes == 1)
		{
			callRes = 0;
			Resume();
		}
		if(PauseButtonScript.checker != 1)
		{
			if(player)
			{
				playerX = player.position.x;
			}
		}

		if(resume == 0)
		{
			guiTexture.texture = texDefault;
			GUIControl.checkTouch = 0;
			//Load required level
			darkLayer.renderer.enabled = false;
			pauseTitle.enabled = false;
			pauseButton.enabled = true;
			quitGame.enabled = false;
			guiTexture.enabled = false;
			bonusObj.enabled = false;
			PauseButtonScript.isPaused = 0;
			Time.timeScale = 1;
			PauseButtonScript.checker = 0;
			ninja.gameObject.SetActive(true);
			resume = 1;
		}
		if(Input.touchCount == 1 && GUIControl.checkTouch ==0 && PauseButtonScript.isPaused == 1)
		{	
			
			Touch touch = Input.GetTouch(0);
			
			if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
			{
				guiTexture.texture = texSelect;
				GUIControl.checkTouch =1;
			}
			if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position))
			{
				Resume();
			}
			if(touch.phase == TouchPhase.Stationary && guiTexture.HitTest(touch.position))
			{
				guiTexture.texture = texSelect;
			}
			if(touch.phase == TouchPhase.Canceled)
			{
				guiTexture.texture = texDefault;
				GUIControl.checkTouch =0;
			}
			if (touch.phase == TouchPhase.Ended)
			{
				GUIControl.checkTouch =0;
			}
		}
		else
		{
			guiTexture.texture = texDefault;
			GUIControl.checkTouch = 0;
		}
		if(PauseButtonScript.checker == 1)
		{
			if(player)
			{
				tPlayer = player.position;
			}

			if(tPlayer.x != playerX)
			{
				tPlayer.x = playerX;
			}
			if(player)
			{
				player.position = tPlayer;
			}
		}

	}
}
