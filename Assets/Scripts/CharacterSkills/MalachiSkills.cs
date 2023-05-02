using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MalachiSkills : MonoBehaviour
{
  
    InfoLockManager infoLock;
    private Board board;

    public Image malachiImage;
    public float fillSpeed = 0.5f;
    public double TargetBar = 0;
    double points;
    string level;

    public scoreBar ScoreBar;
    public int pointGive = 0;
    //public int pointGive = 250;
    void Start()
    {
        malachiImage.fillAmount = 0;
        board = FindObjectOfType<Board>();
        ScoreBar = FindObjectOfType<scoreBar>();
        infoLock = FindObjectOfType<InfoLockManager>();
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
                case "Area1_level1": points += Random.Range(0.10f, 0.30f); break;
                case "Area1_level2": points += Random.Range(0.10f, 0.30f); break;
                case "Area1_level3": points += Random.Range(0.10f, 0.30f); break;
                case "Area1_level4": points += Random.Range(0.10f, 0.30f); break;
                case "Area1_level5": points += Random.Range(0.10f, 0.30f); break;
                case "Area2_level1": points += Random.Range(0.10f, 0.30f); break;
                case "Area2_level2": points += Random.Range(0.10f, 0.30f); break;
                case "Area2_level3": points += Random.Range(0.10f, 0.30f); break;
                case "Area2_level4": points += Random.Range(0.10f, 0.30f); break;
                case "Area2_level5": points += Random.Range(0.10f, 0.30f); break;
                case "Area3_level1": points += Random.Range(0.10f, 0.30f); break;
                case "Area3_level2": points += Random.Range(0.10f, 0.30f); break;
                case "Area3_level3": points += Random.Range(0.10f, 0.30f); break;
                case "Area3_level4": points += Random.Range(0.10f, 0.30f); break;
                case "Area3_level5": points += Random.Range(0.10f, 0.30f); break;
                case "Area4_level1": points += Random.Range(0.10f, 0.30f); break;
                case "Area4_level2": points += Random.Range(0.10f, 0.30f); break;
                case "Area4_level3": points += Random.Range(0.10f, 0.30f); break;
                case "Area4_level4": points += Random.Range(0.10f, 0.30f); break;
                case "Area4_level5": points += Random.Range(0.10f, 0.30f); break;
                case "Area5_level1": points += Random.Range(0.10f, 0.30f); break;
                case "Area5_level2": points += Random.Range(0.10f, 0.30f); break;
                case "Area5_level3": points += Random.Range(0.10f, 0.30f); break;
                case "Area5_level4": points += Random.Range(0.10f, 0.30f); break;
                case "Area5_level5": points += Random.Range(0.10f, 0.30f); break;
                case "Final_level1": points += Random.Range(0.10f, 0.30f); break;
                case "Final_level2": points += Random.Range(0.10f, 0.30f); break;
                case "Final_level3": points += Random.Range(0.10f, 0.30f); break;
                case "Final_level4": points += Random.Range(0.10f, 0.30f); break;
                case "Final_level5": points += Random.Range(0.10f, 0.30f); break;
            }
            increaseBar(points);
            board.getPoints = false;
        }
    }

    public void ReceivePointsFromOscar(int oscarBondLevel)
    {
        if (malachiImage.fillAmount < 1)
        {
            switch(oscarBondLevel){
                case 3: points +=0.50f; break;
                case 2: points +=0.30f; break;
                case 1: points += 0.20f; break;
                case 0: points += 0.10f; break;
                
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
        if (malachiImage.fillAmount == 1 && infoLock.GetMalachiBondUnlocked() < 1)
        {
            pointGive = 250;
            ScoreBar.SetScore(pointGive);
            malachiImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
        else if (malachiImage.fillAmount == 1 && infoLock.GetMalachiBondUnlocked() >= 1 && infoLock.GetMalachiBondUnlocked() < 2)
        {
            pointGive = 300;
            ScoreBar.SetScore(pointGive);
            malachiImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
        else if (malachiImage.fillAmount == 1 && infoLock.GetMalachiBondUnlocked() >= 2 && infoLock.GetMalachiBondUnlocked() < 3)
        {
            pointGive = 350;
            ScoreBar.SetScore(pointGive);
            malachiImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
        else if (malachiImage.fillAmount == 1 && infoLock.GetMalachiBondUnlocked() >= 3)
        {
            pointGive = 400;
            ScoreBar.SetScore(pointGive);
            malachiImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
    }
}
