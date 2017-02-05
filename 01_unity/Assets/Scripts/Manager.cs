using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

	[Range(1950,2017)]
	public int year = 1950;
    int alreadyUpdated;
	public int yearInSec = 5;

	public GameObject SeaLevel;

    public GameObject Deutschland;
    public GameObject Indien;
    public GameObject USA;
    public GameObject Russland;
    public GameObject Brasilien;
    public GameObject China;
    public GameObject Australien;
    public GameObject Aegypten;


    // Use this for initialization
    void Start () {
        StartCoroutine("YearCount");
	}
	
	// Update is called once per frame
	void Update () {
        if(year == 1950 | year != alreadyUpdated)
        {
            SeaLevel.GetComponent<SeaLevel>().WaterLevel(year,yearInSec);

            alreadyUpdated = year;
        }

	}

    IEnumerator YearCount()
    {
        while (year < 2017)
        {
            yield return new WaitForSeconds(yearInSec);
            year++;
            Debug.Log(year);
        }
    }
}
