using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetButton : MonoBehaviour {

	public BoolOpsCompletion boolOpsPuzzle;
	public LogicalAndCompletion logAndPuzzle;
	public LogicalOrCompletion logOrPuzzle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClick(){
		switch (GlobalController.Instance.camName) {
		case "BoolOpsCamera":
			boolOpsPuzzle.resetPuzzle ();
			break;
		case "LogicalAndCamera":
			logOrPuzzle.resetPuzzle ();
			break;
		case "LogicalOrCamera":
			logAndPuzzle.resetPuzzle ();
			break;
		}
	}		
}
