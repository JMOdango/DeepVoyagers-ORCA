using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{   
    public static InventoryUI inventoryUI;
    InventoryManager inventory;
    public TextMeshProUGUI smallenergytext, mediumenergytext, largeenergytext, mysterysnacktext, magnettext, neptunestridenttext, voidgemtext, 
    nettext, fungitext, pocketwatchtext, mermaidsorbtext, baskettext;
    public TextMeshProUGUI stufftoytext, waterproofcameratext, maptext, historybooktext, seaweedtext, crystalstext, toyfiguretext;

    public void Awake(){
        if(inventoryUI == null)
        {
            inventoryUI = this;
        }
        else
        {
            if(inventoryUI != this){
                Destroy(this.gameObject);
            }
        }
    }

    public void SetUIPowerUps(int smallenergycount, 
        int mediumenergycount, 
        int largeenergycount, 
        int mysterysnackcount,
        int magnetcount, 
        int neptunestridentcount, 
        int voidgemcount, 
        int netcount, 
        int fungicount, 
        int pocketwatchcount, 
        int mermaidsorbcount, 
        int basketcount
    ){
        smallenergytext.text = smallenergycount.ToString();
        mediumenergytext.text = mediumenergycount.ToString();
        largeenergytext.text = largeenergycount.ToString();
        mysterysnacktext.text = mysterysnackcount.ToString();
        magnettext.text = magnetcount.ToString();
        neptunestridenttext.text = neptunestridentcount.ToString();
        voidgemtext.text = voidgemcount.ToString();
        nettext.text = netcount.ToString();
        fungitext.text = fungicount.ToString();
        pocketwatchtext.text = pocketwatchcount.ToString();
        mermaidsorbtext.text = mermaidsorbcount.ToString();
        baskettext.text = basketcount.ToString();
    }

       public void SetUIGifts(int stufftoycount, 
       int waterproofcameracount, 
       int mapcount, 
       int historybookcount, 
       int seaweedcount, 
       int crystalscount, 
       int toyfigurecount
    ){
        stufftoytext.text = stufftoycount.ToString();
        waterproofcameratext.text = waterproofcameracount.ToString();
        maptext.text = mapcount.ToString();
        historybooktext.text = historybookcount.ToString();
        seaweedtext.text = seaweedcount.ToString();
        crystalstext.text = crystalscount.ToString();
        toyfiguretext.text = toyfigurecount.ToString();
    }
}