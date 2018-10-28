using UnityEngine;
using System.Collections;

public class EGShop : MonoBehaviour {

	public Texture2D texDefault;
	public Texture2D texSelect;
	public GUITexture shopTex;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(shopTex.enabled == true)
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
					PlayerPrefs.SetInt("myMoney", (PlayerPrefs.GetInt("myMoney")+ EndGameGUI.myCash));

					Application.LoadLevel(3);
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
