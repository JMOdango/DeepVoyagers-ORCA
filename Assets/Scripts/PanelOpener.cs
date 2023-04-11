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
    
    //TopUp Shop Variable
    public GameObject ShellTopUp;
    public GameObject CoinTopUp;
    public GameObject PromoTopUp;

    public GameObject on_shell;
    public GameObject off_shell;
    public GameObject on_coin;
    public GameObject off_coin;
    public GameObject on_promo;
    public GameObject off_promo;

    public GameObject warning;


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

    public void CloseTopUpShop()
    {
      TopUpShop.SetActive(false);
    }

//TopUpShop
    
    public void OpenShellTopUp()
    {
     OpenTopUpShop();
     ShellTopUp.SetActive(true);
     CoinTopUp.SetActive(false);
     PromoTopUp.SetActive(false);

     on_shell.SetActive(true);
     off_shell.SetActive(false);
     on_coin.SetActive(false);
     off_coin.SetActive(true);
     on_promo.SetActive(false);
     off_promo.SetActive(true);
    }

    public void OpenCoinTopUp()
    {
     OpenTopUpShop();
     ShellTopUp.SetActive(false);
     CoinTopUp.SetActive(true);
     PromoTopUp.SetActive(false);

     on_shell.SetActive(false);
     off_shell.SetActive(true);
     on_coin.SetActive(true);
     off_coin.SetActive(false);
     on_promo.SetActive(false);
     off_promo.SetActive(true);
    }

    public void OpenPromoTopUp()
    {
     OpenTopUpShop();
     ShellTopUp.SetActive(false);
     CoinTopUp.SetActive(false);
     PromoTopUp.SetActive(true);

     on_shell.SetActive(false);
     off_shell.SetActive(true);
     on_coin.SetActive(false);
     off_coin.SetActive(true);
     on_promo.SetActive(true);
     off_promo.SetActive(false);
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

    public void OpenWarning()
    {
        warning.SetActive(true);
    }

    public void CloseWarning()
    {
        warning.SetActive(false);
    }
}
