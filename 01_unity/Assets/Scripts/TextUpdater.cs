using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour {

	[Range(0,7)]public int id; //0=de,1=ind,2=us,3=rus,4=bras,5=chi,6=aus,7=agyp
	public string name;
	private Manager manager;
	private Text info;

	void Awake () {
		manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
		info = GetComponent<Text>();
	}

	private void OnNewData (int country, float emiss, float temp) {
		if (id != country) return;
		info.text = name + "\n<size=75>Emission: "+emiss+" Megatonnen"+"\nTemperatur: "+temp+"°C</size>";
	}

	void OnEnable () {
		manager.NewData += OnNewData;
	}

	void OnDisable () {
		manager.NewData -= OnNewData;
	}
}
