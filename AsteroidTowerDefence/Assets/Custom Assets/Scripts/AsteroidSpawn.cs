using UnityEngine;
using System.Collections;

public class AsteroidSpawn : MonoBehaviour {

	public Rigidbody[] Asteroids;
	public Transform[] SpawnPoint;
	int x = 0;
	int mod = 70;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		x++;
		if (Random.Range(0,100) > mod && x % 60 == 0){
			int spawn = Random.Range(0, SpawnPoint.Length);
			int type = Random.Range(0, Asteroids.Length);
			
						
			Rigidbody instance = Instantiate(Asteroids[type],
											 SpawnPoint[spawn].position,
											 SpawnPoint[spawn].rotation) as Rigidbody;
			
			instance.AddForce(-Random.Range(10,100),Random.Range(-50,50),0);
			
		}
	}
}
