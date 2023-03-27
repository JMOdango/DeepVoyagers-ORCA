using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MalachiSkills : MonoBehaviour
{
  

    private Board board;

    public Image malachiImage;
    public float fillSpeed = 0.5f;
    public double TargetBar = 0;
    double points;
    string level;

    public scoreBar ScoreBar;
    public int pointGive = 250;
    void Start()
    {
        malachiImage.fillAmount = 0;
        board = FindObjectOfType<Board>();
        ScoreBar = FindObjectOfType<scoreBar>();
    }

    void Awake(){
        level = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (malachiImage.fillAmount < TargetBar)
        {
            malachiImage.fillAmount += fillSpeed * Time.deltaTime;
        }
    }

    public void GetPoints()
    {
        if (malachiImage.fillAmount < 1)
        {
            switch(level){
                case "Level1": points += Random.Range(0.30f, 0.50f); break;
                case "Level2": points += Random.Range(0.30f, 0.40f); break;
                case "Level3": points += Random.Range(0.20f, 0.40f); break;
                case "Level4": points += Random.Range(0.20f, 0.30f); break;
                case "Level5": points += Random.Range(0.10f, 0.30f); break;
            }
            increaseBar(points);
            board.getPoints = false;
        }
    }
    public void increaseBar(double score)
    {
        TargetBar = score;
    }

    public void giveScore() {
        if (malachiImage.fillAmount == 1)
        {
            ScoreBar.SetScore(pointGive);
            malachiImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
    }
}
