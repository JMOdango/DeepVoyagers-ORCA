using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeTrash : MonoBehaviour
{
    public GameObject[] randomTrashCollect;
    public Transform spawnPoint;
    public string whatToCollect;
    void Start()
    {
        //spawnTrash();
        Debug.Log(whatToCollect);
    }
    public void spawnTrash() {
        int trashToUse = Random.Range(0, randomTrashCollect.Length);
        Instantiate(randomTrashCollect[trashToUse], spawnPoint.position, spawnPoint.rotation);

        switch (trashToUse)
        {
            case 0: whatToCollect = "Trash1";
                break;
            case 1:
                whatToCollect = "Trash2";
                break;
            case 2:
                whatToCollect = "Trash3";
                break;
            case 3:
                whatToCollect = "Trash4";
                break;
            case 4:
                whatToCollect = "Trash5";
                break;

        }
    }
}
