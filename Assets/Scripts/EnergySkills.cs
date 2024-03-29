using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class EnergySkills : MonoBehaviour
{
    public InventoryManager inventoryManager;  
    public GameObject smallEnergyPanel;
    public GameObject mediumEnergyPanel;
    public GameObject largeEnergyPanel;

    public void Start(){
        inventoryManager = FindObjectOfType<InventoryManager>();
    }
    
    void OnAddCoinsSuccess(ModifyUserVirtualCurrencyResult result){
        VirtualCurrency.virtualCurrency.GetVirtualCurrencies();
    }

    void OnError(PlayFabError error){
        Debug.Log("Error: " + error.ErrorMessage);
    }

    //small energy 

    public void UseSmallEnergy()
    {
        var request = new AddUserVirtualCurrencyRequest{
                VirtualCurrency = "EN",
                Amount = 20
        };
        PlayFabClientAPI.AddUserVirtualCurrency(request, OnAddCoinsSuccess, OnError);
        inventoryManager.ReduceInventory("smallenergy");
        smallEnergyPanel.SetActive(false);
    }
    //medium energy 

    public void UseMediumEnergy()
    {
        var request = new AddUserVirtualCurrencyRequest{
                VirtualCurrency = "EN",
                Amount = 40
        };
        PlayFabClientAPI.AddUserVirtualCurrency(request, OnAddCoinsSuccess, OnError);
        inventoryManager.ReduceInventory("mediumenergy");
        mediumEnergyPanel.SetActive(false);
    }

    //medium energy 
    
    public void UseLargeEnergy()
    {
        var request = new AddUserVirtualCurrencyRequest{
                VirtualCurrency = "EN",
                Amount = 100
        };
        PlayFabClientAPI.AddUserVirtualCurrency(request, OnAddCoinsSuccess, OnError);
        inventoryManager.ReduceInventory("largeenergy");
        largeEnergyPanel.SetActive(false);
    }
}
