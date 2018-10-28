using UnityEngine;
using System.Collections;

public class StatHiScore : MonoBehaviour 
{
	public Texture2D texDefault;
	public Texture2D texSelect;

	public GUIText[] HiScoreText;
	public GUIText[] AchText01, AchText02, AchText03;
	public GUITexture[] AchTexture;

	public GUITexture achTex01, achTex02, achTex03, achTex04, achTex05, achTex06;
	public Texture2D achComplete, achNotComplete;

	public GUITexture back, forward;
	public GUIText pageNo;

	public GUIText hiScoreVal, maxTurretVal, maxMoneyVal, maxDistVal, maxRockVal;

	int achievementChecker;

	// Use this for initialization
	void Start () 
	{
		guiTexture.texture = texDefault;
		hiScoreVal.text = PlayerPrefs.GetInt("highScore") + "";
		maxTurretVal.text = PlayerPrefs.GetInt("turretKillCount") + "";
		maxMoneyVal.text = PlayerPrefs.GetInt("maxCash") + "";
		maxDistVal.text = PlayerPrefs.GetInt("maxDist") + "";
		maxRockVal.text = PlayerPrefs.GetInt("rockKillCount") + "";

		//Setting the playerPrefs for achievements Space Explorer, Meaning of Life, Edge of the universe
		achievementChecker = PlayerPrefs.GetInt("highScore");
		if(achievementChecker >= 5000)
		{
			PlayerPrefs.SetInt("ach01", 10);
		}
		if(achievementChecker >= 42000)
		{
			PlayerPrefs.SetInt("ach01", 10);
			PlayerPrefs.SetInt("ach07", 10);
		}
		if(achievementChecker >= 100000)
		{
			PlayerPrefs.SetInt("ach01", 10);
			PlayerPrefs.SetInt("ach07", 10);
			PlayerPrefs.SetInt("ach13", 10);
		}

		//Setting prefs for achievements treasure hunter, money can buy hapiness, lucy
		achievementChecker = PlayerPrefs.GetInt("maxCash");
		if(achievementChecker >= 1000)
		{
			PlayerPrefs.SetInt("ach02", 10);
		}
		if(achievementChecker >= 3000)
		{
			PlayerPrefs.SetInt("ach02", 10);
			PlayerPrefs.SetInt("ach08", 10);
		}
		if(achievementChecker >= 10000)
		{
			PlayerPrefs.SetInt("ach02", 10);
			PlayerPrefs.SetInt("ach08", 10);
			PlayerPrefs.SetInt("ach14", 10);
		}

		//Setting prefs for achievements space samurai, ship smash
		achievementChecker = PlayerPrefs.GetInt("rockKillCount");
		if(achievementChecker >= 50)
		{
			PlayerPrefs.SetInt("ach11", 10);
		}
		if(achievementChecker >= 100)
		{
			PlayerPrefs.SetInt("ach11", 10);
			PlayerPrefs.SetInt("ach12", 10);
		}

	}
	
