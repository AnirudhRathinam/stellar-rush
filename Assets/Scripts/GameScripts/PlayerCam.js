#pragma strict

private var screenX :float;
private var playerPosScreen : Vector3;


function Start () 
{
	screenX = (Screen.width * 5) / 100;
}

function Update () 
{
	playerPosScreen = Camera.main.WorldToScreenPoint(transform.position);
	if(PlayerPrefs.GetInt("warpMe") != 0)
	{
		if (playerPosScreen.x < screenX)
		{
    		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - screenX,playerPosScreen.y,playerPosScreen.z));
		}
		else if (playerPosScreen.x > Screen.width - screenX)
		{
    		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(screenX,playerPosScreen.y,playerPosScreen.z));
		}
	}
	else if (PlayerPrefs.GetInt("warpMe") == 0)
	{
		if (playerPosScreen.x < screenX)
		{
    		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(screenX, playerPosScreen.y, playerPosScreen.z));
		}
		else if (playerPosScreen.x > Screen.width - screenX)
		{
    		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - screenX, playerPosScreen.y, playerPosScreen.z));
		}
	}
	
}
function Explode()
{
	
}