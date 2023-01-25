using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest1 : MonoBehaviour
{
  // public bool isCompleted = false;
  
  public int shellReward;
  public int coinReward;

  // public enum Project 
  // {
  //   Fertilizer,
  //   BirdFeeder,
  //   ClotheBag,
  //   PenHolder,
  //   PlasticPot
  // }

  // public Project goal1_project;
  // public Project goal2_project;

  // public int goal1_requiredAmount=2; //can be randomized
  // public int goal1_currentAmount;
  

  // public int goal2_requiredAmount=2; //can be randomized
  // public int goal2_currentAmount;

  public Text required1;
  public Text required2;
  
  
  // public Timer1 timer1;
  
  public TimeMaster timemaster;
  public RealTimeCounter realcounter;

  public GameObject submit_off;
  public GameObject submit_on;

  public TempPlayerInventory player;

  [SerializeField]
  public SceneInfo sceneinfo;

  void Start()
  {
    DontDestroyOnLoad(this.gameObject);
    DontDestroyOnLoad(sceneinfo);
    DontDestroyOnLoad(realcounter);

    if (sceneinfo.instantiated == false)
    {
    required1.text = sceneinfo.requiredAmount.ToString();
    required2.text = sceneinfo.requiredAmount.ToString();
    spawnGoal1();
    spawnGoal2();

    CheckGoal1();
    CheckGoal2();

    Goal1IsReached();
    Goal2IsReached();

    GoalChecking();
    }
    else
    {
      randomGoal1Project[sceneinfo.goal1_projectToMake].SetActive(true);
      randomGoal2Project[sceneinfo.goal2_projectToMake].SetActive(true);
    }
  }

  void Update()
  {
     DontDestroyOnLoad(randomGoal1Project[sceneinfo.goal1_projectToMake]);
     DontDestroyOnLoad(randomGoal1Project[sceneinfo.goal2_projectToMake]);
     DontDestroyOnLoad(this.gameObject);
     DontDestroyOnLoad(sceneinfo);
     DontDestroyOnLoad(realcounter);
  }

  public void Complete()
  {
    isCompleted = true;
    Debug.Log("Completed");
    
  }

    /////for generating goal 1
  public GameObject[] randomGoal1Project;
  public Transform Goal1_Point;
  // public string goal1_whatToMake;

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

   public void hidegoal2()
   {
    randomGoal2Project[0].SetActive(false);
    randomGoal2Project[1].SetActive(false);
    randomGoal2Project[2].SetActive(false);
    randomGoal2Project[3].SetActive(false);
    randomGoal2Project[4].SetActive(false);
   }

   public void spawnGoal1() {
        sceneinfo.goal1_projectToMake = Random.Range(0, randomGoal1Project.Length);
        Instantiate(randomGoal1Project[sceneinfo.goal1_projectToMake], Goal1_Point.position, Goal1_Point.rotation);
        DontDestroyOnLoad(randomGoal1Project[sceneinfo.goal1_projectToMake]);
        sceneinfo.isCompleted = false;
        switch (sceneinfo.goal1_projectToMake)
        {
            case 0: 
                sceneinfo.goal1_whatToMake = "Fertilizer";
                sceneinfo.goal1_project = SceneInfo.Project.Fertilizer;
                break;
            case 1:
                sceneinfo.goal1_whatToMake = "BirdFeeder";
                sceneinfo.goal1_project = SceneInfo.Project.BirdFeeder;                
                break;
            case 2:
                sceneinfo.goal1_whatToMake = "ClotheBag";
                sceneinfo.goal1_project = SceneInfo.Project.ClotheBag;  
                break;
            case 3:
                sceneinfo.goal1_whatToMake = "PenHolder";
                sceneinfo.goal1_project = SceneInfo.Project.PenHolder;  
                break;
            case 4:
                sceneinfo.goal1_whatToMake = "PlasticPot";
                sceneinfo.goal1_project = SceneInfo.Project.PlasticPot;  
                break;

        }
         
        randomGoal1Project[sceneinfo.goal1_projectToMake].SetActive(true);
    }


    /////for generating goal 2
  public GameObject[] randomGoal2Project;
  public Transform Goal2_Point;
  // public string goal2_whatToMake;

    public void spawnGoal2() {
        sceneinfo.goal2_projectToMake = Random.Range(0, randomGoal2Project.Length);
        Instantiate(randomGoal2Project[sceneinfo.goal2_projectToMake], Goal2_Point.position, Goal2_Point.rotation);
        DontDestroyOnLoad(randomGoal1Project[sceneinfo.goal2_projectToMake]);
        switch (sceneinfo.goal2_projectToMake)
        {
            case 0: 
                if(sceneinfo.goal1_whatToMake != "Fertilizer")
                {
                 sceneinfo.goal2_whatToMake = "Fertilizer";
                 sceneinfo.goal2_project = SceneInfo.Project.Fertilizer;
                }
                else
                {
                  hidegoal2();
                  spawnGoal2();
                }

                break;
            case 1:
            if(sceneinfo.goal1_whatToMake != "BirdFeeder")
                {
                sceneinfo.goal2_whatToMake = "BirdFeeder";
                sceneinfo.goal2_project = SceneInfo.Project.BirdFeeder;
                }
                else
                {
                  hidegoal2();
                  spawnGoal2();
                }
                break;
            case 2:
            if(sceneinfo.goal1_whatToMake != "ClotheBag")
                {
                sceneinfo.goal2_whatToMake = "ClotheBag";
                sceneinfo.goal2_project = SceneInfo.Project.ClotheBag;
                }
                else
                {
                  hidegoal2();
                  spawnGoal2();
                }
                break;
            case 3:
            if(sceneinfo.goal1_whatToMake != "PenHolder")
                {
                sceneinfo.goal2_whatToMake = "PenHolder";
                sceneinfo.goal2_project = SceneInfo.Project.PenHolder;
                }
                else
                {
                  hidegoal2();
                  spawnGoal2();
                }
                break;
            case 4:
            if(sceneinfo.goal1_whatToMake != "PlasticPot")
                {
                sceneinfo.oal2_whatToMake = "PlasticPot";
                sceneinfo.goal2_project = SceneInfo.Project.PlasticPot;
                }
                else
                {
                  hidegoal2();
                  spawnGoal2();
                }
                break;

        }
        if (sceneinfo.goal2_whatToMake == "Fertilizer")
      {
       hidegoal2();
       randomGoal2Project[0].SetActive(true);
      }

      if (sceneinfo.goal2_whatToMake == "BirdFeeder")
      {
        hidegoal2();
        randomGoal2Project[1].SetActive(true);
      }

      if (sceneinfo.goal2_whatToMake == "ClotheBag")
      {
        hidegoal2();
        randomGoal2Project[2].SetActive(true);
      }

      if (sceneinfo.goal2_whatToMake == "PenHolder")
      {
        hidegoal2();
        randomGoal2Project[3].SetActive(true);
      }

      if (sceneinfo.goal2_whatToMake == "PlasticPot")
      {
        hidegoal2();
        randomGoal2Project[4].SetActive(true);
      }
    }

    

    

    public void CheckGoal1()  ///needs to reference inventory
    {
      if (sceneinfo.goal1_project == Project.Fertilizer)
      {
        sceneinfo.goal1_currentAmount = player.Fertilizer;
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
          // timer1.TimeLeft = 5; //restart time here
          submit_off.SetActive(true);
          submit_on.SetActive(false);
          realcounter.timeron1 = true;
          realcounter.ResetClock1();
          
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
