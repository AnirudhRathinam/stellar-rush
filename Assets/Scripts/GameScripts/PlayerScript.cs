using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	//movement
	Quaternion myRot;
	float acceleration, maxVelocity, rampageVelocity;
	public static float velocity;
	public ParticleEmitter bottomThruster;

	//spawner
	int choice;
	public GameObject[] prefabList;
	public Transform myPos;
	float x1,x2,x3;
	float y1,y2,y3;
	float x,y;
	int z;
	GameObject[] Enemies,count;
	GameObject theObject;
	private Vector3 spawnPoint1, spawnPoint2, spawnPoint3;
	
	float distanceTravelled;
	int score;

	void Start () 
	{
		acceleration = 0.003f;
		velocity = 0.2f;
		maxVelocity = 0.7f;
		rampageVelocity = 1.2f;

	}
	

	void Update () 
	{
		// Input Section
		if(StartupMessage.checker != 1)
		{
			transform.Translate(Input.acceleration.x,0,0);
		}

		// Asteroid Spawner
		count = GameObject.FindGameObjectsWithTag("Rock");
		if(count.Length == 0)
		{
			SpawnCaseZero();
		}
		if(count.Length ==1)
		{
			SpawnCaseOne();
		}
		else if(count.Length == 2)
		{
			SpawnCaseTwo();
		}

		Enemies = GameObject.FindGameObjectsWithTag("Rock");
		foreach (GameObject target in Enemies) 
		{	
			if(target.transform.localPosition.y < transform.localPosition.y - 8)
			{
				Destroy(target);
			}
		}
	}

	void FixedUpdate()
	{
		if(StartupMessage.waiter != 0)
		{
			if(StartupMessage.checker != 1)
			{
				if(PowerUpManager.option != 4)
				{
					velocity = velocity + (Time.deltaTime * acceleration);
					if(velocity > maxVelocity)
					{
						print ("At max velocity");
						velocity = maxVelocity;
					}
					transform.Translate(0,velocity,0);
				}	
				if(PowerUpManager.option == 4)
				{	
					if(PowerUpManager.rampageTime > 1)
					{
						transform.Translate(0, rampageVelocity, 0);
					}
					else
					{
						velocity = velocity + (Time.deltaTime * acceleration);
						transform.Translate(0,velocity,0);
					}
				}
				bottomThruster.emit = true;
				distanceTravelled =  transform.localPosition.y + 14;
				GUIControl.currentScore = (int)distanceTravelled;
			}
		}
	}

	void SpawnCaseZero()
	{
		z=0;
		
		x1 = Random.Range (-10,10);
		y1 = Random.Range ((transform.localPosition.y +32),(transform.localPosition.y +42));
		spawnPoint1.x = x1;
		spawnPoint1.y = y1;
		spawnPoint1.z = z;
		choice = Random.Range(0,prefabList.Length);
		theObject = prefabList[choice];
		Instantiate(theObject,spawnPoint1,theObject.transform.rotation);
		
		x2 = Random.Range (-10,10);
		y2 = Random.Range ((transform.localPosition.y +44),(transform.localPosition.y +54));
		spawnPoint2.x = x2;
		spawnPoint2.y = y2;
		spawnPoint2.z = z;
		choice = Random.Range(0,prefabList.Length);
		theObject = prefabList[choice];
		Instantiate(theObject,spawnPoint2,theObject.transform.rotation);
		
		x3 = Random.Range (-10,10);
		y3 = Random.Range (transform.localPosition.y +56,transform.localPosition.y +65);
		spawnPoint3.x = x3;
		spawnPoint3.y = y3;
		spawnPoint3.z = z;
		choice = Random.Range(0,prefabList.Length);
		theObject = prefabList[choice];
		Instantiate(theObject,spawnPoint3,theObject.transform.rotation);
	}

	void SpawnCaseOne()
	{
		x = Random.Range (-10,10);
		float i,j;
		z=0;
		i = transform.localPosition.y +14;
		j = transform.localPosition.y + 25;
		y = Random.Range(i,j);
		spawnPoint3.x = x;
		spawnPoint3.y = y;
		spawnPoint3.z = z;
		choice = Random.Range(0,prefabList.Length);
		theObject = prefabList[choice];
		Instantiate(theObject,spawnPoint3,theObject.transform.rotation);

		x = Random.Range (-10,10);
		i = transform.localPosition.y +27;
		j = transform.localPosition.y + 33;
		y = Random.Range(i,j);
		spawnPoint3.x = x;
		spawnPoint3.y = y;
		spawnPoint3.z = z;
		choice = Random.Range(0,prefabList.Length);
		theObject = prefabList[choice];
		Instantiate(theObject,spawnPoint3,theObject.transform.rotation);
	}

	void SpawnCaseTwo()
	{
		x = Random.Range (-10,10);
		float i,j;
		z=0;
		i = transform.localPosition.y +40;
		j = transform.localPosition.y + 85;
		y = Random.Range(i,j);
		spawnPoint3.x = x;
		spawnPoint3.y = y;
		spawnPoint3.z = z;
		choice = Random.Range(0,prefabList.Length);
		theObject = prefabList[choice];
		Instantiate(theObject,spawnPoint3,theObject.transform.rotation);
	}



}
