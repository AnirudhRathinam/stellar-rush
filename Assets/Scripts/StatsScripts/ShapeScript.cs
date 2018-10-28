using UnityEngine;
using System.Collections;

public class ShapeScript : MonoBehaviour {

	public Texture2D highScoreShape;
	public Texture2D achievementShape;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(CamGUI.option == 0)
		{
			guiTexture.texture = highScoreShape;
		}
		if(CamGUI.option == 1)
		{
			guiTexture.texture = achievementShape;
		}
	}
}
