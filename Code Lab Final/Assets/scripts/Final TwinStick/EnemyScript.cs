using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public float moveSpeed = 5;  //enemy movement speed
	public float pauseTime = 0.5f; //amount of time to wait at each waypoint

	public Transform waypointHolder; //holds waypoints for path

	void Start(){
		Vector3[] waypoints = new Vector3[waypointHolder.childCount]; //creates an array to hold a number of positions equal to the number of waypoints
		for (int i = 0; i < waypoints.Length; i++){
			waypoints[i] = waypointHolder.GetChild(i).position; //sets each waypoint in the array to equal the position of one of the holders child objects
		}
		StartCoroutine(FollowWaypointPath(waypoints)); //starts our coroutine for following our waypoint path
	}

	IEnumerator FollowWaypointPath(Vector3[] waypoints){ //enemy waypoint movement coroutine, using an array of waypoints
		transform.position = waypoints [0]; //set position to equal starting waypoint

		int targetWaypointIndex = 1; //the index of the current target waypoint to move towards
		Vector3 targetWaypoint = waypoints [targetWaypointIndex]; //the current target waypoint drawn from the array using the index

		while (true) { //loop forever....change this later?
			transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, moveSpeed * Time.deltaTime);//move towards the target waypoint at set speed
			if(transform.position == targetWaypoint){ //if we reach our target waypoint
				targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length; //increase the index to the next waypoint, using modulo operator to loop back to the begginning. MATH IS COOL?!?!
				targetWaypoint = waypoints [targetWaypointIndex]; //sets the new target waypoint using the new index
				yield return new WaitForSeconds(pauseTime); //wait for pauseTime before moving to next waypoint
			}
			yield return null;//DO NOT REMOVE. wait one frame between loops, keeps us from blowing up
		}
	}

	void OnDrawGizmos(){ //visualizes waypoints in scene view
		Vector3 startPos = waypointHolder.GetChild(0).position; //the first waypoint position
		Vector3 prevPos = startPos; //our previous waypoint, starts equal to first
		foreach (Transform waypoint in waypointHolder){ //for each waypoint in the holder
			Gizmos.DrawSphere (waypoint.position, 0.3f); //draw a sphere at the waypoint position
			Gizmos.DrawLine(prevPos, waypoint.position); //draw a line between this waypoint and the previous one
			prevPos = waypoint.position; //set the new previous waypoint to equal the current one
		}
		Gizmos.DrawLine(prevPos, startPos); //draw a line between the last waypoint and the first one, completing loop
	}
}
