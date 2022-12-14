using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest2 : MonoBehaviour
{
  public bool isCompleted = false;
  
  public int shellReward;
  public int coinReward;

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

  public Text required1;
  public Text required2;

  public TimeMaster timemaster;
  public RealTimeCounter realcounter;
  
  // public Timer2 timer2;

  public GameObject submit_off;
  public GameObject submit_on;

  public TempPlayerInventory player;

  void Start()
  {
    
    required1.text = goal1_requiredAmount.ToString();
    required2.text = goal2_requiredAmount.ToString();
    spawnGoal1();
    spawnGoal2();

    CheckGoal1();
    CheckGoal2();

    GoalChecking();
  }

  public void Complete()
  {
    isCompleted = true;
    Debug.Log("Completed");
    
  }

    /////for generating goal 1
  public GameObject[] randomGoal1Project;
  public Transform Goal1_Point;
  public string goal1_whatToMake;

   public void hideall()
   {
    randomGoal1Project[0].SetActive(false);
    randomGoal1Project[1].SetActive(false);
    randomGoal1Project[2].SetActive(false);
    randomGoal1Project[3].SetActive(false);
    randomGoal1Project[4].SetActive(false);

    randomGoal2Project[0].SetActive(false);
    randomGoal2Project[1].SetActive(false);
    randomGoal2Project[2].SetActive(false);
    randomGoal2Project[3].SetActive(false);
    randomGoal2Project[4].SetActive(false);
   }

   public void spawnGoal1() {
        int goal1_projectToMake = Random.Range(0, randomGoal1Project.Length);
        Instantiate(randomGoal1Project[goal1_projectToMake], Goal1_Point.position, Goal1_Point.rotation);

        switch (goal1_projectToMake)
        {
            case 0: 
                goal1_whatToMake = "Fertilizer";
                goal1_project = Project.Fertilizer;
                break;
            case 1:
                goal1_whatToMake = "BirdFeeder";
                goal1_project = Project.BirdFeeder;                
                break;
            case 2:
                goal1_whatToMake = "ClotheBag";
                goal1_project = Project.ClotheBag;  
                break;
            case 3:
                goal1_whatToMake = "PenHolder";
                goal1_project = Project.PenHolder;  
                break;
            case 4:
                goal1_whatToMake = "PlasticPot";
                goal1_project = Project.PlasticPot;  
                break;

        }
         
        randomGoal1Project[goal1_projectToMake].SetActive(true);
    }


    /////for generating goal 2
  public GameObject[] randomGoal2Project;
  public Transform Goal2_Point;
  public string goal2_whatToMake;

   public void spawnGoal2() {
        int goal2_projectToMake = Random.Range(0, randomGoal2Project.Length);
        Instantiate(randomGoal2Project[goal2_projectToMake], Goal2_Point.position, Goal2_Point.rotation);

        switch (goal2_projectToMake)
        {
            case 0: 
                goal2_whatToMake = "Fertilizer";
                goal2_project = Project.Fertilizer;
                break;
            case 1:
                goal2_whatToMake = "BirdFeeder";
                goal2_project = Project.BirdFeeder;
                break;
            case 2:
                goal2_whatToMake = "ClotheBag";
                goal2_project = Project.ClotheBag;
                break;
            case 3:
                goal2_whatToMake = "PenHolder";
                goal2_project = Project.PenHolder;
                break;
            case 4:
                goal2_whatToMake = "PlasticPot";
                goal2_project = Project.PlasticPot;
                break;

        }
        
        randomGoal2Project[goal2_projectToMake].SetActive(true);
    }

    

    

    public void CheckGoal1()  ///needs to reference inventory
    {
      if (goal1_project == Project.Fertilizer)
      {
        goal1_currentAmount = player.Fertilizer;
      }

      if (goal1_project == Project.BirdFeeder)
      {
        goal1_currentAmount = player.BirdFeeder;
      }

      if (goal1_project == Project.ClotheBag)
      {
        goal1_currentAmount = player.ClotheBag;
      }

      if (goal1_project == Project.PenHolder)
      {
        goal1_currentAmount = player.PenHolder;
      }

      if (goal1_project == Project.PlasticPot)
      {
        goal1_currentAmount = player.PlasticPot;
      }
    }

    public void CheckGoal2() ///needs to reference inventory
    {
      if (goal2_project == Project.Fertilizer)
      {
        goal2_currentAmount = player.Fertilizer;
      }

      if (goal2_project == Project.BirdFeeder)
      {
        goal2_currentAmount = player.BirdFeeder;
      }

      if (goal2_project == Project.ClotheBag)
      {
        goal2_currentAmount = player.ClotheBag;
      }

      if (goal2_project == Project.PenHolder)
      {
        goal2_currentAmount = player.PenHolder;
      }

      if (goal2_project == Project.PlasticPot)
      {
        goal2_currentAmount = player.PlasticPot;
      }
    }

    public bool Goal1IsReached()
    {
      return (goal1_currentAmount >= goal1_requiredAmount);
    }

    public bool Goal2IsReached()
    {
      return (goal2_currentAmount >= goal2_requiredAmount);
    }

    public void GoalChecking()
    {
      if (Goal1IsReached() && Goal2IsReached())
        {
          
          submit_off.SetActive(false);
          submit_on.SetActive(true);
        }
    }

    public GameObject questdonebutton;

    public void SubmitProjects() ///needs to reference inventory
    {

      if (isCompleted == false)
      {
        if (Goal1IsReached() && Goal2IsReached())
        {
          player.player_coins += coinReward;
          player.player_shells += shellReward;
          Complete();
          timemaster.SaveDate();
         
          ////add buttons changing here
          questdonebutton.SetActive(true);
          // timer2.TimeLeft = 5; //restart time here
          submit_off.SetActive(true);
          submit_on.SetActive(false);
          realcounter.timeron2 = true;
          realcounter.ResetClock2();
          
        }


      }

    }

}
