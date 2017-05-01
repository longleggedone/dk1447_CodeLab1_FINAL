using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space)){ //if the spacebar is pressed
			//get a bullet from the bullet pool
			GameObject bullet = ObjectPool.GetFromPool(Poolable.types.BULLET);
		}
	}
}
