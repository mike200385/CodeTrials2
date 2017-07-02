using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeScientists : MonoBehaviour {


	public GameObject loopScientists, arithScientists, condScientists, arrayScientists;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (GlobalController.Instance.loopComplete) {
			loopScientists.gameObject.SetActive (false);
		}

		if (GlobalController.Instance.arithComplete) {
			arithScientists.gameObject.SetActive (false);
		}

		if (GlobalController.Instance.condComplete) {
			condScientists.gameObject.SetActive (false);
		}

		if (GlobalController.Instance.arrayComplete) {
			arrayScientists.gameObject.SetActive (false);
		}
	}
}
