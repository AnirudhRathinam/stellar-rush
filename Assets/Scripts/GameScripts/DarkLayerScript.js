#pragma strict

private var player : GameObject;

function Start () 
{
	player = GameObject.FindGameObjectWithTag("Player");
}

function Update () 
{
	if(player)
	{
		transform.position.y = player.transform.position.y + 14;
	}
}