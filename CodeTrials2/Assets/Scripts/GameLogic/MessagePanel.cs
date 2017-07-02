
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/**
 * Manages the display for text and breifings.
 */ 
public class MessagePanel : MonoBehaviour {
	public Text WordDisplay;
	public GameObject button;

	// Use this for initialization
	void Start () {
		this.GetComponent<SpriteRenderer>().enabled = false;
		button.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		// if the text is not empty then it should be shown
		if (!string.IsNullOrEmpty (WordDisplay.text.ToString ().Trim ())) {
			this.GetComponent<SpriteRenderer>().enabled = true;
			button.SetActive(true);
		}  else {
			// otherwise it will disappear until it is filled again
			this.GetComponent<SpriteRenderer>().enabled = false;
			button.SetActive(false);
		}
	}
}