using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scientistRun : MonoBehaviour {
	public Animator anim;

	// Use this for initialization
	void Start () {
		anim.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player"){
			anim.enabled = true;
		}
	}
			
}
