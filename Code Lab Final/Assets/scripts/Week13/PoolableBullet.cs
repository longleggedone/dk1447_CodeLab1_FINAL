using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableBullet : Poolable { //extends the abstract class "Poolable"

	public float maxDistance; //distance the bullet can be from the player
	public float moveSpeed = 100; //force to apply to the bullet
	GameObject player;//ref to the player object

	public override void Setup () //override Setup (you have to, because it's abstract)
	{
		player = GameObject.Find("Player"); //get a reference to the "Player" object
	}

	public override bool RePool(){ //override Repool (you have to, because it's abstract)
		return Vector3.Distance(player.transform.position, transform.position) > maxDistance; //if the bullet is too far from the player
	}

	public override void Reset(){ //override Reset (you have to, because it's abstract)
		print("Reset");

		if(player == null){ //if we don't have a reference to the player yet
			player = GameObject.Find("Player"); //get a ref to the player
		}

		Rigidbody rb = GetComponent<Rigidbody>(); //get the rigidBody attached to this bullet
		transform.position = player.transform.position + new Vector3(0, 1, 0); //put the bullet near the player

		print(player.transform.position);

		rb.velocity = Vector3.zero; //remove it's current velocity
		rb.AddForce(Vector3.up * moveSpeed); //give it an init force
	}
}
