﻿// This code automatically generated by TableCodeGen
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EmissionsByCountry : MonoBehaviour
{

    public TextAsset file;
    void Awake()
    {
        Load(file);

        //FindAll_Year("1999").ForEach(item => Debug.Log(item.Country + ", " + item.Total));
        //Debug.Log(Find_Total_By_Year_Country("1999", "Germany").Total);

    }

    public class Row
    {
        public string Country;
        public string Year;
        public string Total;

    }

    static List<Row> rowList = new List<Row>();
    bool isLoaded = false;

    public bool IsLoaded()
    {
        return isLoaded;
    }

    public List<Row> GetRowList()
    {
        return rowList;
    }

    public void Load(TextAsset csv)
    {
        rowList.Clear();
        string[][] grid = CsvParser2.Parse(csv.text);
        for (int i = 1; i < grid.Length; i++)
        {
            Row row = new Row();
            row.Country = grid[i][0];
            row.Year = grid[i][1];
            row.Total = grid[i][2];

            rowList.Add(row);
        }
        isLoaded = true;
    }

    public int NumRows()
    {
        return rowList.Count;
    }

    public Row GetAt(int i)
    {
        if (rowList.Count <= i)
            return null;
        return rowList[i];
    }

    public Row Find_Country(string find)
    {
        return rowList.Find(x => x.Country == find);
    }
    public List<Row> FindAll_Country(string find)
    {
        return rowList.FindAll(x => x.Country == find);
    }
    public Row Find_Year(string find)
    {
        return rowList.Find(x => x.Year == find);
    }
    public List<Row> FindAll_Year(string find)
    {
        return rowList.FindAll(x => x.Year == find);
    }
    public Row Find_Total(string find)
    {
        return rowList.Find(x => x.Total == find);
    }
    public List<Row> FindAll_Total(string find)
    {
        return rowList.FindAll(x => x.Total == find);
    }

    /// <summary>
    /// NEW FUNCTION TO FIND TOTAL EMISSIONS BY YEAR AND COUNTRY
    /// </summary>
    /// <param name="find"></param>
    /// <param name="country"></param>
    /// <returns></returns>
    public static Row Find_Total_By_Year_Country(string find, string country)
    {
        return rowList.Find(x => x.Year == find && x.Country == country);
    }
}