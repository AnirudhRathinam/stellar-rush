using UnityEngine;
using System.Collections;

public class AbtShape : MonoBehaviour 
{
	public Texture2D instrShape;
	public Texture2D credShape;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(AbtCam.option == 0)
		{
			guiTexture.texture = instrShape;
		}
		if(AbtCam.option == 1)
		{
			guiTexture.texture = credShape;
		}
	}
}
