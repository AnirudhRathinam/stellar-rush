using UnityEngine;
using System.Collections;

public class _CAM : MonoBehaviour 
{

	public static int checkTouch = 0;
	public static int option = 0;
	public static int displayMsg = 0;

	public GUIText cashText;
	public static int myCash;
	
	public GUITexture msg, msgClose, msgAlien;
	public GUIText msgText;

	//GUI for upgrade option
	public GUITexture[] upgradeIconsMain;
	public GUIText[] upgradeText;
	public GUITexture[] upgradeBuyButtons;
	public GUITexture[] upgradeLevels;

	//GUI for ship
	public GUITexture[] shipGUI;
	public GUIText[] shipText;
	public GameObject shipSample;

	//GUI for background selection
	public GUITexture[] backGUI;
	public GUIText[] backText;

	//GUI for GetGold
	public GUITexture[] getGoldGUI;
	public GUIText[] getGoldText;

	//Variables that keep track of whether or not ship materials have been brought by the player
	public static int buyLight00;
	public static int buyLight01;
	public static int buyLight02;
	public static int buyLight03;
	public static int buyLight04;
	public static int buyLight05;

	public static int buyBody00;
	public static int buyBody01;
	public static int buyBody02;
	public static int buyBody03;
	public static int buyBody04;
	public static int buyBody05;

	//These keep track of whether or not backgrounds have been brought
	public static int buyBack00;
	public static int buyBack01;
	public static int buyBack02;
	public static int buyBack03;
	public static int buyBack04;
	public static int buyBack05;

	public static int shopPhoneBack;


