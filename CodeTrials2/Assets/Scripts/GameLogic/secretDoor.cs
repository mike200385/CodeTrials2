using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secretDoor : MonoBehaviour {


	public GameObject explosion;
	public int health;

	// Use this for initialization
	void Start () {
		health = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (health < 0) {
			Destroy (this.gameObject);
		}
	}
}
