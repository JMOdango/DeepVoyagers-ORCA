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
    public LevelManager level;
    LevelUnlock levelunlock;
    [Header("Core Mechanics")]
    public GameObject gameOverCanvas;
    public GameObject completedLevel;
    public GameObject deadlockPanel;
    [SerializeField]
    private MovesLeft moves;
    public bool GameOver = false;
    public bool Complete = false;
    public scoreBar score;
    public Board board;
    
    public FindMatches matches;
    // public string sceneName;
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

    //Check if first win
    [SerializeField]
    int unlockedCount;
    
    private void Start()
    {
        gameOverCanvas.SetActive(false);
        completedLevel.SetActive(false);
        deadlockPanel.SetActive(false);
    }

    private void Update()
    {

        if (score.slider.value >= score.slider.maxValue && moves.TrashCollected <= 0 && moves.Moves > 0)
        {
            stageComplete();
            board.completeOrFailed = true;
            board.currentState = GameState.wait;
            Debug.Log(board.currentState);

        }
        if (moves.Moves <= 0 && moves.TrashCollected > 0 && matches.currentMatches.Count == 0
         || moves.Moves <= 0 && score.slider.value < score.slider.maxValue && matches.currentMatches.Count == 0
         || moves.Moves <= 0 && score.slider.value >= score.slider.maxValue && moves.TrashCollected > 0
         )
        {
            board.completeOrFailed = true;
            board.currentState = GameState.wait;
            Debug.Log(board.currentState);
            Invoke("gameOver", 1.0f);
        }
        if (moves.Moves <= 0 && score.slider.value < score.slider.maxValue && matches.currentMatches.Count > 0){
            //still matching
            Invoke("gameOver", 1.0f);
            board.currentState = GameState.wait;
            Debug.Log(board.currentState);
        }
        if (board.isDeadlocked) {
            deadlockPanel.SetActive(true);
            Invoke("gameOver", 1.0f);
        }

        ChangeSprite();
    }

    public void Awake(){
        level.GetLevels();
        unlockedCount = LevelManager.level.GetArea1Unlocked();
    }

    public void gameOver()
    {
        gameOverCanvas.SetActive(true);
        GameOver = true;
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

    public void stageComplete()
    {
        gameOverCanvas.SetActive(false);
        completedLevel.SetActive(true);
        GameOver = false;
        Complete = true;
        shellsText.text = shellsReward.ToString();
        coinsText.text = coinsReward.ToString();
        trash1Text.text = trash1Reward.ToString();
        trashText2.text = trash2Reward.ToString();

        switch(SceneManager.GetActiveScene().name){
            case "Level1": 
            if(LevelManager.level.GetArea1Unlocked() == 1){
                unlockedCount = 2;
            };
            break; //unlock level2
            case "Level2": 
            if(LevelManager.level.GetArea1Unlocked() == 2){
                unlockedCount = 3;
            };
            break; //unlock level3
            case "Level3": 
            if(LevelManager.level.GetArea1Unlocked() == 3){
                unlockedCount = 4;
            };
            break; //unlock level4
            case "Level4": 
            if(LevelManager.level.GetArea1Unlocked() == 4){
                unlockedCount = 5;
            }; break; //unlock level5
            case "Level5":
            if(LevelManager.level.GetArea1Unlocked() == 5){
                unlockedCount = 5;
            }; break; //unlock level5
        }
        level.unlockLevel(unlockedCount);
    }

    public void unlockLevel(){
        level.SaveLevels();
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