using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * Checks the respective challenge and makes changes to the game if the user is correct or not
 * Challenge: Array Challenge 1
 */ 

public class ArrayAccessCompletion : MonoBehaviour {

	// LEVEL MANAGER FOR THE ARRAY LEVEL
	/// <summary>
	/// The slots that will be checked
	/// </summary>
	public ArrayReaction checkOne, checkTwo, checkThree;
	/// the tiles that will be dragged
	public GameObject[] arrayTiles; // the tiles that will be dragged
	/// <summary>
	/// The replacement tiles that go into the slots
	/// </summary>
	public GameObject[] replacementTiles;
	/// Cameras that manage the blue screen and the puzzle camera for avoiding problems
	public Camera errorCam, puzzleCam;
	public Text errorMessage;
	public bool puzzleFinished, camToggled, errorValUsed, scoreChanged;

	// Use this for initialization
	void Start () {
		arrayTiles = GameObject.FindGameObjectsWithTag ("ArrayTile");
		puzzleFinished = false;
		camToggled = false;
		errorValUsed = false;
		scoreChanged = false;
		errorMessage.enabled = false;
	}

	// Update is called once per frame
	void Update () {

		//if all 3 spots are filled
		if (checkOne.success && checkTwo.success && checkThree.success) {
			//activate the platforms
			if (!camToggled) {
				if (errorValueUsed ()) {
					puzzleCam.enabled = false; // disable puzzle cam
					errorCam.enabled = true; //show blue screen of death
					camToggled = true;
					puzzleFinished = true;
					errorValUsed = true;
					errorMessage.enabled = true;
				}
				else {
					GlobalController.Instance.toggleCamera ();
					camToggled = true;
					makePlatformsVisible ();
					puzzleFinished = true;
					//add to score
					if (!scoreChanged) {
						GlobalController.Instance.incScore ();
						scoreChanged = true;
					}

				}
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
		resetPlatforms ();
		resetCheckValues ();
		//puzzleCam.enabled = true;
		camToggled = false;
		puzzleFinished = false;
		errorValUsed = false;
		errorMessage.enabled = false;
		//lower additive
		GlobalController.Instance.decAdditive ();
	}

	public void switchToErrorScreen(){

	}

	public bool errorValueUsed(){
		//checks to see if the N array tile was placed, which will cause an out of bounds error
		if (checkOne.giveName == "ReplacementN"
		   || checkTwo.giveName == "ReplacementN"
		   || checkThree.giveName == "ReplacementN") {
			GlobalController.Instance.changeSecondCamera (errorCam);

			return true;
		}
		return false;
	}
	/**
	 * Resets the slot's success bools so they can be used again 
	*/
	public void resetCheckValues(){
		checkOne.resetSuccessBool ();
		checkTwo.resetSuccessBool ();
		checkThree.resetSuccessBool ();
	}
	/**
	 * Makes the transparent platforms visible by calling their member functions
	*/
	public void makePlatformsVisible(){
		foreach (GameObject temp in arrayTiles) {
			// if this tile was used as part of the sum
			if (temp.GetComponent<ArrayTileController> ().isUsed) { 
				//drop it's corresponding box
				temp.GetComponent<ArrayTileController>().connectedPlatform.SetVisibleAndActive();
				temp.GetComponent<ArrayTileController> ().resetUsed ();
			}

		}
		//resetCheckValues ();
	}
	///reset slots to empty
	public void resetSlots(){
		replacementTiles = GameObject.FindGameObjectsWithTag ("ReplaceTile");

		foreach (GameObject repTile in replacementTiles) {
			Destroy (repTile);
		}
	}

	/// reset tiles to active and in original position
	public void resetTiles(){
		for (int i = 0; i < arrayTiles.Length; i++) {
			//arrayTiles [i].gameObject.SetActive (false);

//			arrayTiles [i].transform.position = arrayTilePositions [i]; // move to original position
			arrayTiles[i].GetComponent<TileDrag>().onReset();
			//arrayTiles [i].GetComponent<ArrayTileController> ().resetUsed (); // change bool to false;
			// THIS LINE MESSES UP THE RESET
			//arrayTiles [i].GetComponent<BoxCollider2D>().enabled = true;
		}


	}
	/// Resets all of the tiles to be active when resetting
	public void resetActive()
	{
		for (int i = 0; i < arrayTiles.Length; i++) 
		{
			arrayTiles[i].gameObject.SetActive(true);
		}
	}
	/// Makes the platforms invisible during resetting
	public void resetPlatforms(){
		//set all platforms back to original state of being inactive
		foreach (GameObject temp in arrayTiles) {
			if (temp.GetComponent<ArrayTileController> ().connectedPlatform != null) {
				temp.GetComponent<ArrayTileController> ().connectedPlatform.SetInvisibleAndInactive ();
			}
		}
	}


}
