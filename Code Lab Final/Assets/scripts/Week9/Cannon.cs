using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cannon extends "BasicGun"
//Notice it has access to the variable "name"
//from it's super super class "BasicGun" even
//though it's never declared in "Cannon"
//It's also important to remember that "Cannon"
//also extends "MonoBehaviour", even though it's
//not referenced in this class. It extends "MonoBehaviour"
//because it extends "BasicGun", which extends "MonoBehaviour"
public class Cannon : BasicGun {

	// Use this for initialization
	void Start () {
		name = "Cannon";  //The var "name" comes from "BasicGun"
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
