using UnityEngine;
using System.Collections;

public class BackBuy : MonoBehaviour 
{

	public Texture2D texBuyDefault, texBuySelect, texSelectDefault, texSelectSelect;
	int costBack0, costBack1, costBack2, costBack3, costBack4, costBack5;
	public GUIText backPrice;

	public GUITexture selectBackground, selectAlien;
	public GUIText selectText;

	// Use this for initialization
	void Start () 
	{
		costBack0 = 0;
		costBack1 = 100000;
		costBack2 = 280000;
		costBack3 = 150000;
		costBack4 = 90000;
		costBack5 = 350000;

		selectBackground.enabled = false;
		selectText.enabled = false;
		selectAlien.enabled = false;
	}

	IEnumerator showSelect()
	{
		selectBackground.enabled = true;
		selectText.enabled = true;
		selectAlien.enabled = true;
		yield return new WaitForSeconds(0.5f);
		selectBackground.enabled = false;
		selectText.enabled = false;
		selectAlien.enabled = false;
	}

	void Update () 
	{
		if(guiTexture.enabled == true)
		{
		if(_BackMain.choice == 0)//first light selected
		{
			if(_CAM.buyBack00 == 0)//first light not brought
			{
				backPrice.text = costBack0 + "g";
				guiTexture.texture = texBuyDefault;
				if(Input.touchCount == 1 && _CAM.checkTouch ==0)//if buy is pressed
				{	
					
					Touch touch = Input.GetTouch(0);
					
					if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texBuySelect;
						_CAM.checkTouch =1;
						
					}
					if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position))
					{
						//Load required level
						if(_CAM.myCash >= costBack0)
						{
							_CAM.myCash = _CAM.myCash - costBack0;
							_CAM.buyBack00 = 1;
								PlayerPrefs.SetInt("backSelect", 0);
							guiTexture.texture = texSelectDefault;
						}
						else
						{
							_CAM.displayMsg = 1;
							guiTexture.texture = texBuyDefault;
						}
						_CAM.checkTouch = 0;
					}
					if(touch.phase == TouchPhase.Stationary && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texBuySelect;
					}
					if(touch.phase == TouchPhase.Canceled)
					{
						guiTexture.texture = texBuyDefault;
						_CAM.checkTouch =0;
					}
					if (touch.phase == TouchPhase.Ended)
					{
						_CAM.checkTouch =0;
					}
				}
				else//buy not pressed
				{
					guiTexture.texture = texBuyDefault;
					_CAM.checkTouch = 0;
				}
			}
			else//first light brought
			{
				guiTexture.texture =texSelectDefault;
				backPrice.text = "";
				if(Input.touchCount == 1 && _CAM.checkTouch ==0)
				{	
					
					Touch touch = Input.GetTouch(0);
					
					if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texSelectSelect;
						_CAM.checkTouch =1;
					}
					if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texSelectDefault;
						//Load required level (Apply changes to main ship)
						PlayerPrefs.SetInt("backSelect", 0);
						StartCoroutine(showSelect());
						_CAM.checkTouch = 0;
					}
					if(touch.phase == TouchPhase.Stationary && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texSelectSelect;
					}
					if(touch.phase == TouchPhase.Canceled)
					{
						guiTexture.texture = texSelectDefault;
						_CAM.checkTouch =0;
					}
					if (touch.phase == TouchPhase.Ended)
					{
						_CAM.checkTouch =0;
					}
				}
				else
				{
					guiTexture.texture = texSelectDefault;
					_CAM.checkTouch = 0;
				}
			}
		}
		
		// Second Light
		if(_BackMain.choice == 1)//first light selected
		{
			if(_CAM.buyBack01 == 0)//first light not brought
			{
				backPrice.text = costBack1 + "g";
				guiTexture.texture = texBuyDefault;
				if(Input.touchCount == 1 && _CAM.checkTouch ==0)//if buy is pressed
				{	
					
					Touch touch = Input.GetTouch(0);
					
					if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texBuySelect;
						_CAM.checkTouch =1;
					}
					if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position))
					{
						//Load required level
						if(_CAM.myCash >= costBack1)
						{
							_CAM.myCash = _CAM.myCash - costBack1;
							_CAM.buyBack01 = 1;
								PlayerPrefs.SetInt("backSelect", 1);
							guiTexture.texture = texSelectDefault;
						}
						else
						{
							_CAM.displayMsg = 1;
							guiTexture.texture = texBuyDefault;
						}
						_CAM.checkTouch = 0;
					}
					if(touch.phase == TouchPhase.Stationary && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texBuySelect;
					}
					if(touch.phase == TouchPhase.Canceled)
					{
						guiTexture.texture = texBuyDefault;
						_CAM.checkTouch =0;
					}
					if (touch.phase == TouchPhase.Ended)
					{
						_CAM.checkTouch =0;
					}
				}
				else//buy not pressed
				{
					guiTexture.texture = texBuyDefault;
					_CAM.checkTouch = 0;
				}
			}
			else//first light brought
			{
				guiTexture.texture =texSelectDefault;
				backPrice.text = "";
				if(Input.touchCount == 1 && _CAM.checkTouch ==0)
				{	
					
					Touch touch = Input.GetTouch(0);
					
					if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texSelectSelect;
						_CAM.checkTouch =1;
					}
					if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texSelectDefault;
						//Load required level (Apply changes to main ship)
						PlayerPrefs.SetInt("backSelect", 1);
						StartCoroutine(showSelect());
						_CAM.checkTouch = 0;
					}
					if(touch.phase == TouchPhase.Stationary && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texSelectSelect;
					}
					if(touch.phase == TouchPhase.Canceled)
					{
						guiTexture.texture = texSelectDefault;
						_CAM.checkTouch =0;
					}
					if (touch.phase == TouchPhase.Ended)
					{
						_CAM.checkTouch =0;
					}
				}
				else
				{
					guiTexture.texture = texSelectDefault;
					_CAM.checkTouch = 0;
				}
			}
		}
		//third light
		if(_BackMain.choice == 2)//first light selected
		{
			if(_CAM.buyBack02 == 0)//first light not brought
			{
				backPrice.text = costBack2 + "g";
				guiTexture.texture = texBuyDefault;
				if(Input.touchCount == 1 && _CAM.checkTouch ==0)//if buy is pressed
				{	
					
					Touch touch = Input.GetTouch(0);
					
					if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texBuySelect;
						_CAM.checkTouch =1;
					}
					if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position))
					{
						//Load required level
						if(_CAM.myCash >= costBack2)
						{
							_CAM.myCash = _CAM.myCash - costBack2;
							_CAM.buyBack02 = 1;
								PlayerPrefs.SetInt("backSelect", 2);
							guiTexture.texture = texSelectDefault;
						}
						else
						{
							_CAM.displayMsg = 1;
							guiTexture.texture = texBuyDefault;
						}
						_CAM.checkTouch = 0;
					}
					if(touch.phase == TouchPhase.Stationary && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texBuySelect;
					}
					if(touch.phase == TouchPhase.Canceled)
					{
						guiTexture.texture = texBuyDefault;
						_CAM.checkTouch =0;
					}
					if (touch.phase == TouchPhase.Ended)
					{
						_CAM.checkTouch =0;
					}
				}
				else//buy not pressed
				{
					guiTexture.texture = texBuyDefault;
					_CAM.checkTouch = 0;
				}
			}
			else//first light brought
			{
				guiTexture.texture =texSelectDefault;
				backPrice.text = "";
				if(Input.touchCount == 1 && _CAM.checkTouch ==0)
				{	
					
					Touch touch = Input.GetTouch(0);
					
					if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texSelectSelect;
						_CAM.checkTouch =1;
					}
					if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texSelectDefault;
						//Load required level (Apply changes to main ship)
						PlayerPrefs.SetInt("backSelect", 2);
						StartCoroutine(showSelect());
						_CAM.checkTouch = 0;
					}
					if(touch.phase == TouchPhase.Stationary && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texSelectSelect;
					}
					if(touch.phase == TouchPhase.Canceled)
					{
						guiTexture.texture = texSelectDefault;
						_CAM.checkTouch =0;
					}
					if (touch.phase == TouchPhase.Ended)
					{
						_CAM.checkTouch =0;
					}
				}
				else
				{
					guiTexture.texture = texSelectDefault;
					_CAM.checkTouch = 0;
				}
			}
		}
		
		//fourth light
		
		if(_BackMain.choice == 3)//first light selected
		{
			if(_CAM.buyBack03 == 0)//first light not brought
			{
				backPrice.text = costBack3 + "g";
				guiTexture.texture = texBuyDefault;
				if(Input.touchCount == 1 && _CAM.checkTouch ==0)//if buy is pressed
				{	
					
					Touch touch = Input.GetTouch(0);
					
					if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texBuySelect;
						_CAM.checkTouch =1;
					}
					if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position))
					{
						//Load required level
						if(_CAM.myCash >= costBack3)
						{
							_CAM.myCash = _CAM.myCash - costBack3;
							_CAM.buyBack03 = 1;
								PlayerPrefs.SetInt("backSelect", 3);
							guiTexture.texture = texSelectDefault;
						}
						else
						{
							_CAM.displayMsg = 1;
							guiTexture.texture = texBuyDefault;
						}
						_CAM.checkTouch = 0;
					}
					if(touch.phase == TouchPhase.Stationary && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texBuySelect;
					}
					if(touch.phase == TouchPhase.Canceled)
					{
						guiTexture.texture = texBuyDefault;
						_CAM.checkTouch =0;
					}
					if (touch.phase == TouchPhase.Ended)
					{
						_CAM.checkTouch =0;
					}
				}
				else//buy not pressed
				{
					guiTexture.texture = texBuyDefault;
					_CAM.checkTouch = 0;
				}
			}
			else//first light brought
			{
				guiTexture.texture =texSelectDefault;
				backPrice.text = "";
				if(Input.touchCount == 1 && _CAM.checkTouch ==0)
				{	
					
					Touch touch = Input.GetTouch(0);
					
					if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texSelectSelect;
						_CAM.checkTouch =1;
					}
					if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texSelectDefault;
						//Load required level (Apply changes to main ship)
						PlayerPrefs.SetInt("backSelect", 3);
						StartCoroutine(showSelect());
						_CAM.checkTouch = 0;
					}
					if(touch.phase == TouchPhase.Stationary && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texSelectSelect;
					}
					if(touch.phase == TouchPhase.Canceled)
					{
						guiTexture.texture = texSelectDefault;
						_CAM.checkTouch =0;
					}
					if (touch.phase == TouchPhase.Ended)
					{
						_CAM.checkTouch =0;
					}
				}
				else
				{
					guiTexture.texture = texSelectDefault;
					_CAM.checkTouch = 0;
				}
			}
		}
		
		//fifth light
		if(_BackMain.choice == 4)//first light selected
		{
			if(_CAM.buyBack04 == 0)//first light not brought
			{
				backPrice.text = costBack4 + "g";
				guiTexture.texture = texBuyDefault;
				if(Input.touchCount == 1 && _CAM.checkTouch ==0)//if buy is pressed
				{	
					
					Touch touch = Input.GetTouch(0);
					
					if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texBuySelect;
						_CAM.checkTouch =1;
					}
					if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position))
					{
						//Load required level
						if(_CAM.myCash >= costBack4)
						{
							_CAM.myCash = _CAM.myCash - costBack4;
							_CAM.buyBack04 = 1;
								PlayerPrefs.SetInt("backSelect", 4);
							guiTexture.texture = texSelectDefault;
						}
						else
						{
							_CAM.displayMsg = 1;
							guiTexture.texture = texBuyDefault;
						}
						_CAM.checkTouch = 0;
					}
					if(touch.phase == TouchPhase.Stationary && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texBuySelect;
					}
					if(touch.phase == TouchPhase.Canceled)
					{
						guiTexture.texture = texBuyDefault;
						_CAM.checkTouch =0;
					}
					if (touch.phase == TouchPhase.Ended)
					{
						_CAM.checkTouch =0;
					}
				}
				else//buy not pressed
				{
					guiTexture.texture = texBuyDefault;
					_CAM.checkTouch = 0;
				}
			}
			else//first light brought
			{
				guiTexture.texture =texSelectDefault;
				backPrice.text = "";
				if(Input.touchCount == 1 && _CAM.checkTouch ==0)
				{	
					
					Touch touch = Input.GetTouch(0);
					
					if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texSelectSelect;
						_CAM.checkTouch =1;
					}
					if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texSelectDefault;
						//Load required level (Apply changes to main ship)
						PlayerPrefs.SetInt("backSelect", 4);
						StartCoroutine(showSelect());
						_CAM.checkTouch = 0;
					}
					if(touch.phase == TouchPhase.Stationary && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texSelectSelect;
					}
					if(touch.phase == TouchPhase.Canceled)
					{
						guiTexture.texture = texSelectDefault;
						_CAM.checkTouch =0;
					}
					if (touch.phase == TouchPhase.Ended)
					{
						_CAM.checkTouch =0;
					}
				}
				else
				{
					guiTexture.texture = texSelectDefault;
					_CAM.checkTouch = 0;
				}
			}
		}
		
		//sixth light
		
		if(_BackMain.choice == 5)//first light selected
		{
			if(_CAM.buyBack05 == 0)//first light not brought
			{
				backPrice.text = costBack5 + "g";
				guiTexture.texture = texBuyDefault;
				if(Input.touchCount == 1 && _CAM.checkTouch ==0)//if buy is pressed
				{	
					
					Touch touch = Input.GetTouch(0);
					
					if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texBuySelect;
						_CAM.checkTouch =1;
					}
					if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position))
					{
						//Load required level
						if(_CAM.myCash >= costBack5)
						{
							_CAM.myCash = _CAM.myCash - costBack5;
							_CAM.buyBack05 = 1;
								PlayerPrefs.SetInt("backSelect", 5);
							guiTexture.texture = texSelectDefault;
						}
						else
						{
							_CAM.displayMsg = 1;
							guiTexture.texture = texBuyDefault;
						}
						_CAM.checkTouch = 0;
					}
					if(touch.phase == TouchPhase.Stationary && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texBuySelect;
					}
					if(touch.phase == TouchPhase.Canceled)
					{
						guiTexture.texture = texBuyDefault;
						_CAM.checkTouch =0;
					}
					if (touch.phase == TouchPhase.Ended)
					{
						_CAM.checkTouch =0;
					}
				}
				else//buy not pressed
				{
					guiTexture.texture = texBuyDefault;
					_CAM.checkTouch = 0;
				}
			}
			else//first light brought
			{
				guiTexture.texture =texSelectDefault;
				backPrice.text = "";
				if(Input.touchCount == 1 && _CAM.checkTouch ==0)
				{	
					
					Touch touch = Input.GetTouch(0);
					
					if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texSelectSelect;
						_CAM.checkTouch =1;
					}
					if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texSelectDefault;
						//Load required level (Apply changes to main ship)
						PlayerPrefs.SetInt("backSelect", 5);
						StartCoroutine(showSelect());
						_CAM.checkTouch = 0;
					}
					if(touch.phase == TouchPhase.Stationary && guiTexture.HitTest(touch.position))
					{
						guiTexture.texture = texSelectSelect;
					}
					if(touch.phase == TouchPhase.Canceled)
					{
						guiTexture.texture = texSelectDefault;
						_CAM.checkTouch =0;
					}
					if (touch.phase == TouchPhase.Ended)
					{
						_CAM.checkTouch =0;
					}
				}
				else
				{
					guiTexture.texture = texSelectDefault;
					_CAM.checkTouch = 0;
				}
			}
		}
	}	
	}
}
