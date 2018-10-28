#pragma strict

var bulletSpeed : float = 10;
var bulletRange : float = 10;
var bulletExplosion : GameObject;
var myTarget : Transform;

private var player : GameObject;
private var bulletDist : float;

function Update () 
{
	player = GameObject.FindWithTag("Player");
	if(player)
	{
		myTarget = player.transform;
		transform.LookAt(myTarget);
	
		transform.Translate(Vector3.forward *Time.deltaTime * bulletSpeed);
		bulletDist += Time.deltaTime * bulletSpeed;
		if (bulletDist >= bulletRange)
		{
			Explode();
			Destroy(gameObject);
		}
	}
	else
	{
		Explode();
		Destroy(gameObject);
	}
}

function Explode()
{
	Instantiate(bulletExplosion, transform.position, transform.rotation);
	Destroy(gameObject);
}
