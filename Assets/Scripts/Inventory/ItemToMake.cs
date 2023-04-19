using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.UI;

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
    private float timeToWait = 3f;
    public Button btn;

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
        ClickButton();
        
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
        ClickButton();

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
        ClickButton();

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
        ClickButton();

        if(fabricLeft < itemReq && metalLeft < itemReq)
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
        ClickButton();

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

    public void ClickButton()
    {
        // do not start the function if we are already in the process
        if (IsInvoking("ReEnableButton"))
            return;

        // disable our button interactability
        btn.interactable = false;

        // call our function ReenableButton in timeToWait seconds
        Invoke("ReEnableButton", timeToWait);
    }
    
    private void ReEnableButton()
    {
        // re-enable the button
        btn.interactable = true;
    }
}