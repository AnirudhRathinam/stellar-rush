using UnityEngine;
using System.Collections;

public class RockHealth : MonoBehaviour 
{

	public static int rockHealth = 3;
	public GameObject rockExplosion;
	Vector2 plusPos;
	Camera cam;

	// Use this for initialization
	void Start () 
	{
		if(cam == null)
		{
			cam = Camera.main;
		}
		rockHealth = 4;
	}
}
