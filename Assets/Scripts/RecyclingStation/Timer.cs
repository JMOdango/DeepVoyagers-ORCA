using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;
    public bool generated ;
   
    public Text TimerTxt;
    public Quest quest;
    public TempPlayerInventory player;

    public GameObject submit_off;
    public GameObject submit_on;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (quest.isCompleted)
        {
         TimerOn = true;
          //set seconds or time here as well
        //  generated = false;
         
        
        }
        if(TimerOn && quest.isCompleted)
        {
            if(TimeLeft>0)
            {
              TimeLeft -= Time.deltaTime;
              updateTimer(TimeLeft);
              submit_off.SetActive(true);
              submit_on.SetActive(false);
            }
            else
            {
                quest.hideall();
                quest.spawnGoal1();
                quest.spawnGoal2();
                GoalChecking();
                TimeLeft = 0;
                TimerOn = false;
                quest.isCompleted = false;
                
            }

            
        }

      
         

    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void GoalChecking()
    {
      if (quest.Goal1IsReached() && quest.Goal2IsReached())
        {
          
          submit_off.SetActive(false);
          submit_on.SetActive(true);
        }
    }
}
