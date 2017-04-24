using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (PlayerControllerScript))]
[RequireComponent (typeof (GunControllerScript))]
public class PlayerScript : MonoBehaviour {

	public float movementSpeed = 10;

	Camera camera;
	PlayerControllerScript controller;
	GunControllerScript gunController;

	// Use this for initialization
	void Start () {
		controller = GetComponent<PlayerControllerScript>();
		gunController = GetComponent<GunControllerScript>();
		camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 movementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		Vector3 movementVelocity = movementInput.normalized * movementSpeed;
		controller.Move(movementVelocity);

		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		Plane ground = new Plane(Vector3.up, Vector3.zero);
		float rayDistance;

		if (ground.Raycast(ray, out rayDistance)){
			Vector3 point = ray.GetPoint(rayDistance);
			Debug.DrawLine(ray.origin, point, Color.red);
			controller.LookAt(point);
		}

		if(Input.GetMouseButton(0)){
			gunController.Shoot();
		}
	}
}
