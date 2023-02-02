using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject Settings;
    public GameObject Inventory;
    public GameObject PowerUpsInventory;
    public GameObject GiftsInventory;
    public GameObject ProjectsInventory;
    public GameObject TopUpShop;

    public GameObject PowerUpsShop;
    public GameObject GiftsShop;

    public GameObject ShellTopUp;
    public GameObject CoinTopUp;
    public GameObject PromoTopUp;
    public void OpenSettings()
    {
        if(Settings != null){
            bool isActive = Settings.activeSelf;
            Settings.SetActive(!isActive);
        }
    }

    public void OpenTopUpShop()
    {
      TopUpShop.SetActive(true);
    }

//TopUpShop
    
    public void OpenShellTopUp()
    {

    }

//Inventory Panels
    public void GotoInventory()
    {
        Inventory.SetActive(true);
    }

    public void CloseInventory()
    {
        Inventory.SetActive(false);
    }

    public void OpenGiftsInventory()
    {
        GiftsInventory.SetActive(true);
        PowerUpsInventory.SetActive(false);
        ProjectsInventory.SetActive(false);
    }

    public void OpenPowerUpsInventory()
    {
        PowerUpsInventory.SetActive(true);
        GiftsInventory.SetActive(false);
        ProjectsInventory.SetActive(false);
    }

    public void OpenProjectsInventory()
    {
        ProjectsInventory.SetActive(true);
        PowerUpsInventory.SetActive(false);
        GiftsInventory.SetActive(false);
    }

    
//Item Shop Panels

    public void OpenGiftsShop()
    {
        GiftsShop.SetActive(true);
        PowerUpsShop.SetActive(false);
    }

    public void OpenPowerUpsShop()
    {
        PowerUpsShop.SetActive(true);
        GiftsShop.SetActive(false);
    }
}
