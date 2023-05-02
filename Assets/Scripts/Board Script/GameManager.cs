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
    public TextGoal goalComplete;
    
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
    int unlockedCount1, unlockedCount2, unlockedCount3, unlockedCount4, unlockedCount5, unlockedCount6, unlockedCount7, unlockedCount8;
    
    private void Start()
    {
        GetUnlockedValues();
        goalComplete = FindObjectOfType<TextGoal>();
        gameOverCanvas.SetActive(false);
        completedLevel.SetActive(false);
        deadlockPanel.SetActive(false);
    }

    private void Update()
    {
        if (score.slider.value >= score.slider.maxValue && goalComplete.allGoalComplete && moves.Moves >= 0)
        {
            stageComplete();
            board.completeOrFailed = true;
            board.currentState = GameState.wait;
            Debug.Log("Complete");
        }

        if (score.slider.value <= score.slider.maxValue && !goalComplete.allGoalComplete && moves.Moves == 0)
        {
            board.completeOrFailed = true;
            board.currentState = GameState.wait;
            Invoke("gameOver", 1.0f);
        }

        if (score.slider.value >= score.slider.maxValue && !goalComplete.allGoalComplete && moves.Moves == 0)
        {
            board.completeOrFailed = true;
            board.currentState = GameState.wait;
            Invoke("gameOver", 1.0f);
        }

        if (score.slider.value <= score.slider.maxValue && goalComplete.allGoalComplete && moves.Moves == 0)
        {
            board.completeOrFailed = true;
            board.currentState = GameState.wait;
            Invoke("gameOver", 1.0f);
        }
        
        if (board.isDeadlocked) {
            deadlockPanel.SetActive(true);
            Invoke("gameOver", 1.0f);
        }

        ChangeSprite();
    }

    public void Awake(){
        level.GetLevels();
        unlockedCount1 = LevelManager.level.GetArea1Unlocked();
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

    public void GetUnlockedValues(){
        unlockedCount1 = LevelManager.level.GetArea1Unlocked();
        unlockedCount2 = LevelManager.level.GetArea2Unlocked();
        unlockedCount3 = LevelManager.level.GetArea3Unlocked();
        unlockedCount4 = LevelManager.level.GetArea4Unlocked();
        unlockedCount5 = LevelManager.level.GetArea5Unlocked();
        unlockedCount6 = LevelManager.level.GetFinalAreaUnlocked();
        unlockedCount7 = LevelManager.level.GetSecretArea1Unlocked();
        unlockedCount8 = LevelManager.level.GetSecretArea2Unlocked();
    }

    public void SetUnlockedValues(){
        level.unlockLevel1(unlockedCount1);
        level.unlockLevel2(unlockedCount2);
        level.unlockLevel3(unlockedCount3);
        level.unlockLevel4(unlockedCount4);
        level.unlockLevel5(unlockedCount5);
        level.unlockFinal(unlockedCount6);
        level.unlockSA1(unlockedCount7);
        level.unlockSA2(unlockedCount8);
    }

        //     public void stageComplete()
    // {
    //     gameOverCanvas.SetActive(false);
    //     completedLevel.SetActive(true);
    //     GameOver = false;
    //     Complete = true;
    //     shellsText.text = shellsReward.ToString();
    //     coinsText.text = coinsReward.ToString();
    //     trash1Text.text = trash1Reward.ToString();
    //     trashText2.text = trash2Reward.ToString();

    //     switch(SceneManager.GetActiveScene().name){
    //         case "Level1": 
    //         if(LevelManager.level.GetArea1Unlocked() == 1){
    //             unlockedCount1 = 2;
    //         }
    //         else
    //         {
    //             unlockedCount1 = LevelManager.level.GetArea1Unlocked();
    //         };
    //         break; //unlock level2
    //         case "Level2": 
    //         if(LevelManager.level.GetArea1Unlocked() == 2){
    //             unlockedCount1 = 3;
    //         }
    //         else
    //         {
    //             unlockedCount1 = LevelManager.level.GetArea1Unlocked();
    //         };
    //         break; //unlock level3
    //         case "Level3": 
    //         if(LevelManager.level.GetArea1Unlocked() == 3){
    //             unlockedCount1 = 4;
    //         }
    //         else
    //         {
    //             unlockedCount1 = LevelManager.level.GetArea1Unlocked();
    //         };
    //         break; //unlock level4
    //         case "Level4": 
    //         if(LevelManager.level.GetArea1Unlocked() == 4){
    //             unlockedCount1 = 5;
    //         }
    //         else
    //         {
    //             unlockedCount1 = LevelManager.level.GetArea1Unlocked();
    //         };
    //         break; //unlock level5
    //         case "Level5":
    //         if(LevelManager.level.GetArea1Unlocked() == 5){
    //             unlockedCount1 = 5;
    //             unlockedCount2 = 1;
    //         }
    //         else
    //         {
    //             unlockedCount1 = LevelManager.level.GetArea1Unlocked();
    //         };
    //         break; //unlock Area 2 level 1
    //     }
    //     level.unlockLevel1(unlockedCount1);
    //     level.unlockLevel2(unlockedCount2);
    // }

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
                unlockedCount1 = 2;
            }
            else
            {
                GetUnlockedValues();
            };
            break; //unlock level2
            case "Level2": 
            if(LevelManager.level.GetArea1Unlocked() == 2){
                unlockedCount1 = 3;
            }
            else
            {
                GetUnlockedValues();
            };
            break; //unlock level3
            case "Level3": 
            if(LevelManager.level.GetArea1Unlocked() == 3){
                unlockedCount1 = 4;
            }
            else
            {
                GetUnlockedValues();
            };
            break; //unlock level4
            case "Level4": 
            if(LevelManager.level.GetArea1Unlocked() == 4){
                unlockedCount1 = 5;
            }
            else
            {
                GetUnlockedValues();
            };
            break; //unlock level5
            case "Level5":
            if(LevelManager.level.GetArea1Unlocked() == 5){
                unlockedCount1 = 5;
                unlockedCount2 = 1;
            }
            else
            {
                GetUnlockedValues();
            };
            break; //unlock Area 2 level 1
            case "Area2_Level1":
            if(LevelManager.level.GetArea2Unlocked() == 1){
                unlockedCount1 = 5;
                unlockedCount2 = 2;
            }
            else
            {
                GetUnlockedValues();
            };
            break; //unlock Area 2 level 2
            case "Area2_Level2":
            if(LevelManager.level.GetArea2Unlocked() == 2){
                unlockedCount1 = 5;
                unlockedCount2 = 3;
            }
            else
            {
                GetUnlockedValues();
            };
            break; //unlock Area 2 level 3
            case "Area2_Level3":
            if(LevelManager.level.GetArea2Unlocked() == 3){
                unlockedCount1 = 5;
                unlockedCount2 = 4;
            }
            else
            {
                GetUnlockedValues();
            };
            break; //unlock Area 2 level 4
            case "Area2_Level4":
            if(LevelManager.level.GetArea2Unlocked() == 4){
                unlockedCount1 = 5;
                unlockedCount2 = 4;
            }
            else
            {
                GetUnlockedValues();
            };
            break; //unlock Area 2 level 5
            case "Area2_Level5":
            if(LevelManager.level.GetArea2Unlocked() == 5){
                unlockedCount1 = 5;
                unlockedCount2 = 5;
                unlockedCount3 = 1;
            }
            else
            {
                GetUnlockedValues();
            };
            break; //unlock Area 3 level 1
            case "Area3_Level1":
            if(LevelManager.level.GetArea3Unlocked() == 1){
                unlockedCount1 = 5;
                unlockedCount2 = 5;
                unlockedCount3 = 2;
            }
            else
            {
                GetUnlockedValues();
            };
            break; //unlock Area 3 level 2
            case "Area3_Level2":
            if(LevelManager.level.GetArea3Unlocked() == 2){
                unlockedCount1 = 5;
                unlockedCount2 = 5;
                unlockedCount3 = 3;
            }
            else
            {
                GetUnlockedValues();
            };
            break; //unlock Area 3 level 3
            case "Area3_Level3":
            if(LevelManager.level.GetArea3Unlocked() == 3){
                unlockedCount1 = 5;
                unlockedCount2 = 5;
                unlockedCount3 = 4;
            }
            else
            {
                GetUnlockedValues();
            };
            break; //unlock Area 3 level 4
            case "Area3_Level4":
            if(LevelManager.level.GetArea3Unlocked() == 4){
                unlockedCount1 = 5;
                unlockedCount2 = 5;
                unlockedCount3 = 5;
            }
            else
            {
                GetUnlockedValues();
            };
            break; //unlock Area 3 level 5
            case "Area3_Level5":
            if(LevelManager.level.GetArea3Unlocked() == 5){
                unlockedCount1 = 5;
                unlockedCount2 = 5;
                unlockedCount3 = 5;
                unlockedCount4 = 1;
            }
            else
            {
                GetUnlockedValues();
            };
            break; //unlock Area 4 level 1
            case "Area4_Level1":
            if(LevelManager.level.GetArea4Unlocked() == 1){
                unlockedCount1 = 5;
                unlockedCount2 = 5;
                unlockedCount3 = 5;
                unlockedCount4 = 2;
            }
            else
            {
                GetUnlockedValues();
            };
            break; //unlock Area 4 level 2
            case "Area4_Level2":
            if(LevelManager.level.GetArea4Unlocked() == 2){
                unlockedCount1 = 5;
                unlockedCount2 = 5;
                unlockedCount3 = 5;
                unlockedCount4 = 3;
            }
            else
            {
                GetUnlockedValues();
            };
            break; //unlock Area 4 level 3
            case "Area4_Level3":
            if(LevelManager.level.GetArea4Unlocked() == 3){
                unlockedCount1 = 5;
                unlockedCount2 = 5;
                unlockedCount3 = 5;
                unlockedCount4 = 4;
            }
            else
            {
                GetUnlockedValues();
            };
            break; //unlock Area 4 level 4
            case "Area4_Level4":
            if(LevelManager.level.GetArea4Unlocked() == 4){
                unlockedCount1 = 5;
                unlockedCount2 = 5;
                unlockedCount3 = 5;
                unlockedCount4 = 5;
            }
            else
            {
                GetUnlockedValues();
            };
            break; //unlock Area 4 level 5
            case "Area4_Level5":
            if(LevelManager.level.GetArea4Unlocked() == 5){
                unlockedCount1 = 5;
                unlockedCount2 = 5;
                unlockedCount3 = 5;
                unlockedCount4 = 5;
                unlockedCount5 = 1;
            }
            else
            {
                GetUnlockedValues();
            };
            break; //unlock Area 4 level 5
            case "Area5_Level1":
            if(LevelManager.level.GetArea5Unlocked() == 1){
                unlockedCount1 = 5;
                unlockedCount2 = 5;
                unlockedCount3 = 5;
                unlockedCount4 = 5;
                unlockedCount5 = 1;
            }
            else
            {
                GetUnlockedValues();
            };
            break; //unlock Area 5 level 1
        }
        SetUnlockedValues();
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