using UnityEngine;
using System.Collections;

public class BonObjButton : MonoBehaviour {

	public Texture2D texDefault;
	public Texture2D texSelect;

	public GUITexture msgBox, closeButton, alien;
	public GUIText title, objective, remaining, reward;
	
	// Use this for initialization
	void Start () 
	{
		guiTexture.texture = texDefault;
		GUIControl.checkTouch =0;

		msgBox.guiTexture.enabled = false;
		closeButton.guiTexture.enabled = false;
		alien.guiTexture.enabled = false;

		title.guiText.enabled = false;
		objective.guiText.enabled = false;
		remaining.guiText.enabled = false;
		reward.guiText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.touchCount == 1 && GUIControl.checkTouch ==0 && PauseButtonScript.isPaused == 1)
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
				PauseButtonScript.phoneBack = 2;
				GUIControl.displayMsg = 1;
				GUIControl.checkTouch = 0;


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
