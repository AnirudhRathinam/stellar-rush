using UnityEngine;
using System.Collections;

public class playMusic : MonoBehaviour 
{
	public Texture2D texOn;
	public Texture2D texOff;
	public GUITexture musicIcon;
	public Texture2D musicOn, musicOff;
	// Use this for initialization
	void Start () 
	{
		if(PlayerPrefs.GetInt("playMusic") == 0)
		{
			guiTexture.texture = texOn;
			musicIcon.texture = musicOn;
		}
		else if (PlayerPrefs.GetInt("playMusic") != 0)
		{
			guiTexture.texture = texOff;
			musicIcon.texture = musicOff;
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
					if(PlayerPrefs.GetInt("playMusic") == 0)
					{
						guiTexture.texture = texOff;
						musicIcon.texture = musicOff;
						PlayerPrefs.SetInt("playMusic", 1);
					}
					else if (PlayerPrefs.GetInt("playMusic") != 0)
					{
						guiTexture.texture = texOn;
						musicIcon.texture = musicOn;
						PlayerPrefs.SetInt("playMusic", 0);
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
