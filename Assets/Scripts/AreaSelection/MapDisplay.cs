using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MapDisplay : MonoBehaviour
{
    LevelManager level;
    InfoLockManager infolock;
    ScriptableObjectChanger scriptableObjectChanger;
    [SerializeField] private Image mapImage;
    [SerializeField] private Button playButton;
    [SerializeField] private TextMeshProUGUI lockedStatus;
    [SerializeField] private TextMeshProUGUI reqStatus;
    private int currentScene;

    void Start(){
        scriptableObjectChanger = FindObjectOfType<ScriptableObjectChanger>();
        infolock = FindObjectOfType<InfoLockManager>();
        currentScene = 0;
    }

    void Update(){
        if(scriptableObjectChanger.GetCurrentIndex() == 6 || scriptableObjectChanger.GetCurrentIndex() == 7){
            reqStatus.text = "DISCOVER THE CONDITIONS TO UNLOCK SECRET AREAS";
        }
        else{
            reqStatus.text = "COMPLETE PREVIOUS AREA FIRST";
        }

        //// unlock areas

        if(LevelManager.level.GetArea2Unlocked() >= 1 && LevelManager.level.GetArea3Unlocked() <= 0){
            currentScene = 1;
        }
        else if(LevelManager.level.GetArea3Unlocked() >= 1 && LevelManager.level.GetArea4Unlocked() <= 0){
            currentScene = 2;
        }
        else if(LevelManager.level.GetArea4Unlocked() >= 1 && LevelManager.level.GetArea5Unlocked() <= 0){
            currentScene = 3;
        }
        else if(LevelManager.level.GetArea5Unlocked() >= 1 && LevelManager.level.GetArea6Unlocked() <= 0){
            currentScene = 4;
        }
        else if(LevelManager.level.GetArea6Unlocked() >= 1){
            currentScene = 5;
        }
        else if(infolock.GetGaryBondUnlocked() >= 3 && infolock.GetDianeBondUnlocked() >= 3){
            currentScene = 7;
        }
    }

    public void DisplayMap(Map _map)
    {
        mapImage.sprite = _map.mapImage;
        string sceneToLoad = _map.sceneToLoad;

        bool mapUnlocked = currentScene >= _map.mapIndex;
        lockedStatus.enabled = !mapUnlocked;
        reqStatus.enabled = !mapUnlocked;
        playButton.interactable = mapUnlocked;

        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(()=> SceneManager.LoadScene(sceneToLoad));
    }
}
