using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//tutorial by Pygmy Tyrant
public class RealTimeCounter : MonoBehaviour
{
    public float timer;
    public float timer1;
    public float timer2;

    public Quest quest;
    public Quest1 quest1;
    public Quest2 quest2;

    public bool timeron;
    public bool timeron1;
    public bool timeron2;
   
    public Text TimerTxt;
    public Text TimerTxt1;
    public Text TimerTxt2;

    public TempPlayerInventory player;
   
    public GameObject submit_off;
    public GameObject submit_on;

    public GameObject submit_off1;
    public GameObject submit_on1;

    public GameObject submit_off2;
    public GameObject submit_on2;
    
    [SerializeField]
    public SceneInfo sceneinfo;
    public SceneInfo sceneinfo1;

    // Start is called before the first frame update
    void Start()
    {
       
        // timer = 300;
        sceneinfo.timer -= TimeMaster.instance.CheckDate();
        sceneinfo1.timer -= TimeMaster.instance.CheckDate();
        timer2 -= TimeMaster.instance.CheckDate();

        quest.CheckGoal1();
        quest.CheckGoal2();
        quest.Goal1IsReached();
        quest.Goal2IsReached();
        quest.GoalChecking();

        quest1.CheckGoal1();
        quest1.CheckGoal2();
        quest1.Goal1IsReached();
        quest1.Goal2IsReached();
        quest1.GoalChecking();

        quest2.CheckGoal1();
        quest2.CheckGoal2();
        quest2.Goal1IsReached();
        quest2.Goal2IsReached();
        quest2.GoalChecking();
     
    }

    // Update is called once per frame
    void Update()
    {
        //****only update when submit is pressed then connect to UI
        
       

        //  timer -= Time.deltaTime;
        quest.CheckGoal1();
        quest.CheckGoal2();
        quest.Goal1IsReached();
        quest.Goal2IsReached();
        quest.GoalChecking();

        quest1.CheckGoal1();
        quest1.CheckGoal2();
        quest1.Goal1IsReached();
        quest1.Goal2IsReached();
        quest1.GoalChecking();

        quest2.CheckGoal1();
        quest2.CheckGoal2();
        quest2.Goal1IsReached();
        quest2.Goal2IsReached();
        quest2.GoalChecking();

        


        if (sceneinfo.isCompleted == true)
        {
        
          if(sceneinfo.timer>0)
            {
              sceneinfo.timer -= Time.deltaTime;
              submit_off.SetActive(true);
              submit_on.SetActive(false);
              updateTimer(sceneinfo.timer);
            }
            else
            {
                quest.hideall();
                quest.spawnGoal1();
                quest.spawnGoal2();
                // quest.CheckGoal1();
                // quest.CheckGoal2();
               
                sceneinfo.timer = 0;
                sceneinfo.timeron= false;
                //sceneinfo.isCompleted = false;
                quest.questdonebutton.SetActive(false);
                sceneinfo.isCompleted = false;
            }
        
        }

        
        if (sceneinfo1.isCompleted == true)
        {
        
          if(sceneinfo1.timer>0)
            {
              sceneinfo1.timer -= Time.deltaTime;
              submit_off1.SetActive(true);
              submit_on1.SetActive(false);
              updateTimer1(timer1);
            }
            else
            {
                quest1.hideall();
                quest1.spawnGoal1();
                quest1.spawnGoal2();
                // quest1.CheckGoal1();
                // quest1.CheckGoal2();
                
                sceneinfo1.timer = 0;
                sceneinfo1.timeron= false;
                sceneinfo1..isCompleted = false;
                quest1.questdonebutton.SetActive(false);
            }
        
        }

        
        if (quest2.isCompleted)
        {
        
          if(timer2>0)
            {
              timer2 -= Time.deltaTime;
              submit_off2.SetActive(true);
              submit_on2.SetActive(false);
              updateTimer2(timer2);
            }
            else
            {
                quest2.hideall();
                quest2.spawnGoal1();
                quest2.spawnGoal2();
                // quest2.CheckGoal1();
                // quest2.CheckGoal2();
                
                timer2 = 0;
                timeron2= false;
                quest2.isCompleted = false;
                quest2.questdonebutton.SetActive(false);
            }
        
        }


        
        
       

        
        
    }

    // void onGUI()
    // {
    //     if(GUI.Button(new Rect(10,10,100,50), "Save Time"))
    //     {
    //         ResetClock();
    //     }
    //     if(GUI.Button(new Rect(10,150,100,50),"Check Time"))
    //     {
    //         print (60 - TimeMaster.instance.CheckDate() + " in real seconds has passed");
    //     }

    //     GUI.Label (new Rect(10,150,100,50), timer.ToString());
    // }

    public void ResetClock()
    {
        if (sceneinfo.timeron)
        {
         TimeMaster.instance.SaveDate();
         sceneinfo.timer = 10;
         sceneinfo.timer -= TimeMaster.instance.CheckDate();
        }

        if (timeron1)
        {
         TimeMaster.instance.SaveDate();
         timer1 = 10;
         timer1 -= TimeMaster.instance.CheckDate();
        }

        if (timeron2)
        {
         TimeMaster.instance.SaveDate();
         timer2 = 10;
         timer2 -= TimeMaster.instance.CheckDate();
        }
        
    }

    public void ResetClock1()
    {

        if (timeron1)
        {
         TimeMaster.instance.SaveDate();
         timer1 = 10;
         timer1 -= TimeMaster.instance.CheckDate();
        }

        
    }

    public void ResetClock2()
    {
        

        if (timeron2)
        {
         TimeMaster.instance.SaveDate();
         timer2 = 10;
         timer2 -= TimeMaster.instance.CheckDate();
        }
        
    }

    public void GoalChecking()
    {
      if (quest.Goal1IsReached() && quest.Goal2IsReached())
        {
          
          submit_off.SetActive(false);
          submit_on.SetActive(true);
        }
    }

     public void GoalChecking1()
    {
      if (quest1.Goal1IsReached() && quest1.Goal2IsReached())
        {
          
          submit_off1.SetActive(false);
          submit_on1.SetActive(true);
        }
    }

     public void GoalChecking2()
    {
      if (quest2.Goal1IsReached() && quest2.Goal2IsReached())
        {
          
          submit_off2.SetActive(false);
          submit_on2.SetActive(true);
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    void updateTimer1(float currentTime1)
    {
        currentTime1 += 1;

        float minutes = Mathf.FloorToInt(currentTime1 / 60);
        float seconds = Mathf.FloorToInt(currentTime1 % 60);

        TimerTxt1.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    void updateTimer2(float currentTime2)
    {
        currentTime2 += 1;

        float minutes = Mathf.FloorToInt(currentTime2 / 60);
        float seconds = Mathf.FloorToInt(currentTime2 % 60);

        TimerTxt2.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
