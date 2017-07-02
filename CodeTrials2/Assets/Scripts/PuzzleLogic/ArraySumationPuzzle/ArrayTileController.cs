using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Manages the array Tiles
 * Stores the tiles name,connected box(array level)
 * Stores connected platform(array level)
 */ 
public class ArrayTileController : MonoBehaviour {

	public string tileName;
	public ArrayBoxController connectedBox; //used for sum puzzle
	public PlatformAccessController connectedPlatform; //used for access puzzle

	public bool isUsed;

	// Use this for initialization
	void Start () {
		isUsed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void resetUsed(){
		isUsed = false;
	}

}
