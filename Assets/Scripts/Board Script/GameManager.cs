using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Core Mechanics")]
    public GameObject gameOverCanvas;
    public GameObject completedLevel;
    [SerializeField]
    private MovesLeft moves;
    public bool GameOver = false;
    public bool Complete = false;
    public scoreBar score;
    public Board board;
    public string nextSceneName;
    public enum trashEnum {PL, OR, ME, GL, FA}

    [Header("Rewards")]
    public Sprite[] trashSpriteArray;
    public TextMeshProUGUI shellsText;
    public int shellsReward;
    public TextMeshProUGUI coinsText;
    public int coinsReward;
    public TextMeshProUGUI trash1Text;
    public GameObject trash1Icon;
    public trashEnum trash1 = trashEnum.PL;
    public int trash1Reward;
    public TextMeshProUGUI trashText2;
    public GameObject trash2Icon;
    public trashEnum trash2 = trashEnum.ME;
    public int trash2Reward;
    
    private void Start()
    {

        gameOverCanvas.SetActive(false);
        completedLevel.SetActive(false);
        Time.timeScale = 1;

    }
    private void Update()
    {
        if (score.slider.value >= score.slider.maxValue && moves.TrashCollected <= 0)
        {
            stageComplete();
        }

        if (moves.Moves == 0)
        {
            gameOver();
        }

        if (score.slider.value >= score.slider.maxValue && moves.TrashCollected > 0) {
            gameOver();
        }

        if (board.isDeadlocked) {
            gameOver();
        }

        ChangeSprite();
    }

    public void Awake(){
        
    }

    public void gameOver()
    {
        gameOverCanvas.SetActive(true);
        GameOver = true;
        Time.timeScale = 0;
    }

    public void restart()
    {
        int x = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(x);
        GameOver = false;
    }

    public void Return()
    {
        SceneManager.LoadScene("Area1_LevelSelection");
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(nextSceneName);
        Complete = false;
    }

    public void stageComplete()
    {
        completedLevel.SetActive(true);
        Complete = true;
        shellsText.text = shellsReward.ToString();
        coinsText.text = coinsReward.ToString();
        trash1Text.text = trash1Reward.ToString();
        trashText2.text = trash2Reward.ToString();
        Time.timeScale = 0;
    }

    void OnAddCoinsSuccess(ModifyUserVirtualCurrencyResult result){
        VirtualCurrency.virtualCurrency.GetVirtualCurrencies();
    }

    void OnError(PlayFabError error){
        Debug.Log("Error: " + error.ErrorMessage);
    }

    public void GiveRewards()
    {
        var coinsReq = new AddUserVirtualCurrencyRequest{
                VirtualCurrency = "CN",
                Amount = coinsReward
        };
        PlayFabClientAPI.AddUserVirtualCurrency(coinsReq, OnAddCoinsSuccess, OnError);

        var shellsReq = new AddUserVirtualCurrencyRequest{
                VirtualCurrency = "SH",
                Amount = shellsReward
        };
        PlayFabClientAPI.AddUserVirtualCurrency(shellsReq, OnAddCoinsSuccess, OnError);

        var trash1Req = new AddUserVirtualCurrencyRequest{
                VirtualCurrency = trash1.ToString(),
                Amount = trash1Reward
        };
        PlayFabClientAPI.AddUserVirtualCurrency(trash1Req, OnAddCoinsSuccess, OnError);

        var trash2Req = new AddUserVirtualCurrencyRequest{
                VirtualCurrency = trash2.ToString(),
                Amount = trash2Reward
        };
        PlayFabClientAPI.AddUserVirtualCurrency(trash2Req, OnAddCoinsSuccess, OnError);
    }

    public void ChangeSprite()
    {
        switch(trash1.ToString()){
            case "PL": trash1Icon.GetComponent<Image>().sprite = trashSpriteArray[0]; 
            break;
            case "OR": trash1Icon.GetComponent<Image>().sprite = trashSpriteArray[1]; 
            break;
            case "ME": trash1Icon.GetComponent<Image>().sprite = trashSpriteArray[2]; 
            break;
            case "GL": trash1Icon.GetComponent<Image>().sprite = trashSpriteArray[3]; 
            break;
            case "FA": trash1Icon.GetComponent<Image>().sprite = trashSpriteArray[4]; 
            break;
        }

        switch(trash2.ToString()){
            case "PL": trash2Icon.GetComponent<Image>().sprite = trashSpriteArray[0]; 
            break;
            case "OR": trash2Icon.GetComponent<Image>().sprite = trashSpriteArray[1]; 
            break;
            case "ME": trash2Icon.GetComponent<Image>().sprite = trashSpriteArray[2]; 
            break;
            case "GL": trash2Icon.GetComponent<Image>().sprite = trashSpriteArray[3]; 
            break;
            case "FA": trash2Icon.GetComponent<Image>().sprite = trashSpriteArray[4]; 
            break;
        }
    }   
}