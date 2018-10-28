using UnityEngine;
using System.Collections;

public class _BuyBody : MonoBehaviour {

	public Texture2D texBuyDefault, texBuySelect, texSelectDefault, texSelectSelect;
	int costBody0, costBody1, costBody2, costBody3, costBody4, costBody5;
	public GUIText bodyPrice;

	public GUITexture selectBackground, selectAlien;
	public GUIText selectText;
	// Use this for initialization
	void Start () 
	{
		costBody0 = 0;
		costBody1 = 100000;
		costBody2 = 150000;
		costBody3 = 120000;
		costBody4 = 300000;
		costBody5 = 80000;

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
		if(ShipBody.choice == 0)//first light selected
		{
			if(_CAM.buyBody00 == 0)//first light not brought
			{
				bodyPrice.text = costBody0 + "g";
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
						if(_CAM.myCash >= costBody0)
						{
							_CAM.myCash = _CAM.myCash - costBody0;
							_CAM.buyBody00 = 1;
								PlayerPrefs.SetInt("bodySelect", 0);
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
				bodyPrice.text = "";
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
						PlayerPrefs.SetInt("bodySelect", 0);
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
		
		// Second Light
		if(ShipBody.choice == 1)//first light selected
		{
			if(_CAM.buyBody01 == 0)//first light not brought
			{
				bodyPrice.text = costBody1 + "g";
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
						if(_CAM.myCash >= costBody1)
						{
							_CAM.myCash = _CAM.myCash - costBody1;
							_CAM.buyBody01 = 1;
								PlayerPrefs.SetInt("bodySelect", 1);
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
				bodyPrice.text = "";
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
						PlayerPrefs.SetInt("bodySelect", 1);
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
		if(ShipBody.choice == 2)//first light selected
		{
			if(_CAM.buyBody02 == 0)//first light not brought
			{
				bodyPrice.text = costBody2 + "g";
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
						if(_CAM.myCash >= costBody2)
						{
							_CAM.myCash = _CAM.myCash - costBody2;
							_CAM.buyBody02 = 1;
								PlayerPrefs.SetInt("bodySelect", 2);
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
				bodyPrice.text = "";
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
						PlayerPrefs.SetInt("bodySelect", 2);
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
		
		if(ShipBody.choice == 3)//first light selected
		{
			if(_CAM.buyBody03 == 0)//first light not brought
			{
				bodyPrice.text = costBody3 + "g";
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
						if(_CAM.myCash >= costBody3)
						{
							_CAM.myCash = _CAM.myCash - costBody3;
							_CAM.buyBody03 = 1;
								PlayerPrefs.SetInt("bodySelect", 3);
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
				bodyPrice.text = "";
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
						PlayerPrefs.SetInt("bodySelect", 3);
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
		if(ShipBody.choice == 4)//first light selected
		{
			if(_CAM.buyBody04 == 0)//first light not brought
			{
				bodyPrice.text = costBody4 + "g";
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
						if(_CAM.myCash >= costBody4)
						{
							_CAM.myCash = _CAM.myCash - costBody4;
							_CAM.buyBody04 = 1;
								PlayerPrefs.SetInt("bodySelect", 4);
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
				bodyPrice.text = "";
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
						PlayerPrefs.SetInt("bodySelect", 4);
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
		
		if(ShipBody.choice == 5)//first light selected
		{
			if(_CAM.buyBody05 == 0)//first light not brought
			{
				bodyPrice.text = costBody5 + "g";
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
						if(_CAM.myCash >= costBody5)
						{
							_CAM.myCash = _CAM.myCash - costBody5;
							_CAM.buyBody05 = 1;
								PlayerPrefs.SetInt("bodySelect", 5);
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
				bodyPrice.text = "";
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
						PlayerPrefs.SetInt("bodySelect", 5);
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
