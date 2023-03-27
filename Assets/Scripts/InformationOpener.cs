using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationOpener : MonoBehaviour
{
    public GameObject[] InformationPanels;
    InfoLockManager infoLockManager;
    public Button[] InformationBtns;
    [SerializeField]
    int GaryInfoUnlocked;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < InformationPanels.Length; i++){
            InformationPanels[i].SetActive(false);
            InformationBtns[i].interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetBondsUnlocked();
        for(int i = 0; i < GaryInfoUnlocked; i++){
            switch(GaryInfoUnlocked){
                case 1: InformationBtns[i].interactable = true; break;
                case 2: InformationBtns[i].interactable = true; break;
                case 3: InformationBtns[i].interactable = true; break;
            }
        }
    }

    public void SetBondsUnlocked(){
        GaryInfoUnlocked = InfoLockManager.infoLock.GetGaryBondUnlocked();
    }

    public void OpenInfoPanel(int value){
        InformationPanels[value].SetActive(true);
    }

    public void CloseInfoPanel(int value){
        InformationPanels[value].SetActive(false);
    }
}

