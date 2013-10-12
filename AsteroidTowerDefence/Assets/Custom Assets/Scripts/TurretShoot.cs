using UnityEngine;
using System.Collections;

public class TurretShoot : MonoBehaviour {
	
	int BulletSpeed = 10;
	public Rigidbody bullet;
	public Transform BarrelSpawn;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		Rigidbody instance = Instantiate(bullet,
										 BarrelSpawn.position,
										 BarrelSpawn.rotation) as Rigidbody;
		
		instance.AddForce(BarrelSpawn.forward * 10);
	}
}
