using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class ItemToBuy : MonoBehaviour
{
    public string itemName;
    public int itemPrice;

    public void BuyPowerup(){
        var request = new SubtractUserVirtualCurrencyRequest{
            VirtualCurrency = "SH",
            Amount = itemPrice
        };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnSubtractCoinsSuccess, OnError);
    }

     public void BuyGift(){
        var request = new SubtractUserVirtualCurrencyRequest{
            VirtualCurrency = "CN",
            Amount = itemPrice
        };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnSubtractCoinsSuccess, OnError);
    }

    void OnSubtractCoinsSuccess(ModifyUserVirtualCurrencyResult result){
        switch(itemName){
            case "smallenergy": break;
        }
        VirtualCurrency.VC.GetVirtualCurrencies();
    }

    void OnError(PlayFabError error){
        Debug.Log("Error: " + error.ErrorMessage);
    }
}
