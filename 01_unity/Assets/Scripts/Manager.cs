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
	public UIWidgetsSamples.ListViewVariableHeight newsTicker;

    public GameObject Deutschland;
    public GameObject Indien;
    public GameObject USA;
    public GameObject Russland;
    public GameObject Brasilien;
    public GameObject China;
    public GameObject Australien;
    public GameObject Aegypten;


    // Use this for initialization
    void Start ()
    {
    	newsTicker.startYear = year;
        StartCoroutine("YearCount");
	}
	
	// Update is called once per frame
	void Update () {
        if(year != alreadyUpdated | year == 1950)
        {
            SeaLevel.GetComponent<SeaLevel>().WaterLevel(year,yearInSec);
            MoveBalls(year);
            alreadyUpdated = year;
        }

	}

    IEnumerator YearCount()
    {
        while (year < 2017)
        {
            yield return new WaitForSeconds(yearInSec);
            year++;
            newsTicker.OnYearChange(year);
            Debug.Log(year);
        }
    }

    IEnumerator YearCountDown()
    {
        while (year > 1950)
        {
            yield return new WaitForSeconds(yearInSec);
            year--;
            Debug.Log(year);
        }
    }

    public void raufzaehlen()
    {
        stopCounter();
        StartCoroutine("YearCount");
    }

    public void runterzaehlen()
    {
        stopCounter();
        StartCoroutine("YearCountDown");
    }

    public void stopCounter()
    {
        StopCoroutine("YearCount");
        StopCoroutine("YearCountDown");
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

    }
}
