using UnityEngine;
using System.Collections;

public class _BackMain : MonoBehaviour 
{
	public Texture2D[] mainTex;
	public static int choice;
	// Use this for initialization
	void Start () 
	{
		choice = PlayerPrefs.GetInt("backSelect");
		if(choice > 5)
		{
			choice = 0;
		}
		else if (choice < 0)
		{
			choice = 0;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		guiTexture.texture = mainTex[choice];
	}
}
