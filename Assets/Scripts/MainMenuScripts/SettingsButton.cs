using UnityEngine;
using System.Collections;

public class SettingsButton : MonoBehaviour {

	public Texture2D texDefault;
	public Texture2D texSelect;
	public GUITexture[] textures;
	public GUIText setText;

	public GUITexture[] setTextures;
	public GUIText[] setTexts;
	// Use this for initialization
	void Start () 
	{
		guiTexture.texture = texDefault;
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
					guiTexture.texture = texSelect;
					GUIControl.checkTouch =1;
				}
				if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position))
				{
					guiTexture.texture = texDefault;
					GUIControl.checkTouch = 0;
					//Load required level
					foreach(GUITexture myTexture in textures)
					{
						myTexture.enabled = false;
					}
					setText.guiText.enabled = false;

					foreach(GUITexture myTexture in setTextures)
					{
						myTexture.enabled = true;
					}
					foreach(GUIText myText in setTexts)
					{
						myText.enabled = true;
					}
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
