using UnityEngine;
using System.Collections;

public class BuyHealth : MonoBehaviour 
{
	public Texture2D texDefault, texSelect;

	public GUITexture bar1, bar2, bar3;
	public Texture2D barFull, barEmpty;

	public GUIText amount;

	public GUITexture msgBox;
	public GUITexture msgBoxClose;

	public GUITexture healthTemp, alien;
	public GUIText healthTempInstr;

	int level1 = 500, level2 = 1500, level3 = 5000, levelcount;
	// Use this for initialization
	void Start () 
	{
		level1 = 500;
		level2 = 1500;
		level3 = 5000;
		levelcount = PlayerPrefs.GetInt("healthLevel");
		healthTemp.guiTexture.enabled = false;
		alien.guiTexture.enabled = false;
		healthTempInstr.guiText.enabled = false;
	}

	IEnumerator dispMsg()
	{
		healthTemp.guiTexture.enabled = true;
		alien.guiTexture.enabled = true;
		healthTempInstr.guiText.enabled = true;

		yield return new WaitForSeconds(1f);

		healthTemp.guiTexture.enabled = false;
		alien.guiTexture.enabled = false;
		healthTempInstr.guiText.enabled = false;
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
			PlayerPrefs.SetInt("healthLevel", 0);
		}
		if(levelcount == 1)
		{
			bar1.texture = barFull;
			bar2.texture = barEmpty;
			bar3.texture = barEmpty;
			amount.text = level2 + " g";
			PlayerPrefs.SetInt("healthLevel", 1);
		}
		if(levelcount == 2)
		{
			bar1.texture = barFull;
			bar2.texture = barFull;
			bar3.texture = barEmpty;
			amount.text = level3 + " g";
			PlayerPrefs.SetInt("healthLevel", 2);
		}
		if(levelcount == 3)
		{
			bar1.texture = barFull;
			bar2.texture = barFull;
			bar3.texture = barFull;
			amount.text = "full";
			PlayerPrefs.SetInt("healthLevel", 3);
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
						StartCoroutine(dispMsg());

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
						StartCoroutine(dispMsg());

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
						StartCoroutine(dispMsg());

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
