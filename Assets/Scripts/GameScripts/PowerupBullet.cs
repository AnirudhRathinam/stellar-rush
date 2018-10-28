using UnityEngine;
using System.Collections;

public class PowerupBullet : MonoBehaviour 
{
	float bulletSpeed;
	float bulletRange = 1f;
	float bulletDist;
	public GameObject bulletExplosion, turretExplosion, rockExplosion;
	Vector2 plusPos;
	Camera cam;
	// Use this for initialization
	void Start () 
	{
		if (cam == null)
		{
			cam = Camera.main;
		}
	}
	// Update is called once per frame
	void Update () 
	{
		bulletSpeed = PlayerScript.velocity + 1.2f;
		transform.Translate(0,0,bulletSpeed);
		bulletDist += Time.deltaTime * bulletSpeed;
		if (bulletDist >= bulletRange)
		{
			Explode();
		}
	}
	void Explode()
	{
		Instantiate(bulletExplosion, transform.position, transform.rotation);
		Destroy(gameObject);
	}
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Rock")
		{
			RockHealth.rockHealth--;
			if(RockHealth.rockHealth == 0)
			{
				SlashScript.rockCount++;
				plusPos = cam.WorldToScreenPoint(other.transform.position);
				plusPos.x = plusPos.x/Screen.width;
				plusPos.y = plusPos.y/Screen.height;
				SlashScript.ShootPos = plusPos;
				SlashScript.ShootRock = 1;
				Instantiate(rockExplosion, other.transform.position, other.transform.rotation);
				Destroy(other.gameObject);
			}
			Explode();
			Destroy(gameObject);
		}
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

			plusPos = cam.WorldToScreenPoint(other.transform.position);
			plusPos.x = plusPos.x/Screen.width;
			plusPos.y = plusPos.y/Screen.height;
			SlashScript.ShootPos = plusPos;
			SlashScript.ShootDestroy = 1;

			Instantiate(turretExplosion, other.transform.position, other.transform.rotation);
			Destroy(other.gameObject);
			Explode();
		}
	}
}
