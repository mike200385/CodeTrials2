using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Manages the submit button in the final level's indent challenge
 */ 
public class submitButton : MonoBehaviour {

	public InsertPuzzleCompletion complete;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void submitClick(){
		if (complete.puzzleFinished) {
			if (!complete.camToggled) {
				GlobalController.Instance.toggleCamera ();
				complete.camToggled = true;
			}
			if (!complete.doorOpened) {
				complete.openDoor ();
			}

			GlobalController.Instance.indentComplete = true;
			if (!complete.scoreChanged) {
				GlobalController.Instance.incScore ();
				complete.scoreChanged = true;
			}
		}
	}
}
