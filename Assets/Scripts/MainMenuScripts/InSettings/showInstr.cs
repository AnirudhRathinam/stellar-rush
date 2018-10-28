using UnityEngine;
using System.Collections;

public class showInstr : MonoBehaviour {

	public Texture2D texOn;
	public Texture2D texOff;
	public GUITexture instrIcon;
	public Texture2D instrOn, instrOff;
	// Use this for initialization
	void Start () 
	{
		if(PlayerPrefs.GetInt("showInstr") == 0)
		{
			guiTexture.texture = texOn; 
			instrIcon.texture = instrOn;
		}
		else if (PlayerPrefs.GetInt("showInstr") != 0)
		{
			guiTexture.texture = texOff;
			instrIcon.texture = instrOff;
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
						instrIcon.texture = instrOff;
						PlayerPrefs.SetInt("showInstr", 1);
					}
					else if (PlayerPrefs.GetInt("showInstr") != 0)
					{
						guiTexture.texture = texOn;
						instrIcon.texture = instrOn;
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
