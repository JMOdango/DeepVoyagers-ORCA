using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
        int basket
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
    }
}

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager inventory;
    StoreAmount storeAmount;
    public InventoryManager[] inventoryManager;
    public TextMeshProUGUI smallenergytext, mediumenergytext, largeenergytext, mysterysnacktext, magnettext, neptunestridenttext, voidgemtext, 
    nettext, fungitext, pocketwatchtext, mermaidsorbtext, baskettext;
    public int smallenergycount, mediumenergycount, largeenergycount, mysterysnackcount, magnetcount, neptunestridentcount, voidgemcount, 
    netcount, fungicount, pocketwatchcount, mermaidsorbcount, basketcount;

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
        basketcount
        );
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
        // GetInventory();
    }

    public void SetUI(Inventory inventory){
        smallenergytext.text = ""+inventory.smallenergy+"";
        mediumenergytext.text = ""+inventory.mediumenergy+"";
        largeenergytext.text = ""+inventory.largeenergy+"";
        mysterysnacktext.text = ""+inventory.mysterysnack+"";
        magnettext.text = ""+inventory.magnet+"";
        neptunestridenttext.text = ""+inventory.neptunestrident+"";
        voidgemtext.text = ""+inventory.voidgem+"";
        nettext.text = ""+inventory.net+"";
        fungitext.text = ""+inventory.fungi+"";
        pocketwatchtext.text = ""+inventory.pocketwatch+"";
        mermaidsorbtext.text = ""+inventory.mermaidsorb+"";
        baskettext.text = ""+inventory.basket+"";
    }

    public void SetCount(Inventory inventory){
        smallenergycount = inventory.smallenergy + StoreAmount.storeAmount.smallenergyamount;
        mediumenergycount = inventory.mediumenergy + StoreAmount.storeAmount.mediumenergyamount;
        largeenergycount = inventory.largeenergy + StoreAmount.storeAmount.largeenergyamount;
        mysterysnackcount = inventory.mysterysnack + StoreAmount.storeAmount.mysterysnackamount;
        magnetcount = inventory.magnet + StoreAmount.storeAmount.magnetamount;
        neptunestridentcount = inventory.neptunestrident + StoreAmount.storeAmount.neptunestridentamount;
        voidgemcount = inventory.voidgem + StoreAmount.storeAmount.voidgemamount;
        netcount = inventory.net + StoreAmount.storeAmount.netamount;
        fungicount = inventory.fungi + StoreAmount.storeAmount.fungiamount;
        pocketwatchcount = inventory.pocketwatch + StoreAmount.storeAmount.pocketwatchamount;
        mermaidsorbcount = inventory.pocketwatch + StoreAmount.storeAmount.mermaidsorbamount;
        basketcount = inventory.basket + StoreAmount.storeAmount.basketamount;
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

    public void GetInventory(){
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnInventoryDataReceived, 
        error => Debug.LogError(error.GenerateErrorReport()));
    }

    public void OnDataSend(UpdateUserDataResult result){
        Debug.Log("User data successfully sent.");
    }

    void OnInventoryDataReceived(GetUserDataResult result){
        Debug.Log("Received inventory data");
        if(result.Data != null && result.Data.ContainsKey("Inventory")){
            List<Inventory> inventories = JsonConvert.DeserializeObject<List<Inventory>>(result.Data["Inventory"].Value);
            for(int i = 0; i < inventoryManager.Length; i++){
                inventoryManager[i].SetUI(inventories[i]);
                inventoryManager[i].SetCount(inventories[i]);
            }
        }
        SaveInventory();
    }
}
   
