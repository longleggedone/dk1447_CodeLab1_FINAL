using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public static event System.Action OnPlayerSpotted; //event for when player is spotted

	public float moveSpeed = 5;  //enemy movement speed
	public float rotateSpeed = 90; //enemy rotation speed
	public float pauseTime = 0.5f; //amount of time to wait at each waypoint
	public float timeToSpotPlayer = 0.6f; //amount of time needed for the enemy to spot player once they are visible

	public Transform waypointHolder; //holds waypoints for path
	public Transform player; //holds reference to player
	public Color patrolColor; //holds reference to spotlight color
	public Color alertColor; //alerted color for spotlight
	float playerVisibleTimer; //how long the player has been visible to the enemy


	public LayerMask viewMask; //for obstacles
	public Light spotlight; //the spotlight object for our enemy
	public float viewDistance; //how far away we want our enemy to be able to spot things
	private float viewAngle; //the angle we want our enemy to be able to spot things in

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player").transform; //gets the transform of our player
		patrolColor = spotlight.color; //sets patrolColor to equal the spotlight color
		viewAngle = spotlight.spotAngle; //sets the view angle equal to the spot angle of the spotlight
		Vector3[] waypoints = new Vector3[waypointHolder.childCount]; //creates an array to hold a number of positions equal to the number of waypoints
		for (int i = 0; i < waypoints.Length; i++){
			waypoints[i] = waypointHolder.GetChild(i).position; //sets each waypoint in the array to equal the position of one of the holders child objects
			waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z); //moves actual waypoints vertically to match the enemy y position, leaves visualized waypoint objects on ground as 'footpath'
		}
		StartCoroutine(FollowWaypointPath(waypoints)); //starts our coroutine for following our waypoint path
	}

	void Update(){
		if(PlayerIsVisible()){ //if we can see the player
			playerVisibleTimer += Time.deltaTime; //increase how long the player has been visible
			//spotlight.color = alertColor; //set the spotlight to the alert color
		}else{ //if we can't see the player
			playerVisibleTimer -= Time.deltaTime; //decrease the timer
			//spotlight.color = patrolColor; //set the spotlight to the patrol color
		}
		playerVisibleTimer = Mathf.Clamp(playerVisibleTimer, 0, timeToSpotPlayer); //clamps timer value between zero and the time needed to spot the player
		spotlight.color = Color.Lerp(patrolColor, alertColor, playerVisibleTimer/timeToSpotPlayer); //changes spotlight color smoothly based on how long the player has been visible
	
		if(playerVisibleTimer >= timeToSpotPlayer){
			if (OnPlayerSpotted != null){
				OnPlayerSpotted();
			}
		}
	}

	IEnumerator FollowWaypointPath(Vector3[] waypoints){ //enemy waypoint movement coroutine, using an array of waypoints
		transform.position = waypoints [0]; //set position to equal starting waypoint

		int targetWaypointIndex = 1; //the index of the current target waypoint to move towards
		Vector3 targetWaypoint = waypoints [targetWaypointIndex]; //the current target waypoint drawn from the array using the index
		transform.LookAt (targetWaypoint); //sets our rotation to be looking at our current target waypoint

		while (true) { //loop forever....change this later?
			transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, moveSpeed * Time.deltaTime);//move towards the target waypoint at set speed
			if(transform.position == targetWaypoint){ //if we reach our target waypoint
				targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length; //increase the index to the next waypoint, using modulo operator to loop back to the begginning. MATH IS COOL?!?!
				targetWaypoint = waypoints [targetWaypointIndex]; //sets the new target waypoint using the new index
				yield return new WaitForSeconds(pauseTime); //wait for pauseTime before moving to next waypoint
				yield return StartCoroutine (RotateToFace(targetWaypoint));//begins rotate coroutine, waits until that is completed
			}
			yield return null;//DO NOT REMOVE. wait one frame between loops, keeps us from blowing up
		}
	}

	bool PlayerIsVisible(){ //bool for whether we can see the player or not
		if(Vector3.Distance(transform.position, player.position) < viewDistance){ //if the player is within our view distance
			Vector3 directionToPlayer = (player.position - transform.position).normalized; //gets the direction between us and the player
			float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer); //gets the angle between our forward facing and the direction to the player
			if(angleToPlayer < viewAngle/2f){ //if the player is within our view angle
				if (!Physics.Linecast(transform.position, player.position, viewMask)){ //casts out a line between our position and the players, if it returns anything there is an obstacle in the way and we can't see the player
					return true; //if nothing was hit, return true
				}
			}
		}
		return false; //if any of our three checks fail, return false
	}

	IEnumerator RotateToFace(Vector3 lookAtTarget){ //enemy rotation coroutine
		Vector3 dirToLookAtTarget = (lookAtTarget - transform.position).normalized; //the direction from our position to the target we want to look at
		float angleToLookAtTarget = 90 - Mathf.Atan2(dirToLookAtTarget.z, dirToLookAtTarget.x) * Mathf.Rad2Deg; //MATH MATH MATH but seriously, we find the angle we need to rotate to be looking at the target, in degrees

		while(Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, angleToLookAtTarget)) > 0.05f){ //while the difference between our rotation and the angle needed to look at the target is less than a very small value, i.e. we are looking at the target
			float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, angleToLookAtTarget, rotateSpeed * Time.deltaTime);//moves an angle along the y axis towards our look at target over time using rotate speed
			transform.eulerAngles = Vector3.up * angle; //sets our rotation on our local up axis to our new angle
			yield return null;//DO NOT REMOVE
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

		Gizmos.color = Color.green;//set gizmo color to green
		Gizmos.DrawRay(transform.position,transform.forward * viewDistance);//draw a line from our position forward out to our view distance
	}
}
