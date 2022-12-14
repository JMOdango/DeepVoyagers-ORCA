using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//tutorial by Pygmy Tyrant
public class TimeMaster : MonoBehaviour
{
    DateTime currentDate;
    DateTime oldDate;
    public Quest quest;
    public string saveLocation;
    public static TimeMaster instance;

    void Awake()
    {
        instance = this;
        saveLocation = "LastSavedDate1";
    }

   



    public float CheckDate()
{
    currentDate = System.DateTime.Now;

    string tempString = PlayerPrefs.GetString(saveLocation,"1");

    long tempLong = Convert.ToInt64(tempString);

    DateTime oldDate = DateTime.FromBinary(tempLong);
    print("Old Date: " + oldDate);

    TimeSpan difference = currentDate.Subtract(oldDate);
    print("Difference: " + difference);

    return (float)difference.TotalSeconds;

}

public void SaveDate()
{
    PlayerPrefs.SetString(saveLocation,System.DateTime.Now.ToBinary().ToString() );
    print("Saving this date to player prefs: " + System.DateTime.Now );
}

}
