using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class BondsCompleted
{
    public int garyBond, coralineBond, pamBond, dianeBond, malachiBond, oscarBond, mariBond;

    public BondsCompleted(
        int garyBond,
        int coralineBond, 
        int pamBond, 
        int dianeBond, 
        int malachiBond,
        int oscarBond,
        int mariBond
    ){
        this.garyBond = garyBond;
        this.coralineBond = coralineBond;
        this.pamBond = pamBond;
        this.dianeBond = dianeBond;
        this.malachiBond = malachiBond;
        this.oscarBond = oscarBond;
        this.mariBond = mariBond;
    }
}

public class InfoLockManager : MonoBehaviour
{
    public static InfoLockManager infoLock;
    public InfoLockManager[] infoLockManager;
    
    [SerializeField]
    private int garyBondUnlocked, coralineBondUnlocked, pamBondUnlocked, dianeBondUnlocked, malachiBondUnlocked, oscarBondUnlocked, mariBondUnlocked;

    public BondsCompleted ReturnClass(){
        return new BondsCompleted(garyBondUnlocked,
        coralineBondUnlocked,
        pamBondUnlocked,
        dianeBondUnlocked,
        malachiBondUnlocked,
        oscarBondUnlocked,
        mariBondUnlocked
        );
    }

    public void Start(){
    
    }

    public void Awake(){
        if(infoLock == null)
        {
            infoLock = this;
        }
        else
        {
            if(infoLock != this){
                Destroy(this.gameObject);
            }
        }
        GetBondsUnlocked();
    }

    public void Update(){
        
    }

    public void unlockGaryBonds(int unlocked){
        switch(unlocked){
            case 1: 
                if(garyBondUnlocked == 0)
                garyBondUnlocked = 1; 
            break;
            case 2: 
                if(garyBondUnlocked <= 1)
                garyBondUnlocked = 2; 
            break;
            case 3: 
                if(garyBondUnlocked <= 2)
                garyBondUnlocked = 3;  
            break;
        }
        SaveBondsUnlocked();
    }

    public void SetCount(BondsCompleted infoLock){
        garyBondUnlocked = infoLock.garyBond;
        coralineBondUnlocked = infoLock.coralineBond;
        pamBondUnlocked = infoLock.pamBond;
        dianeBondUnlocked = infoLock.dianeBond;
        malachiBondUnlocked = infoLock.malachiBond;
        oscarBondUnlocked = infoLock.oscarBond;
        mariBondUnlocked = infoLock.mariBond;
    }

    public int GetGaryBondUnlocked(){
        return garyBondUnlocked;
    }

    public int GetCoralineBondUnlocked(){
        return coralineBondUnlocked;
    }

    public int GetPamBondUnlocked(){
        return pamBondUnlocked;
    }

    public int GetDianeBondUnlocked(){
        return dianeBondUnlocked;
    }

    public int GetMalachiBondUnlocked(){
        return malachiBondUnlocked;
    }

    public int GetOscarBondUnlocked(){
        return oscarBondUnlocked;
    }

    public int GetMariBondUnlocked(){
        return mariBondUnlocked;
    }

    

    public void SaveBondsUnlocked(){
        List<BondsCompleted> bonds = new List<BondsCompleted>();
        foreach (var infoLock in infoLockManager){
            bonds.Add(infoLock.ReturnClass());
        }
        var request = new UpdateUserDataRequest{
            Data = new Dictionary<string, string>{
                {"BondsCompleted", JsonConvert.SerializeObject(bonds)}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, 
            error => Debug.LogError(error.GenerateErrorReport())
        );
    }

    public void OnDataSend(UpdateUserDataResult result){
        Debug.Log("User data successfully sent.");
    }

    public void GetBondsUnlocked(){
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnInventoryDataReceived, 
        error => Debug.LogError(error.GenerateErrorReport()));
    }

    void OnInventoryDataReceived(GetUserDataResult result){
        Debug.Log("Received inventory data");
        if(result.Data != null && result.Data.ContainsKey("BondsCompleted")){List<BondsCompleted> bonds = JsonConvert.DeserializeObject<List<BondsCompleted>>(result.Data["BondsCompleted"].Value);
            for(int i = 0; i < infoLockManager.Length; i++){
                infoLockManager[i].SetCount(bonds[i]);
            }
        }
    }
}
   
