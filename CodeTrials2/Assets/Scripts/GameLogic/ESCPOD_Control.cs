using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Controls the walls on the escape pod so thet the player doesn't fall tot heir doom
 * 
*/
public class ESCPOD_Control : MonoBehaviour {

	public GameObject wall1, wall2, wall3, wall4;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			wall1.SetActive (true);
			wall2.SetActive (true);
		}

	}
}


