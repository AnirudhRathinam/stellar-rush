using UnityEngine;
using System.Collections;

public class ShipBodySelect : MonoBehaviour {

	public Material[] bodyMats;
	Material onMaterial;
	public static int choice;
	
	// Use this for initialization
	void Start () 
	{
		choice = PlayerPrefs.GetInt("bodySelect");
		onMaterial = bodyMats[choice];
		renderer.material = onMaterial;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
