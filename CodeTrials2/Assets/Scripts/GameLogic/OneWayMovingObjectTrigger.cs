using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Manages objects that are designed to move toward a goal only once
 * This script used a trigger to detect the player
 * The object only moves if the player hits the trigger
 */
public class OneWayMovingObjectTrigger : MonoBehaviour {
	
	/// reference to the player
	public PlayerMovement player;
	/// trigger for the object
	public JITScript triggerCollider;
	/// object to be moved
	public GameObject objToMove; 

	/// ending point
	public Transform endPoint; 
	/// how fast the object moves
	public float moveSpeed;
	/// the current point it's going to
	private Vector3 currentTarget;
	/// initial pos of the object
	public Vector3 initialPosition; 

	// Use this for initialization
	void Start () {
		currentTarget = endPoint.transform.position;
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//if it has been deactivated because the player touched it
		if (!triggerCollider.gameObject.activeSelf) { 
			//move the barrier
			moveObjectOneWay ();
		}
	}
	/// Responsible for moving the object
	public void moveObjectOneWay(){
		// uses move towards to let the object move towards it's goal
		if (objToMove != null) {
			objToMove.transform.position = Vector3.MoveTowards (objToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime);
		}
	}
	/// resets the position of the object
	public void resetPosition(){
		transform.position = initialPosition;
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Player") {
			//set the flag
			other.gameObject.transform.parent = this.transform;
			other.GetComponent<PlayerMovement> ().zoomOut ();
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			other.gameObject.transform.parent = null;
		}
	}
	
}
