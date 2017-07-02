using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveName : MonoBehaviour 
{
	public string sSave;
	public Text tSave;
	public InputField saveField;
	public GlobalController gc;

	public void SetSaveName()
	{
		sSave = saveField.onValueChanged.ToString();
		PlayerPrefs.SetString("SAVENAME", sSave);
		PlayerPrefs.Save();
	}

	public void GetSaveName()
	{
		gc.userName = PlayerPrefs.GetString("SAVENAME");
	}

	void Update(){
	}
		
}
