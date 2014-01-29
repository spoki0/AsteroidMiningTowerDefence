using UnityEngine;
using System.Collections;

public class Earth : Body {
	
	
	protected override void Start () {
		base.Start();
		mMass = 1;
		Health = 10;
	}
	
	protected override void Update ()
	{
		transform.Rotate(new Vector3(1,1,0)*Time.deltaTime*5);
		//Don't move you shit...
	}
	

	void OnGUI(){
	GUI.color = Color.red;
        GUI.Label(new Rect(15, 35, 100, 20), "EARTH:  " + Health);
	}
}
