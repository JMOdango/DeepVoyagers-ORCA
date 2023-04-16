using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.UI;

public class ItemToBuy : MonoBehaviour
{
    public Animator notifanim;
    public TextMeshProUGUI notif;
    InventoryManager inventory;
    public string itemName;
    public int itemPrice;
    [SerializeField]
    public Button btn;
    private int smallenergy, mediumenergy, largeenergy, mysterysnack, magnet, neptunestrident, voidgem, net, fungi, pocketwatch, mermaidsorb, basket;
    private int stufftoy, waterproofcamera, map, historybook, seaweed, crystals, toyfigure;
    private int shellsLeft, coinsLeft;
    public GameObject NoCurrencyPanel;
    private float timeToWait = 2f;

    public void Start(){
        NoCurrencyPanel.SetActive(false);
    }

    public void Update(){
        shellsLeft = CurrencyManager.currencyManager.GetShellsLeft();
        coinsLeft = CurrencyManager.currencyManager.GetCoinsLeft();
    }

    public void BuyPowerup(){
        ClickButton();

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
                notif.text = "Successfully purchased!";
                notifanim.SetBool("playNotif",true); 
                break;
                case "mediumenergy": 
                mediumenergy++;
                InventoryManager.inventory.AddInventory(itemName);
                notif.text = "Successfully purchased!";
                notifanim.SetBool("playNotif",true); 
                break;
                case "largeenergy": 
                largeenergy++;
                InventoryManager.inventory.AddInventory(itemName);
                notif.text = "Successfully purchased!";
                notifanim.SetBool("playNotif",true); 
                break;
                case "mysterysnack": 
                mysterysnack++;
                InventoryManager.inventory.AddInventory(itemName);
                notif.text = "Successfully purchased!";
                notifanim.SetBool("playNotif",true); 
                break;
                case "magnet": 
                magnet++;
                InventoryManager.inventory.AddInventory(itemName);
                notif.text = "Successfully purchased!";
                notifanim.SetBool("playNotif",true); 
                break;
                case "neptunestrident": 
                neptunestrident++; 
                InventoryManager.inventory.AddInventory(itemName);
                notif.text = "Successfully purchased!";
                notifanim.SetBool("playNotif",true); 
                break;
                case "voidgem": 
                voidgem++; 
                InventoryManager.inventory.AddInventory(itemName);
                notif.text = "Successfully purchased!";
                notifanim.SetBool("playNotif",true); 
                break;
                case "net": 
                net++; 
                InventoryManager.inventory.AddInventory(itemName);
                notif.text = "Successfully purchased!";
                notifanim.SetBool("playNotif",true); 
                break;
                case "fungi": 
                fungi++; 
                InventoryManager.inventory.AddInventory(itemName);
                notif.text = "Successfully purchased!";
                notifanim.SetBool("playNotif",true); 
                break;
                case "pocketwatch": 
                pocketwatch++; 
                InventoryManager.inventory.AddInventory(itemName);
                notif.text = "Successfully purchased!";
                notifanim.SetBool("playNotif",true); 
                break;
                case "mermaidsorb": 
                mermaidsorb++; 
                InventoryManager.inventory.AddInventory(itemName);
                notif.text = "Successfully purchased!";
                notifanim.SetBool("playNotif",true); 
                break;
                case "basket": 
                basket++; 
                InventoryManager.inventory.AddInventory(itemName);
                notif.text = "Successfully purchased!";
                notifanim.SetBool("playNotif",true); 
                break;
            }
        }
    }

     public void BuyGift(){
        ClickButton();

        if(coinsLeft < itemPrice)
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
                notif.text = "Successfully purchased!";
                notifanim.SetBool("playNotif",true); 
                break;
                case "waterproofcamera": 
                waterproofcamera++;
                InventoryManager.inventory.AddInventory(itemName);
                notif.text = "Successfully purchased!";
                notifanim.SetBool("playNotif",true); 
                break;
                case "map": 
                map++;
                InventoryManager.inventory.AddInventory(itemName);
                notif.text = "Successfully purchased!";
                notifanim.SetBool("playNotif",true); 
                break;
                case "historybook": 
                historybook++;
                InventoryManager.inventory.AddInventory(itemName);
                notif.text = "Successfully purchased!";
                notifanim.SetBool("playNotif",true); 
                break;
                case "seaweed": 
                seaweed++;
                InventoryManager.inventory.AddInventory(itemName);
                notif.text = "Successfully purchased!";
                notifanim.SetBool("playNotif",true); 
                break;
                case "crystals": 
                crystals++; 
                InventoryManager.inventory.AddInventory(itemName);
                notif.text = "Successfully purchased!";
                notifanim.SetBool("playNotif",true); 
                break;
                case "toyfigure": 
                toyfigure++; 
                InventoryManager.inventory.AddInventory(itemName);
                notif.text = "Successfully purchased!";
                notifanim.SetBool("playNotif",true); 
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
