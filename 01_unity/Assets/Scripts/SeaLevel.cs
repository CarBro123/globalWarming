using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;
using UnityEngine.SceneManagement;

public class SeaLevel : MonoBehaviour
{


    float[] Array = new float[68];

    float newY = 0;
    float oldY = 0;
    float percentage;
    int year = 0;
    int yearold = 0;
    int yearinsec = 5;

    bool islerping;
    float timeStartedLerping;



    // Use this for initialization
    void Start()
    {             //WerteArray für Wasserstand
        Array[0] = 0;
        Array[1] = 9.5f;
        Array[2] = 6.9f;
        Array[3] = 11.3f;
        Array[4] = 8.4f;
        Array[5] = 9.3f;
        Array[6] = 4.2f;
        Array[7] = 17.6f;
        Array[8] = 19f;
        Array[9] = 19.3f;
        Array[10] = 23f;
        Array[11] = 29.2f;
        Array[12] = 24f;
        Array[13] = 22.4f;
        Array[14] = 14.5f;
        Array[15] = 25.7f;
        Array[16] = 20.3f;
        Array[17] = 21.7f;
        Array[18] = 22.5f;
        Array[19] = 29.3f;
        Array[20] = 27.4f;
        Array[21] = 32.6f;
        Array[22] = 41.7f;
        Array[23] = 35.7f;
        Array[24] = 47.6f;
        Array[25] = 46f;
        Array[26] = 45f;
        Array[27] = 43.3f;
        Array[28] = 49.7f;
        Array[29] = 44.8f;
        Array[30] = 50.8f;
        Array[31] = 63.2f;
        Array[32] = 57.4f;
        Array[33] = 65.8f;
        Array[34] = 64.9f;
        Array[35] = 54.6f;
        Array[36] = 55.2f;
        Array[37] = 55.8f;
        Array[38] = 60.5f;
        Array[39] = 65f;
        Array[40] = 67.3f;
        Array[41] = 69.8f;
        Array[42] = 70.5f;
        Array[43] = 68.7f;
        Array[44] = 73.9f;
        Array[45] = 76.8f;
        Array[46] = 80.9f;
        Array[47] = 87.9f;
        Array[48] = 78f;
        Array[49] = 86.5f;
        Array[50] = 87.8f;
        Array[51] = 93.3f;
        Array[52] = 95.7f;
        Array[53] = 104.9f;
        Array[54] = 104.5f;
        Array[55] = 104.6f;
        Array[56] = 108.9f;
        Array[57] = 110.8f;
        Array[58] = 119.5f;
        Array[59] = 125.3f;
        Array[60] = 133f;
        Array[61] = 134.6f;
        Array[62] = 143.4f;
        Array[63] = 135f;
        Array[64] = 136.4f;
        Array[65] = 137.5f;
        Array[66] = 138.5f;
        Array[67] = 140f;
    }

    void FixedUpdate()
    {
        if (year <= 2017 && year >= 1950 && yearold < year)                        //Nur wenn in Wertebereich des Arrays
        {
            islerping = true;                               //Lerp Aktivieren
            timeStartedLerping = Time.time;
            newY = Array[(year - 1950)];                    //Neue Y Koordinate berechnen
            newY = newY / 100;
            yearold = year;
        }

        if (islerping)                                          //y Position ändern
        {
            float timeSinceStart = Time.time - timeStartedLerping;
            float percentage = timeSinceStart / (yearinsec * 0.9f);

            this.transform.position = new Vector3(0, Mathf.Lerp(oldY, newY, percentage), 0);    //Positionsänderung
            oldY = Mathf.Lerp(oldY, newY, percentage);

            if (percentage >= 1.0f)                                                             //Exit
            {
                islerping = false;
                //oldY = newY;
            }
        }

    }

    public void WaterLevel(int bingo, int bongo)
    {
        year = bingo;
        yearold = bingo - 1;
        yearinsec = bongo;

    }
}
