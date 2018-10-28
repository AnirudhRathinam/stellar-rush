using UnityEngine;
using System.Collections;

public class PowerUpManager : MonoBehaviour {

	public static int option;
	int disp;

	//variables for shooter
	float nextFireTime;
	float reloadTime = 0.05f;
	public GameObject playerBullet, shipShield, shipComet, player;
	public Transform muzzlePosition;

	public GUITexture autoShooter;
	public GUITexture shield;
	public GUITexture rampage;
	public GUITexture slasher;

	public GUITexture displayPower;
	public Texture2D shootShow, slashShow, shieldShow, rampageShow;

	public GUIText autoshootText;
	public GUIText slashText;
	public GUIText shieldText;
	public GUIText rampageText;

	//powerup time counters
	float autoshootTime;
	float slashTime;
	float shieldTime;
	public static float rampageTime;
	int timeDisplay;

	// Use this for initialization
	void Start () 
	{
		option = 0;// no powerup on
		reloadTime = 0.15f;
		nextFireTime = 0;
		disp = 0;
		displayPower.guiTexture.enabled = false;
		shipShield.gameObject.renderer.enabled = false;
		shipComet.gameObject.renderer.enabled = false;

		//disabling the guitextures
		autoShooter.guiTexture.enabled = false;
		shield.guiTexture.enabled = false;
		rampage.guiTexture.enabled = false;
		slasher.guiTexture.enabled = false;

		autoshootText.guiText.enabled = false;
		slashText.guiText.enabled = false;
		shieldText.guiText.enabled = false;
		rampageText.guiText.enabled = false;

		//assigning the time allotted for powerups
		if(PlayerPrefs.GetInt("shieldLevel") == 0)
		{
			shieldTime = 5;
		}
		if(PlayerPrefs.GetInt("shieldLevel") == 1)
		{
			shieldTime = 8;
		}
		if(PlayerPrefs.GetInt("shieldLevel") == 2)
		{
			shieldTime = 10;
		}
		if(PlayerPrefs.GetInt("shieldLevel") == 3)
		{
			shieldTime = 13;
		}
		if(PlayerPrefs.GetInt("slashLevel") == 0)
		{
			slashTime = 5;
		}
		if(PlayerPrefs.GetInt("slashLevel") == 1)
		{
			slashTime = 8;
		}
		if(PlayerPrefs.GetInt("slashLevel") == 2)
		{
			slashTime = 10;
		}
		if(PlayerPrefs.GetInt("slashLevel") == 3)
		{
			slashTime = 13;
		}
		if(PlayerPrefs.GetInt("rampageLevel") == 0)
		{
			rampageTime = 5;
		}
		if(PlayerPrefs.GetInt("rampageLevel") == 1)
		{
			rampageTime = 8;
		}
		if(PlayerPrefs.GetInt("rampageLevel") == 2)
		{
			rampageTime = 10;
		}
		if(PlayerPrefs.GetInt("rampageLevel") == 3)
		{
			rampageTime = 13;
		}
		if(PlayerPrefs.GetInt("shootLevel") == 0)
		{
			autoshootTime = 5;
		}
		if(PlayerPrefs.GetInt("shootLevel") == 1)
		{
			autoshootTime = 8;
		}
		if(PlayerPrefs.GetInt("shootLevel") == 2)
		{
			autoshootTime = 10;
		}
		if(PlayerPrefs.GetInt("shootLevel") == 3)
		{
			autoshootTime = 13;
		}
	}
	IEnumerator showOne()
	{
		displayPower.guiTexture.texture = shootShow;
		displayPower.guiTexture.enabled = true;
		yield return new WaitForSeconds(0.5f);
		displayPower.guiTexture.enabled = false;
	}
	IEnumerator showTwo()
	{
		displayPower.guiTexture.texture = slashShow;
		displayPower.guiTexture.enabled = true;
		yield return new WaitForSeconds(0.5f);
		displayPower.guiTexture.enabled = false;
	}
	IEnumerator showThree()
	{
		displayPower.guiTexture.texture = shieldShow;
		displayPower.guiTexture.enabled = true;
		yield return new WaitForSeconds(0.5f);
		displayPower.guiTexture.enabled = false;
	}
	IEnumerator showFour()
	{
		displayPower.guiTexture.texture = rampageShow;
		displayPower.guiTexture.enabled = true;
		yield return new WaitForSeconds(0.5f);
		displayPower.guiTexture.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(player)
		{
			if(option == 0)
			{
				disp = 0;
			}
			if(option == 1)//Auto Shooter
			{
				if(disp != 1)
				{
					StartCoroutine(showOne());
					disp = 1;
				}
				autoShooter.guiTexture.enabled = true;
				autoshootText.guiText.enabled = true;
				slasher.guiTexture.enabled = false;
				slashText.guiText.enabled = false;
				shipShield.gameObject.renderer.enabled = false;
				shield.guiTexture.enabled = false;
				shieldText.guiText.enabled = false;
				shipComet.gameObject.renderer.enabled = false;
				rampage.guiTexture.enabled = false;
				rampageText.guiText.enabled = false;
					
				if(Time.time >= nextFireTime)
				{
					FireProjectile();
				}
				autoshootTime -= Time.deltaTime;
				timeDisplay = (int)autoshootTime;
				autoshootText.text = timeDisplay + "";
				if(autoshootTime <= 0)
				{
					option = 0;
					if(PlayerPrefs.GetInt("shootLevel") == 0)
					{
						autoshootTime = 5;
					}
					if(PlayerPrefs.GetInt("shootLevel") == 1)
					{
						autoshootTime = 8;
					}
					if(PlayerPrefs.GetInt("shootLevel") == 2)
					{
						autoshootTime = 10;
					}
					if(PlayerPrefs.GetInt("shootLevel") == 3)
					{
						autoshootTime = 13;
					}
					autoShooter.guiTexture.enabled = false;
					autoshootText.guiText.enabled = false;
				}
			}
			if(option == 2)//Super Slasher
			{
				if(disp != 2)
				{
					StartCoroutine(showTwo());
					disp = 2;
				}

				slasher.guiTexture.enabled = true;
				slashText.guiText.enabled = true;
				autoShooter.guiTexture.enabled = false;
				autoshootText.guiText.enabled = false;
				shipShield.gameObject.renderer.enabled = false;
				shield.guiTexture.enabled = false;
				shieldText.guiText.enabled = false;
				shipComet.gameObject.renderer.enabled = false;
				rampage.guiTexture.enabled = false;
				rampageText.guiText.enabled = false;

				slashTime -= Time.deltaTime;
				timeDisplay = (int)slashTime;
				slashText.text = timeDisplay + "";
				if(slashTime <= 0)
				{
					option = 0;
					if(PlayerPrefs.GetInt("slashLevel") == 0)
					{
						slashTime = 5;
					}
					if(PlayerPrefs.GetInt("slashLevel") == 1)
					{
						slashTime = 8;
					}
					if(PlayerPrefs.GetInt("slashLevel") == 2)
					{
						slashTime = 10;
					}
					if(PlayerPrefs.GetInt("slashLevel") == 3)
					{
						slashTime = 13;
					}
					slasher.guiTexture.enabled = false;
					slashText.guiText.enabled = false;
				}
			}
			if(option == 3)//Shield (god mode)
			{
					
				if(disp != 3)
				{
					StartCoroutine(showThree());
					disp = 3;
				}
				shipShield.gameObject.renderer.enabled = true;
				shield.guiTexture.enabled = true;
				shieldText.guiText.enabled = true;
				autoShooter.guiTexture.enabled = false;
				autoshootText.guiText.enabled = false;
				slasher.guiTexture.enabled = false;
				slashText.guiText.enabled = false;
				shipComet.gameObject.renderer.enabled = false;
				rampage.guiTexture.enabled = false;
				rampageText.guiText.enabled = false;
	
				shieldTime -= Time.deltaTime;
				timeDisplay = (int)shieldTime;
				shieldText.text = timeDisplay + "";
				if(shieldTime <= 0)
				{
					option = 0;
					if(PlayerPrefs.GetInt("shieldLevel") == 0)
					{
						shieldTime = 5;
					}
					if(PlayerPrefs.GetInt("shieldLevel") == 1)
					{
						shieldTime = 8;
					}
					if(PlayerPrefs.GetInt("shieldLevel") == 2)
					{
						shieldTime = 10;
					}
					if(PlayerPrefs.GetInt("shieldLevel") == 3)
					{
						shieldTime = 13;
					}
					shield.guiTexture.enabled = false;
					shieldText.guiText.enabled = false;
					shipShield.gameObject.renderer.enabled = false;
				}
			}
			if(option == 4)//rampage
			{
					
				if(disp != 4)
				{
					StartCoroutine(showFour());
					disp = 4;
				}
				autoShooter.guiTexture.enabled = false;
				autoshootText.guiText.enabled = false;
				slasher.guiTexture.enabled = false;
				slashText.guiText.enabled = false;
				shipShield.gameObject.renderer.enabled = false;
				shield.guiTexture.enabled = false;
				shieldText.guiText.enabled = false;
				shipComet.gameObject.renderer.enabled = true;
				rampage.guiTexture.enabled = true;
				rampageText.guiText.enabled = true;

				rampageTime -= Time.deltaTime;
				timeDisplay = (int)rampageTime;
				rampageText.text = timeDisplay + "";
				if(rampageTime <= 0)
				{
					option = 0;
					if(PlayerPrefs.GetInt("rampageLevel") == 0)
					{
						rampageTime = 5;
					}
					if(PlayerPrefs.GetInt("rampageLevel") == 1)
					{
						rampageTime = 8;
					}
					if(PlayerPrefs.GetInt("rampageLevel") == 2)
					{
						rampageTime = 10;
					}
					if(PlayerPrefs.GetInt("rampageLevel") == 3)
					{
						rampageTime = 13;
					}
					rampage.guiTexture.enabled = false;
					rampageText.guiText.enabled = false;
					shipComet.gameObject.renderer.enabled = false;
				}
			}
		}
	}

	void FireProjectile()
	{
		nextFireTime = Time.time+reloadTime;
		Instantiate(playerBullet, muzzlePosition.position, muzzlePosition.rotation);
	}
}
