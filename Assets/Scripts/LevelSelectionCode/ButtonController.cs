using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
public class ButtonController : MonoBehaviour
{
    CurrencyManager currencyManager;
    public GameObject staminaRequirementScreen;
    private int levelNo;
    public string sceneName;
    public int staminaReq;
    [SerializeField]
    private int staminaLeft;
    public GameObject noStaminaPanel;

    void Start()
    {
        staminaRequirementScreen.SetActive(false);
        noStaminaPanel.SetActive(false);
    }

    void Update()
    {
        staminaLeft = CurrencyManager.currencyManager.GetStaminaLeft();
    }

    public void StaminaRequirement() 
    {
        staminaRequirementScreen.SetActive(true);
    }

    public void CloseStaminaRequirement() 
    {
        staminaRequirementScreen.SetActive(false);
    }

    public void CloseNoStamina() 
    {
        noStaminaPanel.SetActive(false);
    }

    public void OpenScene(){
        if(staminaLeft < staminaReq)
        {
            noStaminaPanel.SetActive(true);
        }
        else
        {
            var request = new SubtractUserVirtualCurrencyRequest{
                VirtualCurrency = "EN",
                Amount = staminaReq,
            };
            PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnSubtractCoinsSuccess, OnError);
            SceneManager.LoadScene(sceneName);
        }
    }

    void OnSubtractCoinsSuccess(ModifyUserVirtualCurrencyResult result){
        VirtualCurrency.virtualCurrency.GetVirtualCurrencies();
    }

    void OnError(PlayFabError error){
        Debug.Log("Error: " + error.ErrorMessage);
    }
}
