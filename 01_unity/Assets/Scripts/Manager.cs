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
	[HideInInspector] public bool isPaused = true;

	public SeaLevel seaLevel;
	public UIWidgetsSamples.ListViewVariableHeight newsTicker;

    public GameObject Deutschland;
    public GameObject Indien;
    public GameObject USA;
    public GameObject Russland;
    public GameObject Brasilien;
    public GameObject China;
    public GameObject Australien;
    public GameObject Aegypten;

    int cloneCounter = 1950;


    // Use this for initialization
    void Start ()
    {
    	newsTicker.startYear = year;
        StartCoroutine(YearLoop());
		MoveBalls(year);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			isPaused = !isPaused;
		}
	}

	public void IncreaseYear () {
		if (year < 2017) {
			year++;
			UpdateScene();
		} 
	}

	public void DecreaseYear () {
		if (year > 1950) {
			year--;
			UpdateScene();
		} 
	}

	public void UpdateScene () {
	    seaLevel.WaterLevel(year,yearInSec);
		if (year < 2014) MoveBalls(year);
		newsTicker.OnYearChange(year);
		//Debug.Log(year);
	}

    IEnumerator YearLoop ()
    {
        while (year < 2017)
        {
            yield return new WaitForSeconds(yearInSec);
            while (isPaused) yield return new WaitForSeconds(0.5f);
            IncreaseYear();
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

        cloneSpheres(0.05f);
        

    }

    void cloneSpheres(float alpha)
    {
        //clone if not cloned before
        if (cloneCounter <= year)
        {
            GameObject cloneDeutschland = Instantiate(Deutschland);
            Color colorDeutschland = cloneDeutschland.GetComponent<Renderer>().material.color;
            colorDeutschland.a = alpha;
            cloneDeutschland.GetComponent<Renderer>().material.color = colorDeutschland;
            cloneDeutschland.transform.position = Deutschland.transform.position;

            GameObject cloneUSA = Instantiate(USA);
            Color colorUSA = cloneUSA.GetComponent<Renderer>().material.color;
            colorUSA.a = alpha;
            cloneUSA.GetComponent<Renderer>().material.color = colorUSA;
            cloneUSA.transform.position = USA.transform.position;

            GameObject cloneIndien = Instantiate(Indien);
            Color colorIndien = cloneIndien.GetComponent<Renderer>().material.color;
            colorIndien.a = alpha;
            cloneIndien.GetComponent<Renderer>().material.color = colorIndien;
            cloneIndien.transform.position = Indien.transform.position;

            GameObject cloneRussland = Instantiate(Russland);
            Color colorRussland = cloneRussland.GetComponent<Renderer>().material.color;
            colorRussland.a = alpha;
            cloneRussland.GetComponent<Renderer>().material.color = colorRussland;
            cloneRussland.transform.position = Russland.transform.position;

            GameObject cloneBrasilien = Instantiate(Brasilien);
            Color colorBrasilien = cloneRussland.GetComponent<Renderer>().material.color;
            colorBrasilien.a = alpha;
            cloneBrasilien.GetComponent<Renderer>().material.color = colorBrasilien;
            cloneBrasilien.transform.position = Brasilien.transform.position;

            GameObject cloneAustralien = Instantiate(Australien);
            Color colorAustralien = cloneAustralien.GetComponent<Renderer>().material.color;
            colorAustralien.a = alpha;
            cloneAustralien.GetComponent<Renderer>().material.color = colorAustralien;
            cloneAustralien.transform.position = Australien.transform.position;

            GameObject cloneAegypten = Instantiate(Aegypten);
            Color colorAegypten = cloneAegypten.GetComponent<Renderer>().material.color;
            colorAegypten.a = alpha;
            cloneAegypten.GetComponent<Renderer>().material.color = colorAegypten;
            cloneAegypten.transform.position = Aegypten.transform.position;

            GameObject cloneChina = Instantiate(China);
            Color colorChina = cloneChina.GetComponent<Renderer>().material.color;
            colorChina.a = alpha;
            cloneChina.GetComponent<Renderer>().material.color = colorChina;
            cloneChina.transform.position = China.transform.position;

            cloneCounter++;
        }
    }
}
