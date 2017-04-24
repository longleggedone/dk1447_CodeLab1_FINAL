using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Space)){
			//GetComponent will grab whatever "BasicGun" is attached to this GameObject
			//This could be a "BasicGun", "Cannon", or "TripleShot", because all of them
			//are part of the "BasicGun" heirachy
			GetComponent<BasicGun>().Fire(Vector3.left, Vector3.zero);
		}
	}
}
