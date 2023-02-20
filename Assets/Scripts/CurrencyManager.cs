using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager currencyManager;
    VirtualCurrency virtualCurrency;
    [SerializeField]
    private int storeStamina, storeShells, storeCoins, storePlastic, storeGlass, storeMetal, storeOrganic, storeFabric;
    [SerializeField]
    public float secondsLeft;
    System.TimeSpan time;
    public TextMeshProUGUI coinsValueText, shellsValueText, energyValueText, energyRechargeTimeText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Awake()
    {
        if(currencyManager == null)
        {
            currencyManager = this;
        }
        else
        {
            if(currencyManager != this){
                Destroy(this.gameObject);
            }
        }

        energyValueText.text = storeStamina.ToString();
        coinsValueText.text = storeCoins.ToString();
        shellsValueText.text = storeShells.ToString();
        energyRechargeTimeText.text = time.ToString("mm' : 'ss");
    }

    void Update(){
        energyValueText.text = storeStamina.ToString();
        coinsValueText.text = storeCoins.ToString();
        shellsValueText.text = storeShells.ToString();
        energyRechargeTimeText.text = time.ToString("mm' : 'ss");
    }

    public void SetStamina(int stamina)
    {
        storeStamina = stamina;
        return;
    }

    public void SetShells(int shells)
    {
        storeShells = shells;
        return;
    }

    public void SetCoins(int coins)
    {
        storeCoins = coins;
        return;
    }

    public void SetPlastic(int plastic)
    {
        storePlastic = plastic;
        return;
    }

    public void SetGlass(int glass)
    {
        storeGlass = glass;
        return;
    }

    public void SetMetal(int metal)
    {
        storeMetal = metal;
        return;
    }

    public void SetOrganic(int organic)
    {
        storeOrganic = organic;
        return;
    }

    public void SetFabric(int fabric)
    {
        storeFabric = fabric;
        return;
    }

    public void SetTimer(float secondsLeftToRefreshEnergy){
        secondsLeft = secondsLeftToRefreshEnergy;
        time = System.TimeSpan.FromSeconds(secondsLeftToRefreshEnergy);
        return;
    }

    public int GetStaminaLeft(){
        return storeStamina;
    }
    
    public int GetShellsLeft(){
        return storeShells;
    }

    public int GetCoinsLeft(){
        return storeCoins;
    }

    public int GetPlasticLeft(){
        return storePlastic;
    }

    public int GetGlassLeft(){
        return storeGlass;
    }

    public int GetMetalLeft(){
        return storeMetal;
    }

    public int GetOrganicLeft(){
        return storeOrganic;
    }

    public int GetFabricLeft(){
        return storeFabric;
    }
}
