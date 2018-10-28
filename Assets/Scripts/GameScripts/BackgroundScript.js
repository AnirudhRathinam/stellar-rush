#pragma strict

private var spawnPoint: Vector3;
var background : GameObject;

function Start () 
{
	spawnPoint.x = transform.position.x;
	spawnPoint.y = transform.position.y;
	spawnPoint.z = transform.position.z;
}

function OnTriggerEnter(other : Collider)
{
	if(other.gameObject.tag == "Player")
		{
			spawnPoint.y += 100;
			Instantiate(background,spawnPoint,background.transform.rotation);
		}

}
function OnTriggerExit(other : Collider)
{
	if(other.gameObject.tag == "Player")
		{
			Kill();
		}
}

function Kill()
{
	yield WaitForSeconds(7f);
	Destroy(gameObject);
}
