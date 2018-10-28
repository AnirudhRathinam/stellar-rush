using UnityEngine;
using System.Collections;

public class SlashScript : MonoBehaviour 
{
	Camera cam;  
	Vector3 defaultPos = Vector3.zero;
	public GameObject turretExplosion, bulletExplosion, rockExplosion;
	public Transform playerPos;
	public GameObject superSlasher, player;
	public GUITexture plusTen, plusFifteen;
	Vector2 plusPos;

	public static int ShootDestroy = 0, ShootRock = 0;
	public static Vector2 ShootPos;

	public GameObject money, power;
	int amount, count, powerChance, powerType;

	public static int autoCount, samCount, bombCount, flameCount, rockCount;
	
	void Start () 
	{
		ShootDestroy = 0;
		ShootRock = 0;
		if (cam == null)
		{
			cam = Camera.main;
		}
		autoCount = 0;
		samCount = 0;
		bombCount = 0;
		flameCount = 0;
		rockCount = 0;
		plusTen.guiTexture.enabled = false;
		plusFifteen.guiTexture.enabled = false;
	}
	
	void Update () 
	{
		if(ShootDestroy != 0)
		{
			plusTen.transform.position = ShootPos;
			StartCoroutine(showTen());
			ShootDestroy = 0;
		}
		if(ShootRock != 0)
		{
			plusFifteen.transform.position = ShootPos;
			StartCoroutine(showFifteen());
			ShootRock = 0;
		}
		if(player)
		{
			defaultPos.y = playerPos.position.y - 2;
			// Input
			if (Input.touchCount==1)
			{
				float distance = transform.position.z - cam.transform.position.z;
				Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
				position = cam.ScreenToWorldPoint(position);
				transform.position = position;
				if(PowerUpManager.option != 2)
				{
					gameObject.GetComponent<TrailRenderer>().enabled = true;
					superSlasher.GetComponent<TrailRenderer>().enabled = false;
				}
				else if(PowerUpManager.option == 2)
				{
					gameObject.GetComponent<TrailRenderer>().enabled = false;
					superSlasher.GetComponent<TrailRenderer>().enabled = true;
				}
				gameObject.collider.enabled = true;
				
			}
			else
			{
				gameObject.collider.enabled = false;
				collider.isTrigger = false;
				gameObject.GetComponent<TrailRenderer>().enabled = false;
				superSlasher.GetComponent<TrailRenderer>().enabled = false;
				transform.position = defaultPos;
			}
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
		print ("you hit " + other.gameObject.name);
		if(PowerUpManager.option != 2)
		{
			if(other.gameObject.tag =="Turret")
			{
				if(other.gameObject.name == "Auto Turret")
				{
					autoCount ++;
				}
				else if(other.gameObject.name == "Turret SAM")
				{
					samCount++;
				}
				else if(other.gameObject.name == "Bomber Turret")
				{
					bombCount++;
				}
				else if(other.gameObject.name == "TurretBurner")
				{
					flameCount++;
				}
				plusPos = cam.WorldToScreenPoint(other.transform.position);
				plusPos.x = plusPos.x/Screen.width;
				plusPos.y = plusPos.y/Screen.height;
				plusTen.transform.position = plusPos;
				print (plusPos.x + "," + plusPos.y);

				Spawn(other);
				Instantiate(turretExplosion, other.transform.position, other.transform.rotation);
				Destroy(other.gameObject);

				StartCoroutine(showTen());

			}
		}
		if(PowerUpManager.option == 2)
		{
			if(other.gameObject.tag =="Turret")
			{
				if(other.gameObject.name == "Auto Turret")
				{
					autoCount ++;
				}
				else if(other.gameObject.name == "Turret SAM")
				{
					samCount++;
				}
				else if(other.gameObject.name == "Bomber Turret")
				{
					bombCount++;
				}
				else if(other.gameObject.name == "TurretBurner")
				{
					flameCount++;
				}
				plusPos = cam.WorldToScreenPoint(other.transform.position);
				plusPos.x = plusPos.x/Screen.width;
				plusPos.y = plusPos.y/Screen.height;
				plusTen.transform.position = plusPos;
				print (plusPos.x + "," + plusPos.y);

				Spawn(other);
				Instantiate(turretExplosion, other.transform.position, other.transform.rotation);
				Destroy(other.gameObject);

				StartCoroutine(showTen());
			}
			if(other.gameObject.tag =="Rock")
			{
				rockCount++;

				plusPos = cam.WorldToScreenPoint(other.transform.position);
				plusPos.x = plusPos.x/Screen.width;
				plusPos.y = plusPos.y/Screen.height;
				plusFifteen.transform.position = plusPos;
				print (plusPos.x + "," + plusPos.y);

				Instantiate(rockExplosion, other.transform.position, other.transform.rotation);
				Destroy(other.gameObject);

				StartCoroutine(showFifteen());

			}
		}
	}
	void Spawn(Collision other)
	{
		amount = Random.Range(1,4);
		for(count = 0; count < amount; count++)
		{
			Instantiate(money, other.transform.position, other.transform.rotation);
		}
		powerChance = Random.Range(0,60);
		if(powerChance <= 10)
		{
			Instantiate(power, other.transform.position, other.transform.rotation);
			powerType = Random.Range(1,5);
			PowerUpManager.option = powerType;
		}
	}
}
