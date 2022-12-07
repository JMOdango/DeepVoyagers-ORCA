using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal 
{
    public GoalType goalType;
    public TempPlayerInventory player;

    public int requiredAmount;
    public int currentAmount;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void checkGoal()
    {
        if (goalType == GoalType.fertilizer)
        {
          currentAmount = player.organicfertilizer;
        }
        
    }
}

public enum GoalType
{
    fertilizer,
    birdfeeder
}
