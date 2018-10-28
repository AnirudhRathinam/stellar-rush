using UnityEngine;
using System.Collections;

public class BuyEL : MonoBehaviour 
{

	public Texture2D texDefault, texSelect;
	
	public GUITexture bar1, bar2, bar3;
	public Texture2D barFull, barEmpty;
	
	public GUIText amount;
	
	public GUITexture msgBox;
	public GUITexture msgBoxClose;
	
	int level1 = 5000, level2 = 20000, level3 = 50000, levelcount;
	// Use this for initialization
	void Start () 
	{
		level1 = 5000;
		level2 = 20000;
		level3 = 50000;
		levelcount = PlayerPrefs.GetInt("shootLevel");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(levelcount == 0)
		{
			bar1.texture = barEmpty;
			bar2.texture = barEmpty;
			bar3.texture = barEmpty;
			amount.text = level1 + " g";
			PlayerPrefs.SetInt("shootLevel", 0);
		}
		if(levelcount == 1)
		{
			bar1.texture = barFull;
			bar2.texture = barEmpty;
			bar3.texture = barEmpty;
			amount.text = level2 + " g";
			PlayerPrefs.SetInt("shootLevel", 1);
		}
		if(levelcount == 2)
		{
			bar1.texture = barFull;
			bar2.texture = barFull;
			bar3.texture = barEmpty;
			amount.text = level3 + " g";
			PlayerPrefs.SetInt("shootLevel", 2);
		}
		if(levelcount == 3)
		{
			bar1.texture = barFull;
			bar2.texture = barFull;
			bar3.texture = barFull;
			amount.text = "full";
			PlayerPrefs.SetInt("shootLevel", 3);
		}
		if(guiTexture.enabled == true)
		{
			if(Input.touchCount == 1 && _CAM.checkTouch ==0)
			{	
				
				Touch touch = Input.GetTouch(0);
				
				if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
				{
					guiTexture.texture = texSelect;
					_CAM.checkTouch =1;
				}
				if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position)&&levelcount == 0)
				{
					guiTexture.texture = texDefault;
					//Load required level
					
					if(_CAM.myCash >= level1)
					{
						_CAM.myCash = _CAM.myCash - level1;
						levelcount++;
						
					}
					else
					{
						_CAM.displayMsg = 1;
					}
					_CAM.checkTouch = 0;
				}
				else if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position)&&levelcount == 1)
				{
					guiTexture.texture = texDefault;
					//Load required level
					
					if(_CAM.myCash >= level2)
					{
						_CAM.myCash = _CAM.myCash - level2;
						levelcount++;
						
					}
					else
					{
						_CAM.displayMsg = 1;
					}
					_CAM.checkTouch = 0;
					
				}
				else if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position)&&levelcount == 2)
				{
					guiTexture.texture = texDefault;
					//Load required level
					
					if(_CAM.myCash >= level3)
					{
						_CAM.myCash = _CAM.myCash - level3;
						levelcount++;
						
					}
					else
					{
						_CAM.displayMsg = 1;
					}
					_CAM.checkTouch = 0;
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
					_CAM.checkTouch =0;
				}
			}
			else
			{
				guiTexture.texture = texDefault;
				_CAM.checkTouch = 0;
			}
		}
	}
}
