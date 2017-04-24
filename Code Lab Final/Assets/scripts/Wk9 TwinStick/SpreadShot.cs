using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShot : GunScript {



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

	public void FireProjectile(Vector3 pos, Quaternion rot){
		ProjectileScript newProjectile = Instantiate(projectile, pos, rot) as ProjectileScript;
		newProjectile.SetSpeed (projStartVelocity);
	}
}
