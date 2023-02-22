using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class Quest : MonoBehaviour
{
  InventoryManager inventory;
  TrashCollectionManager trashCollectionManager;
  public int shellsReward;
  public int coinsReward;
  
  // public bool isCompleted = false;
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

  public GameObject submit_off;
  public GameObject submit_on;
  
  public GameObject[] randomGoal1Project;
  public Transform Goal1_Point;
  // public string goal1_whatToMake;

  public GameObject[] randomGoal2Project;
  public Transform Goal2_Point;
  // public string goal2_whatToMake;

   public Text required1;
   public Text required2;
  
  // // public Timer timer;

   public TimeMaster timemaster;
   public RealTimeCounter realcounter;  
  
  [SerializeField]
  public SceneInfo sceneinfo;

  void Start()
  {
    //DontDestroyOnLoad(this.gameObject);
    // DontDestroyOnLoad(this.gameObject);
    // DontDestroyOnLoad(sceneinfo);
    // DontDestroyOnLoad(realcounter);
    if (sceneinfo.instantiated == false && sceneinfo.timeron == false)
    {
     required1.text = sceneinfo.goal1_requiredAmount.ToString();
     required2.text = sceneinfo.goal2_requiredAmount.ToString();
     spawnGoal1();
     spawnGoal2();

    

     CheckGoal1();
     CheckGoal2();

     Goal1IsReached();
     Goal2IsReached();

     GoalChecking();
     sceneinfo.instantiated = true;
    
    }

    else
    {
      randomGoal1Project[sceneinfo.goal1_projectToMake].SetActive(true);
      randomGoal2Project[sceneinfo.goal2_projectToMake].SetActive(true);
    }
  }

  void Update()
  {
<<<<<<< Updated upstream
    //  DontDestroyOnLoad(randomGoal1Project[sceneinfo.goal1_projectToMake]);
    //  DontDestroyOnLoad(randomGoal1Project[sceneinfo.goal2_projectToMake]);
=======
     //DontDestroyOnLoad(randomGoal1Project[sceneinfo.goal1_projectToMake]);
     //DontDestroyOnLoad(randomGoal1Project[sceneinfo.goal2_projectToMake]);
>>>>>>> Stashed changes
    //  DontDestroyOnLoad(this.gameObject);
    //  DontDestroyOnLoad(sceneinfo);
    //  DontDestroyOnLoad(realcounter);
     required1.text = sceneinfo.goal1_requiredAmount.ToString();
     required2.text = sceneinfo.goal2_requiredAmount.ToString();
  }

  public void Complete()
  {
    sceneinfo.isCompleted = true;
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
        sceneinfo.goal1_projectToMake = Random.Range(0, randomGoal1Project.Length);
        Instantiate(randomGoal1Project[sceneinfo.goal1_projectToMake], Goal1_Point.position, Goal1_Point.rotation);
<<<<<<< Updated upstream
        // DontDestroyOnLoad(randomGoal1Project[sceneinfo.goal1_projectToMake]);
=======
        //DontDestroyOnLoad(randomGoal1Project[sceneinfo.goal1_projectToMake]);
>>>>>>> Stashed changes
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
  

   public void spawnGoal2() {
        sceneinfo.goal2_projectToMake = Random.Range(0, randomGoal2Project.Length);
        Instantiate(randomGoal2Project[sceneinfo.goal2_projectToMake], Goal2_Point.position, Goal2_Point.rotation);
<<<<<<< Updated upstream
        // DontDestroyOnLoad(randomGoal1Project[sceneinfo.goal2_projectToMake]);
=======
        //DestroyOnLoad(randomGoal1Project[sceneinfo.goal2_projectToMake]);
>>>>>>> Stashed changes
        
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
                sceneinfo.goal2_whatToMake = "PlasticPot";
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
      if (sceneinfo.goal1_project == SceneInfo.Project.Fertilizer)
      {
        sceneinfo.goal1_currentAmount = TrashCollectionManager.trashCollectionManager.GetFertilizerLeft();
      }

      if (sceneinfo.goal1_project == SceneInfo.Project.BirdFeeder)
      {
        sceneinfo.goal1_currentAmount = TrashCollectionManager.trashCollectionManager.GetBirdFeederLeft();
      }

      if (sceneinfo.goal1_project == SceneInfo.Project.ClotheBag)
      {
        sceneinfo.goal1_currentAmount = TrashCollectionManager.trashCollectionManager.GetClotheBagLeft();
      }

      if (sceneinfo.goal1_project == SceneInfo.Project.PenHolder)
      {
        sceneinfo.goal1_currentAmount = TrashCollectionManager.trashCollectionManager.GetPenHolderLeft();
      }

      if (sceneinfo.goal1_project == SceneInfo.Project.PlasticPot)
      {
        sceneinfo.goal1_currentAmount = TrashCollectionManager.trashCollectionManager.GetPlasticPotLeft();
      }
    }

    public void CheckGoal2() ///needs to reference inventory
    {
      if (sceneinfo.goal2_project == SceneInfo.Project.Fertilizer)
      {
        sceneinfo.goal2_currentAmount = TrashCollectionManager.trashCollectionManager.GetFertilizerLeft();
      }

      if (sceneinfo.goal2_project == SceneInfo.Project.BirdFeeder)
      {
        sceneinfo.goal2_currentAmount = TrashCollectionManager.trashCollectionManager.GetBirdFeederLeft();
      }

      if (sceneinfo.goal2_project == SceneInfo.Project.ClotheBag)
      {
        sceneinfo.goal2_currentAmount = TrashCollectionManager.trashCollectionManager.GetClotheBagLeft();
      }

      if (sceneinfo.goal2_project == SceneInfo.Project.PenHolder)
      {
        sceneinfo.goal2_currentAmount = TrashCollectionManager.trashCollectionManager.GetPenHolderLeft();
      }

      if (sceneinfo.goal2_project == SceneInfo.Project.PlasticPot)
      {
        sceneinfo.goal2_currentAmount = TrashCollectionManager.trashCollectionManager.GetPlasticPotLeft();
      }
    }

    public bool Goal1IsReached()
    {
      return (sceneinfo.goal1_currentAmount >= sceneinfo.goal1_requiredAmount);
    }

    public bool Goal2IsReached()
    {
      return (sceneinfo.goal2_currentAmount >= sceneinfo.goal2_requiredAmount);
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

      if (sceneinfo.isCompleted == false)
      {
        if (Goal1IsReached() && Goal2IsReached())
        {
          DecreaseGoal1();
          DecreaseGoal2();
      
          var coinsReq = new AddUserVirtualCurrencyRequest{
                  VirtualCurrency = "CN",
                  Amount = coinsReward
          };
          PlayFabClientAPI.AddUserVirtualCurrency(coinsReq, OnAddCoinsSuccess, OnError);

          var shellsReq = new AddUserVirtualCurrencyRequest{
                  VirtualCurrency = "SH",
                  Amount = shellsReward
          };
          PlayFabClientAPI.AddUserVirtualCurrency(shellsReq, OnAddCoinsSuccess, OnError);

          Complete();
          timemaster.SaveDate();
          
         
          ////add buttons changing here
          questdonebutton.SetActive(true);
           //restart time here
          submit_off.SetActive(true);
          submit_on.SetActive(false);
          
          sceneinfo.timeron = true;
          realcounter.ResetClock();
          sceneinfo.isCompleted = true;
          
        }
      }
    }

    void OnAddCoinsSuccess(ModifyUserVirtualCurrencyResult result){
        VirtualCurrency.virtualCurrency.GetVirtualCurrencies();
    }

    void OnError(PlayFabError error){
        Debug.Log("Error: " + error.ErrorMessage);
    }

    public void DecreaseGoal1()  ///needs to reference inventory
    {
      if (sceneinfo.goal1_project == SceneInfo.Project.Fertilizer)
      {
        inventory.ReduceProjects("fertilizer", sceneinfo.goal1_requiredAmount);
      }

      if (sceneinfo.goal1_project == SceneInfo.Project.BirdFeeder)
      {
        inventory.ReduceProjects("birdfeeder", sceneinfo.goal1_requiredAmount);
      }

      if (sceneinfo.goal1_project == SceneInfo.Project.ClotheBag)
      {
        inventory.ReduceProjects("clothebag", sceneinfo.goal1_requiredAmount);
      }

      if (sceneinfo.goal1_project == SceneInfo.Project.PenHolder)
      {
        inventory.ReduceProjects("penholder", sceneinfo.goal1_requiredAmount);
      }

      if (sceneinfo.goal1_project == SceneInfo.Project.PlasticPot)
      {
        inventory.ReduceProjects("plasticpot", sceneinfo.goal1_requiredAmount);
      }
    }

    public void DecreaseGoal2()  ///needs to reference inventory
    {
      if (sceneinfo.goal2_project == SceneInfo.Project.Fertilizer)
      {
        inventory.ReduceProjects("fertilizer", sceneinfo.goal2_requiredAmount);
      }

      if (sceneinfo.goal2_project == SceneInfo.Project.BirdFeeder)
      {
        inventory.ReduceProjects("birdfeeder", sceneinfo.goal2_requiredAmount);
      }

      if (sceneinfo.goal2_project == SceneInfo.Project.ClotheBag)
      {
        inventory.ReduceProjects("clothebag", sceneinfo.goal2_requiredAmount);
      }

      if (sceneinfo.goal2_project == SceneInfo.Project.PenHolder)
      {
        inventory.ReduceProjects("penholder", sceneinfo.goal2_requiredAmount);
      }

      if (sceneinfo.goal2_project == SceneInfo.Project.PlasticPot)
      {
        inventory.ReduceProjects("plasticpot", sceneinfo.goal2_requiredAmount);
      }
    }

}
