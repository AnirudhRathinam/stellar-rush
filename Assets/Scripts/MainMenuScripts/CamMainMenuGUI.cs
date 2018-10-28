using UnityEngine;
using System.Collections;

public class CamMainMenuGUI : MonoBehaviour {

	public GUITexture[] textures;
	public GUIText loadText, setText;

	public GUITexture[] setTextures;
	public GUIText[] setTexts;
	// Use this for initialization
	void Start () 
	{
		foreach(GUITexture myTexture in setTextures)
		{
			myTexture.enabled = false;
		}
		foreach(GUIText myText in setTexts)
		{
			myText.enabled = false;
		}
		foreach(GUITexture myTexture in textures)
		{
			myTexture.enabled = true;
		}
		loadText.guiText.enabled = false;
		setText.guiText.enabled = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
