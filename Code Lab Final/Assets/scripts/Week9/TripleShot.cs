using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TripleShot extends "BasicGun"
//It's important to remember that "Cannon"
//also extends "MonoBehaviour", even though it's
//not referenced in this class. It extends "MonoBehaviour"
//because it extends "BasicGun", which extends "MonoBehaviour"
//Also, notice that is overriding the "Fire" function below
public class TripleShot : BasicGun {

	//overriding the basic "Fire" function, in order to create
	//a triple shot instead of a single shot
	public override void Fire (Vector3 dir, Vector3 modPos)
	{
		//call the "base" version of fire (from "BasicGun")
		//3 times to create 3 different bullets
		base.Fire(dir, modPos);
		base.Fire(Vector3.up, new Vector3(0, 1, 0));
		base.Fire(Vector3.down, new Vector3(0, -1, 0));
//		print("fire! Fire! FIRE!!!");
	}
}
