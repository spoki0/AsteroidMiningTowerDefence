using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	transform.position -= new Vector3(0.2f, 0 , 0);	
		
	//transform.position += new Vector3(Random.Range(0,0.2f), (Random.Range(0,0.2f)), 0);
	}
}
