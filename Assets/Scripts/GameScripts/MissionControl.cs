using UnityEngine;
using System.Collections;

public class MissionControl : MonoBehaviour {

	public GUIText objective, remaining, reward, objectiveStart, rewardStart;
	int choice, amount, difference;
	public static int cash;

	// Use this for initialization
	void Start () 
	{
		difference = 1;
		choice = Random.Range(1,8);
		cash = Random.Range(1,6);
		cash = cash * 100;
		if(choice == 1)
		{
			amount = Random.Range(4,10);
			amount = amount * 10;
			objective.text = "Destroy " + amount + " auto turrets";
			reward.text = "Reward: " + cash;
		}
		else if(choice == 2)
		{
			amount = Random.Range(4,10);
			amount = amount * 10;
			objective.text = "Destroy " + amount + " SAM turrets";
			reward.text = "Reward: " + cash;
		}
		else if(choice == 3)
		{
			amount = Random.Range(4,10);
			amount = amount * 10;
			objective.text = "Destroy " + amount + " Bomb turrets";
			reward.text = "Reward: " + cash;
		}
		else if(choice == 4)
		{
			amount = Random.Range(4,10);
			amount = amount * 10;
			objective.text = "Destroy " + amount + " Flame turrets";
			reward.text = "Reward: " + cash;
		}
		else if(choice == 5)
		{
			amount = Random.Range(1,5);
			amount = amount * 1000;
			objective.text = "Travel over " + amount + " m";
			reward.text = "Reward: " + cash;
		}
		else if(choice == 6)
		{
			amount = Random.Range(3,9);
			amount = amount * 100;
			objective.text = "Earn over " + amount + " g";
			reward.text = "Reward: " + cash;
		}
		else if(choice == 7)
		{
			amount = Random.Range(10,21);
			objective.text = "Break over " + amount + " rocks";
			reward.text = "Reward: " + cash;
		}
		objectiveStart.text = objective.text;
		rewardStart.text = reward.text;
	}

	
	// Update is called once per frame
	void Update () 
	{
		if(choice == 1)
		{
			difference = amount - SlashScript.autoCount;
			if(difference > 0)
			{
				remaining.text = "Remaining: " + difference;
			}
			else if (difference <= 0)
			{
				remaining.text = "Remaining: 0";
				EndGameGUI.missionCheck = 1;
			}
		}
		else if(choice == 2)
		{
			difference = amount - SlashScript.samCount;
			if(difference > 0)
			{
				remaining.text = "Remaining: " + difference;
			}
			else if (difference <= 0)
			{
				remaining.text = "Remaining: 0";
				EndGameGUI.missionCheck = 1;
			}
		}
		else if(choice == 3)
		{
			difference = amount - SlashScript.bombCount;
			if(difference > 0)
			{
				remaining.text = "Remaining: " + difference;
			}
			else if (difference <= 0)
			{
				remaining.text = "Remaining: 0";
				EndGameGUI.missionCheck = 1;
			}
		}
		else if(choice == 4)
		{
			difference = amount - SlashScript.flameCount;
			if(difference > 0)
			{
				remaining.text = "Remaining: " + difference;
			}
			else if (difference <= 0)
			{
				remaining.text = "Remaining: 0";
				EndGameGUI.missionCheck = 1;
			}
		}
		else if(choice == 5)
		{
			difference = amount - GUIControl.currentScore;
			if(difference > 0)
			{
				remaining.text = "Remaining: " + difference;
			}
			else if (difference <= 0)
			{
				remaining.text = "Remaining: 0";
				EndGameGUI.missionCheck = 1;
			}
		}
		else if(choice == 6)
		{
			difference = amount - GUIControl.currentMoney;
			if(difference > 0)
			{
				remaining.text = "Remaining: " + difference;
			}
			else if (difference <= 0)
			{
				remaining.text = "Remaining: 0";
				EndGameGUI.missionCheck = 1;
			}
		}
		else if(choice == 7)
		{
			difference = amount - SlashScript.rockCount;
			if(difference > 0)
			{
				remaining.text = "Remaining: " + difference;
			}
			else if (difference <= 0)
			{
				remaining.text = "Remaining: 0";
				EndGameGUI.missionCheck = 1;
			}
		}
	}
}
