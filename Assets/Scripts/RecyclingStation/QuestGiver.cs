using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    public TempPlayerInventory player;

    public GameObject questWindow;

    public RandomizeGoal1 toMake1;
    public RandomizeGoal2 toMake2;

    public Text shellText;
    public Text coinText;

    //to do: equal goal type and the random generated goal
    //equal ui reuirednumbertext to the required number in quest goal
    //duplicte check buttons and make sure they lead to appropriate windows
    //if completed checkmark should be green

    void Start()
    {
        toMake1 = FindObjectOfType<RandomizeGoal1>();
        toMake2 = FindObjectOfType<RandomizeGoal2>();
        toMake1.spawnGoal1();
        toMake2.spawnGoal2();
        player.quest = quest;
    }

}
