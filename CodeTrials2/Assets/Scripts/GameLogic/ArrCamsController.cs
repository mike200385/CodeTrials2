using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/**
 * Allows the player to toggle between camera that show the platforms or boxes in the array level
 */ 
public class ArrCamsController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//SPECIFIFC TO ARRAY LEVEL
		if (SceneManager.GetActiveScene ().name.Equals("ArrayLevel")) {
			//ACCES CAMERA
			if (Input.GetKeyDown (KeyCode.C)) {
				Camera arrCam = GameObject.Find ("ArrayPlatformCamera").GetComponent<Camera> ();
				GlobalController.Instance.changeSecondCamera (arrCam);
				GlobalController.Instance.toggleCamera ();
			}
			//SUMMATION CAMERA
			if (Input.GetKeyDown (KeyCode.V)) {
				Camera arrSumCam = GameObject.Find ("ArraySumCamera").GetComponent<Camera> ();
				GlobalController.Instance.changeSecondCamera (arrSumCam);
				GlobalController.Instance.toggleCamera ();
			}
		}
		
	}




}
