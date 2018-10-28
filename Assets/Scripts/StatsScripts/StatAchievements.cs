using UnityEngine;
using System.Collections;

public class StatAchievements : MonoBehaviour 
{
	public Texture2D texDefault;
	public Texture2D texSelect;

	// Use this for initialization
	void Start () 
	{
		guiTexture.texture = texDefault;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(CamGUI.option ==1)
		{
			guiTexture.texture = texSelect;
		}
		if(CamGUI.option ==0)
		{
			guiTexture.texture = texDefault;
		}
		if(Input.touchCount == 1 && CamGUI.checkTouch ==0 && CamGUI.option == 0)
		{	
			
			Touch touch = Input.GetTouch(0);
			
			if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
			{
				guiTexture.texture = texSelect;
				CamGUI.checkTouch =1;
			}
			if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position))
			{
				guiTexture.texture = texSelect;
				CamGUI.checkTouch = 0;
				//Load required level
				CamGUI.option = 1;
			}
			if(touch.phase == TouchPhase.Stationary && guiTexture.HitTest(touch.position))
			{
				guiTexture.texture = texSelect;
			}
			if(touch.phase == TouchPhase.Canceled)
			{
				guiTexture.texture = texDefault;
				CamGUI.checkTouch =0;
			}
			if (touch.phase == TouchPhase.Ended)
			{
				CamGUI.checkTouch =0;
			}
		}
		else
		{
			CamGUI.checkTouch = 0;
		}
	}
}
