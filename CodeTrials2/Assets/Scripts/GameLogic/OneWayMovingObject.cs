using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Manages objects that are designed to move toward a goal only once
 */
public class OneWayMovingObject : MonoBehaviour {

	public GameObject objToMove; // object to be moved

	/// point that object will move towards
	public Transform endPoint; 
	/// how fast the object moves
	public float moveSpeed; 
	/// the current point it's going to
	private Vector3 currentTarget;
	/// initial pos of the object
	public Vector3 initialPosition; 
	/// is obj at final position
	public bool finishedMoving; 

	// Use this for initialization
	void Start () {
		currentTarget = endPoint.transform.position;
		initialPosition = transform.position;
		finishedMoving = false;
	}

	// Update is called once per frame
	void Update () {
		// uses move towards to let the object move towards it's goal on a one way trip.
		if (objToMove != null) {
			objToMove.transform.position = Vector3.MoveTowards (objToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime);
		}

		if (objToMove.transform.position.Equals (currentTarget)) {
			finishedMoving = true;
		}
	}
	/// Checks to see if the object is done moving
	public bool isFinishedMoving(){
		if (finishedMoving) {
			return true;
		} 
		return false;
	}
		

}
