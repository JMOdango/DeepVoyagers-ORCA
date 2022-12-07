using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Quest
{
  
  public bool isCompleted = false;
  
  public int shellReward;
  public int coinReward;
  
  public QuestGoal goal;

  public void Complete()
  {
    isCompleted = true;
    Debug.Log("Completed");
  }

  

}



