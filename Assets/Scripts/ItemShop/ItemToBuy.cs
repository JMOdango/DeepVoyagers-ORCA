using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;

public class ItemToBuy : MonoBehaviour
{
    InventoryManager inventory;
    StoreAmount storeAmount;
    public string itemName;
    public int itemPrice;
    private int smallenergy,
    mediumenergy, 
    largeenergy, 
    mysterysnack, 
    magnet, 
    neptunestrident, 
    voidgem, 
    net, 
    fungi, 
    pocketwatch, 
    mermaidsorb, 
    basket;


    public void BuyPowerup(){
        var request = new SubtractUserVirtualCurrencyRequest{
            VirtualCurrency = "SH",
            Amount = itemPrice
        };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnSubtractCoinsSuccess, OnError);

        switch(itemName){
            case "smallenergy": 
            smallenergy++;
            StoreAmount.storeAmount.getSmallEnergy(smallenergy);
            break;
            case "mediumenergy": 
            mediumenergy++;
            StoreAmount.storeAmount.getMediumEnergy(mediumenergy);
            break;
            case "largeenergy": 
            largeenergy++;
            StoreAmount.storeAmount.getLargeEnergy(largeenergy);
            break;
            case "mysterysnack": 
            mysterysnack++;
            StoreAmount.storeAmount.getMysterySnack(mysterysnack);
            break;
            case "magnet": 
            magnet++;
            StoreAmount.storeAmount.getMagnet(magnet);
            break;
            case "neptunestrident": 
            neptunestrident++; 
            StoreAmount.storeAmount.getNeptunesTrident(neptunestrident);
            break;
            case "voidgem": 
            voidgem++; 
            StoreAmount.storeAmount.getVoidGem(voidgem);
            break;
            case "net": 
            net++; 
            StoreAmount.storeAmount.getNet(net);
            break;
            case "fungi": 
            fungi++; 
            StoreAmount.storeAmount.getFungi(fungi);
            break;
            case "pocketwatch": 
            pocketwatch++; 
            StoreAmount.storeAmount.getPocketWatch(pocketwatch);
            break;
            case "mermaidsorb": 
            mermaidsorb++; 
            StoreAmount.storeAmount.getMermaidsOrb(mermaidsorb);
            break;
            case "basket": 
            basket++; 
            StoreAmount.storeAmount.getBasket(basket);
            break;
        }
    }

    public void BuyGift(){
        var request = new SubtractUserVirtualCurrencyRequest{
            VirtualCurrency = "CN",
            Amount = itemPrice
        };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnSubtractCoinsSuccess, OnError);
    }

    void OnSubtractCoinsSuccess(ModifyUserVirtualCurrencyResult result){
        VirtualCurrency.virtualCurrency.GetVirtualCurrencies();
    }

    void OnError(PlayFabError error){
        Debug.Log("Error: " + error.ErrorMessage);
    }
}
