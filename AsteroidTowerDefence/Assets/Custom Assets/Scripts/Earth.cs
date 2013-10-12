using UnityEngine;
using System.Collections;

public class Earth : Body {
	
	
	protected override void Start () {
		base.Start();
		mMass = 10;
	}
	
	protected override void Update ()
	{
		//Don't move you shit...
	}
}
