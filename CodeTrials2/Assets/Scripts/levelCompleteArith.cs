using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelCompleteArith : MonoBehaviour {

	public GameObject[] levelCompleteRemove;

	// Use this for initialization
	void Start () {
		if (GlobalController.Instance.arithComplete) {
			for (int i = 0; i < levelCompleteRemove.Length; i++) {
				levelCompleteRemove [i].SetActive (false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
