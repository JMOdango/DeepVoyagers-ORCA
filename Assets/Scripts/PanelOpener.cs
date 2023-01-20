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

    public GameObject PowerUpsShop;
    public GameObject GiftsShop;
    
    public void OpenPanel()
    {
        if(Settings != null){
            bool isActive = Settings.activeSelf;
            Settings.SetActive(!isActive);
        }
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
