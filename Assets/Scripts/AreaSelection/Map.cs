using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Map", menuName = "Scriptable Objects/Maps")]

public class Map : ScriptableObject
{
    public int mapIndex;
    public Sprite mapImage;
    public string sceneToLoad; 
    // public bool isUnlock = false;
    // public GameObject lockGo;
    // public GameObject unlockGo;

    // private void Update()
    // {
    //     UpdateMapStatus();
    // }

    // private void UpdateMapStatus()
    // {
    //     if(isUnlock)
    //     {
    //         unlockGo.gameObject.SetActive(true);
    //         lockGo.gameObject.SetActive(false);
    //     }
    //     else
    //     {
    //         unlockGo.gameObject.SetActive(false);
    //         lockGo.gameObject.SetActive(true);
    //     }
    // }
    
}
