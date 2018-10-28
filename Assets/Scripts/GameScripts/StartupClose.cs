using UnityEngine;
using System.Collections;

public class StartupClose : MonoBehaviour 
{

	public Texture2D texDefault;
	public Texture2D texSelect;
	public GUITexture[] startupTextures, otherTextures;
	public GUIText[] startupTexts;
	public GameObject ninja;
	public static int closeCheck = 0;

	
	// Use this for initialization
	void Start () 
	{
		guiTexture.texture = texDefault;
		GUIControl.checkTouch =0;
		closeCheck = 0;
	}
	void Close()
	{

		guiTexture.texture = texDefault;
		GUIControl.checkTouch = 0;
		StartupMessage.checker = 0;
		//Load required level
		foreach(GUITexture myTexture in startupTextures)
		{
			myTexture.enabled = false;
		}
		foreach(GUITexture myTexture in otherTextures)
		{
			myTexture.enabled = true;
		}
		foreach(GUIText myText in startupTexts)
		{
			myText.enabled = false;
		}
		ninja.gameObject.SetActive(true);
		Time.timeScale = 1;
		PauseButtonScript.phoneBack = 0;

	}
	
	
	void Update ()
	{
		if(closeCheck == 1)
		{
			closeCheck = 0;
			Close();
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
				guiTexture.texture = texDefault;
				GUIControl.checkTouch = 0;
				StartupMessage.checker = 0;
				//Load required level
				foreach(GUITexture myTexture in startupTextures)
				{
					myTexture.enabled = false;
				}
				foreach(GUITexture myTexture in otherTextures)
				{
					myTexture.enabled = true;
				}
				foreach(GUIText myText in startupTexts)
				{
					myText.enabled = false;
				}
				StartupMessage.instrEnabled = 0;
				ninja.gameObject.SetActive(true);
				Time.timeScale = 1;
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
