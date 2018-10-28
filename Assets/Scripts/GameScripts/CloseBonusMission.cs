using UnityEngine;
using System.Collections;

public class CloseBonusMission : MonoBehaviour 
{
	public GUITexture msgBox, closeButton, alien;
	public GUIText title, objective, remaining, reward;

	public Texture2D texDefault;
	public Texture2D texSelect;
	public static int callClose = 0;
	// Use this for initialization
	void Start () 
	{
		callClose = 0;
	}
	void Close()
	{
		PauseButtonScript.phoneBack = 1;
		GUIControl.displayMsg = 0;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(callClose == 1)
		{
			callClose = 0;
			Close();
		}
		if(GUIControl.displayMsg == 1)
		{
			if(Input.touchCount == 1)
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
					//Load required level
					PauseButtonScript.phoneBack = 1;
					GUIControl.displayMsg = 0;
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
					GUIControl.checkTouch =1;
				}
			}
			else
			{
				guiTexture.texture = texDefault;
				GUIControl.checkTouch = 1;
			}
		}
	}
}
