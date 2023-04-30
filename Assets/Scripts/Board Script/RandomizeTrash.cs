using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeTrash : MonoBehaviour
{
    Board board;
    public int mechanicArrayPlace;
    public GameObject[] randomTrashCollect;
    public Transform spawnPoint;
    public string whatToCollect;

    public Transform[] goalSpawnpoint = new Transform[3];
    public string[] goalToCollect;
    private List<int> uniqueNumbers = new List<int>();
    public int[] spawnTrashArray;
    void Start()
    {
        board = FindObjectOfType<Board>();
        uniqueNumbers.Clear();
        generateUniqueNumber();
        trashGoalToCollect();
        spawnGoal();
       
    }

    public void spawnGoal() {
        for (int i = 0; i < goalSpawnpoint.Length; i++)
        {
            int x = spawnTrashArray[i];
            GameObject goals = Instantiate(randomTrashCollect[x]);
            goals.transform.position = goalSpawnpoint[i].position;
        }
    }
    public void trashGoalToCollect() {
        if (board.hasMechanics) {
            if (spawnTrashArray.Length == 1) {
                spawnTrashArray[0] = mechanicArrayPlace;
            }
            else if (spawnTrashArray.Length == 2)
            {
                spawnTrashArray[1] = mechanicArrayPlace;
            }
            else if (spawnTrashArray.Length == 3)
            {
                spawnTrashArray[2] = mechanicArrayPlace;
            }

            for (int i = 0; i < spawnTrashArray.Length; i++)
            {
                int x = spawnTrashArray[i];
                if (x == 0)
                {
                    goalToCollect[i] = "Trash1";
                }
                if (x == 1)
                {
                    goalToCollect[i] = "Trash2";
                }
                if (x == 2)
                {
                    goalToCollect[i] = "Trash3";
                }
                if (x == 3)
                {
                    goalToCollect[i] = "Trash4";
                }
                if (x == 4)
                {
                    goalToCollect[i] = "Trash5";
                }
                if (x == 5)
                {
                    goalToCollect[i] = "SubmarinePart";
                }
                if (x == 6)
                {
                    goalToCollect[i] = "Ghostnet";
                }
                if (x == 7)
                {
                    goalToCollect[i] = "Algae";
                }
            }
        }
        if (!board.hasMechanics) {
            for (int i = 0; i < spawnTrashArray.Length; i++)
            {
                int x = spawnTrashArray[i];
                if (x == 0)
                {
                    goalToCollect[i] = "Trash1";
                }
                if (x == 1)
                {
                    goalToCollect[i] = "Trash2";
                }
                if (x == 2)
                {
                    goalToCollect[i] = "Trash3";
                }
                if (x == 3)
                {
                    goalToCollect[i] = "Trash4";
                }
                if (x == 4)
                {
                    goalToCollect[i] = "Trash5";
                }
            }
        }

        
    }

    public void generateUniqueNumber() {
        for (int i = 0; i < randomTrashCollect.Length; i++)
        {
            int v = Random.Range(0, 4);
            if (v != 6 && v != 7 && v != 5) {
                if (!uniqueNumbers.Contains(v))
                {
                    uniqueNumbers.Add(v);
                }
            }
           
        }

        for (int j = 0; j < spawnTrashArray.Length; j++)
        {
            spawnTrashArray[j] = uniqueNumbers[j];
        }

    }


}
