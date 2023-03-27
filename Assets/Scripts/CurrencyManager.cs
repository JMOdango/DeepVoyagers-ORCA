using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager currencyManager;
    VirtualCurrency virtualCurrency;
    [SerializeField]
    private int storeStamina, storeShells, storeCoins;
    [SerializeField]
    public float secondsLeft;
    System.TimeSpan time;
    public TextMeshProUGUI coinsValueText, shellsValueText, energyValueText, energyRechargeTimeText;
    private int maxStamina = 100;
    
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

    public void SetTimer(float secondsLeftToRefreshEnergy){
        if(storeStamina < maxStamina){
            secondsLeft = secondsLeftToRefreshEnergy;
            time = System.TimeSpan.FromSeconds(secondsLeftToRefreshEnergy);
        }
        else{
            secondsLeft = 0;
            time = System.TimeSpan.FromSeconds(0);
        }
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
}
