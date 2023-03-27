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
        unlockedLevelsNumber = PlayerPrefs.GetInt("levelsUnlocked");

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
        
        unlockedLevelsNumber = LevelManager.level.GetArea1Unlocked();
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
