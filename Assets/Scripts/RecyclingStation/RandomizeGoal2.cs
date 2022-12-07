using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeGoal2 : MonoBehaviour
{
     public GameObject[] randomGoal1Project;
    public Transform Goal1_Point;
    public string whatToMake;

    
    void Start()
    {
        //spawnTrash();
        Debug.Log(whatToMake);
    }

    public void HideAll()
    {

    }
    public void spawnGoal2() {
        int projectToMake = Random.Range(0, randomGoal1Project.Length);
        Instantiate(randomGoal1Project[projectToMake], Goal1_Point.position, Goal1_Point.rotation);

        switch (projectToMake)
        {
            case 0: whatToMake = "Fertilizer";
                break;
            case 1:
                whatToMake = "BirdFeeder";
                break;
            case 2:
                whatToMake = "ClotheBag";
                break;
            case 3:
                whatToMake = "PenHolder";
                break;
            case 4:
                whatToMake = "PlasticPot";
                break;

        }

        randomGoal1Project[projectToMake].SetActive(true);
    }
}
