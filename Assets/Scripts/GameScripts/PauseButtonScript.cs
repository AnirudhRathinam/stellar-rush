using UnityEngine;
using System.Collections;

public class PauseButtonScript : MonoBehaviour {

	public Texture2D texDefault;
	public Texture2D texSelect;
	public GUITexture pauseTitle, resumeGame, quitGame, bonusObj;
	public GameObject darkLayer,ninja, ship;
	public static int checker;
	public static int isPaused;
	Vector3 shipVect;

	public static int phoneBack;

	// Use this for initialization
	void Start () 
	{
		guiTexture.texture = texDefault;
		guiTexture.enabled = true;
		GUIControl.checkTouch =0;
		checker = 0;
		isPaused = 0;
		if(PlayerPrefs.GetInt("showInstr") == 0)
		{
			phoneBack = 3;
		}
		else
		{
			phoneBack = 0;
		}
	}
	void hitPause()
	{
		guiTexture.texture = texDefault;
		GUIControl.checkTouch = 0;
		
		//Load required level
		if(ship)
		{
			shipVect = ship.transform.position;
		}
		darkLayer.renderer.enabled = true;
		pauseTitle.enabled = true;
		resumeGame.enabled = true;
		quitGame.enabled = true;
		bonusObj.enabled = true;
		guiTexture.enabled = false;
		checker = 1;
		isPaused = 1;
		ninja.gameObject.SetActive(false);
		phoneBack = 1;
		
		Time.timeScale = 0;
		if(ship)
		{
			ship.transform.position = shipVect;
		}

	}
	
	void Update ()
	{

		if(Input.GetKeyDown(KeyCode.Escape) && phoneBack == 0)// if not paused
		{
			hitPause();
			print("works!!!");
		}
		else if(Input.GetKeyDown(KeyCode.Escape) && phoneBack == 1)// if paused
		{
			ResumeButtonScript.callRes = 1;
		}
		else if(Input.GetKeyDown(KeyCode.Escape) && phoneBack == 2)// if bonus mission is displayed
		{
			CloseBonusMission.callClose = 1;
		}
		else if(Input.GetKeyDown(KeyCode.Escape) && phoneBack == 3)// if bonus mission is displayed
		{
			StartupClose.closeCheck = 1;
		}

		if(guiTexture.enabled == true)
		{
			if(Input.touchCount == 1 && GUIControl.checkTouch ==0)
			{	
				
				Touch touch = Input.GetTouch(0);
			
				if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
				{
					guiTexture.texture = texSelect;
					GUIControl.checkTouch =1;
				}
				if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position))
				{
					hitPause();
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
		}
	}
}
