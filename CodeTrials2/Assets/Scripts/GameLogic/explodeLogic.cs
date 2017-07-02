using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodeLogic : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "secret") {
			print ("KABOOM");
			Destroy (other.gameObject);
		}
	}
}
