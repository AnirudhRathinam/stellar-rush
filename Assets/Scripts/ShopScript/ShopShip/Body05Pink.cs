using UnityEngine;
using System.Collections;

public class Body05Pink : MonoBehaviour {

	public Texture2D texDefault;
	public Texture2D texSelect;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(ShipBody.choice == 4)
		{
			guiTexture.texture = texSelect;
		}
		else
		{
			guiTexture.texture = texDefault;
		}
		if(Input.touchCount == 1 && _CAM.checkTouch == 0 && ShipBody.choice != 4)
		{
			Touch touch = Input.GetTouch(0);
			
			if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
			{
				guiTexture.texture = texSelect;
				_CAM.checkTouch =1;
			}
			if(touch.phase == TouchPhase.Ended && guiTexture.HitTest(touch.position))
			{
				guiTexture.texture = texSelect;
				//Load required level
				ShipBody.choice = 4;
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
			_CAM.checkTouch = 0;
		}
	}
}
