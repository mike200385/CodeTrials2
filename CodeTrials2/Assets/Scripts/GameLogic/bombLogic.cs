using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombLogic : MonoBehaviour {

	public float startTime, elapsedTime;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime = Time.time - startTime;
		if (elapsedTime > 2.0f) {
			Destroy (this.gameObject);
			explode ();
			resetTime ();
		}
	}

	public void resetTime(){
		startTime = Time.time;
	}

	void explode(){
		GameObject clone = (GameObject)Instantiate (explosion, this.transform.position, Quaternion.identity);
		Destroy (clone, 4.0f);
	}
		
}
