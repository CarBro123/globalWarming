﻿using UnityEngine;
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
	[HideInInspector] public bool isPaused = true;

	public SeaLevel seaLevel;
	public UIWidgetsSamples.ListViewVariableHeight newsTicker;

	public delegate void DataHandler(int id, float emission, float temp);
	public event DataHandler NewData;
    public GameObject Deutschland;
    public GameObject Indien;
    public GameObject USA;
    public GameObject Russland;
    public GameObject Brasilien;
    public GameObject China;
    public GameObject Australien;
    public GameObject Aegypten;
    
    public AudioClip Einleitung;
    public AudioClip Erklaerung;
    public AudioClip Schluss;

    private Boolean endAlreadyPlayed = false;

    int cloneCounter = 1950;

    void Awake () {
		MoveBalls(year);
    }

    // Use this for initialization
    void Start ()
    {
    	newsTicker.startYear = year;
        StartCoroutine(YearLoop());
		GetComponent<AudioSource>().PlayOneShot(Einleitung);
		Invoke("PlayAudio", Einleitung.length);
	}

    void PlayAudio()
    {
        GetComponent<AudioSource>().PlayOneShot(Erklaerung);
    }

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			isPaused = !isPaused;
		}
	}

	public void IncreaseYear () {
		if (year < 2017) {
			StopAllCoroutines();
			StartCoroutine(YearLoop());
			year++;
			UpdateScene();
		} 
	}

	public void DecreaseYear () {
		if (year > 1950) {
			StopAllCoroutines();
			StartCoroutine(YearLoop());
			year--;
			UpdateScene();
		} 
	}

	public void UpdateScene () {
	    seaLevel.WaterLevel(year,yearInSec);
		if (year < 2014) MoveBalls(year);
		if (year < 2017) newsTicker.OnYearChange(year);
        if (year == 2017 && !endAlreadyPlayed) {
            this.GetComponent<AudioSource>().PlayOneShot(Schluss);
            endAlreadyPlayed = true;
        }
        //Debug.Log(year);
    }

    IEnumerator YearLoop ()
    {
        while (true)
        {
            yield return new WaitForSeconds(yearInSec);
            while (isPaused) yield return new WaitForSeconds(0.5f);
            if (year < 2017) {
				year++;
            	UpdateScene();
            }
        }
    }


    void MoveBalls(int year)
    {
        float deutschlandEmissionen = float.Parse(EmissionsByCountry.Find_Total_By_Year_Country(year.ToString(), "Germany").Total);
        float deutschlandTemperatur = float.Parse(TemperaturesByCountry.Find_Temperature_By_Year_Country(year + "-08-01", "Germany").AverageTemperature);
        Deutschland.GetComponent<Ball>().moveThis(year, deutschlandEmissionen, deutschlandTemperatur);


        float indienEmissionen = float.Parse(EmissionsByCountry.Find_Total_By_Year_Country(year.ToString(), "India").Total);
        float indienTemperatur = float.Parse(TemperaturesByCountry.Find_Temperature_By_Year_Country(year + "-08-01", "India").AverageTemperature);
        Indien.GetComponent<Ball>().moveThis(year, indienEmissionen, indienTemperatur);

        float usaEmissionen = float.Parse(EmissionsByCountry.Find_Total_By_Year_Country(year.ToString(), "United States").Total);
        float usaTemperatur = float.Parse(TemperaturesByCountry.Find_Temperature_By_Year_Country(year + "-08-01", "United States").AverageTemperature);
        USA.GetComponent<Ball>().moveThis(year, usaEmissionen, usaTemperatur);

        float russlandEmissionen = float.Parse(EmissionsByCountry.Find_Total_By_Year_Country(year.ToString(), "Russian Federation").Total);
        float russlandTemperatur = float.Parse(TemperaturesByCountry.Find_Temperature_By_Year_Country(year + "-08-01", "Russia").AverageTemperature);
        Russland.GetComponent<Ball>().moveThis(year, russlandEmissionen, russlandTemperatur);

        float brasilienEmissionen = float.Parse(EmissionsByCountry.Find_Total_By_Year_Country(year.ToString(), "Brazil").Total);
        float brasilienTemperatur = float.Parse(TemperaturesByCountry.Find_Temperature_By_Year_Country(year + "-08-01", "Brazil").AverageTemperature);
        Brasilien.GetComponent<Ball>().moveThis(year, brasilienEmissionen, brasilienTemperatur);

        float chinaEmissionen = float.Parse(EmissionsByCountry.Find_Total_By_Year_Country(year.ToString(), "China").Total);
        float chinaTemperatur = float.Parse(TemperaturesByCountry.Find_Temperature_By_Year_Country(year + "-08-01", "China").AverageTemperature);
        China.GetComponent<Ball>().moveThis(year, chinaEmissionen, chinaTemperatur);

        float australienEmissionen = float.Parse(EmissionsByCountry.Find_Total_By_Year_Country(year.ToString(), "Australia").Total);
        float australienTemperatur = float.Parse(TemperaturesByCountry.Find_Temperature_By_Year_Country(year + "-08-01", "Australia").AverageTemperature);
        Australien.GetComponent<Ball>().moveThis(year, australienEmissionen, australienTemperatur);

        float aegyptenEmissionen = float.Parse(EmissionsByCountry.Find_Total_By_Year_Country(year.ToString(), "Egypt").Total);
        float aegyptenTemperatur = float.Parse(TemperaturesByCountry.Find_Temperature_By_Year_Country(year + "-08-01", "Egypt").AverageTemperature);
        Aegypten.GetComponent<Ball>().moveThis(year, aegyptenEmissionen, aegyptenTemperatur);

		if (NewData != null) {
        	NewData(0, deutschlandEmissionen, deutschlandTemperatur);
        	NewData(1, indienEmissionen, indienTemperatur);
        	NewData(2, usaEmissionen, usaTemperatur);
        	NewData(3, russlandEmissionen, russlandTemperatur);
        	NewData(4, brasilienEmissionen, brasilienTemperatur);
        	NewData(5, chinaEmissionen, chinaTemperatur);
        	NewData(6, australienEmissionen, australienTemperatur);
        	NewData(7, aegyptenEmissionen, aegyptenTemperatur);
        }

    }

}
