﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        this.GetComponentInChildren<TextMesh>().text = this.GetComponent<Manager>().year.ToString() ;
	}
	
	// Update is called once per frame
	void Update () {

        this.GetComponentInChildren<TextMesh>().text = this.GetComponent<Manager>().year.ToString();
    }
}
