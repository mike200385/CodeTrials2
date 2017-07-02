﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToConditionalLevel : MonoBehaviour {

	//public Text prompt; //text to display
	private bool inArea = false;
	public Text prompt; //text to display

	public Scene scene;

	// Use this for initialization
	void Start () {
		//prompt.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (inArea) {
			if (Input.GetKeyDown ("x")) {
				SceneManager.LoadScene ("ConditionalLevel");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			//show interact text
			//prompt.enabled = true;
			inArea = true;
			prompt.enabled = true;

		}
	}

	void OnTriggerExit2D(Collider2D other){
		//prompt.enabled = false;
		inArea = false;
		prompt.enabled = false;
	}
}