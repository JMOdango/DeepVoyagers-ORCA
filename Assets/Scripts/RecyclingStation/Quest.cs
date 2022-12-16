using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
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
  
  // public Timer timer;

  public TimeMaster timemaster;
  public RealTimeCounter realcounter;

  public GameObject submit_off;
  public GameObject submit_on;

  public TempPlayerInventory player; //connect each quest to the actual inventory code. prolly more convenient to use the subname 'player'

  public GameObject[] randomGoal1Project;
  public Transform Goal1_Point;
  public string goal1_whatToMake;

  public GameObject[] randomGoal2Project;
  public Transform Goal2_Point;
  public string goal2_whatToMake;

  void Start()
  {
    
    required1.text = goal1_requiredAmount.ToString();
    required2.text = goal2_requiredAmount.ToString();
    spawnGoal1();
    spawnGoal2();

    

    CheckGoal1();
    CheckGoal2();

    Goal1IsReached();
    Goal2IsReached();

    GoalChecking();
  }

  public void Complete()
  {
    isCompleted = true;
    Debug.Log("Completed");
    
  }

    /////for generating goal 1
  

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

   public void hidegoal1()
   {
    randomGoal1Project[0].SetActive(false);
    randomGoal1Project[1].SetActive(false);
    randomGoal1Project[2].SetActive(false);
    randomGoal1Project[3].SetActive(false);
    randomGoal1Project[4].SetActive(false);
   }

   public void hidegoal2()
   {
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
  

   public void spawnGoal2() {
        int goal2_projectToMake = Random.Range(0, randomGoal2Project.Length);
        Instantiate(randomGoal2Project[goal2_projectToMake], Goal2_Point.position, Goal2_Point.rotation);

        switch (goal2_projectToMake)
        {
            case 0: 
                if(goal1_whatToMake != "Fertilizer")
                {
                 goal2_whatToMake = "Fertilizer";
                 goal2_project = Project.Fertilizer;
                }
                else
                {
                  hidegoal2();
                  spawnGoal2();
                }

                break;
            case 1:
            if(goal1_whatToMake != "BirdFeeder")
                {
                goal2_whatToMake = "BirdFeeder";
                goal2_project = Project.BirdFeeder;
                }
                else
                {
                  hidegoal2();
                  spawnGoal2();
                }
                break;
            case 2:
            if(goal1_whatToMake != "ClotheBag")
                {
                goal2_whatToMake = "ClotheBag";
                goal2_project = Project.ClotheBag;
                }
                else
                {
                  hidegoal2();
                  spawnGoal2();
                }
                break;
            case 3:
            if(goal1_whatToMake != "PenHolder")
                {
                goal2_whatToMake = "PenHolder";
                goal2_project = Project.PenHolder;
                }
                else
                {
                  hidegoal2();
                  spawnGoal2();
                }
                break;
            case 4:
            if(goal1_whatToMake != "PlasticPot")
                {
                goal2_whatToMake = "PlasticPot";
                goal2_project = Project.PlasticPot;
                }
                else
                {
                  hidegoal2();
                  spawnGoal2();
                }
                break;

      

        }
       
       if (goal2_whatToMake == "Fertilizer")
      {
       hidegoal2();
       randomGoal2Project[0].SetActive(true);
      }

      if (goal2_whatToMake == "BirdFeeder")
      {
        hidegoal2();
        randomGoal2Project[1].SetActive(true);
      }

      if (goal2_whatToMake == "ClotheBag")
      {
        hidegoal2();
        randomGoal2Project[2].SetActive(true);
      }

      if (goal2_whatToMake == "PenHolder")
      {
        hidegoal2();
        randomGoal2Project[3].SetActive(true);
      }

      if (goal2_whatToMake == "PlasticPot")
      {
        hidegoal2();
        randomGoal2Project[4].SetActive(true);
      }
        
         
        
        
    }

    // public void spawngoals()
    // {
    //   if (goal1_whatToMake == "Fertilizer")
    //   {
    //    hidegoal1();
    //    randomGoal1Project[0].SetActive(true);
    //   }

    //   if (goal1_whatToMake == "BirdFeeder")
    //   {
    //     hidegoal1();
    //     randomGoal1Project[1].SetActive(true);
    //   }

    //   if (goal1_whatToMake == "ClotheBag")
    //   {
    //     hidegoal1();
    //     randomGoal1Project[2].SetActive(true);
    //   }

    //   if (goal1_whatToMake == "PenHolder")
    //   {
    //     hidegoal1();
    //     randomGoal1Project[3].SetActive(true);
    //   }

    //   if (goal1_whatToMake == "PlasticPot")
    //   {
    //     hidegoal1();
    //     randomGoal1Project[4].SetActive(true);
    //   }
      
    //   ///////////////////

    //   if (goal2_whatToMake == "Fertilizer")
    //   {
    //    hidegoal2();
    //    randomGoal2Project[0].SetActive(true);
    //   }

    //   if (goal2_whatToMake == "BirdFeeder")
    //   {
    //     hidegoal2();
    //     randomGoal2Project[1].SetActive(true);
    //   }

    //   if (goal2_whatToMake == "ClotheBag")
    //   {
    //     hidegoal2();
    //     randomGoal2Project[2].SetActive(true);
    //   }

    //   if (goal2_whatToMake == "PenHolder")
    //   {
    //     hidegoal2();
    //     randomGoal2Project[3].SetActive(true);
    //   }

    //   if (goal2_whatToMake == "PlasticPot")
    //   {
    //     hidegoal2();
    //     randomGoal2Project[4].SetActive(true);
    //   }
     

    // }

    

    

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
      else
      {
        
        submit_on.SetActive(false);
        submit_off.SetActive(true);
      }
    }

    public GameObject questdonebutton;

    public void SubmitProjects() ///needs to reference inventory
    {

      if (isCompleted == false)
      {
        if (Goal1IsReached() && Goal2IsReached())
        {
          DecreaseGoal1();
          DecreaseGoal2();
          player.player_coins += coinReward;
          player.player_shells += shellReward;
          Complete();
          timemaster.SaveDate();
          
         
          ////add buttons changing here
          questdonebutton.SetActive(true);
           //restart time here
          submit_off.SetActive(true);
          submit_on.SetActive(false);
          
          realcounter.timeron = true;
          realcounter.ResetClock();
        }


      }

    }

    public void DecreaseGoal1()  ///needs to reference inventory
    {
      if (goal1_project == Project.Fertilizer)
      {
         player.Fertilizer-=goal1_requiredAmount;
      }

      if (goal1_project == Project.BirdFeeder)
      {
         player.BirdFeeder-=goal1_requiredAmount;
      }

      if (goal1_project == Project.ClotheBag)
      {
        player.ClotheBag-=goal1_requiredAmount;
      }

      if (goal1_project == Project.PenHolder)
      {
        player.PenHolder-=goal1_requiredAmount;
      }

      if (goal1_project == Project.PlasticPot)
      {
        player.PlasticPot-=goal1_requiredAmount;
      }
    }

    public void DecreaseGoal2()  ///needs to reference inventory
    {
      if (goal2_project == Project.Fertilizer)
      {
         player.Fertilizer-=goal2_requiredAmount;
      }

      if (goal2_project == Project.BirdFeeder)
      {
         player.BirdFeeder-=goal2_requiredAmount;
      }

      if (goal2_project == Project.ClotheBag)
      {
        player.ClotheBag-=goal2_requiredAmount;
      }

      if (goal2_project == Project.PenHolder)
      {
        player.PenHolder-=goal2_requiredAmount;
      }

      if (goal2_project == Project.PlasticPot)
      {
        player.PlasticPot-=goal2_requiredAmount;
      }
    }

}
