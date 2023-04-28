using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomizeTrash : MonoBehaviour
{
    public GameObject[] randomTrashCollect;
    public Transform spawnPoint;
    public string whatToCollect;
    public Transform[] goalSpawnpoint = new Transform[3];
    public string[] goalToCollect;
    private List<int> uniqueNumbers = new List<int>();
    public int[] spawnTrashArray;
    void Start()
    {
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
        for (int i = 0; i < spawnTrashArray.Length; i++)
        {
            int x = spawnTrashArray[i];
            if (x == 0) {
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
    //public void spawnTrash()
    //{
    //    int trashToUse = Random.Range(0, randomTrashCollect.Length);
    //    Instantiate(randomTrashCollect[trashToUse], spawnPoint.position, spawnPoint.rotation);

    //    switch (trashToUse)
    //    {
    //        case 0:
    //            whatToCollect = "Trash1";
    //            break;
    //        case 1:
    //            whatToCollect = "Trash2";
    //            break;
    //        case 2:
    //            whatToCollect = "Trash3";
    //            break;
    //        case 3:
    //            whatToCollect = "Trash4";
    //            break;
    //        case 4:
    //            whatToCollect = "Trash5";
    //            break;

    //    }
    //}

    public void generateUniqueNumber() {
        for (int i = 0; i < randomTrashCollect.Length; i++)
        {
            int v = Random.Range(0, randomTrashCollect.Length);
            if (!uniqueNumbers.Contains(v))
            {
                uniqueNumbers.Add(v);
            }
        }

        for (int j = 0; j < spawnTrashArray.Length; j++)
        {
            spawnTrashArray[j] = uniqueNumbers[j];
        }
       
    }


}
