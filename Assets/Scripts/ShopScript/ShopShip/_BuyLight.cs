using UnityEngine;
using System.Collections;

public class _BuyLight : MonoBehaviour 
{

	public Texture2D texBuyDefault, texBuySelect, texSelectDefault, texSelectSelect;
	int costLight0, costLight1, costLight2, costLight3, costLight4, costLight5;
	public GUIText lightPrice;

	public GUITexture selectBackground, selectAlien;
	public GUIText selectText;

	// Use this for initialization
	void Start () 
	{
		costLight0 = 0;
		costLight1 = 17000;
		costLight2 = 10000;
		costLight3 = 8000;
		costLight4 = 30000;
		costLight5 = 20000;

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
	
	// Update is called once per frame
	void Update () 
	{
		if(guiTexture.enabled == true)
		{
		if(ShipLights.choice == 0)//first light selected
		{
			if(_CAM.buyLight00 == 0)//first light not brought
			{
				lightPrice.text = costLight0 + "g";
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
						if(_CAM.myCash >= costLight0)
						{
							_CAM.myCash = _CAM.myCash - costLight0;
							_CAM.buyLight00 = 1;
								PlayerPrefs.SetInt("lightSelect", 0);
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
				lightPrice.text = "";
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
						PlayerPrefs.SetInt("lightSelect", 0);
						//Load required level (Apply changes to main ship)
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
		if(ShipLights.choice == 1)//first light selected
		{
			if(_CAM.buyLight01 == 0)//first light not brought
			{
				lightPrice.text = costLight1 + "g";
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
						if(_CAM.myCash >= costLight1)
						{
							_CAM.myCash = _CAM.myCash - costLight1;
							_CAM.buyLight01 = 1;
								PlayerPrefs.SetInt("lightSelect", 1);
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
				lightPrice.text = "";
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
						PlayerPrefs.SetInt("lightSelect", 1);
							StartCoroutine(showSelect());
						//Load required level (Apply changes to main ship)
						
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
		if(ShipLights.choice == 2)//first light selected
		{
			if(_CAM.buyLight02 == 0)//first light not brought
			{
				lightPrice.text = costLight2 + "g";
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
						if(_CAM.myCash >= costLight2)
						{
							_CAM.myCash = _CAM.myCash - costLight2;
							_CAM.buyLight02 = 1;
								PlayerPrefs.SetInt("lightSelect", 2);
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
				lightPrice.text = "";
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
						PlayerPrefs.SetInt("lightSelect", 2);
						//Load required level (Apply changes to main ship)
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

		if(ShipLights.choice == 3)//first light selected
		{
			if(_CAM.buyLight03 == 0)//first light not brought
			{
				lightPrice.text = costLight3 + "g";
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
						if(_CAM.myCash >= costLight3)
						{
							_CAM.myCash = _CAM.myCash - costLight3;
							_CAM.buyLight03 = 1;
								PlayerPrefs.SetInt("lightSelect", 3);
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
				lightPrice.text = "";
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
						PlayerPrefs.SetInt("lightSelect", 3);
						//Load required level (Apply changes to main ship)
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
		if(ShipLights.choice == 4)//first light selected
		{
			if(_CAM.buyLight04 == 0)//first light not brought
			{
				lightPrice.text = costLight4 + "g";
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
						if(_CAM.myCash >= costLight4)
						{
							_CAM.myCash = _CAM.myCash - costLight4;
							_CAM.buyLight04 = 1;
								PlayerPrefs.SetInt("lightSelect", 4);
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
				lightPrice.text = "";
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
						PlayerPrefs.SetInt("lightSelect", 4);
						//Load required level (Apply changes to main ship)
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

		if(ShipLights.choice == 5)//first light selected
		{
			if(_CAM.buyLight05 == 0)//first light not brought
			{
				lightPrice.text = costLight5 + "g";
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
						if(_CAM.myCash >= costLight5)
						{
							_CAM.myCash = _CAM.myCash - costLight5;
							_CAM.buyLight05 = 1;
								PlayerPrefs.SetInt("lightSelect", 5);
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
				lightPrice.text = "";
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
						PlayerPrefs.SetInt("lightSelect", 5);
						//Load required level (Apply changes to main ship)
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
