#pragma strict

var paul : Transform;
var paulMovement : PaulMovement;

function Update () {

	transform.position.x = Mathf.MoveTowards(transform.position.x, paul.position.x, Time.deltaTime * 1000F);
	transform.position.y = Mathf.Lerp(transform.position.y, paul.position.y + .25F, Time.deltaTime * 2);

}