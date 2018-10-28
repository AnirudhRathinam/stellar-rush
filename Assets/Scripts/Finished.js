#pragma strict

function Start () {

}

function Update () {

	if(Input.GetKeyDown(KeyCode.R))
		Application.LoadLevel("bounce");
}