using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationOpener : MonoBehaviour
{
    public GameObject[] InformationPanels;
    InfoLockManager infoLockManager;
    public Button[] GaryBtns, CoralineBtns, PamBtns, DianeBtns, MalachiBtns, MariBtns, OscarBtns;
    [SerializeField]
    int GaryInfoUnlocked, CoralineInfoUnlocked, PamInfoUnlocked, DianeInfoUnlocked, MalachiInfoUnlocked, MariInfoUnlocked, OscarInfoUnlocked;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 3; i++){
            InformationPanels[i].SetActive(false);
            GaryBtns[i].interactable = false;
            CoralineBtns[i].interactable = false;
            PamBtns[i].interactable = false;
            DianeBtns[i].interactable = false;
            MalachiBtns[i].interactable = false;
            MariBtns[i].interactable = false;
            OscarBtns[i].interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetBondsUnlocked();
        for(int i = 0; i < GaryInfoUnlocked; i++){
            switch(GaryInfoUnlocked){
                case 1: GaryBtns[i].interactable = true; break;
                case 2: GaryBtns[i].interactable = true; break;
                case 3: GaryBtns[i].interactable = true; break;
            }
        }
        for(int i = 0; i < CoralineInfoUnlocked; i++){
            switch(CoralineInfoUnlocked){
                case 1: CoralineBtns[i].interactable = true; break;
                case 2: CoralineBtns[i].interactable = true; break;
                case 3: CoralineBtns[i].interactable = true; break;
            }
        }
        for(int i = 0; i < PamInfoUnlocked; i++){
            switch(PamInfoUnlocked){
                case 1: PamBtns[i].interactable = true; break;
                case 2: PamBtns[i].interactable = true; break;
                case 3: PamBtns[i].interactable = true; break;
            }
        }
        for(int i = 0; i < DianeInfoUnlocked; i++){
            switch(DianeInfoUnlocked){
                case 1: DianeBtns[i].interactable = true; break;
                case 2: DianeBtns[i].interactable = true; break;
                case 3: DianeBtns[i].interactable = true; break;
            }
        }
        for(int i = 0; i < MalachiInfoUnlocked; i++){
            switch(MalachiInfoUnlocked){
                case 1: MalachiBtns[i].interactable = true; break;
                case 2: MalachiBtns[i].interactable = true; break;
                case 3: MalachiBtns[i].interactable = true; break;
            }
        }
        for(int i = 0; i < MariInfoUnlocked; i++){
            switch(MariInfoUnlocked){
                case 1: MariBtns[i].interactable = true; break;
                case 2: MariBtns[i].interactable = true; break;
                case 3: MariBtns[i].interactable = true; break;
            }
        }
        for(int i = 0; i < OscarInfoUnlocked; i++){
            switch(OscarInfoUnlocked){
                case 1: OscarBtns[i].interactable = true; break;
                case 2: OscarBtns[i].interactable = true; break;
                case 3: OscarBtns[i].interactable = true; break;
            }
        }
    }

    public void SetBondsUnlocked(){
        GaryInfoUnlocked = InfoLockManager.infoLock.GetGaryBondUnlocked();
        CoralineInfoUnlocked = InfoLockManager.infoLock.GetCoralineBondUnlocked();
        PamInfoUnlocked = InfoLockManager.infoLock.GetPamBondUnlocked();
        DianeInfoUnlocked = InfoLockManager.infoLock.GetDianeBondUnlocked();
        MalachiInfoUnlocked = InfoLockManager.infoLock.GetMalachiBondUnlocked();
        MariInfoUnlocked = InfoLockManager.infoLock.GetMariBondUnlocked();
        OscarInfoUnlocked = InfoLockManager.infoLock.GetOscarBondUnlocked();
    }

    public void OpenInfoPanel(int value){
        InformationPanels[value].SetActive(true);
    }

    public void CloseInfoPanel(int value){
        InformationPanels[value].SetActive(false);
    }
}

