using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnalyticsByLevel : MonoBehaviour {

	public GoogleAnalyticsV4 googleAnalytics;
	public long noteButtonCounter, helpButtonCounter;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NotesAnalytics(){
		googleAnalytics.LogEvent (GlobalController.Instance.userName + SceneManager.GetActiveScene ().name, "User Clicked Notes", "Assist Page", noteButtonCounter);
		googleAnalytics.LogEvent (new EventHitBuilder ()
			.SetEventCategory (GlobalController.Instance.userName + SceneManager.GetActiveScene ().name)
			.SetEventAction ("User Clicked Notes")
			.SetEventLabel ("Assist Page")
			.SetEventValue (noteButtonCounter));
	}

	public void HelpButtonAnalytics(){
		googleAnalytics.LogEvent (GlobalController.Instance.userName + GlobalController.Instance.camName, "User Hovered Over Help", "HelpButton", helpButtonCounter);
		googleAnalytics.LogEvent (new EventHitBuilder ()
			.SetEventCategory (GlobalController.Instance.userName + GlobalController.Instance.camName)
			.SetEventAction ("User Hovered Over Help")
			.SetEventLabel ("Assist Page")
			.SetEventValue (helpButtonCounter));
	}
		
}
