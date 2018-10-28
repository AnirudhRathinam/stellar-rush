using UnityEngine;
using System.Collections;

public class StartupMessage : MonoBehaviour {

	public GUITexture[] startupTextures, otherTextures;
	public GUIText[] startupTexts;
	public GameObject ninja;
	public static int checker;
	public Transform player;
	public static int instrEnabled = 0;
	Vector3 tPlayer;

	public GUITexture instrText;
	public Texture2D instr01,instr02;

	public static int waiter = 0;

	public static int dontSlash = 0;
	public static int closeDontSlash = 0;
	public GUITexture dontSlashBox, dontSlashAlien, dontSlashClose;
	public GUIText dontSlashText;

	IEnumerator Wait()
	{
		waiter = 0;
		instrText.enabled = true;
		instrText.texture = instr01;
		yield return new WaitForSeconds(2.5f);
		instrText.texture = instr02;
		yield return new WaitForSeconds(2.5f);
		instrText.enabled = false;
		waiter = 1;
	}


	// Use this for initialization
	void Start () 
	{
		dontSlash = 0;
		closeDontSlash = 0;
		dontSlashBox.enabled = false;
		dontSlashAlien.enabled = false;
		dontSlashClose.enabled = false;
		dontSlashText.enabled = false;

		tPlayer = player.position;
		if(PlayerPrefs.GetInt("firstGame") == 0)
		{
			PlayerPrefs.SetInt("showInstr", 1);
			StartCoroutine(Wait());
		}

		if(PlayerPrefs.GetInt("showInstr") == 0)//if enabled, it will show instructions
		{
			instrEnabled = 1;
			foreach(GUITexture myTexture in startupTextures)
			{
				myTexture.enabled = true;
			}
			foreach(GUITexture myTexture in otherTextures)
			{
				myTexture.enabled = false;
			}
			foreach(GUIText myText in startupTexts)
			{
				myText.enabled = true;
			}
			PauseButtonScript.phoneBack = 3;
			checker = 1;
			ninja.gameObject.SetActive(false);
			Time.timeScale = 0;
		}
		else if(PlayerPrefs.GetInt("showInstr") != 0)
		{
			foreach(GUITexture myTexture in startupTextures)
			{
				myTexture.enabled = false;
			}
			foreach(GUITexture myTexture in otherTextures)
			{
				myTexture.enabled = true;
			}
			foreach(GUIText myText in startupTexts)
			{
				myText.enabled = false;
			}
			checker = 0;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(checker == 1)
		{
			player.position = tPlayer;
		}
		if(PlayerPrefs.GetInt("firstGame") != 0)
		{
			waiter = 1;
		}

		if(dontSlash == 1)
		{
			dontSlashBox.enabled = true;
			dontSlashAlien.enabled = true;
			dontSlashClose.enabled = true;
			dontSlashText.enabled = true;
			PauseButtonScript.phoneBack = 4;
			ninja.gameObject.SetActive(false);
			Time.timeScale = 0;
		}
		if(Input.GetKeyDown(KeyCode.Escape) && PauseButtonScript.phoneBack == 4)
		{
			dontSlash = 0;
			dontSlashBox.enabled = false;
			dontSlashAlien.enabled = false;
			dontSlashClose.enabled = false;
			dontSlashText.enabled = false;
			ninja.gameObject.SetActive(true);
			Time.timeScale = 1;
			PauseButtonScript.phoneBack = 0;
		}
		if(closeDontSlash == 1)
		{
			closeDontSlash = 0;
			dontSlash = 0;
			dontSlashBox.enabled = false;
			dontSlashAlien.enabled = false;
			dontSlashClose.enabled = false;
			dontSlashText.enabled = false;
			ninja.gameObject.SetActive(true);
			Time.timeScale = 1;
			PauseButtonScript.phoneBack = 0;
		}
	}
	
}
