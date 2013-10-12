#pragma strict

var health = 1;


function OnCollisionEnter(collision : Collision) {

	Debug.Log("Hoppla Hei!");
	
	if (health == 5){
		Destroy(gameObject);
	
	} else {
		Debug.Log("Inte død enda!");
	
	}
	
	health++;
  
}