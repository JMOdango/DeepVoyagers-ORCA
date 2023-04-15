using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemShopCloseUp : MonoBehaviour
{
    //PowerUps
    public GameObject smallenergy;
    public GameObject mediumenergy;
    public GameObject largeenergy;
    public GameObject mysterysnack;
    public GameObject magnet;
    public GameObject neptunestrident;
    public GameObject voidgem;
    public GameObject net;
    public GameObject plasticeatingfungi;
    public GameObject pocketwatch;
    public GameObject mermaidsorb;
    public GameObject basket;

    //Gifts
    public GameObject stufftoy;
    public GameObject waterproofcamera;
    public GameObject map;
    public GameObject historybook;
    public GameObject seaweed;
    public GameObject crystals;
    public GameObject toyfigure;

    

    //for storing which gift was chosen or used
    public string chosengift;

    
    public void CloseCloseUp()
    {
        smallenergy.SetActive(false);
        mediumenergy.SetActive(false);
        largeenergy.SetActive(false);
        mysterysnack.SetActive(false);
        magnet.SetActive(false);
        neptunestrident.SetActive(false);
        voidgem.SetActive(false);
        plasticeatingfungi.SetActive(false);
        pocketwatch.SetActive(false);
        mermaidsorb.SetActive(false);
        basket.SetActive(false);
        net.SetActive(false);

        stufftoy.SetActive(false);
        waterproofcamera.SetActive(false);
        map.SetActive(false);
        historybook.SetActive(false);
        seaweed.SetActive(false);
        crystals.SetActive(false);
        toyfigure.SetActive(false);
    }

    //PowerUps

    public void OpenSmallEnergy()
    {
        CloseCloseUp();
        smallenergy.SetActive(true);
    }

    public void OpenMediumEnergy()
    {
        CloseCloseUp();
        mediumenergy.SetActive(true);
    }

    public void OpenLargeEnergy()
    {
        CloseCloseUp();
        largeenergy.SetActive(true);
    }

    public void OpenMysterySnack()
    {
        CloseCloseUp();
        mysterysnack.SetActive(true);
    }

    public void OpenMagnet()
    {
        CloseCloseUp();
        magnet.SetActive(true);
    }

    public void OpenNeptunesTrident()
    {
        CloseCloseUp();
        neptunestrident.SetActive(true);
    }

    public void OpenVoidGem()
    {
        CloseCloseUp();
        voidgem.SetActive(true);
    }

    
    public void OpenPlasticFungi()
    {
        CloseCloseUp();
        plasticeatingfungi.SetActive(true);
    }

    public void OpenPocketWatch()
    {
        CloseCloseUp();
        pocketwatch.SetActive(true);
    }

    public void OpenMermaidsOrb()
    {
        CloseCloseUp();
        mermaidsorb.SetActive(true);
    }

    public void OpenBasket()
    {
        CloseCloseUp();
        basket.SetActive(true);
    }

    public void OpenNet()
    {
        CloseCloseUp();
        net.SetActive(true);
    }


    //Gifts

    public void OpenStufftoy() 
    {
        CloseCloseUp();
        chosengift = "stufftoy";
        stufftoy.SetActive(true);
    }

    public void OpenWaterproofCamera()
    {
        CloseCloseUp();
        chosengift = "waterproofcamera";
        waterproofcamera.SetActive(true);
    }

    public void OpenMap()
    {
        CloseCloseUp();
        chosengift = "map";
        map.SetActive(true);
    }

    public void OpenHistoryBook()
    {
        CloseCloseUp();
        chosengift = "historybook";
        historybook.SetActive(true);
    }

    public void OpenSeaweed()
    {
        CloseCloseUp();
        chosengift = "seaweed";
        seaweed.SetActive(true);
    }

    public void OpenCrystals()
    {
        CloseCloseUp();
        chosengift = "crystals";
        crystals.SetActive(true);
    }

    public void OpenToyfigure()
    {
        CloseCloseUp();
        chosengift = "toyfigure";
        toyfigure.SetActive(true);
    }
}
