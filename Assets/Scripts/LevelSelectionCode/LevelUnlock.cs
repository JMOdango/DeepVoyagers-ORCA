using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUnlock : MonoBehaviour
{
    public static LevelUnlock levelunlock;
    LevelManager level;
    [SerializeField] Button[] buttons;
    int unlockedLevelsNumber;
    [SerializeField]
    int area1, area2, area3, area4, area5;

    void Start()
    {
        switch(SceneManager.GetActiveScene().name){
            case "Area1_LevelSelection": 
            unlockedLevelsNumber = LevelManager.level.GetArea1Unlocked();
            break; 
            case "Area2_LevelSelection": 
            unlockedLevelsNumber = LevelManager.level.GetArea2Unlocked();
            break; 
            case "Area3_LevelSelection": 
            unlockedLevelsNumber = LevelManager.level.GetArea3Unlocked();
            break; 
            case "Area4_LevelSelection": 
            unlockedLevelsNumber = LevelManager.level.GetArea4Unlocked();
            break; 
            case "Area5_LevelSelection":
            unlockedLevelsNumber = LevelManager.level.GetArea5Unlocked();
            break;
        }

        for(int i = 0; i < buttons.Length; i++){
            buttons[i].interactable = false;
        }
    }

    void Awake(){
        if(levelunlock == null)
        {
            levelunlock = this;
        }
        else
        {
            if(levelunlock != this){
                Destroy(this.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetLevels();
        
        switch(SceneManager.GetActiveScene().name){
            case "Area1_LevelSelection": 
            unlockedLevelsNumber = LevelManager.level.GetArea1Unlocked();
            break; 
            case "Area2_LevelSelection": 
            unlockedLevelsNumber = LevelManager.level.GetArea2Unlocked();
            break; 
            case "Area3_LevelSelection": 
            unlockedLevelsNumber = LevelManager.level.GetArea3Unlocked();
            break; 
            case "Area4_LevelSelection": 
            unlockedLevelsNumber = LevelManager.level.GetArea4Unlocked();
            break; 
            case "Area5_LevelSelection":
            unlockedLevelsNumber = LevelManager.level.GetArea5Unlocked();
            break;
        }
        
        for (int i = 0; i < unlockedLevelsNumber; i++){
            buttons[i].interactable = true;
        }
    }

    public void SetLevels(){
        area1 = LevelManager.level.GetArea1Unlocked();
        area2 = LevelManager.level.GetArea2Unlocked();
        area3 = LevelManager.level.GetArea3Unlocked();
        area4 = LevelManager.level.GetArea4Unlocked();
        area5 = LevelManager.level.GetArea5Unlocked();
    }
}
