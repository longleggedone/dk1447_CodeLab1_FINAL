using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriShot : GunScript {


	public float moveSpeed = 1;
	public float spreadAngle1 = 45;
	public float spreadAngle2 = 315;

	public Transform projStartPointLeft;
	public Transform projStartPointRight;

	public void Start(){

	}

	public override void Shoot(){ 

		if (Time.time > shotTimer){
			shotTimer = Time.time + fireInterval / 1000;
			FireProjectile(projStartPoint.position, projStartPoint.rotation);
			FireProjectile(projStartPointRight.position, projStartPointRight.rotation * Quaternion.Euler(0,spreadAngle1,0));
			FireProjectile(projStartPointLeft.position, projStartPointLeft.rotation * Quaternion.Euler(0,spreadAngle2,0));
		}
	}

	public override void FireProjectile(Vector3 pos, Quaternion rot){
		GameObject bullet = ObjectPool.GetFromPool(Poolable.types.BULLET);
		bullet.transform.position = pos;
		bullet.transform.rotation = rot;
//		Debug.Log (bullet.transform.rotation);
		Rigidbody rb = bullet.GetComponent<Rigidbody>();
		rb.velocity = Vector3.zero; //remove it's current velocity
		rb.AddForce(bullet.transform.forward * moveSpeed, ForceMode.VelocityChange); //moveSpeed); //give it an init force
		//Debug.Log ("force added");
		//ProjectileScript newProjectile = Instantiate(projectile, pos, rot) as ProjectileScript;
		//newProjectile.SetSpeed (projStartVelocity);
	}
}
