using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCharNotif : MonoBehaviour
{
    LevelManager levelManager;
    public GameObject newCharPanel;

    void Start(){
        levelManager = FindObjectOfType<LevelManager>();
        newCharPanel.SetActive(false);
    }

    void Update(){
        if(LevelManager.level.GetArea2Unlocked() == 1){
            newCharPanel.SetActive(true);
        }
        if(LevelManager.level.GetArea3Unlocked() == 1){
            newCharPanel.SetActive(false);
        }
        if(LevelManager.level.GetArea4Unlocked() == 1){
            newCharPanel.SetActive(false);
        }
        if(LevelManager.level.GetArea5Unlocked() == 1){
            newCharPanel.SetActive(false);
        }
        if(LevelManager.level.GetFinalAreaUnlocked() == 1){
            newCharPanel.SetActive(false);
        }
        if(LevelManager.level.GetFinalAreaUnlocked() == 5){
            newCharPanel.SetActive(false);
        }
    }
}
