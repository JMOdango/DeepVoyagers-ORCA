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
    

   

    public TempPlayerInventory player;
    public Text TimerTxt;
    public GameObject submit_off;
    public GameObject submit_on;

    


    // Start is called before the first frame update
    void Start()
    {
        // timer = 300;
        timer -= TimeMaster.instance.CheckDate();
        timer1 -= TimeMaster.instance.CheckDate();
        timer2 -= TimeMaster.instance.CheckDate();
     
    }

    // Update is called once per frame
    void Update()
    {
        //****only update when submit is pressed then connect to UI
        

        //  timer -= Time.deltaTime;

        if (quest.isCompleted)
        {
        
         
        
          if(timer>0)
            {
              timer -= Time.deltaTime;
              submit_off.SetActive(true);
              submit_on.SetActive(false);
              updateTimer(timer);
            }
            else
            {
                quest.hideall();
                quest.spawnGoal1();
                quest.spawnGoal2();
                GoalChecking();
                timer = 0;
                timeron= false;
                quest.isCompleted = false;
                quest.questdonebutton.SetActive(false);
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
        if (timeron)
        {
         TimeMaster.instance.SaveDate();
         timer = 10;
         timer -= TimeMaster.instance.CheckDate();
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

    //  public void GoalChecking1()
    // {
    //   if (quest1.Goal1IsReached() && quest1.Goal2IsReached())
    //     {
          
    //       submit_off.SetActive(false);
    //       submit_on.SetActive(true);
    //     }
    // }

    //  public void GoalChecking2()
    // {
    //   if (quest2.Goal1IsReached() && quest2.Goal2IsReached())
    //     {
          
    //       submit_off.SetActive(false);
    //       submit_on.SetActive(true);
    //     }
    // }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
