using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TastaturEingaben : MonoBehaviour {

    public GameObject managerObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("pause");
            //stop coroutines
            managerObject.SendMessage("stopCounter");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("forward");
            //startCoroutine raufzählen
            managerObject.SendMessage("IncreaseYear");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("backward");
            //startCoroutine runterzählen
            managerObject.SendMessage("DecreaseYear");
        }

    }
}
