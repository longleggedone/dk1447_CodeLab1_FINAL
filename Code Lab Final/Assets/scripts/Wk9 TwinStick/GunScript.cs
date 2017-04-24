using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

	public Transform projStartPoint;
	public ProjectileScript projectile;
	public float fireInterval = 100f;
	public float projStartVelocity = 35f;

	protected float shotTimer;

	public virtual void Shoot(){ 

		if (Time.time > shotTimer){
			shotTimer = Time.time + fireInterval / 1000;
			ProjectileScript newProjectile = Instantiate(projectile, projStartPoint.position, projStartPoint.rotation) as ProjectileScript;
			newProjectile.SetSpeed (projStartVelocity);
		}
	}
}
