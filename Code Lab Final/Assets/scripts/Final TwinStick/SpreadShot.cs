using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShot : GunScript {



	public float spreadAngle1 = 45f;
	public float spreadAngle2 = 315f;
	public float spreadAngle3 = 22.5f;
	public float spreadAngle4 = 337.5f; 

	public Transform projStartPointLeft;
	public Transform projStartPointRight;
	public Transform projStartPointFarLeft;
	public Transform projStartPointFarRight;

	public void Start(){
		
	}

	public override void Shoot(){ 

		if (Time.time > shotTimer){
			shotTimer = Time.time + fireInterval / 1000;
			FireProjectile(projStartPoint.position, projStartPoint.rotation);
			FireProjectile(projStartPointRight.position, projStartPointRight.rotation * Quaternion.Euler(0,spreadAngle1,0));
			FireProjectile(projStartPointLeft.position, projStartPointLeft.rotation * Quaternion.Euler(0,spreadAngle2,0));

			FireProjectile(projStartPointRight.position, projStartPointRight.rotation * Quaternion.Euler(0,spreadAngle4,0));
			FireProjectile(projStartPointLeft.position, projStartPointLeft.rotation * Quaternion.Euler(0,spreadAngle3,0));
		}
	}

	public void FireProjectile(Vector3 pos, Quaternion rot){
		ProjectileScript newProjectile = Instantiate(projectile, pos, rot) as ProjectileScript;
		newProjectile.SetSpeed (projStartVelocity);
	}
}
