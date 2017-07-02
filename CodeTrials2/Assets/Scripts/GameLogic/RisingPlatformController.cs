using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RisingPlatformController : MonoBehaviour {

	public GameObject risingPlatform;
	/// number so that 14 increments makes the platform the correct height
	public float unit; 
	/// text showing weight on platform
	public Text weightText;
	/// total weight so far
	public float sumWeight;
	/// used to change color based on weight
	public SpriteRenderer[] sprites;
	/// used for placing the player when test is failed
	public GameObject desktop; 
	/// Wall to stop player from cheating and jumping across with powerups
	public GameObject invisibleWall;
	Vector3 initialPosition;
	public bool scoreChanged;

	// Use this for initialization
	void Start () {
		unit = 0.35f;
		weightText.enabled = false;
		sumWeight = 0;
		sprites = GetComponentsInChildren<SpriteRenderer> ();
		initialPosition = this.transform.position;
		scoreChanged = false;
		//set color to red for heat
		foreach (SpriteRenderer spr in sprites) {
			spr.color = Color.red;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	///increase platform height
	void platformUp(int boxWeight){
		float adjust = unit * boxWeight;
		transform.position = new Vector3 (transform.position.x, transform.position.y+adjust, 0); // move water upward
	}
	///decrease platform height
	void platformDown(int boxWeight){
		float adjust = unit * boxWeight;
		transform.position = new Vector3 (transform.position.x, transform.position.y-adjust, 0); // move water downward

	}

	void OnCollisionEnter2D(Collision2D other){
		//enable the text the first time
		weightText.enabled = true;
		if (other.gameObject.CompareTag("ArrayBox")) {
			//print ("Collision detected");
			int wght = other.gameObject.GetComponent<ArrayBoxController> ().getWeight ();
			sumWeight += wght; // increase sum
			//change text
			weightText.text = "Weight Needed: 14 \nCurrent Weight: " + sumWeight; // change weight
			//move platform up specified amount
			platformUp (wght);

			//check the weight and adjust color if needed
			checkWeightColor ();
		}

		if (other.gameObject.CompareTag ("Player")) {
			if (sumWeight != 14) {
				other.gameObject.transform.position = desktop.transform.position;
			}
		}


	}
	///change color based on the weight
	public void checkWeightColor(){
		if (sumWeight == 14) {
			foreach (SpriteRenderer spr in sprites) {
				spr.color = Color.white;
			}
			//add to score
			if (!scoreChanged) {
				GlobalController.Instance.incScore ();
				scoreChanged = true;
			}

			//disable invisible wall collider
			invisibleWall.GetComponent<BoxCollider2D>().enabled = false;
		}
	}
	/// Resets the position of the platform changes the color and resets the weight
	public void resetPlatformTotally (){
		this.transform.position = initialPosition;
		foreach (SpriteRenderer spr in sprites) {
			spr.color = Color.red;
		}
		sumWeight = 0;
		weightText.text = "Weight Needed: 14 \nCurrent Weight: " + sumWeight; // change weight
		invisibleWall.GetComponent<BoxCollider2D>().enabled = true;
	}



}
