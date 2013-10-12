using UnityEngine;
using System.Collections;

public class AsteroidSpawn : MonoBehaviour {

	int BulletSpeed = 10;
	public Rigidbody asteroid;
	public Transform[] SpawnPoint;
	int x = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		x++;
		if (x % 180 == 0){
			int spawn = Random.Range(0, SpawnPoint.Length);
			
			Rigidbody instance = Instantiate(asteroid,
											 SpawnPoint[spawn].position,
											 SpawnPoint[spawn].rotation) as Rigidbody;
			
			
			instance.AddForce(Vector3.right * -Random.Range(50,500));
			
		}
	}
}
