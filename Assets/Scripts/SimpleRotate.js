#pragma strict

var xrot : float;
var yrot : float;
var zrot : float;

function Update () {
	transform.Rotate(xrot*Time.deltaTime , yrot*Time.deltaTime, zrot*Time.deltaTime);
}