using UnityEngine;
using System.Collections;

public class MoneyScript : MonoBehaviour 
{
	GameObject player;
	Transform myTarget;
	float bulletSpeed;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player");
		bulletSpeed = Random.Range(0.71f,0.8f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(player)
		{
			myTarget = player.transform;
			transform.LookAt(myTarget);
			
			transform.Translate(0,0,bulletSpeed);
		}
		else
		{
			Explode();
			Destroy(gameObject);
		}
	}
	
	void Explode()
	{
		Destroy(gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			GUIControl.currentMoney +=5;
			print ("Money!!");
			Explode ();
		}
	}
}
