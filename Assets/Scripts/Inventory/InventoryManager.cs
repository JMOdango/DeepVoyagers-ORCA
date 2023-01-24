using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;

public class Inventory{
    public int smallenergy,
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
    public int stufftoy, 
    waterproofcamera, 
    map, 
    historybook, 
    seaweed, 
    crystals, 
    toyfigure;

    public Inventory(
        int smallenergy,
        int mediumenergy, 
        int largeenergy, 
        int mysterysnack, 
        int magnet, 
        int neptunestrident, 
        int voidgem, 
        int net, 
        int fungi, 
        int pocketwatch,
        int mermaidsorb,
        int basket,
        int stufftoy, 
        int waterproofcamera, 
        int map, 
        int historybook, 
        int seaweed, 
        int crystals, 
        int toyfigure
    ){
        this.smallenergy = smallenergy;
        this.mediumenergy = mediumenergy;
        this.largeenergy = largeenergy;
        this.mysterysnack = mysterysnack;
        this.magnet = magnet;
        this.neptunestrident = neptunestrident;
        this.voidgem = voidgem;
        this.net = net;
        this.fungi = fungi;
        this.pocketwatch = pocketwatch;
        this.mermaidsorb = mermaidsorb;
        this.basket = basket;
        this.stufftoy = stufftoy;
        this.waterproofcamera = waterproofcamera;
        this.map = map;
        this.historybook = historybook;
        this.seaweed = seaweed;
        this.crystals = crystals;
        this.toyfigure = toyfigure;
    }
}

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager inventory;
    InventoryUI inventoryUI;
    public InventoryManager[] inventoryManager;
    
    [SerializeField]
    private int smallenergycount, mediumenergycount, largeenergycount, mysterysnackcount, magnetcount, neptunestridentcount, voidgemcount, 
    netcount, fungicount, pocketwatchcount, mermaidsorbcount, basketcount;
    [SerializeField]
    private int stufftoycount, waterproofcameracount, mapcount, historybookcount, seaweedcount, crystalscount, toyfigurecount;

    public Inventory ReturnClass(){
        return new Inventory(smallenergycount, 
        mediumenergycount, 
        largeenergycount, 
        mysterysnackcount,
        magnetcount, 
        neptunestridentcount, 
        voidgemcount, 
        netcount, 
        fungicount, 
        pocketwatchcount, 
        mermaidsorbcount, 
        basketcount,
        stufftoycount, 
        waterproofcameracount, 
        mapcount, 
        historybookcount, 
        seaweedcount, 
        crystalscount, 
        toyfigurecount
        );
    }

    public void Start(){
        GetInventory();
    }

    public void Awake(){
        if(inventory == null)
        {
            inventory = this;
        }
        else
        {
            if(inventory != this){
                Destroy(this.gameObject);
            }
        }
    }

    public void SetUI()
    {
        InventoryUI.inventoryUI.SetUIPowerUps(smallenergycount, 
        mediumenergycount, 
        largeenergycount, 
        mysterysnackcount,
        magnetcount, 
        neptunestridentcount, 
        voidgemcount, 
        netcount, 
        fungicount, 
        pocketwatchcount, 
        mermaidsorbcount, 
        basketcount
        );
        
       InventoryUI.inventoryUI.SetUIGifts(stufftoycount, 
       waterproofcameracount, 
       mapcount, 
       historybookcount, 
       seaweedcount, 
       crystalscount, 
       toyfigurecount
       );
    }

    public void SetCount(Inventory inventory){
        smallenergycount = inventory.smallenergy;
        mediumenergycount = inventory.mediumenergy;
        largeenergycount = inventory.largeenergy;
        mysterysnackcount = inventory.mysterysnack;
        magnetcount = inventory.magnet;
        neptunestridentcount = inventory.neptunestrident;
        voidgemcount = inventory.voidgem;
        netcount = inventory.net;
        fungicount = inventory.fungi;
        pocketwatchcount = inventory.pocketwatch;
        mermaidsorbcount = inventory.mermaidsorb;
        basketcount = inventory.basket;
        stufftoycount = inventory.stufftoy;
        waterproofcameracount = inventory.waterproofcamera;
        mapcount = inventory.map;
        historybookcount = inventory.historybook;
        seaweedcount = inventory.seaweed;
        crystalscount = inventory.crystals;
        toyfigurecount = inventory.toyfigure;
    }

    public void SaveInventory(){
        List<Inventory> inventories = new List<Inventory>();
        foreach (var item in inventoryManager){
            inventories.Add(item.ReturnClass());
        }
        var request = new UpdateUserDataRequest{
            Data = new Dictionary<string, string>{
                {"Inventory", JsonConvert.SerializeObject(inventories)}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, 
            error => Debug.LogError(error.GenerateErrorReport())
        );
    }

    public void OnDataSend(UpdateUserDataResult result){
        Debug.Log("User data successfully sent.");
    }

    public void GetInventory(){
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnInventoryDataReceived, 
        error => Debug.LogError(error.GenerateErrorReport()));
    }

    void OnInventoryDataReceived(GetUserDataResult result){
        Debug.Log("Received inventory data");
        if(result.Data != null && result.Data.ContainsKey("Inventory")){
            List<Inventory> inventories = JsonConvert.DeserializeObject<List<Inventory>>(result.Data["Inventory"].Value);
            for(int i = 0; i < inventoryManager.Length; i++){
                inventoryManager[i].SetCount(inventories[i]);
            }
        }
    }

    public void AddInventory(string item){
        switch(item){
            case "smallenergy": 
            smallenergycount++;
            break;
            case "mediumenergy": 
            mediumenergycount++;
            break;
            case "largeenergy": 
            largeenergycount++;
            break;
            case "mysterysnack": 
            mysterysnackcount++;
            break;
            case "magnet": 
            magnetcount++;
            break;
            case "neptunestrident": 
            neptunestridentcount++; 
            break;
            case "voidgem": 
            voidgemcount++; 
            break;
            case "net": 
            netcount++; 
            break;
            case "fungi": 
            fungicount++; 
            break;
            case "pocketwatch": 
            pocketwatchcount++; 
            break;
            case "mermaidsorb": 
            mermaidsorbcount++; 
            break;
            case "basket": 
            basketcount++; 
            break;
            case "stufftoy": 
            stufftoycount++;
            break;
            case "waterproofcamera": 
            waterproofcameracount++;
            break;
            case "map": 
            mapcount++;
            break;
            case "historybook": 
            historybookcount++;
            break;
            case "seaweed": 
            seaweedcount++;
            break;
            case "crystals": 
            crystalscount++; 
            break;
            case "toyfigure": 
            toyfigurecount++; 
            break;
        }
    }


    public void ReduceInventory(string item){
        switch(item){
            case "smallenergy": 
            smallenergycount--;
            break;
            case "mediumenergy": 
            mediumenergycount--;
            break;
            case "largeenergy": 
            largeenergycount--;
            break;
            case "mysterysnack": 
            mysterysnackcount--;
            break;
            case "magnet": 
            magnetcount--;
            break;
            case "neptunestrident": 
            neptunestridentcount--; 
            break;
            case "voidgem": 
            voidgemcount--; 
            break;
            case "net": 
            netcount--; 
            break;
            case "fungi": 
            fungicount--; 
            break;
            case "pocketwatch": 
            pocketwatchcount--; 
            break;
            case "mermaidsorb": 
            mermaidsorbcount--; 
            break;
            case "basket": 
            basketcount--; 
            break;
            case "stufftoy": 
            stufftoycount--;
            break;
            case "waterproofcamera": 
            waterproofcameracount--;
            break;
            case "map": 
            mapcount--;
            break;
            case "historybook": 
            historybookcount--;
            break;
            case "seaweed": 
            seaweedcount--;
            break;
            case "crystals": 
            crystalscount--; 
            break;
            case "toyfigure": 
            toyfigurecount--; 
            break;
        }
    }
}
   
