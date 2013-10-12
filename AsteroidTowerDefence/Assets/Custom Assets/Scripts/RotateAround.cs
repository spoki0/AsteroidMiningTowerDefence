using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {
	
	public Transform parent;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(parent.position, new Vector3(0,0,1), Time.deltaTime * 20);
	}
}
