using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerControllerScript : MonoBehaviour {

	Vector3 velocity;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	public void Move (Vector3 passedVelocity){
		velocity = passedVelocity;
	}

	public void LookAt(Vector3 point){
		Vector3 correctPoint = new Vector3(point.x, transform.position.y, point.z);
		transform.LookAt (correctPoint);
	}

	public void FixedUpdate(){
		rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
	}
}
