using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public Transform waypointHolder;


	void OnDrawGizmos(){
		Vector3 startPos = waypointHolder.GetChild(0).position;
		Vector3 prevPos = startPos;
		foreach (Transform waypoint in waypointHolder){
			Gizmos.DrawSphere (waypoint.position, 0.3f);
			Gizmos.DrawLine(prevPos, waypoint.position);
			prevPos = waypoint.position;
		}
		Gizmos.DrawLine(prevPos, startPos);
	}
}