	// Use this for initialization
	void Start () 
	{

		shopPhoneBack = 0;

		myCash = PlayerPrefs.GetInt("myMoney");
		checkTouch = 0;
		if(PlayerPrefs.GetInt("freeGold") != 0)
		{
			option = 3;
			PlayerPrefs.SetInt("freeGold", 0);
		}
		else if(PlayerPrefs.GetInt("freeGold") == 0)
		{
			option = 0;
		}
		displayMsg = 0;
		PlayerPrefs.SetInt("lightPrefs00",1);
		PlayerPrefs.SetInt("bodyPrefs00", 1);
		PlayerPrefs.SetInt("backPrefs00", 1);

		buyLight00 = PlayerPrefs.GetInt("lightPrefs00");
		buyLight01 = PlayerPrefs.GetInt("lightPrefs01");
		buyLight02 = PlayerPrefs.GetInt("lightPrefs02");
		buyLight03 = PlayerPrefs.GetInt("lightPrefs03");
		buyLight04 = PlayerPrefs.GetInt("lightPrefs04");
		buyLight05 = PlayerPrefs.GetInt("lightPrefs05");

		buyBody00 = PlayerPrefs.GetInt("bodyPrefs00");
		buyBody01 = PlayerPrefs.GetInt("bodyPrefs01");
		buyBody02 = PlayerPrefs.GetInt("bodyPrefs02");
		buyBody03 = PlayerPrefs.GetInt("bodyPrefs03");
		buyBody04 = PlayerPrefs.GetInt("bodyPrefs04");
		buyBody05 = PlayerPrefs.GetInt("bodyPrefs05");

		buyBack00 = PlayerPrefs.GetInt("backPrefs00");
		buyBack01 = PlayerPrefs.GetInt("backPrefs01");
		buyBack02 = PlayerPrefs.GetInt("backPrefs02");
		buyBack03 = PlayerPrefs.GetInt("backPrefs03");
		buyBack04 = PlayerPrefs.GetInt("backPrefs04");
		buyBack05 = PlayerPrefs.GetInt("backPrefs05");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(shopPhoneBack == 0 && Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel(0);
		}
		if(shopPhoneBack == 1 && Input.GetKeyDown(KeyCode.Escape))
		{
			MsgBoxClose.closeGold = 1;
		}

		PlayerPrefs.SetInt("lightPrefs00", buyLight00);
		PlayerPrefs.SetInt("lightPrefs01", buyLight01);
		PlayerPrefs.SetInt("lightPrefs02", buyLight02);
		PlayerPrefs.SetInt("lightPrefs03", buyLight03);
		PlayerPrefs.SetInt("lightPrefs04", buyLight04);
		PlayerPrefs.SetInt("lightPrefs05", buyLight05);

		PlayerPrefs.SetInt("bodyPrefs00", buyBody00);
		PlayerPrefs.SetInt("bodyPrefs01", buyBody01);
		PlayerPrefs.SetInt("bodyPrefs02", buyBody02);
		PlayerPrefs.SetInt("bodyPrefs03", buyBody03);
		PlayerPrefs.SetInt("bodyPrefs04", buyBody04);
		PlayerPrefs.SetInt("bodyPrefs05", buyBody05);

		PlayerPrefs.SetInt("backPrefs00", buyBack00);
		PlayerPrefs.SetInt("backPrefs01", buyBack01);
		PlayerPrefs.SetInt("backPrefs02", buyBack02);
		PlayerPrefs.SetInt("backPrefs03", buyBack03);
		PlayerPrefs.SetInt("backPrefs04", buyBack04);
		PlayerPrefs.SetInt("backPrefs05", buyBack05);

		if(myCash < 0)
		{
			myCash = 0;
		}
		//When to display messageBox
		if(displayMsg == 1)
		{
			msg.guiTexture.enabled = true;
			msgClose.guiTexture.enabled = true;
			msgAlien.guiTexture.enabled = true;
			msgText.guiText.enabled = true;
			checkTouch = 1;
		}
		else if (displayMsg == 0)
		{
			msg.guiTexture.enabled = false;
			msgClose.guiTexture.enabled = false;
			msgAlien.guiTexture.enabled = false;
			msgText.guiText.enabled = false;
		}
		cashText.text = myCash+ "g";
		if(option == 1)
		{
			GameObject me = GameObject.FindGameObjectWithTag("Player");
			if(me == null)
			{
				Instantiate(shipSample,new Vector3(0,4,-1),Quaternion.Euler(315,0,0));
			}
		}
		if (option !=1)
		{
			GameObject me = GameObject.FindGameObjectWithTag("Player");
			if(me)
			{
				Destroy(me);
			}
		}

		//If upgrade button is selected disable option 1,2 gui and enable option 0 gui
		if(option == 0)
		{
			//enable upgrade gui
			foreach(GUITexture tex in upgradeIconsMain)
			{
				tex.enabled = true;
			}
			foreach (GUIText tup in upgradeText)
			{
				tup.enabled = true;
			}
			foreach(GUITexture upBut in upgradeBuyButtons)
			{
				upBut.enabled = true;
			}
			foreach(GUITexture upLvl in upgradeLevels)
			{
				upLvl.enabled = true;
			}

			//disable other gui
			//ship
			foreach(GUITexture tex in shipGUI)
			{
				tex.enabled = false;
			}
			foreach (GUIText tup in shipText)
			{
				tup.enabled = false;
			}
			//background
			foreach(GUITexture tex in backGUI)
			{
				tex.enabled = false;
			}
			foreach (GUIText tup in backText)
			{
				tup.enabled = false;
			}

			foreach(GUITexture myTexture in getGoldGUI)
			{
				myTexture.enabled = false;
			}
			foreach(GUIText myText in getGoldText)
			{
				myText.enabled = false;
			}

		}

		if(option == 1)//shop
		{

			foreach(GUITexture tex in upgradeIconsMain)
			{
				tex.enabled = false;
			}
			foreach (GUIText tup in upgradeText)
			{
				tup.enabled = false;
			}
			foreach(GUITexture upBut in upgradeBuyButtons)
			{
				upBut.enabled = false;
			}
			foreach(GUITexture upLvl in upgradeLevels)
			{
				upLvl.enabled = false;
			}
			

			foreach(GUITexture tex in shipGUI)
			{
				tex.enabled = true;
			}
			foreach (GUIText tup in shipText)
			{
				tup.enabled = true;
			}

		
			foreach(GUITexture tex in backGUI)
			{
				tex.enabled = false;
			}
			foreach (GUIText tup in backText)
			{
				tup.enabled = false;
			}
			foreach(GUITexture myTexture in getGoldGUI)
			{
				myTexture.enabled = false;
			}
			foreach(GUIText myText in getGoldText)
			{
				myText.enabled = false;
			}
		}

		if(option == 2)//background
		{
			foreach(GUITexture tex in upgradeIconsMain)
			{
				tex.enabled = false;
			}
			foreach (GUIText tup in upgradeText)
			{
				tup.enabled = false;
			}
			foreach(GUITexture upBut in upgradeBuyButtons)
			{
				upBut.enabled = false;
			}
			foreach(GUITexture upLvl in upgradeLevels)
			{
				upLvl.enabled = false;
			}
			
			
			foreach(GUITexture tex in shipGUI)
			{
				tex.enabled = false;
			}
			foreach (GUIText tup in shipText)
			{
				tup.enabled = false;
			}
			
			
			foreach(GUITexture tex in backGUI)
			{
				tex.enabled = true;
			}
			foreach (GUIText tup in backText)
			{
				tup.enabled = true;
			}
			foreach(GUITexture myTexture in getGoldGUI)
			{
				myTexture.enabled = false;
			}
			foreach(GUIText myText in getGoldText)
			{
				myText.enabled = false;
			}
		}
		if(option == 3)//earngold
		{
			foreach(GUITexture tex in upgradeIconsMain)
			{
				tex.enabled = false;
			}
			foreach (GUIText tup in upgradeText)
			{
				tup.enabled = false;
			}
			foreach(GUITexture upBut in upgradeBuyButtons)
			{
				upBut.enabled = false;
			}
			foreach(GUITexture upLvl in upgradeLevels)
			{
				upLvl.enabled = false;
			}
			
			
			foreach(GUITexture tex in shipGUI)
			{
				tex.enabled = false;
			}
			foreach (GUIText tup in shipText)
			{
				tup.enabled = false;
			}
			
			
			foreach(GUITexture tex in backGUI)
			{
				tex.enabled = false;
			}
			foreach (GUIText tup in backText)
			{
				tup.enabled = false;
			}

			// Enable getGold Gui

			foreach(GUITexture myTexture in getGoldGUI)
			{
				myTexture.enabled = true;
			}
			foreach(GUIText myText in getGoldText)
			{
				myText.enabled = true;
			}
		}
	}
}
