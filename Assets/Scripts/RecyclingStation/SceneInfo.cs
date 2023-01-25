using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//public class SceneInfo: Using UnityEngine;
[CreateAssetMenu(fileName = "SceneInfo", menuName = "Persistence", order = 0)]

public class SceneInfo : ScriptableObject
{
public bool instantiated = false;
   public bool isCompleted = true;
  public enum Project 
  {
    Fertilizer,
    BirdFeeder,
    ClotheBag,
    PenHolder,
    PlasticPot
  }
  
  
  public Project goal1_project;
  public Project goal2_project;

  public int goal1_requiredAmount=2; //can be randomized
  public int goal1_currentAmount;
  

  public int goal2_requiredAmount=2; //can be randomized
  public int goal2_currentAmount;

//   public GameObject submit_off;
//   public GameObject submit_on;
  
//   public GameObject[] randomGoal1Project;
//   public Transform Goal1_Point;
  public string goal1_whatToMake;
  public int goal1_projectToMake;
//   public GameObject[] randomGoal2Project;
//   public Transform Goal2_Point;
  public string goal2_whatToMake;
  public int goal2_projectToMake;
  //public Text required1;
  //public Text required2;
  
  // public Timer timer;

  //public TimeMaster timemaster;
//   public RealTimeCounter realcounter;
  public float timer;
  public bool timeron;
  //public Text TimerTxt;
}
