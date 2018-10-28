using UnityEngine;
using System.Collections;

public class FreeGoldButton : MonoBehaviour {

	public Texture2D texOn, texOff;
	// Use this for initialization
	void Start () 
	{
		if(PlayerPrefs.GetInt("warpMe") == 0)
		{
			guiTexture.texture = texOff;
		}
		else if (PlayerPrefs.GetInt("warpMe") != 0)
		{
			guiTexture.texture = texOn;
		}
		GUIControl.checkTouch =0;
	}
	
	void Update ()
	{
		if(guiTexture.enabled == true)
		{
			if(Input.touchCount == 1 && GUIControl.checkTouch ==0)
			{	
				
				Touch touch = Input.GetTouch(0);
				
				if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
				{
					GUIControl.checkTouch =1;
				}
				if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position))
				{
					GUIControl.checkTouch = 0;
					//Load required level
					if(PlayerPrefs.GetInt("warpMe") == 0)
					{
						guiTexture.texture = texOn;
						PlayerPrefs.SetInt("warpMe", 1);
					}
					else if (PlayerPrefs.GetInt("warpMe") != 0)
					{
						guiTexture.texture = texOff;
						PlayerPrefs.SetInt("warpMe", 0);
					}
					
				}
				if(touch.phase == TouchPhase.Stationary && guiTexture.HitTest(touch.position))
				{
					
				}
				if(touch.phase == TouchPhase.Canceled)
				{
					GUIControl.checkTouch =0;
				}
				if (touch.phase == TouchPhase.Ended)
				{
					GUIControl.checkTouch =0;
				}
			}
			else
			{
				GUIControl.checkTouch = 0;
			}
		}
	}
}
