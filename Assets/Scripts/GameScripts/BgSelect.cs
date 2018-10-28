using UnityEngine;
using System.Collections;

public class BgSelect : MonoBehaviour {

	public Material[] bgMats;
	Material onMaterial;
	public static int choice;

	// Use this for initialization
	void Start () 
	{
		choice = PlayerPrefs.GetInt("backSelect");
		onMaterial = bgMats[choice];
		renderer.material = onMaterial;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
