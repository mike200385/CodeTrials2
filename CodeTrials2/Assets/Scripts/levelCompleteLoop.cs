using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelCompleteLoop : MonoBehaviour {

	public GameObject[] levelCompleteRemove;

	// Use this for initialization
	void Start () {
		if (GlobalController.Instance.loopComplete) {
			for (int i = 0; i < levelCompleteRemove.Length; i++) {
				levelCompleteRemove [i].SetActive (false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
