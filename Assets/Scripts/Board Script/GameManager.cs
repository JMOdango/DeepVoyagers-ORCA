using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject completedLevel;
    [SerializeField]
    private MovesLeft moves;
    public bool GameOver = false;
    public bool Complete = false;
    public scoreBar score;
    public Board board;
    public string nextSceneName;
    public TextMeshProUGUI shellsText;
    public TextMeshProUGUI coinsText;
    public int shellsReward;
    public int coinsReward;
    
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
    }
}