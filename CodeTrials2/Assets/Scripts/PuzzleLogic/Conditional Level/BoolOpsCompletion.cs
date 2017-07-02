using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Checks the respective challenge and makes changes to the game if the user is correct or not
 * Challenge: Elevator controller in Conditional
 */ 

public class BoolOpsCompletion : MonoBehaviour {
	
	public ArrayReaction upSuccess, notUpSuccess;
	public ArrayReaction replacementTrue, replacementFalse, replacementNotUp;
	public ElevatorController floorLocation;

	public AudioSource solved;


	public bool puzzleFinished, camToggled, useElevator, goingUp, scoreChanged;

	public GameObject[] arrayTiles; // the tiles that will be dragged
	public GameObject[] replacementTiles; //The replacements when tiles dragged into the slots


	// Use this for initialization
	void Start () {
		resetPuzzle ();
		arrayTiles = GameObject.FindGameObjectsWithTag ("ArrayTile");
		puzzleFinished = false;
		camToggled = false;
		scoreChanged = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (upSuccess.success && replacementTrue.giveName == "ReplacementTrue" &&
			notUpSuccess.success && replacementNotUp.giveName == "ReplacementNotUp") {
			if (!GlobalController.Instance.boolOpsComplete && !puzzleFinished) {
				GlobalController.Instance.boolOpsComplete = true;
				useElevator = true;
				goingUp = true;
				puzzleFinished = true;
				solved.Play ();
				if (!camToggled) {
					GlobalController.Instance.toggleCamera ();
					camToggled = true;
				}
				//add to score
				if (!scoreChanged) {
					GlobalController.Instance.incScore ();
					scoreChanged = true;
				}
			}
		}
		if (upSuccess.success && replacementFalse.giveName == "ReplacementFalse" &&
			notUpSuccess.success && replacementNotUp.giveName == "ReplacementNotUp") {
			if (!GlobalController.Instance.boolOpsComplete && !puzzleFinished) {
				GlobalController.Instance.boolOpsComplete = true;
				useElevator = true;
				goingUp = false;
				puzzleFinished = true;
				solved.Play ();
				if (!camToggled) {
					GlobalController.Instance.toggleCamera ();
					camToggled = true;
				}
				//add to score
				if (!scoreChanged) {
					GlobalController.Instance.incScore ();
					scoreChanged = true;
				}
			}	
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			resetPuzzle ();
		}
	}

	public void resetCheckValues(){
		upSuccess.resetSuccessBool ();
		notUpSuccess.resetSuccessBool ();
	}

	public void resetPuzzle(){
		if (GlobalController.Instance.camName == "BoolOpsCamera") {
			
			GlobalController.Instance.boolOpsComplete = false;
			resetTiles ();
			resetSlots ();
			resetActive ();
			resetCheckValues ();
			camToggled = false;
			puzzleFinished = false;
			floorLocation.up = false;
			floorLocation.down = false;
			useElevator = false;
			goingUp = false;
		}
	}
		

	public void resetSlots(){
		replacementTiles = GameObject.FindGameObjectsWithTag ("ReplaceTile");

		foreach (GameObject repTile in replacementTiles) {
			Destroy (repTile);
		}
	}

	public void resetTiles(){
		for (int i = 0; i < arrayTiles.Length; i++) {
			arrayTiles[i].GetComponent<TileDrag>().onReset();
		}
	}

	public void resetActive(){
		for (int i = 0; i < arrayTiles.Length; i++) {
			arrayTiles[i].gameObject.SetActive(true);
		}
	}
}
