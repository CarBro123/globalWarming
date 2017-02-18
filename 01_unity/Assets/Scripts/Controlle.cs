using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlle : MonoBehaviour {
    float emission = 0;
    float temperature = 0;
    float x;
    float y;
    Vector3 Postitiont = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        x = this.transform.position.x;

        emission = (-(x-3)*10000)/6;

        y = this.transform.position.y;

        temperature = (y)*10;


        print("Emission: "+emission+ "\n   temperature: "+temperature);

        if(temperature<30)
        {
            y = y+ 0.01f;
            this.transform.position = new Vector3(this.transform.position.x, y, -2);
        }

        //this.transform.position = new Vector3((-emissions * 6 / 10000) + 3, temperature / 10, -2);

    }
}
