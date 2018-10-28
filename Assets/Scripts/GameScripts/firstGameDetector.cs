using UnityEngine;
using System.Collections;

public class firstGameDetector : MonoBehaviour {

	int checker = 0;
	public GUITexture instrTexture, hand;
	public Texture2D instr03, instr04;
	int i = 0;
	int j = 0;
	Vector2 handPos;
	Camera cam;
	float leftEnd, rightEnd, current;
	public Texture2D handTexture;

	public GameObject myTarget;
	// Use this for initialization
	void Start () 
	{
		hand.enabled = false;
		hand.texture = handTexture;
		if (cam == null)
		{
			cam = Camera.main;
		}
		checker = 0;
		i = 0;
		j = 0;
		current = 0;
		if(PlayerPrefs.GetInt("firstGame") == 0)
		{
			checker = 1;
		}
	}
	IEnumerator Wait02()
	{
		instrTexture.enabled = false;
		hand.enabled = false;
		yield return new WaitForSeconds(1f);
		instrTexture.enabled = true;
		instrTexture.texture = instr04;
		StartupMessage.waiter = 0;
		yield return new WaitForSeconds(2.5f);
		instrTexture.enabled = false;
		PlayerPrefs.SetInt("firstGame", 1);
		PlayerPrefs.SetInt("showInstr", 0);
		StartupMessage.waiter = 1;

	}
	IEnumerator Handy()
	{
		yield return new WaitForSeconds(0.3f);
		hand.texture = null;
		yield return new WaitForSeconds(0.5f);
		hand.texture = handTexture;
		handPos.x = leftEnd;
		hand.transform.position = handPos;
		yield return new WaitForSeconds(0.3f);
		j = 0;
	}
	// Update is called once per frame
	void Update () 
	{

		if(hand.enabled == true)
		{

			if(j == 0)
			{
				hand.transform.Translate(0.0035f, 0f, 0f);
				current = hand.transform.position.x;
			}
			if(current > rightEnd)
			{
				j = 1;
				current = leftEnd;
				StartCoroutine(Handy());
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{


		if(checker ==1)
		{
			if(other.gameObject.tag == "Detect")
			{
				myTarget = other.gameObject;
				i = 1;
				StartupMessage.waiter = 0;
				instrTexture.enabled = true;
				instrTexture.texture = instr03;
				handPos = cam.WorldToScreenPoint(other.transform.position);
				handPos.x = handPos.x/Screen.width;
				handPos.y = handPos.y/Screen.height;
				handPos.y -= 0.12f;
				leftEnd = handPos.x - 0.2f;
				rightEnd = handPos.x + 0.2f;
				handPos.x = leftEnd;
				hand.transform.position = handPos;
				hand.enabled = true;
			}
		}
		if(i == 1)
		{
			if(myTarget == null)
			{
				instrTexture.enabled = false;
				StartCoroutine(Wait02());
				checker = 0;
				i = 0;
			}
		}
	}
}
