#pragma strict

var myPlay : Transform;
var turretExplosion : GameObject;

var pauseTitle : GUITexture;
var resumeGame : GUITexture;
var quitGame : GUITexture;
var bonusMission: GUITexture;



function Start()
{
	pauseTitle.enabled = false;
	resumeGame.enabled = false;
	quitGame.enabled = false;
	bonusMission.enabled = false;
}

function Update () 
{	
	if (GameObject.Find("PlayerShip"))
	{
		camera.main.transform.position.y = myPlay.position.y +15;
	}
	camera.main.transform.position.x = 0;
	camera.main.transform.position.z = -30;
}