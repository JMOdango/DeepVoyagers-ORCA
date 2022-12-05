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
    public TextMeshProUGUI coinsValueText, shellsValueText;

    void Start(){
        GetVirtualCurrencies();
    }
    private void Awake(){
        VC = this;
    }
    
    public void GetVirtualCurrencies(){
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetUserInventorySuccess, error => Debug.LogError(error.GenerateErrorReport()));
    }

    void OnGetUserInventorySuccess(GetUserInventoryResult result){
        int coins = result.VirtualCurrency["CN"];
        coinsValueText.text = coins.ToString();

        int shells = result.VirtualCurrency["SH"];
        shellsValueText.text = shells.ToString();
    }

    void currencyError(PlayFabError error){
        Debug.Log(error.ErrorMessage);
    }
};



