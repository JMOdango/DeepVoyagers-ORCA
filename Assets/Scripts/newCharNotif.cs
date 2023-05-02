using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCharNotif : MonoBehaviour
{
    LevelManager levelManager;
    public GameObject newCharPanel;
    bool isEnabled = false;

    void Start(){
        levelManager = FindObjectOfType<LevelManager>();
        newCharPanel.SetActive(false);
    }

    void Update(){
        if(LevelManager.level.GetArea2Unlocked() == 1 && PlayerPrefs.GetInt("newCharcounter1") == 0){
            if(!isEnabled)
            {
                newCharPanel.SetActive(true);
                isEnabled = true;
                PlayerPrefs.SetInt("newCharcounter1", 1);
            }
        }
        if(LevelManager.level.GetArea3Unlocked() == 1 && PlayerPrefs.GetInt("newCharcounter2") == 0){
            if(!isEnabled)
            {
                newCharPanel.SetActive(true);
                isEnabled = true;
                PlayerPrefs.SetInt("newCharcounter2", 1);
            }
        }
        if(LevelManager.level.GetArea4Unlocked() == 1 && PlayerPrefs.GetInt("newCharcounter3") == 0){
            if(!isEnabled)
            {
                newCharPanel.SetActive(true);
                isEnabled = true;
                PlayerPrefs.SetInt("counter3", 1);
            }
        }
        if(LevelManager.level.GetArea5Unlocked() == 1 && PlayerPrefs.GetInt("newCharcounter4") == 0){
            if(!isEnabled)
            {
                newCharPanel.SetActive(true);
                isEnabled = true;
                PlayerPrefs.SetInt("newCharcounter4", 1);
            }
        }
        if(LevelManager.level.GetFinalAreaUnlocked() == 1 && PlayerPrefs.GetInt("newCharcounter5") == 0){
            if(!isEnabled)
            {
                newCharPanel.SetActive(true);
                isEnabled = true;
                PlayerPrefs.SetInt("newCharcounter5", 1);
            }
        }
        if(LevelManager.level.GetFinalAreaUnlocked() == 5 && PlayerPrefs.GetInt("newCharcounter6") == 0){
            if(!isEnabled)
            {
                newCharPanel.SetActive(true);
                isEnabled = true;
                PlayerPrefs.SetInt("newCharcounter6", 1);
            }
        }
    }

    public void closeNotif(){
        newCharPanel.SetActive(false);
        isEnabled = false;
    }
}
