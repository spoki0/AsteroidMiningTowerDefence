using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {
	
	public Rigidbody Core;
	int dist = 150;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if( Vector3.Distance(gameObject.transform.position, Core.transform.position) > dist){
			Destroy(gameObject);	
		}
		
	}
}
