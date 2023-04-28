using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextGoal : MonoBehaviour
{
    public RandomizeTrash arrayOfTrash;
    public TextMeshProUGUI[] goalText;
    public int[] goalTextValue;
    public bool trash1 = false;
    public bool trash2 = false;
    public bool trash3 = false;
    public bool allGoalComplete = false;
    private void Start()
    {
        arrayOfTrash = FindObjectOfType<RandomizeTrash>();
        setGoalText();
    }


    public void setGoalText() {
        for (int i = 0; i < goalText.Length; i++)
        {
            goalText[i].text = goalTextValue[i].ToString();
        }
    }

    public void minusCollect(string trashCollected) {
        for (int i = 0; i < arrayOfTrash.goalToCollect.Length; i++)
        {   
            if (arrayOfTrash.goalToCollect[i] == trashCollected) {
                    if (goalTextValue[i] > 0)
                    {
                        goalTextValue[i]--;
                        goalText[i].text = goalTextValue[i].ToString();
                }
               
            }
        }
    }

    public void checkGoalComplete() {
        if (goalTextValue.Length == 1) {
            for (int i = 0; i < goalTextValue.Length; i++)
            {
                if (goalTextValue[0] == 0)
                {
                    trash1 = true;
                }
            }
        }

        if (goalTextValue.Length == 2)
        {
            for (int i = 0; i < arrayOfTrash.goalToCollect.Length; i++)
            {
                if (goalTextValue[0] == 0)
                {
                    trash1 = true;
                }
                if (goalTextValue[1] == 0)
                {
                    trash2 = true;
                }
            }
        }

        if (goalTextValue.Length == 3)
        {
            for (int i = 0; i < arrayOfTrash.goalToCollect.Length; i++)
            {
                if (goalTextValue[0] == 0)
                {
                    trash1 = true;
                }
                if (goalTextValue[1] == 0)
                {
                    trash2 = true;
                }
                if (goalTextValue[2] == 0)
                {
                    trash3 = true;
                }
            }
        }


        if (goalTextValue.Length == 1)
        {
            if (trash1)
            {
                allGoalComplete = true;
            }
        }
        else if (goalTextValue.Length == 2)
        {
            if (trash1 && trash2)
            {
                allGoalComplete = true;
            }
        }
        else
        {
            if (trash1 && trash2 && trash3)
            {
                allGoalComplete = true;
            }
        }
    }
}
