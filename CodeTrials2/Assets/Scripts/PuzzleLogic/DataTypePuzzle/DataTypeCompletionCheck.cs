﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * Checks the respective challenge and makes changes to the game if the user is correct or not
 * Challenge: Arith challenge 1
 */ 
public class DataTypeCompletionCheck : MonoBehaviour {

	// LEVEL MANAGER FOR THE ARRAY LEVEL

	///manually set in inspector, slots to be filled by tiles
	public GameObject[] checkSlots;
	/// the tiles that will be dragged
	public GameObject[] arrayTiles; // the tiles that will be dragged
	/// <summary>
	/// The replacement tiles that go into the slots
	/// </summary>
	public GameObject[] replacementTiles;

	public GameObject door;
	Vector3 initialDoorPosition;
	public AudioSource solved, raiseDoor;
	public Text errorMessage;
	public bool puzzleFinished, camToggled, scoreChanged;
	// Use this for initialization
	void Start () {
		//checkSlots = GameObject.FindGameObjectsWithTag ("InsertSlot");
		arrayTiles = GameObject.FindGameObjectsWithTag ("ArrayTile");
		puzzleFinished = false;
		camToggled = false;
		scoreChanged = false;
		initialDoorPosition = door.transform.position;
		errorMessage.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		//if all 3 spots are filled
		if (checkInputSuccess () && checkInputName ()) { // correct and all slots filled
			if (!camToggled) {
				GlobalController.Instance.toggleCamera ();
				camToggled = true;
				//open the door
				openDoor ();
				puzzleFinished = true;
				solved.Play ();
				//add to score
				if (!scoreChanged) {
					raiseDoor.Play ();
					raiseDoor.loop = false;
					GlobalController.Instance.incScore ();
					scoreChanged = true;
				}
			}

		} else if (checkInputSuccess ()) { // incorrect answer
			if (!camToggled) {
				GlobalController.Instance.toggleCamera ();
				camToggled = true;
				puzzleFinished = true;
				errorMessage.enabled = true;
			}
		}
		//reset puzzle and platforms
		if (Input.GetKeyDown(KeyCode.R)) {
			resetPuzzle ();
		}



	}
	/**
	 * Resets the puzzle
	 * Resets the Tiles, slots, check values, 
	 * camera flag and error message
	*/
	public void resetPuzzle(){
		//GlobalController.Instance.resetBoxBools();
		resetTiles ();
		resetSlots ();
		resetActive ();
		closeDoor ();
		resetCheckValues ();
		camToggled = false;
		puzzleFinished = false;
		errorMessage.enabled = false;
		//lower additive
		GlobalController.Instance.decAdditive ();
	}
		
	public void resetCheckValues(){
		foreach (GameObject slot in checkSlots) {
			slot.GetComponent<ArrayReaction>().resetSuccessBool ();
		}
	}

	public void openDoor(){
		door.SetActive (false);
	}
	public void closeDoor(){
		door.SetActive (true);
	}
	//reset slots to empty
	public void resetSlots(){
		replacementTiles = GameObject.FindGameObjectsWithTag ("ReplaceTile");

		foreach (GameObject repTile in replacementTiles) {
			Destroy (repTile);
		}
	}

	// reset tiles to active and in original position
	public void resetTiles(){
		for (int i = 0; i < arrayTiles.Length; i++) {
			//arrayTiles [i].gameObject.SetActive (false);
			arrayTiles[i].GetComponent<TileDrag>().onReset();
		}


	}

	public void resetActive()
	{
		for (int i = 0; i < arrayTiles.Length; i++) 
		{
			arrayTiles[i].gameObject.SetActive(true);
		}
	}

	public bool checkInputSuccess(){
		foreach (GameObject slot in checkSlots) {
			if (!slot.GetComponent<ArrayReaction>().success) {
				return false;
			}
		}
		return true;
	}

	public bool checkInputName(){
		if (checkSlots [0].GetComponent<ArrayReaction>().giveName == "ReplacementInt" &&
			checkSlots [1].GetComponent<ArrayReaction>().giveName == "ReplacementBool" &&
			checkSlots [2].GetComponent<ArrayReaction>().giveName == "ReplacementDouble" &&
			checkSlots [3].GetComponent<ArrayReaction>().giveName == "ReplacementChar") 
		{
			
			return true;
		}
		return false;
	}


}
