using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{
	public static float health;
	float healthCurrent;

	public GameObject turretExplosion, turretBulletExplosion, shipExplosion, rockExplosion;
	public GUITexture health25, health50, health75, health100, health125, plusTen, plusFifteen;
	public Texture2D healthFull, healthEmpty;
	public GameObject pauseBackground;
	public GUITexture healthMinus;
	Vector2 plusPos;
	Camera cam;

	public static int callBurn;

	// Use this for initialization
	void Start () 
	{
		healthMinus.guiTexture.enabled = false;
		health25.guiTexture.enabled = false;
		health50.guiTexture.enabled = false;
		health75.guiTexture.enabled = false;
		health100.guiTexture.enabled = false;
		health125.guiTexture.enabled = false;
		if (cam == null)
		{
			cam = Camera.main;
		}
		callBurn = 0;
		pauseBackground.renderer.enabled = false;
		if(PlayerPrefs.GetInt("healthLevel") == 0)
		{
			health = 50;
		}
		if(PlayerPrefs.GetInt("healthLevel") == 1)
		{
			health = 75;
		}
		if(PlayerPrefs.GetInt("healthLevel") == 2)
		{
			health = 100;
		}
		if(PlayerPrefs.GetInt("healthLevel") == 3)
		{
			health = 125;
		}

		if (health < 50)
		{
			health = 50;
		}
		if (health > 125)
		{
			health = 125;
		}
		healthCurrent = health;
	}
	IEnumerator showMinus()
	{
		healthMinus.guiTexture.enabled = true;
		yield return new WaitForSeconds(0.2f);
		healthMinus.guiTexture.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{


		if(healthCurrent ==25)
		{
			health25.guiTexture.enabled = true;
			
			health25.texture = healthFull;
		}
		if(healthCurrent ==50)
		{
			
			health25.guiTexture.enabled = true;
			health50.guiTexture.enabled = true;
			
			health25.texture = healthFull;
			health50.texture = healthFull;
		}
		if(healthCurrent ==75)
		{
			health25.guiTexture.enabled = true;
			health50.guiTexture.enabled = true;
			health75.guiTexture.enabled = true;
			
			health25.texture = healthFull;
			health50.texture = healthFull;
			health75.texture = healthFull;
		}
		if(healthCurrent ==100)
		{
			health25.guiTexture.enabled = true;
			health50.guiTexture.enabled = true;
			health75.guiTexture.enabled = true;
			health100.guiTexture.enabled = true;
			
			health25.texture = healthFull;
			health50.texture = healthFull;
			health75.texture = healthFull;
			health100.texture = healthFull;
		}
		if(healthCurrent ==125)
		{
			health25.guiTexture.enabled = true;
			health50.guiTexture.enabled = true;
			health75.guiTexture.enabled = true;
			health100.guiTexture.enabled = true;
			health125.guiTexture.enabled = true;
			
			health25.texture = healthFull;
			health50.texture = healthFull;
			health75.texture = healthFull;
			health100.texture = healthFull;
			health125.texture = healthFull;
		}


		if(healthCurrent <=0)
		{
			print("You died");
			Explode();
		}
		if(callBurn == 1)
		{
			Burn();
		}
	}

	IEnumerator showTen()
	{
		plusTen.guiTexture.enabled = true;
		yield return new WaitForSeconds(0.2f);
		plusTen.guiTexture.enabled = false;
	}
	
	IEnumerator showFifteen()
	{
		plusFifteen.guiTexture.enabled = true;
		yield return new WaitForSeconds(0.2f);
		plusFifteen.guiTexture.enabled = false;
	}

	void OnCollisionEnter(Collision other)
	{
		if(PowerUpManager.option < 3)
		{
			if(other.gameObject.tag == "Turret")
			{
				//gui changes according to amount of health
				if(healthCurrent ==25)
				{
					health25.texture = healthEmpty;
					healthCurrent = healthCurrent - 25;
				}
				if(healthCurrent ==50)
				{
					
					health50.texture = healthEmpty;
					healthCurrent = healthCurrent - 25;
					StartCoroutine(showMinus());
				}
				if(healthCurrent ==75)
				{
				
					health75.texture = healthEmpty;
					healthCurrent = healthCurrent - 25;
					StartCoroutine(showMinus());
				}
				if(healthCurrent ==100)
				{
					
					health100.texture = healthEmpty;
					healthCurrent = healthCurrent - 25;
					StartCoroutine(showMinus());
				}
				if(healthCurrent == 125)
				{
					health125.texture = healthEmpty;
					healthCurrent = healthCurrent - 25;
					StartCoroutine(showMinus());
				}
			
			
				Instantiate(turretExplosion, other.transform.position, Quaternion.identity);
				Destroy(other.gameObject);
			}
		
			if(other.gameObject.tag == "TBullet")
			{
				//gui changes according to amount of health
				if(healthCurrent ==25)
				{
					health25.texture = healthEmpty;
					healthCurrent = healthCurrent - 25;
				}
				if(healthCurrent ==50)
				{
					
					health50.texture = healthEmpty;
					healthCurrent = healthCurrent - 25;
					StartCoroutine(showMinus());
				}
				if(healthCurrent ==75)
				{
					
					health75.texture = healthEmpty;
					healthCurrent = healthCurrent - 25;
					StartCoroutine(showMinus());
				}
				if(healthCurrent ==100)
				{
					
					health100.texture = healthEmpty;
					healthCurrent = healthCurrent - 25;
					StartCoroutine(showMinus());
				}
				if(healthCurrent == 125)
				{
					health125.texture = healthEmpty;
					healthCurrent = healthCurrent - 25;
					StartCoroutine(showMinus());
				}

				Instantiate(turretBulletExplosion, other.transform.position, Quaternion.identity);
				Destroy(other.gameObject);
			}
		
			if(other.gameObject.tag == "Rock")
			{
				//gui changes according to amount of health
				if(healthCurrent ==25)
				{
					health25.texture = healthEmpty;
					healthCurrent = healthCurrent - 25;
				}
				if(healthCurrent ==50)
				{
					
					health50.texture = healthEmpty;
					healthCurrent = healthCurrent - 25;
					StartCoroutine(showMinus());
				}
				if(healthCurrent ==75)
				{
				
					health75.texture = healthEmpty;
					healthCurrent = healthCurrent - 25;
					StartCoroutine(showMinus());
				}
				if(healthCurrent ==100)
				{
					
					health100.texture = healthEmpty;
					healthCurrent = healthCurrent - 25;
					StartCoroutine(showMinus());
				}
				if(healthCurrent == 125)
				{
					health125.texture = healthEmpty;
					healthCurrent = healthCurrent - 25;
					StartCoroutine(showMinus());
				}

				Instantiate(rockExplosion, other.transform.position, Quaternion.identity);
				Destroy(other.gameObject);
			}
			if(other.gameObject.tag == "Ninja")
			{
				if(PlayerPrefs.GetInt("firstGame") != 0 && StartupMessage.instrEnabled != 1)
				{
					if(StartupMessage.dontSlash != 1)
					{
					
						//gui changes according to amount of health
						if(healthCurrent ==25)
						{
							health25.texture = healthEmpty;
							healthCurrent = healthCurrent - 25;
						}
						if(healthCurrent ==50)
						{
						
							health50.texture = healthEmpty;
							healthCurrent = healthCurrent - 25;
							StartCoroutine(showMinus());
						}
						if(healthCurrent ==75)
						{
					
							health75.texture = healthEmpty;
							healthCurrent = healthCurrent - 25;
							StartCoroutine(showMinus());
						}
						if(healthCurrent ==100)
						{
						
							health100.texture = healthEmpty;
							healthCurrent = healthCurrent - 25;
							StartCoroutine(showMinus());
						}
						if(healthCurrent == 125)
						{
							health125.texture = healthEmpty;
							healthCurrent = healthCurrent - 25;
							StartCoroutine(showMinus());
						}
					}
					if(PlayerPrefs.GetInt("showDontSlash") == 0)
					{
						StartupMessage.dontSlash = 1;
						PlayerPrefs.SetInt("showDontSlash",1);
					}
				}
				Instantiate(turretExplosion, other.transform.position, Quaternion.identity);
			}
		}
		if(PowerUpManager.option >= 3)
		{
			if(other.gameObject.tag == "Turret")
			{
				if(other.gameObject.name == "Auto Turret")
				{
					SlashScript.autoCount++;
				}
				else if(other.gameObject.name == "Turret SAM")
				{
					SlashScript.samCount++;
				}
				else if(other.gameObject.name == "Bomber Turret")
				{
					SlashScript.bombCount++;
				}
				else if(other.gameObject.name == "TurretBurner")
				{
					SlashScript.flameCount++;
				}
				Instantiate(turretExplosion, other.transform.position, Quaternion.identity);
				Destroy(other.gameObject);

				plusPos = cam.WorldToScreenPoint(other.transform.position);
				plusPos.x = plusPos.x/Screen.width;
				plusPos.y = plusPos.y/Screen.height;
				plusTen.transform.position = plusPos;
				print (plusPos.x + "," + plusPos.y);

				StartCoroutine(showTen());
			}
			if(other.gameObject.tag == "TBullet")
			{
				Instantiate(turretBulletExplosion, other.transform.position, Quaternion.identity);
				Destroy(other.gameObject);
			}
			if(other.gameObject.tag == "Rock")
			{
				SlashScript.rockCount++;
				Instantiate(rockExplosion, other.transform.position, Quaternion.identity);
				Destroy(other.gameObject);

				plusPos = cam.WorldToScreenPoint(other.transform.position);
				plusPos.x = plusPos.x/Screen.width;
				plusPos.y = plusPos.y/Screen.height;
				plusFifteen.transform.position = plusPos;
				print (plusPos.x + "," + plusPos.y);

				StartCoroutine(showFifteen());
			}
			if(other.gameObject.tag == "Ninja")
			{
				Instantiate(turretExplosion, other.transform.position, Quaternion.identity);
			}
		}
	}

	void Burn()
	{
		if(healthCurrent ==25)
		{
			health25.texture = healthEmpty;
			healthCurrent = healthCurrent - 25;
		}
		if(healthCurrent ==50)
		{
			
			health50.texture = healthEmpty;
			healthCurrent = healthCurrent - 25;
			StartCoroutine(showMinus());
		}
		if(healthCurrent ==75)
		{
			
			health75.texture = healthEmpty;
			healthCurrent = healthCurrent - 25;
			StartCoroutine(showMinus());
		}
		if(healthCurrent ==100)
		{
			
			health100.texture = healthEmpty;
			healthCurrent = healthCurrent - 25;
			StartCoroutine(showMinus());
		}
		if(healthCurrent == 125)
		{
			health125.texture = healthEmpty;
			healthCurrent = healthCurrent - 25;
			StartCoroutine(showMinus());
		}
		callBurn = 0;
	}

	void Explode()
	{
		Instantiate(shipExplosion,transform.position,transform.rotation);
		if(health == 125)
		{
			PlayerPrefs.SetInt("ach16", 10);
		}
		EndGameGUI.gameOverCheck = 1;
		Destroy(gameObject);
	}
}
