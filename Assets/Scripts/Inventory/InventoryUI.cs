using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryUI : MonoBehaviour
{   
    public static InventoryUI inventoryUI;
    InventoryManager inventory;
    [Header("Powerups-Text")]
    public TextMeshProUGUI smallenergytext;
    public TextMeshProUGUI mediumenergytext; 
    public TextMeshProUGUI largeenergytext;
    public TextMeshProUGUI mysterysnacktext; 
    public TextMeshProUGUI magnettext;
    public TextMeshProUGUI neptunestridenttext; 
    public TextMeshProUGUI voidgemtext; 
    public TextMeshProUGUI nettext;
    public TextMeshProUGUI fungitext;
    public TextMeshProUGUI pocketwatchtext; 
    public TextMeshProUGUI mermaidsorbtext;
    public TextMeshProUGUI baskettext;

    [Header("Gifts-Text")]
    public TextMeshProUGUI stufftoytext;
    public TextMeshProUGUI waterproofcameratext;
    public TextMeshProUGUI maptext;
    public TextMeshProUGUI historybooktext;
    public TextMeshProUGUI seaweedtext;
    public TextMeshProUGUI crystalstext;
    public TextMeshProUGUI toyfiguretext;

    [Header("Projects-Text")]
    public TextMeshProUGUI fertilizertext;
    public TextMeshProUGUI birdfeedertext;
    public TextMeshProUGUI clothebagtext;
    public TextMeshProUGUI penholdertext;
    public TextMeshProUGUI plasticpottext;

    [Header("Powerups-Button")]
    public Button smallenergybtn;
    public Button mediumenergybtn;
    public Button largeenergybtn;
    public Button mysterysnackbtn;
    public Button magnetbtn;
    public Button neptunestridentbtn;
    public Button voidgembtn;
    public Button netbtn;
    public Button fungibtn;
    public Button pocketwatchbtn;
    public Button mermaidsorbbtn;
    public Button basketbtn;

    [Header("Gifts-Button")]
    public Button stufftoybtn;
    public Button waterproofcamerabtn;
    public Button  mapbtn;
    public Button historybookbtn;
    public Button seaweedbtn;
    public Button crystalsbtn;
    public Button toyfigurebtn;

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
        Scene scene = SceneManager.GetActiveScene();

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

        if(scene.name == "MainMenu")
        {
            if(smallenergycount != 0)
            {
                smallenergybtn.interactable = true;
            }
            else
            {
                smallenergybtn.interactable = false;
            }

            if(mediumenergycount != 0)
            {
                mediumenergybtn.interactable = true;
            }
            else
            {
                mediumenergybtn.interactable = false;
            }

            if(largeenergycount != 0)
            {
                largeenergybtn.interactable = true;
            }
            else
            {
                largeenergybtn.interactable = false;
            }
            
            mysterysnackbtn.interactable = false;
            magnetbtn.interactable = false;
            neptunestridentbtn.interactable = false;
            voidgembtn.interactable = false;
            netbtn.interactable = false;
            fungibtn.interactable = false;
            pocketwatchbtn.interactable = false;
            mermaidsorbbtn.interactable = false;
            basketbtn.interactable = false;
        }
        else
        {
            if(mysterysnackcount != 0)
            {
                mysterysnackbtn.interactable = true;
            }
            else
            {
                mysterysnackbtn.interactable = false;
            }

            if(magnetcount != 0)
            {
                magnetbtn.interactable = true;
            }
            else
            {
                magnetbtn.interactable = false;
            }

            if(neptunestridentcount != 0)
            {
                neptunestridentbtn.interactable = true;
            }
            else
            {
                neptunestridentbtn.interactable = false;
            }

            if(voidgemcount != 0)
            {
                voidgembtn.interactable = true;
            }
            else
            {
                voidgembtn.interactable = false;
            }

            if(netcount != 0)
            {
                netbtn.interactable = true;
            }
            else
            {
                netbtn.interactable = false;
            }

            if(fungicount != 0)
            {
                fungibtn.interactable = true;
            }
            else
            {
                fungibtn.interactable = false;
            }

            if(pocketwatchcount != 0)
            {
                pocketwatchbtn.interactable = true;
            }
            else
            {
                pocketwatchbtn.interactable = false;
            }

            if(mermaidsorbcount != 0)
            {
                mermaidsorbbtn.interactable = true;
            }
            else
            {
                mermaidsorbbtn.interactable = false;
            }

            if(basketcount != 0)
            {
                basketbtn.interactable = true;
            }
            else
            {
                basketbtn.interactable = false;
            }
        }

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

        if(stufftoycount != 0)
        {
            stufftoybtn.interactable = true;
        }
        else
        {
            stufftoybtn.interactable = false;
        }

        if(waterproofcameracount != 0)
        {
            waterproofcamerabtn.interactable = true;
        }
        else
        {
            waterproofcamerabtn.interactable = false;
        }

        if(mapcount != 0)
        {
            mapbtn.interactable = true;
        }
        else
        {
            mapbtn.interactable = false;
        }

        if(historybookcount != 0)
        {
            historybookbtn.interactable = true;
        }
        else
        {
            historybookbtn.interactable = false;
        }

        if(seaweedcount != 0)
        {
            seaweedbtn.interactable = true;
        }
        else
        {
            seaweedbtn.interactable = false;
        }

        if(crystalscount != 0)
        {
            crystalsbtn.interactable = true;
        }
        else
        {
            crystalsbtn.interactable = false;
        }

        if(toyfigurecount != 0)
        {
            toyfigurebtn.interactable = true;
        }
        else
        {
            toyfigurebtn.interactable = false;
        }
    }

    public void SetUIProjects(int fertilizercount, 
       int birdfeedercount, 
       int clothebagcount, 
       int penholdercount, 
       int plasticpotcount
    ){
        fertilizertext.text = fertilizercount.ToString();
        birdfeedertext.text = birdfeedercount.ToString();
        clothebagtext.text = clothebagcount.ToString();
        penholdertext.text = penholdercount.ToString();
        plasticpottext.text = plasticpotcount.ToString();
    }
}
