using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Checks the respective challenge and makes changes to the game if the user is correct or not
 * Challenge: Final challenge 2
 */ 
public class FinalPuzzleCompletionCheck : MonoBehaviour {

	// LEVEL MANAGER FOR THE ARRAY LEVEL

	///manually set in inspector, slots to be filled by tiles
	public GameObject[] checkSlots; 
	/// the tiles that will be dragged
	public GameObject[] arrayTiles; 
	/// <summary>
	/// The replacement tiles that go into the slots
	/// </summary>
	public GameObject[] replacementTiles;
	/// error message for the canvas
	public Text errorMessage;  
	public bool puzzleFinished, camToggled, scoreChanged;
	// Use this for initialization
	void Start () {
		arrayTiles = GameObject.FindGameObjectsWithTag ("ArrayTile");
		puzzleFinished = false;
		camToggled = false;
		scoreChanged = false;
		errorMessage.enabled = false;
	}
	//
	// Update is called once per frame
	void Update () {
		//MANUAL FIX TO TOGGLE ON FINAL PROBLEM -- WORKAROUND
		if(GlobalController.Instance.finalComplete){ 
			GlobalController.Instance.toggleCamera ();
			//GlobalController.Instance.finalComplete = false;
		}


		/**
		//if all 5 spots are filled and is correct
		*/
		if (checkInputName () && checkInputSuccess ()) {
			if (!camToggled) {
				Debug.Log("No Cam toggled");
				GlobalController.Instance.finalComplete = true;
				//GlobalController.Instance.toggleCamera ();
				camToggled = true;
				//activate the elevator
				activateElevator();
				puzzleFinished = true;

				//add to score
				if (!scoreChanged) {
					GlobalController.Instance.incScore ();
					scoreChanged = true;
				}
			}

		} else if (checkInputSuccess()) { // if input is done, but is incorrct
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
		resetCheckValues ();
		camToggled = false;
		puzzleFinished = false;
		errorMessage.enabled = false;
		//lower additive
		GlobalController.Instance.decAdditive ();
		GlobalController.Instance.finalComplete = false;
	}

	public void resetCheckValues(){
		foreach (GameObject slot in checkSlots) {
			slot.GetComponent<ArrayReaction>().resetSuccessBool ();
		}
	}

	public void activateElevator(){
		GameObject temp = GameObject.FindGameObjectWithTag ("RisingPlatform");
		temp.GetComponent<MovingObject> ().enabled = true;
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
		if (checkSlots [0].GetComponent<ArrayReaction>().giveName == "Replacement-" &&
			checkSlots [1].GetComponent<ArrayReaction>().giveName == "Replacement-" &&
			checkSlots [2].GetComponent<ArrayReaction>().giveName == "ReplacementX" &&
			checkSlots [3].GetComponent<ArrayReaction>().giveName == "ReplacementMOD" &&
			checkSlots [4].GetComponent<ArrayReaction>().giveName == "ReplacementX") 
		{
			return true;
		}
		return false;
	}
		

}


