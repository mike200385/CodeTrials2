using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Controls the platforms in the array level's first challenge
 */ 
public class PlatformAccessController : MonoBehaviour {
	///whether or not it should be visible
	public bool isVisible; 
	/// box collider for this object
	public BoxCollider2D bCol;
	/// sprite used to control color of obj
	public SpriteRenderer spr;
	// used for the number on the platform
	public SpriteRenderer indexNumSpr; 

	// Use this for initialization
	void Start () {
		//temp color
		Color tempColor = new Color(255,255,255,0.5f);

		isVisible = false;
		bCol = GetComponent<BoxCollider2D> ();
		spr = GetComponent<SpriteRenderer> ();

		//set collider to inactive and sprite to low alpha(transparent)
		bCol.enabled = false;
		spr.color = tempColor;
		indexNumSpr.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	///enables box collider2d, and makes obj visible
	public void SetVisibleAndActive(){
		//temp color
		Color tempColor = new Color(255,255,255,1f);

		bCol.enabled = true; 
		spr.color = tempColor;
		indexNumSpr.enabled = true;
	}
	///disables box collider2d, and makes obj invisible
	public void SetInvisibleAndInactive(){
		//temp color
		Color tempColor = new Color(255,255,255,0.5f);

		bCol.enabled = false; 
		spr.color = tempColor;
		indexNumSpr.enabled = false;
	}

}
