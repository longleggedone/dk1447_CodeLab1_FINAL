using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

	public Transform projStartPoint;
	public float moveSpeed = 100;
	//public ProjectileScript projectile;
	public float fireInterval = 100f;
	public float projStartVelocity = 35f;
	public int ammoCount = 10;

	protected float shotTimer;

	public virtual void Shoot(){ 
		if(ammoCount > 0){
			if (Time.time > shotTimer){
				shotTimer = Time.time + fireInterval / 1000;
				ammoCount -= 1;
				Debug.Log (ammoCount);
				//GameObject bullet = ObjectPool.GetFromPool(Poolable.types.BULLET);
				FireProjectile(projStartPoint.position, projStartPoint.rotation);
				//ProjectileScript newProjectile = Instantiate(projectile, projStartPoint.position, projStartPoint.rotation) as ProjectileScript;
				//newProjectile.SetSpeed (projStartVelocity);
			}
		}
	}

	public virtual void FireProjectile(Vector3 pos, Quaternion rot){
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
