using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MapDisplay : MonoBehaviour
{
    [SerializeField] private Image mapImage;
    [SerializeField] private Button playButton;
    [SerializeField] private TextMeshProUGUI lockedStatus;
    [SerializeField] private TextMeshProUGUI reqStatus;

    public void DisplayMap(Map _map)
    {
        mapImage.sprite = _map.mapImage;

        bool mapUnlocked = PlayerPrefs.GetInt("currentScene", 0) >= _map.mapIndex;
        lockedStatus.enabled = !mapUnlocked;
        reqStatus.enabled = !mapUnlocked;
        playButton.interactable = mapUnlocked;

        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(()=> SceneManager.LoadScene(_map.sceneToLoad.name));
    }
}
