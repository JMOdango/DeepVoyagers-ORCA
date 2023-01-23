using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;

public class ItemToBuy : MonoBehaviour
{
    InventoryManager inventory;
    public string itemName;
    public int itemPrice;
    private int smallenergy, mediumenergy, largeenergy, mysterysnack, magnet, neptunestrident, voidgem, net, fungi, pocketwatch, mermaidsorb, basket;
    private int stufftoy, waterproofcamera, map, historybook, seaweed, crystals, toyfigure;
    private int shellsLeft, coinsLeft;
    public GameObject NoCurrencyPanel;

    public void Start(){
        NoCurrencyPanel.SetActive(false);
    }

    public void Update(){
        shellsLeft = CurrencyManager.currencyManager.GetShellsLeft();
        coinsLeft = CurrencyManager.currencyManager.GetShellsLeft();
    }

    public void BuyPowerup(){
        if(shellsLeft < itemPrice)
        {
            NoCurrencyPanel.SetActive(true);
        }
        else
        {
            var request = new SubtractUserVirtualCurrencyRequest{
                VirtualCurrency = "SH",
                Amount = itemPrice
            };
            PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnSubtractCoinsSuccess, OnError);

            switch(itemName){
                case "smallenergy": 
                smallenergy++;
                InventoryManager.inventory.AddInventory(itemName);
                break;
                case "mediumenergy": 
                mediumenergy++;
                InventoryManager.inventory.AddInventory(itemName);
                break;
                case "largeenergy": 
                largeenergy++;
                InventoryManager.inventory.AddInventory(itemName);
                break;
                case "mysterysnack": 
                mysterysnack++;
                InventoryManager.inventory.AddInventory(itemName);
                break;
                case "magnet": 
                magnet++;
                InventoryManager.inventory.AddInventory(itemName);
                break;
                case "neptunestrident": 
                neptunestrident++; 
                InventoryManager.inventory.AddInventory(itemName);
                break;
                case "voidgem": 
                voidgem++; 
                InventoryManager.inventory.AddInventory(itemName);
                break;
                case "net": 
                net++; 
                InventoryManager.inventory.AddInventory(itemName);
                break;
                case "fungi": 
                fungi++; 
                InventoryManager.inventory.AddInventory(itemName);
                break;
                case "pocketwatch": 
                pocketwatch++; 
                InventoryManager.inventory.AddInventory(itemName);
                break;
                case "mermaidsorb": 
                mermaidsorb++; 
                InventoryManager.inventory.AddInventory(itemName);
                break;
                case "basket": 
                basket++; 
                InventoryManager.inventory.AddInventory(itemName);
                break;
            }
        }
    }

     public void BuyGift(){
        if(shellsLeft < itemPrice)
        {
            NoCurrencyPanel.SetActive(true);
        }
        else
        {
            var request = new SubtractUserVirtualCurrencyRequest{
                VirtualCurrency = "CN",
                Amount = itemPrice
            };
            PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnSubtractCoinsSuccess, OnError);

            switch(itemName){
                case "stufftoy": 
                stufftoy++;
                InventoryManager.inventory.AddInventory(itemName);
                break;
                case "waterproofcamera": 
                waterproofcamera++;
                InventoryManager.inventory.AddInventory(itemName);
                break;
                case "map": 
                map++;
                InventoryManager.inventory.AddInventory(itemName);
                break;
                case "historybook": 
                historybook++;
                InventoryManager.inventory.AddInventory(itemName);
                break;
                case "seaweed": 
                seaweed++;
                InventoryManager.inventory.AddInventory(itemName);
                break;
                case "crystals": 
                crystals++; 
                InventoryManager.inventory.AddInventory(itemName);
                break;
                case "toyfigure": 
                toyfigure++; 
                InventoryManager.inventory.AddInventory(itemName);
                break;
            }
        }
    }

    void OnSubtractCoinsSuccess(ModifyUserVirtualCurrencyResult result){
        VirtualCurrency.virtualCurrency.GetVirtualCurrencies();
    }

    void OnError(PlayFabError error){
        Debug.Log("Error: " + error.ErrorMessage);
    }

    public void CloseNoCurrency()
    {
        NoCurrencyPanel.SetActive(false);
    }
}
