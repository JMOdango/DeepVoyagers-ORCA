using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class VirtualCurrency : MonoBehaviour
{
    public static VirtualCurrency virtualCurrency;
    CurrencyManager currencyManager;
    PlayFabManager playFab;
    // public TextMeshProUGUI coinsValueText, shellsValueText, energyValueText, 
    // public TextMeshProUGUI energyRechargeTimeText;
    [SerializeField]
    float secondsLeftToRefreshEnergy = 1;
    [SerializeField]
    private int coins, shells, energy;
    System.TimeSpan time;

    void Start(){
        GetVirtualCurrencies();
    }
    
    private void Awake(){
        if(virtualCurrency == null)
        {
            virtualCurrency = this;
        }
        else
        {
            if(virtualCurrency != this){
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update(){
        secondsLeftToRefreshEnergy -= Time.deltaTime;
        time = System.TimeSpan.FromSeconds(secondsLeftToRefreshEnergy);
        // energyRechargeTimeText.text = time.ToString("mm' : 'ss");
        if(secondsLeftToRefreshEnergy <= 0){
            GetVirtualCurrencies();
        }
        CurrencyManager.currencyManager.SetCoins(coins);
        CurrencyManager.currencyManager.SetShells(shells);
        CurrencyManager.currencyManager.SetStamina(energy);
        CurrencyManager.currencyManager.SetTimer(secondsLeftToRefreshEnergy);
    }
    
    public void GetVirtualCurrencies(){
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetUserInventorySuccess, error => Debug.LogError(error.GenerateErrorReport()));
    }

    void OnGetUserInventorySuccess(GetUserInventoryResult result){
        coins = result.VirtualCurrency["CN"];

        shells = result.VirtualCurrency["SH"];

        energy = result.VirtualCurrency["EN"];
        secondsLeftToRefreshEnergy = result.VirtualCurrencyRechargeTimes["EN"].SecondsToRecharge;
    }

    void currencyError(PlayFabError error){
        Debug.Log(error.ErrorMessage);
    }
};


