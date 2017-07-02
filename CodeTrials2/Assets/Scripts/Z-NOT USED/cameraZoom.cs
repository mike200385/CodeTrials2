using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraZoom : MonoBehaviour {
	public Camera thisCamera;
	public bool inArea;

	// Use this for initialization
	void Start () {
		inArea = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (inArea) {
			thisCamera.orthographicSize = 12;
		} else {
			thisCamera.orthographicSize = 8;
		}
	}

	void onTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			inArea = true;
			}
	}

	void onTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			inArea = false;
		}
	}
}
