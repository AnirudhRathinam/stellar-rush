using UnityEngine;
using System.Collections;

public class CamGUI : MonoBehaviour {

	public static int checkTouch = 0;
	public static int option = 0;
	public static int page =1;
	
	// Use this for initialization
	void Start () 
	{
		checkTouch = 0;
		option = 0;
		PlayerPrefs.SetInt("shipNumber", 0);
		PlayerPrefs.SetInt("bgNumber", 0);

		//Checks if backgrounds have been brought
		if(PlayerPrefs.GetInt("backPrefs00") == 1)
		{
			PlayerPrefs.SetInt("bgNumber", (PlayerPrefs.GetInt("bgNumber") + 1));
		}
		if(PlayerPrefs.GetInt("backPrefs01") == 1)
		{
			PlayerPrefs.SetInt("bgNumber", (PlayerPrefs.GetInt("bgNumber") + 1));
		}
		if(PlayerPrefs.GetInt("backPrefs02") == 1)
		{
			PlayerPrefs.SetInt("bgNumber", (PlayerPrefs.GetInt("bgNumber") + 1));
		}
		if(PlayerPrefs.GetInt("backPrefs03") == 1)
		{
			PlayerPrefs.SetInt("bgNumber", (PlayerPrefs.GetInt("bgNumber") + 1));
		}
		if(PlayerPrefs.GetInt("backPrefs04") == 1)
		{
			PlayerPrefs.SetInt("bgNumber", (PlayerPrefs.GetInt("bgNumber") + 1));
		}
		if(PlayerPrefs.GetInt("backPrefs05") == 1)
		{
			PlayerPrefs.SetInt("bgNumber", (PlayerPrefs.GetInt("bgNumber") + 1));
		}

		// Checking if ship customizations have been unlocked
		if(PlayerPrefs.GetInt("lightPrefs00") == 1)
		{
			PlayerPrefs.SetInt("shipNumber", (PlayerPrefs.GetInt("shipNumber") + 1));
		}
		if(PlayerPrefs.GetInt("lightPrefs01") == 1)
		{
			PlayerPrefs.SetInt("shipNumber", (PlayerPrefs.GetInt("shipNumber") + 1));
		}
		if(PlayerPrefs.GetInt("lightPrefs02") == 1)
		{
			PlayerPrefs.SetInt("shipNumber", (PlayerPrefs.GetInt("shipNumber") + 1));
		}
		if(PlayerPrefs.GetInt("lightPrefs03") == 1)
		{
			PlayerPrefs.SetInt("shipNumber", (PlayerPrefs.GetInt("shipNumber") + 1));
		}
		if(PlayerPrefs.GetInt("lightPrefs04") == 1)
		{
			PlayerPrefs.SetInt("shipNumber", (PlayerPrefs.GetInt("shipNumber") + 1));
		}
		if(PlayerPrefs.GetInt("lightPrefs05") == 1)
		{
			PlayerPrefs.SetInt("shipNumber", (PlayerPrefs.GetInt("shipNumber") + 1));
		}

		if(PlayerPrefs.GetInt("bodyPrefs00") == 1)
		{
			PlayerPrefs.SetInt("shipNumber", (PlayerPrefs.GetInt("shipNumber") + 1));
		}
		if(PlayerPrefs.GetInt("bodyPrefs01") == 1)
		{
			PlayerPrefs.SetInt("shipNumber", (PlayerPrefs.GetInt("shipNumber") + 1));
		}
		if(PlayerPrefs.GetInt("bodyPrefs02") == 1)
		{
			PlayerPrefs.SetInt("shipNumber", (PlayerPrefs.GetInt("shipNumber") + 1));
		}
		if(PlayerPrefs.GetInt("bodyPrefs03") == 1)
		{
			PlayerPrefs.SetInt("shipNumber", (PlayerPrefs.GetInt("shipNumber") + 1));
		}
		if(PlayerPrefs.GetInt("bodyPrefs04") == 1)
		{
			PlayerPrefs.SetInt("shipNumber", (PlayerPrefs.GetInt("shipNumber") + 1));
		}
		if(PlayerPrefs.GetInt("bodyPrefs05") == 1)
		{
			PlayerPrefs.SetInt("shipNumber", (PlayerPrefs.GetInt("shipNumber") + 1));
		}


		if(PlayerPrefs.GetInt("shipNumber") >= 12)
		{
			PlayerPrefs.SetInt("ach17", 10);
		}
		if(PlayerPrefs.GetInt("bgNumber") >= 6)
		{
			PlayerPrefs.SetInt("ach18", 10);
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel(0);
		}
	}
}
