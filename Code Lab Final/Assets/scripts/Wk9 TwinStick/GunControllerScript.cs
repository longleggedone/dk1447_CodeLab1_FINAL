using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControllerScript : MonoBehaviour {

	public Transform gunPos;
	public GunScript startGun;
	GunScript currentGun;

	void Start(){
		if (startGun != null){
			SwitchGun(startGun);
		}
	}

	public void SwitchGun(GunScript gun){
		if (currentGun != null){
			Destroy(gun.gameObject);
		}
		currentGun = Instantiate (gun, gunPos.position, gunPos.rotation);
		currentGun.transform.parent = gunPos;
	}

	public void Shoot(){
		if(currentGun != null){
			currentGun.Shoot();
		}
	}
}
