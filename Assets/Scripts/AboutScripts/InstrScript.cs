using UnityEngine;
using System.Collections;

public class InstrScript : MonoBehaviour 
{

	public Texture2D texDefault;
	public Texture2D texSelect;
	public GUIText[] instrText, credText;

	// Use this for initialization
	void Start () 
	{
		guiTexture.texture = texDefault;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(AbtCam.option == 0)
		{
			guiTexture.texture = texSelect;
		}
		if(AbtCam.option == 1)
		{
			guiTexture.texture = texDefault;
		}
		if(Input.touchCount == 1 && AbtCam.checkTouch ==0 && AbtCam.option == 1)
		{	
			
			Touch touch = Input.GetTouch(0);
			
			if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
			{
				guiTexture.texture = texSelect;
				AbtCam.checkTouch =1;
			}
			if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position))
			{
				guiTexture.texture = texSelect;
				AbtCam.checkTouch = 0;
				//Load required level
				AbtCam.option = 0;
			}
			if(touch.phase == TouchPhase.Stationary && guiTexture.HitTest(touch.position))
			{
				guiTexture.texture = texSelect;
			}
			if(touch.phase == TouchPhase.Canceled)
			{
				guiTexture.texture = texDefault;
				AbtCam.checkTouch =0;
			}
			if (touch.phase == TouchPhase.Ended)
			{
				AbtCam.checkTouch =0;
			}
		}
		else
		{
			AbtCam.checkTouch = 0;
		}
		if(AbtCam.option == 0)
		{
			foreach(GUIText instruction in instrText)
			{
				instruction.enabled = true;
			}
			foreach(GUIText credit in credText)
			{
				credit.enabled = false;
			}
		}
		if(AbtCam.option == 1)
		{
			foreach(GUIText instruction in instrText)
			{
				instruction.enabled = false;
			}
			foreach(GUIText credit in credText)
			{
				credit.enabled = true;
			}
		}
	}
}
