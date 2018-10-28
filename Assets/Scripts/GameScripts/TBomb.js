#pragma strict

var muzzlePositions : Transform[];
var myProjectile : GameObject;
var turretExplosion : GameObject;


function OnTriggerEnter(other : Collider)
{
	if(other.gameObject.tag == "Player")
	{
		for(theMuzzlePos in muzzlePositions)
		{
			Instantiate(myProjectile, theMuzzlePos.position, theMuzzlePos.rotation);
		}
		Explode();
	}
}

function Explode()
{
	Instantiate(turretExplosion, transform.position, transform.rotation);
	Destroy(gameObject);
}