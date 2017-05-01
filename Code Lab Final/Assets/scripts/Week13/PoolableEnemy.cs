using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableEnemy : Poolable { //extends the abstract class "Poolable"

	//These functions are mostly empty. How we fill them out would depend on
	//when we'd want to RePool an enemy object and how it would respawn

	public bool gotHit = false; //flag for if the enemy got hit

	public override void Setup () //override Setup (you have to, because it's abstract)
	{
	}

	public override bool RePool () //override Repool (you have to, because it's abstract)
	{
		return gotHit;
	}

	public override void Reset () //override Reset (you have to, because it's abstract)
	{
		//Respawn
	}

}
