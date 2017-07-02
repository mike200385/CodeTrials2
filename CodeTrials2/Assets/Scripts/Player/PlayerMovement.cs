using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	/// how fast the player moves 
	public float moveSpeed;
	/// how high player jumps
	public float jumpSpeed; 
	/// know if player is on ground
	public bool isGrounded;
	/// know if player is jumping
	public bool isJumping;
	/// Is the player facing left or not
	public bool leftFacing = false;
	/// Can the player jump twice or not
	public bool canDoubleJump = false;
	/// Does the player run faster or not
	public bool canSpeedUp;
	/// Test to see if I can get bombs working.
	public GameObject bomb;
	/// Timer for the use of bombs
	public bombLogic timer;
	public float startTime, elapsedTime;

	///variables for checking if player is on ground or not
	public Transform groundCheck;
	/// radius of ground check space
	public float groundCheckRadius; 
	public LayerMask whatIsGround;
	/// rigid body used for moving and jumping
	private Rigidbody2D myRigidBody; 
	/// flag for using Camera ZoomIn/Out functions.
	public bool zoom = false; 

	private Animator anim;
	public Camera cam;

	public GlobalController gameManager;
	public RespawnController respawnManager;

///Animation States 
	const int STATE_IDLE = 0;
	const int STATE_RIGHT = 1;
	const int STATE_LEFT = 2;
	const int STATE_JUMP = 3;
	int currentAnimState = STATE_IDLE;


	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> (); // rigid body for physics
		anim = GetComponent<Animator> ();
		canSpeedUp = false;
	}
		
	// Update is called once per frame
	void Update () {
		isGrounded = Physics2D.OverlapCircle (groundCheck.position,groundCheckRadius,whatIsGround);
		myRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;

		///if player collected speed up power up
		if (GlobalController.Instance.hasSpeedUp) {
			moveSpeed = 12.0f;
		}

		//Horizontal input is either 0(no input), 1(going right), or -1(going left)

		//checking RIGHT input
		if (Input.GetAxisRaw ("Horizontal") > 0f) {         //don't change y value
			myRigidBody.velocity = new Vector3 (moveSpeed, myRigidBody.velocity.y, 0f);	
			transform.localScale = new Vector3 (4f, 4f, 1f); // 2 b/c that's the sprites scale
			changeState(STATE_RIGHT);
			leftFacing = false;
		} 

		//Checking LEFT input
		else if (Input.GetAxisRaw ("Horizontal") < 0f) {
			myRigidBody.velocity = new Vector3 (-moveSpeed, myRigidBody.velocity.y, 0f);
			transform.localScale = new Vector3 (-4f, 4f, 1f);
			changeState (STATE_LEFT);
			leftFacing = true;
		} 
			
		//NO INPUT
		else {
			myRigidBody.velocity = new Vector3 (0f, myRigidBody.velocity.y, 0f);
			changeState(STATE_IDLE);
		}
			
		// checking jump input(space or up)
		if (Input.GetButtonDown ("Jump")){
			if(isGrounded){
				// put jumpSpeed in y to move up by moveSpeed
				anim.SetBool ("Jumping", true);
				myRigidBody.velocity = new Vector3 (myRigidBody.velocity.x, jumpSpeed, 0f);
				isJumping = true;
				changeState (STATE_JUMP);
				canDoubleJump = true;
			}else{
				if(canDoubleJump && GlobalController.Instance.hasDoubleJump){
					canDoubleJump = false;
					myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpSpeed, 0f);
					anim.SetBool ("DoubleJump", true);
				}
			}
		}
		// if on the ground, set falling and jumping to false
		if(isGrounded){ 
			anim.SetBool ("Jumping", false);
			anim.SetBool ("DoubleJump", false);
			isJumping = false;
		}
		//allows player to zoom out the camera to see larger section of the map.
		if (Input.GetKeyDown ("q")) {
			if (!zoom) {
				zoomOut ();
				zoom = true;
			} else {
				zoomIn ();
				zoom = false;
			}
		}
			

		//Sets variables in order to change animations
		anim.SetFloat("Speed", Mathf.Abs(myRigidBody.velocity.x));
		anim.SetBool ("Grounded", isGrounded);

		elapsedTime = Time.time - startTime;

		if (Input.GetMouseButtonDown (0) && GlobalController.Instance.onMainCam && elapsedTime > 2.0f){
			if (GlobalController.Instance.hasBombs) {
				timer.resetTime ();
				resetBombUseTimer ();
				if (!leftFacing) {
					Instantiate (bomb, new Vector3 (this.transform.position.x + 2f, 
						this.transform.position.y - .75f, this.transform.position.z), Quaternion.identity);
				} else if (leftFacing) {
					Instantiate (bomb, new Vector3 (this.transform.position.x - 2f, 
						this.transform.position.y - .75f, this.transform.position.z), Quaternion.identity);
				}
			}
		}
			

	}
	///Function to change animation state controllers. 
		void changeState(int state){
			if (currentAnimState == state) {
				return;
			}
			switch (state) {

				case STATE_RIGHT:
					anim.SetInteger ("state", STATE_RIGHT);
					break;

				case STATE_LEFT:
					anim.SetInteger ("state", STATE_LEFT);
					break;

				case STATE_IDLE:
					anim.SetInteger ("state", STATE_IDLE);
					break;
				
				case STATE_JUMP:
					anim.SetInteger ("state", STATE_JUMP);
					break;
			}

		currentAnimState = state;
	}

	///Changes Camera.cam ortho size on toggle mapped to "Q" key.
	public void zoomOut(){
		cam.orthographicSize = 16.0f;
	}
	///Changes Camera.cam ortho size on toggle mapped to "Q" key.
	public void zoomIn(){
		cam.orthographicSize = 7;
	}
	/// Sets the camera size to the value of the argument
	public void setCamSize(float newCamSize){
		cam.orthographicSize = newCamSize; //specific to final level
	}
	/// Togles camera so player can see platforms in array scene
	public void goToArrPlatforms(){
		Camera tempcam = GameObject.Find ("ArrayPlatformCamera").GetComponent<Camera>();
		GlobalController.Instance.changeSecondCamera (tempcam);
		GlobalController.Instance.toggleCamera ();

	}
			
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag("ArrayLevel")) {
			// if(Switch is set to correct door, then telepirt player to that level
			GlobalController.Instance.savePlayerPos();
			//GlobalController.Instance.changeScene ("ArrayLevel");
		}

		if (other.gameObject.CompareTag("RisingPlatform")) {
			//transform.parent = other.transform; // stop making the platform a parent
		}
		if (other.gameObject.CompareTag("EscapePod")) {
			//transform.parent = other.transform; // stop making the platform a parent
		}

	}

	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.CompareTag("RisingPlatform")) {
			//transform.parent = null; // stop making the platform a parent
		}
		if (other.gameObject.CompareTag("EscapePod")) {
			transform.parent = null; // stop making the platform a parent
		}
	}

	void resetBombUseTimer(){
		startTime = Time.time;
	}
		
}