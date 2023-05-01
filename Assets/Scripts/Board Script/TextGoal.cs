using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextGoal : MonoBehaviour
{
    Board board;
    public RandomizeTrash arrayOfTrash;
    public TextMeshProUGUI[] goalText;
    public int[] goalTextValue;
    public bool trash1 = false;
    public bool trash2 = false;
    public bool trash3 = false;
    public bool allGoalComplete = false;
    private void Start()
    {
        board = FindObjectOfType<Board>();
        arrayOfTrash = FindObjectOfType<RandomizeTrash>();
        setGoalText();
    }


    public void setGoalText() {
        if (board.hasMechanics) {
            Debug.Log("Entered");
            if (goalTextValue.Length == 1)
            {
                goalTextValue[0] = board.mechanicCounter;
                goalText[0].text = goalTextValue[0].ToString();
            }
            else if (goalTextValue.Length == 2)
            {

                goalTextValue[0] = goalTextValue[0];
                goalText[0].text = goalTextValue[0].ToString();

                goalTextValue[1] = board.mechanicCounter;
                goalText[1].text = goalTextValue[1].ToString();

            }
            else if (goalTextValue.Length == 3)
            {
                goalTextValue[0] = goalTextValue[0];
                goalText[0].text = goalTextValue[0].ToString();

                goalTextValue[1] = goalTextValue[1];
                goalText[1].text = goalTextValue[1].ToString();

                goalTextValue[2] = board.mechanicCounter;
                goalText[2].text = goalTextValue[2].ToString();
            }
            //for (int i = 0; i < goalText.Length; i++)
            //{
            //    goalTextValue[i] = board.mechanicCounter;
            //    goalText[i].text = goalTextValue[i].ToString();
            //}
        }
        else if(!board.hasMechanics){
            for (int i = 0; i < goalText.Length; i++)
            {
                goalText[i].text = goalTextValue[i].ToString();
            }
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


        if (board.hasOilSpill) {
            if (goalTextValue.Length == 1)
            {
                if (trash1 && board.oilCounter <= 0)
                {
                    allGoalComplete = true;
                }
            }
            else if (goalTextValue.Length == 2)
            {
                if (trash1 && trash2 && board.oilCounter <= 0)
                {
                    allGoalComplete = true;
                }
            }
            else
            {
                if (trash1 && trash2 && trash3 && board.oilCounter <= 0)
                {
                    allGoalComplete = true;
                }
            }
        }

        if (!board.hasOilSpill)
        {
            if (goalTextValue.Length == 1)
            {
                if (trash1 )
                {
                    allGoalComplete = true;
                }
            }
            else if (goalTextValue.Length == 2)
            {
                if (trash1 && trash2 )
                {
                    allGoalComplete = true;
                }
            }
            else
            {
                if (trash1 && trash2 && trash3 )
                {
                    allGoalComplete = true;
                }
            }
        }

    }
}
