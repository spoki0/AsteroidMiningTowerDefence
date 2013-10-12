using UnityEngine;
using System.Collections;

public class AsteroidSpawn : MonoBehaviour {

	public Rigidbody[] Asteroids;
	public Transform[] SpawnPoint;
	int x = 0;
	int mod = 30;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		x++;
		if (Random.Range(0,100) > mod && x % 60 == 0){
			int spawn = Random.Range(0, SpawnPoint.Length);
			int type = Random.Range(0, Asteroids.Length);
			Quaternion rotation = new Quaternion(Random.Range(0,10),Random.Range(0,10),Random.Range(0,10),Random.Range(0,10));
			
						
			Rigidbody instance = Instantiate(Asteroids[type],
											 SpawnPoint[spawn].position,
											 rotation) as Rigidbody;
			
			instance.AddForce(-Random.Range(1000,5000),Random.Range(-500,500),0);
		
		}
	}
}
