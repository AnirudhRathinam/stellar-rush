using UnityEngine;
using System.Collections;

public class ShipLightSelect : MonoBehaviour {

	public Material[] lightMats;
	Material onMaterial;
	public static int choice;
	
	// Use this for initialization
	void Start () 
	{
		choice = PlayerPrefs.GetInt("lightSelect");
		onMaterial = lightMats[choice];
		renderer.material = onMaterial;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
