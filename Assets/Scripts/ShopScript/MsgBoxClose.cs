using UnityEngine;
using System.Collections;

public class MsgBoxClose : MonoBehaviour 
{
	public Texture2D texDefault;
	public Texture2D texSelect;

	public GUITexture msgBox, msgBoxClose;
	public static int closeGold = 0;


	// Use this for initialization
	void Start () 
	{
		closeGold = 0;
	}

	void Close()
	{
		_CAM.displayMsg = 0;
		_CAM.shopPhoneBack = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(closeGold == 1)
		{
			Close();
		}

		if(_CAM.displayMsg ==1)
		{
			_CAM.shopPhoneBack = 1;
			_CAM.checkTouch = 1;
			if(Input.touchCount == 1 && _CAM.checkTouch ==1)
			{		
				
				Touch touch = Input.GetTouch(0);
				
				if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
				{
					guiTexture.texture = texSelect;
					_CAM.checkTouch =1;
				}
				if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position))
				{
					guiTexture.texture = texDefault;
					//Load required level
					_CAM.shopPhoneBack = 0;
					_CAM.displayMsg = 0;
				}
				if(touch.phase == TouchPhase.Stationary && guiTexture.HitTest(touch.position))
				{
					guiTexture.texture = texSelect;
				}
				if(touch.phase == TouchPhase.Canceled)
				{
					guiTexture.texture = texDefault;
					_CAM.checkTouch =0;
				}
				if (touch.phase == TouchPhase.Ended)
				{	
					_CAM.checkTouch =1;
				}
			}
			else
			{
				guiTexture.texture = texDefault;
				_CAM.checkTouch = 1;
			}
		}
	}
}
