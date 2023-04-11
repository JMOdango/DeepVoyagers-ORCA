using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MapDisplay : MonoBehaviour
{
    LevelManager level;
    [SerializeField] private Image mapImage;
    [SerializeField] private Button playButton;
    [SerializeField] private TextMeshProUGUI lockedStatus;
    [SerializeField] private TextMeshProUGUI reqStatus;
    private int currentScene;

    void Start(){
        currentScene = 0;
    }

    void Update(){
        if(LevelManager.level.GetArea2Unlocked() >= 1){
            currentScene = 1;
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
