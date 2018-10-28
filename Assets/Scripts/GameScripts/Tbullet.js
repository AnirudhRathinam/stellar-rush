#pragma strict

var bulletSpeed : float = 10;
var bulletRange : float = 10;
var bulletExplosion : GameObject;

private var bulletDist : float;


function Update () 
{
	transform.Translate(Vector3.forward *Time.deltaTime * bulletSpeed);
	bulletDist += Time.deltaTime * bulletSpeed;
	if (bulletDist >= bulletRange)
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

function OnCollisionEnter(collision : Collision)
{
	
	if(collision.gameObject.tag == "Rock")
	{
		Explode();
		Destroy(gameObject);
	}
}
