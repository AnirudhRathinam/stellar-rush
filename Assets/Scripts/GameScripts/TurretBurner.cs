using UnityEngine;
using System.Collections;

public class TurretBurner : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnTriggerEnter(Collider other)
	{
		if(PowerUpManager.option < 3)
		{
			if(other.gameObject.tag == "Player")
			{
				PlayerHealth.callBurn = 1;
			}
		}
	}
}
