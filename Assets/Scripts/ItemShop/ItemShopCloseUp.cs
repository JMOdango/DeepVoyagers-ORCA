using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        smallenergy.SetActive(true);
    }

    public void OpenMediumEnergy()
    {
        mediumenergy.SetActive(true);
    }

    public void OpenLargeEnergy()
    {
        largeenergy.SetActive(true);
    }

    public void OpenMysterySnack()
    {
        mysterysnack.SetActive(true);
    }

    public void OpenMagnet()
    {
        magnet.SetActive(true);
    }

    public void OpenNeptunesTrident()
    {
        neptunestrident.SetActive(true);
    }

    public void OpenVoidGem()
    {
        voidgem.SetActive(true);
    }

    
    public void OpenPlasticFungi()
    {
        plasticeatingfungi.SetActive(true);
    }

    public void OpenPocketWatch()
    {
        pocketwatch.SetActive(true);
    }

    public void OpenMermaidsOrb()
    {
        mermaidsorb.SetActive(true);
    }

    public void OpenBasket()
    {
        basket.SetActive(true);
    }

    public void OpenNet()
    {
        net.SetActive(true);
    }


    //Gifts

    public void OpenStufftoy()
    {
        stufftoy.SetActive(true);
    }

    public void OpenWaterproofCamera()
    {
        waterproofcamera.SetActive(true);
    }

    public void OpenMap()
    {
        map.SetActive(true);
    }

    public void OpenHistoryBook()
    {
        historybook.SetActive(true);
    }

    public void OpenSeaweed()
    {
        seaweed.SetActive(true);
    }

    public void OpenCrystals()
    {
        crystals.SetActive(true);
    }

    public void OpenToyfigure()
    {
        toyfigure.SetActive(true);
    }
}
