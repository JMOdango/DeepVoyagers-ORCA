using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Inventory;
    public GameObject PowerUpsInventory;
    public GameObject GiftsInventory;
    public void OpenPanel()
    {
        if(Panel != null){
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }

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
    }

    public void OpenPowerUpsInventory()
    {
        PowerUpsInventory.SetActive(true);
        GiftsInventory.SetActive(false);
    }
}
