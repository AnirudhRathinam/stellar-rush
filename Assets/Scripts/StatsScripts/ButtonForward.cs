using UnityEngine;
using System.Collections;

public class ButtonForward : MonoBehaviour 
{
	public Texture2D texDefault;
	public Texture2D texSelect;
	public Texture2D texTrans;
	public GUIText pgCount;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.touchCount == 1 && CamGUI.checkTouch ==0 && CamGUI.option == 1)
		{	
			
			Touch touch = Input.GetTouch(0);
			
			if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
			{
				if(CamGUI.page < 3)
				{
					guiTexture.texture = texSelect;
				}
				else if (CamGUI.page == 3)
				{
					guiTexture.texture = texTrans;
				}
				CamGUI.checkTouch =1;
			}
			if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position))
			{
				
				if(CamGUI.page < 3)
				{
					guiTexture.texture = texSelect;
				}
				else if (CamGUI.page == 3)
				{
					guiTexture.texture = texTrans;
				}
				CamGUI.checkTouch = 0;
				//Load required level
				if(CamGUI.page < 3)
				{
					CamGUI.page++;
				}
				
			}
			if(touch.phase == TouchPhase.Stationary && guiTexture.HitTest(touch.position))
			{
				if(CamGUI.page < 3)
				{
					guiTexture.texture = texSelect;
				}
				else if (CamGUI.page == 3)
				{
					guiTexture.texture = texTrans;
				}
			}
			if(touch.phase == TouchPhase.Canceled)
			{
				if(CamGUI.page < 3)
				{
					guiTexture.texture = texDefault;
				}
				else if (CamGUI.page == 3)
				{
					guiTexture.texture = texTrans;
				}
				CamGUI.checkTouch =0;
			}
			if (touch.phase == TouchPhase.Ended)
			{
				CamGUI.checkTouch =0;
			}
		}
		else
		{
			if(CamGUI.page < 3)
			{
				guiTexture.texture = texDefault;
			}
			else if (CamGUI.page == 3)
			{
				guiTexture.texture = texTrans;
			}
			CamGUI.checkTouch = 0;
		}
		pgCount.text = CamGUI.page + "/3";
	}
}
