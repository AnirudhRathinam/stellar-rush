using UnityEngine;
using System.Collections;

public class _ShipRotate : MonoBehaviour 
{
	float speed = 10f;
	// Use this for initialization
	void Start () 
	{
		speed = 10f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate(0, 2.0f*speed*Time.deltaTime, 0);
	}
}
