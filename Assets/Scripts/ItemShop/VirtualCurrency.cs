using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class VirtualCurrency : MonoBehaviour
{
    public static VirtualCurrency VC;
    PlayFabManager playFab;
    public TextMeshProUGUI coinsValueText, shellsValueText, energyValueText, energyRechargeTimeText;
    float secondsLeftToRefreshEnergy = 1;

    void Start(){
        GetVirtualCurrencies();
    }
    
    private void Awake(){
        VC = this;
    }

    private void Update(){
        secondsLeftToRefreshEnergy -= Time.deltaTime;
        System.TimeSpan time = System.TimeSpan.FromSeconds(secondsLeftToRefreshEnergy);
        energyRechargeTimeText.text = time.ToString("mm' : 'ss");
        if(secondsLeftToRefreshEnergy < 0){
            GetVirtualCurrencies();
        }
    }
    
    public void GetVirtualCurrencies(){
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetUserInventorySuccess, error => Debug.LogError(error.GenerateErrorReport()));
    }

    void OnGetUserInventorySuccess(GetUserInventoryResult result){
        int coins = result.VirtualCurrency["CN"];
        coinsValueText.text = coins.ToString();

        int shells = result.VirtualCurrency["SH"];
        shellsValueText.text = shells.ToString();

        int energy = result.VirtualCurrency["EN"];
        energyValueText.text = energy.ToString();
        secondsLeftToRefreshEnergy = result.VirtualCurrencyRechargeTimes["EN"].SecondsToRecharge;
    }

    void currencyError(PlayFabError error){
        Debug.Log(error.ErrorMessage);
    }
};



