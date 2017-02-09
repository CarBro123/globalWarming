using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void moveThis(int year, float emissions, float temperature)
    {
        this.transform.position = new Vector3(-emissions/5000+0.6f, temperature/10-0.092f, -2);
    }
}
