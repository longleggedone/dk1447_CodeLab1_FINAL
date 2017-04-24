using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This is a the base class for our Weapon Heiarchy
//It contains onle a single "protected" variable
//(which means it can only be seen by this class
//and classes that extend this class) and a 
//"virtual" function, meaning it can be overridden
//by any of it's subclasses

//BasicGun extends from MonoBehaviour
public class BasicGun : MonoBehaviour {

	//"protected" vars can only be seen by this class and classes that extend this class
	protected string name = "BasicGun";

	//"virtual" methods can be "overridden" by sub classes
	//This function creates a single bullet to shot from a location offset from the player
	//and a direction to fire the bullet in
	public virtual void Fire(Vector3 dir, Vector3 modPos){
		print("Fired a shot: " + name);

		GameObject bullet = Instantiate(Resources.Load("Prefabs/Bullet")) as GameObject;
		bullet.transform.position = transform.position + modPos;
		bullet.GetComponent<Rigidbody>().velocity = dir;
	}
}
