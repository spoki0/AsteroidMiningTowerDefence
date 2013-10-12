using UnityEngine;
using System.Collections;

public class TurretRotate : MonoBehaviour {
	
	public int rotSpeed = 10;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown ("Fire1")){
			transform.Rotate(new Vector3(0,0,1) * Time.deltaTime* rotSpeed);
		}
	}
}
