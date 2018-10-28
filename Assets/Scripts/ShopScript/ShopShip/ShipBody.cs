using UnityEngine;
using System.Collections;

public class ShipBody : MonoBehaviour 
{

	public Material[] bodyMats;
	Material onMaterial;
	public static int choice;
	
	// Use this for initialization
	void Start () 
	{
		choice = PlayerPrefs.GetInt("bodySelect");
		if(choice > 5)
		{
			choice = 0;
		}
		else if (choice < 0)
		{
			choice = 0;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		onMaterial = bodyMats[choice];
		renderer.material = onMaterial;
	}
}
