#pragma strict

var ourMaterials : Material[];
private var onMaterial : Material;
private var choice : int;

function Start () 
{
	choice = Random.Range(0,ourMaterials.Length);
	onMaterial = ourMaterials[choice];
	renderer.material = onMaterial;
}