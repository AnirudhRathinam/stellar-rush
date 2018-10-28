using UnityEngine;
using System.Collections;

public class AbtCam : MonoBehaviour 
{
	public static int checkTouch = 0;
	public static int option = 0;
	// Use this for initialization
	void Start () 
	{
		checkTouch = 0;
		option = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel(0);
		}
	}
}
