using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wk9Manager : MonoBehaviour {

	//Declaring an object of a basic class we just created
	MyVec3 test;

	// Use this for initialization
	void Start () {
		test = new MyVec3(); //initailizing an object of a basic class we created

		test.x = 10; //setting a value inside of an object we created

//		HighScore[] highScores = new HighScore[2]; //just proving you can make an array out of classes you make

		HighScore hs1 = new HighScore(); //initailizing an object we created
		hs1.name = "MATT"; //setting a value inside of an object we created
		hs1.position = 1; //setting a value inside of an object we created
		hs1.score = 10; //setting a value inside of an object we created

		HighScore hs2 = new HighScore(); //initailizing a class we created
		hs2.name = "David"; //setting a value inside an object we created
		hs2.position = 2; //setting a value inside an objects we created
		hs2.score = 9.9f; //setting a value inside an object we created

		HighScore hs3 = new HighScore(); //initailizing a class we created
		hs3.name = "Dennis"; //setting a value inside an object we created
		hs3.position = 3; //setting a value inside an object we created
		hs3.score = 1; //setting a value inside an object we created

		hs1.next = hs2; //setting a reference inside an object to another instance of the same class!
		hs2.prev = hs1; //setting a reference inside an object to another instance of the same class!
		hs2.next = hs3; //setting a reference inside an object to another instance of the same class!
		hs3.prev = hs2; //setting a reference inside an object to another instance of the same class!

		HighScore current = hs1; //making a new reference to an  object that already exists

		print(current.name);
		current = current.next;	//swith the reference to another object
		print(current.name);
		current = current.next; //swith the reference to another object
		print(current.name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
