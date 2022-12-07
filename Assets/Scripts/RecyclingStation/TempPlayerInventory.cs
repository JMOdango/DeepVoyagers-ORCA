using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerInventory : MonoBehaviour
{
    public Quest quest;
    public int player_shells;
    public int player_coins;
    public int organicfertilizer = 3;
    public int birdfeeder = 3;
    public int clothebag = 3;
    public int penholder = 3;
    public int plasticpot = 3;

    void Start()
    {
        quest.goal.checkGoal();
    }

    public void SubmitProjects()
    {
        if (quest.isCompleted == false)
        {
            
            if (quest.goal.IsReached())
            {
              player_coins += quest.coinReward;
              player_shells += quest.shellReward;
              quest.Complete();
            }
        }
    }
}
