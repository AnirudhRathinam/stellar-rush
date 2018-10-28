using UnityEngine;
using System.Collections;

public class ShipLights : MonoBehaviour 
{
	public Material[] lightMats;
	Material onMaterial;
	public static int choice;

	// Use this for initialization
	void Start () 
	{
		choice = PlayerPrefs.GetInt("lightSelect");
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
		onMaterial = lightMats[choice];
		renderer.material = onMaterial;
	}
}