	void Update ()
	{
		if(CamGUI.option ==0)
		{
			guiTexture.texture = texSelect;
		}
		if(CamGUI.option ==1)
		{
			guiTexture.texture = texDefault;
		}
		if(Input.touchCount == 1 && CamGUI.checkTouch ==0 && CamGUI.option == 1)
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
				CamGUI.option = 0;
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

		if(CamGUI.option == 0)
		{
			foreach(GUIText achievetext in AchText01)
			{
				achievetext.enabled = false;
			}
			foreach(GUIText achievetext in AchText02)
			{
				achievetext.enabled = false;
			}
			foreach(GUIText achievetext in AchText03)
			{
				achievetext.enabled = false;
			}

			foreach(GUITexture achievetexture in AchTexture)
			{
				achievetexture.enabled = false;
			}

			foreach(GUIText hiscore in HiScoreText)
			{
				hiscore.enabled = true;
			}
			back.enabled = false;
			forward.enabled = false;
			pageNo.enabled = false;
		}

		if(CamGUI.option == 1)
		{
			back.enabled = true;
			forward.enabled = true;
			pageNo.enabled = true;

			foreach(GUITexture achievetexture in AchTexture)
			{
				achievetexture.enabled = true;
			}
			foreach(GUIText hiscore in HiScoreText)
			{
				hiscore.enabled = false;
			}
			if(CamGUI.page ==1)
			{
				foreach(GUIText achievetext in AchText01)
				{
					achievetext.enabled = true;
				}
				foreach(GUIText achievetext in AchText02)
				{
					achievetext.enabled = false;
				}
				foreach(GUIText achievetext in AchText03)
				{
					achievetext.enabled = false;
				}
				if(PlayerPrefs.GetInt("ach01") == 10)
				{
					achTex01.texture = achComplete;
				}
				else if(PlayerPrefs.GetInt("ach01") != 10)
				{
					achTex01.texture = achNotComplete;
				}
				if(PlayerPrefs.GetInt("ach02") == 10)
				{
					achTex02.texture = achComplete;
				}
				else if(PlayerPrefs.GetInt("ach02") != 10)
				{
					achTex02.texture = achNotComplete;
				}
				if(PlayerPrefs.GetInt("ach03") == 10)
				{
					achTex03.texture = achComplete;
				}
				else if(PlayerPrefs.GetInt("ach03") != 10)
				{
					achTex03.texture = achNotComplete;
				}
				if(PlayerPrefs.GetInt("ach04") == 10)
				{
					achTex04.texture = achComplete;
				}
				else if(PlayerPrefs.GetInt("ach04") != 10)
				{
					achTex04.texture = achNotComplete;
				}
				if(PlayerPrefs.GetInt("ach05") == 10)
				{
					achTex05.texture = achComplete;
				}
				else if(PlayerPrefs.GetInt("ach05") != 10)
				{
					achTex05.texture = achNotComplete;
				}
				if(PlayerPrefs.GetInt("ach06") == 10)
				{
					achTex06.texture = achComplete;
				}
				else if(PlayerPrefs.GetInt("ach06") != 10)
				{
					achTex06.texture = achNotComplete;
				}
			}
			if(CamGUI.page ==2)
			{
				foreach(GUIText achievetext in AchText01)
				{
					achievetext.enabled = false;
				}
				foreach(GUIText achievetext in AchText02)
				{
					achievetext.enabled = true;
				}
				foreach(GUIText achievetext in AchText03)
				{
					achievetext.enabled = false;
				}

				if(PlayerPrefs.GetInt("ach07") == 10)
				{
					achTex01.texture = achComplete;
				}
				else if(PlayerPrefs.GetInt("ach07") != 10)
				{
					achTex01.texture = achNotComplete;
				}
				if(PlayerPrefs.GetInt("ach08") == 10)
				{
					achTex02.texture = achComplete;
				}
				else if(PlayerPrefs.GetInt("ach08") != 10)
				{
					achTex02.texture = achNotComplete;
				}
				if(PlayerPrefs.GetInt("ach09") == 10)
				{
					achTex03.texture = achComplete;
				}
				else if(PlayerPrefs.GetInt("ach09") != 10)
				{
					achTex03.texture = achNotComplete;
				}
				if(PlayerPrefs.GetInt("ach10") == 10)
				{
					achTex04.texture = achComplete;
				}
				else if(PlayerPrefs.GetInt("ach10") != 10)
				{
					achTex04.texture = achNotComplete;
				}
				if(PlayerPrefs.GetInt("ach11") == 10)
				{
					achTex05.texture = achComplete;
				}
				else if(PlayerPrefs.GetInt("ach11") != 10)
				{
					achTex05.texture = achNotComplete;
				}
				if(PlayerPrefs.GetInt("ach12") == 10)
				{
					achTex06.texture = achComplete;
				}
				else if(PlayerPrefs.GetInt("ach12") != 10)
				{
					achTex06.texture = achNotComplete;
				}
			}
			if(CamGUI.page ==3)
			{
				foreach(GUIText achievetext in AchText01)
				{
					achievetext.enabled = false;
				}
				foreach(GUIText achievetext in AchText02)
				{
					achievetext.enabled = false;
				}
				foreach(GUIText achievetext in AchText03)
				{
					achievetext.enabled = true;
				}
				if(PlayerPrefs.GetInt("ach13") == 10)
				{
					achTex01.texture = achComplete;
				}
				else if(PlayerPrefs.GetInt("ach13") != 10)
				{
					achTex01.texture = achNotComplete;
				}
				if(PlayerPrefs.GetInt("ach14") == 10)
				{
					achTex02.texture = achComplete;
				}
				else if(PlayerPrefs.GetInt("ach14") != 10)
				{
					achTex02.texture = achNotComplete;
				}
				if(PlayerPrefs.GetInt("ach15") == 10)
				{
					achTex03.texture = achComplete;
				}
				else if(PlayerPrefs.GetInt("ach15") != 10)
				{
					achTex03.texture = achNotComplete;
				}
				if(PlayerPrefs.GetInt("ach16") == 10)
				{
					achTex04.texture = achComplete;
				}
				else if(PlayerPrefs.GetInt("ach16") != 10)
				{
					achTex04.texture = achNotComplete;
				}
				if(PlayerPrefs.GetInt("ach17") == 10)
				{
					achTex05.texture = achComplete;
				}
				else if(PlayerPrefs.GetInt("ach17") != 10)
				{
					achTex05.texture = achNotComplete;
				}
				if(PlayerPrefs.GetInt("ach18") == 10)
				{
					achTex06.texture = achComplete;
				}
				else if(PlayerPrefs.GetInt("ach18") != 10)
				{
					achTex06.texture = achNotComplete;
				}
			}
		}
	}
}
