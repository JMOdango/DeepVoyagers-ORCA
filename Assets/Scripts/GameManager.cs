using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject completedLevel;
    public bool GameOver = false;
    public bool Complete = false;
    public scoreBar score;
    private void Start()
    {
        gameOverCanvas.SetActive(false);
        completedLevel.SetActive(false);
    }
    private void Update()
    {
        if (score.slider.value >= score.slider.maxValue)
        {
            stageComplete();
        }
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

    public void nextLevel()
    {
        SceneManager.LoadScene("Area1_LevelSelection");
        Complete = false;
    }

    public void stageComplete()
    {
        
            completedLevel.SetActive(true);
            Complete = true;
    }
}
