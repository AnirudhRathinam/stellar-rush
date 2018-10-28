using UnityEngine;
using System.Collections;

public class StartupChecker : MonoBehaviour {

	public Texture2D texOn;
	public Texture2D texOff;
	// Use this for initialization
	void Start () 
	{
		if(PlayerPrefs.GetInt("showInstr") == 0)
		{
			guiTexture.texture = texOn; 
		}
		else if (PlayerPrefs.GetInt("showInstr") != 0)
		{
			guiTexture.texture = texOff;
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
					if(PlayerPrefs.GetInt("showInstr") == 0)
					{
						guiTexture.texture = texOff;
						PlayerPrefs.SetInt("showInstr", 1);
					}
					else if (PlayerPrefs.GetInt("showInstr") != 0)
					{
						guiTexture.texture = texOn;
						PlayerPrefs.SetInt("showInstr", 0);
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
