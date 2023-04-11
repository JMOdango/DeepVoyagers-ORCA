using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using TMPro;

public class ItemToMake : MonoBehaviour
{
    public Animator notifanim;
    public TextMeshProUGUI notif;
    TrashCollectionManager trashCollectionManager;
    InventoryManager inventory;
    public string itemName;
    public int itemReq;
    private int fertilizer, penholder, plasticpot, birdfeeder, clothebag;
    private int plasticLeft, glassLeft, metalLeft, organicLeft, fabricLeft;
    public GameObject NoMaterialsPanel;

    public void Start(){
        NoMaterialsPanel.SetActive(false);
    }

    public void Update(){
        plasticLeft = TrashCollectionManager.trashCollectionManager.GetPlasticLeft();
        glassLeft = TrashCollectionManager.trashCollectionManager.GetGlassLeft();
        metalLeft = TrashCollectionManager.trashCollectionManager.GetMetalLeft();
        organicLeft = TrashCollectionManager.trashCollectionManager.GetOrganicLeft();
        fabricLeft = TrashCollectionManager.trashCollectionManager.GetFabricLeft();
    }

    public void MakeFertilizer(){
        if(organicLeft < itemReq)
        {
            NoMaterialsPanel.SetActive(true);
        }
        else
        {
            var request = new SubtractUserVirtualCurrencyRequest{
                VirtualCurrency = "OR",
                Amount = itemReq
            };
            PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnSubtractCoinsSuccess, OnError);

            fertilizer++;
            InventoryManager.inventory.AddInventory(itemName);
            notif.text = "Organic Fertilizer added to inventory!";
            notifanim.SetBool("playNotif",true); 
        }
    }

    public void MakePenHolder(){
        if(metalLeft < itemReq)
        {
            NoMaterialsPanel.SetActive(true);
        }
        else
        {
            var request = new SubtractUserVirtualCurrencyRequest{
                VirtualCurrency = "ME",
                Amount = itemReq
            };
            PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnSubtractCoinsSuccess, OnError);

            penholder++;
            InventoryManager.inventory.AddInventory(itemName);
            notif.text = "Pen Holder added to inventory!";
            notifanim.SetBool("playNotif",true); 
        }
    }

    public void MakePlasticPot(){
        if(plasticLeft < itemReq)
        {
            NoMaterialsPanel.SetActive(true);
        }
        else
        {
            var request = new SubtractUserVirtualCurrencyRequest{
                VirtualCurrency = "PL",
                Amount = itemReq
            };
            PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnSubtractCoinsSuccess, OnError);

            plasticpot++;
            InventoryManager.inventory.AddInventory(itemName);
            notif.text = "Plastic Pot added to inventory!";
            notifanim.SetBool("playNotif",true); 
        }
    }

    public void MakeBirdFeeder(){
        if(fabricLeft < itemReq || metalLeft < itemReq)
        {
            NoMaterialsPanel.SetActive(true);
        }
        else
        {
            var request = new SubtractUserVirtualCurrencyRequest{
                VirtualCurrency = "FA",
                Amount = itemReq
            };
            PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnSubtractCoinsSuccess, OnError);

            var request1 = new SubtractUserVirtualCurrencyRequest{
                VirtualCurrency = "ME",
                Amount = itemReq
            };
            PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnSubtractCoinsSuccess, OnError);

            birdfeeder++;
            InventoryManager.inventory.AddInventory(itemName);
            notif.text = "Bird Feeder added to inventory!";
            notifanim.SetBool("playNotif",true); 
        }
    }

    public void MakeClotheBag(){
        if(fabricLeft < itemReq)
        {
            NoMaterialsPanel.SetActive(true);
        }
        else
        {
            var request = new SubtractUserVirtualCurrencyRequest{
                VirtualCurrency = "FA",
                Amount = itemReq
            };
            PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnSubtractCoinsSuccess, OnError);

            clothebag++;
            InventoryManager.inventory.AddInventory(itemName);
            notif.text = "Clothe Bag added to inventory!";
            notifanim.SetBool("playNotif",true); 
        }
    }
     

    void OnSubtractCoinsSuccess(ModifyUserVirtualCurrencyResult result){
        VirtualCurrency.virtualCurrency.GetVirtualCurrencies();
    }

    void OnError(PlayFabError error){
        Debug.Log("Error: " + error.ErrorMessage);
    }

    public void CloseNoMaterials()
    {
        NoMaterialsPanel.SetActive(false);
    }
}