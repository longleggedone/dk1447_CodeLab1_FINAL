using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

	public static Queue<GameObject> bulletPool = new Queue<GameObject>(); //Queue for bullets
	public static Queue<GameObject> enemyPool = new Queue<GameObject>(); //Queue for enemies

	public static GameObject GetFromPool(Poolable.types type){//Get an object from the pool

		GameObject result;

		if(type == Poolable.types.BULLET){ //if type is a BULLET
			if(bulletPool.Count > 0){ //if we have bullets in the bulletPool
				result = bulletPool.Dequeue(); //get a bullet ou of the bulletPool
			} else {
				result = Instantiate(Resources.Load("Bullet")) as GameObject; //create a new bullet, since the pool is empty
			}
		} else {//if (type == Poolable.types.ENEMY){
			if(enemyPool.Count > 0){ //if we have enemies in the enemyPool
				result = enemyPool.Dequeue(); //get a enemy ou of the enemyPool
			} else {
				result = Instantiate(Resources.Load("Enemy")) as GameObject; //create a new enemy, since the pool is empty
			}
		}

		result.SetActive(true); //Activate the bullet
		result.GetComponent<Poolable>().Reset(); //Call "Reset" for this objects Poolable component

		return result; //return the result
	}

	public static void AddToPool(GameObject obj){ //Add an object to the pool
		obj.SetActive(false); //turn off the object

		Poolable p = obj.GetComponent<Poolable>(); //get this objects Poolable component

		if(p is PoolableBullet){ //if p is a "PoolableBullet"
			bulletPool.Enqueue(obj); //put it in the bullet pool
		} else if (p is PoolableEnemy){ //if p is a "PoolableEnemy"
			enemyPool.Enqueue(obj); //put it in the enemy pool
		} else { //if it's an unsupported type of Poolable
			Debug.Log("You have not implemented a pool for this type of Object"); //Print out an warning, don't add it to a pool
		}
	}
}
