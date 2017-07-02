using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Manages the door that clocks the fnial level in the Hub LEvel of the game
 */ 
public class FinalRoomDoor : MonoBehaviour {
	
	public GameObject doorOne;
	private Vector3 doorOneStartingPosition, doorOneOpenPosition;
	private bool doorOpened;

	// Use this for initialization
	void Start () {
		doorOpened = false;
		doorOneStartingPosition = doorOne.transform.position; //The starting position of the door in the scene
		doorOneOpenPosition = new Vector3 (doorOne.transform.position.x, doorOne.transform.position.y + 10.0f, 
			doorOne.transform.position.z);	
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalController.Instance.scientistCount >= 7) {
			openDoor ();
		}
	}
	/// Opens the door if the player has enough scientsts
	void openDoor(){
		doorOne.transform.position = doorOneOpenPosition;
		doorOpened = true;
	}

}
