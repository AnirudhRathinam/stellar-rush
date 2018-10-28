#pragma strict

var collisionShrink : boolean;
var sphereCollider : SphereCollider;

var jumpForce : float;
var bouyantForce : float;
var masterScale : float;
var isInflated : boolean;

function Start(){

	sphereCollider = GetComponent(SphereCollider);
}

function Update () {

	rigidbody.AddForce(Input.GetAxis("Horizontal") * 5, 0, 0);
		
	if(isInflated)
		masterScale = 1;
	else
		masterScale = .75F;
	
	if(collisionShrink){
	
		transform.localScale.y = Mathf.MoveTowards(transform.localScale.y, .8F*masterScale, Time.deltaTime);
		sphereCollider.radius = Mathf.MoveTowards(sphereCollider.radius, .4F*masterScale, Time.deltaTime);
	}else{
	
		transform.localScale.y = Mathf.MoveTowards(transform.localScale.y, 1*masterScale, Time.deltaTime);
		sphereCollider.radius = Mathf.MoveTowards(sphereCollider.radius, .5F*masterScale, Time.deltaTime);
	}
	transform.localScale.x = transform.localScale.z = masterScale;
}
 
function OnCollisionEnter(other : Collision){
	
	collisionShrink = true;
	
	if(other.gameObject.name == "sucker"){ 
	
		isInflated = false;
		masterScale = .75F;
	}
	else if(other.gameObject.name == "inflator"){
	
		isInflated = true;
		masterScale = 1;
	}
	else if(other.gameObject.name == "platform"){
	
		rigidbody.AddForceAtPosition((transform.position - other.contacts[0].point).normalized* jumpForce, other.contacts[0].normal);
	}
	else if(other.gameObject.name == "finish"){
	
		yield WaitForSeconds(2);
		Application.LoadLevel("Finished");
	}
	
	yield WaitForSeconds(.1F);
	collisionShrink = false;
}

function OnTriggerStay(other : Collider){  //for water bouyancy

	if(other.gameObject.name == "water"){
	
		if(isInflated){
			
			rigidbody.AddForce(0, bouyantForce, 0);
		}
	}
}