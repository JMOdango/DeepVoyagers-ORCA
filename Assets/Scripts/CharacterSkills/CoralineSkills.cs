using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoralineSkills : MonoBehaviour
{
    InfoLockManager infoLock;
    public FindMatches selectRandomSquare;
    private Board board;
    public Image coralineImage;
    public float fillSpeed = 0.5f;
    public double TargetBar = 0;
    double points;
    string level;
    // Start is called before the first frame update
    void Start()
    {

        coralineImage.fillAmount = 0;
        board = FindObjectOfType<Board>();
        selectRandomSquare = FindObjectOfType<FindMatches>();
        infoLock = FindObjectOfType<InfoLockManager>();
    }
    void Update()
    {
        if (coralineImage.fillAmount < TargetBar)
        {
            coralineImage.fillAmount += fillSpeed * Time.deltaTime;
        }
    
    }

    void Awake(){
        level = SceneManager.GetActiveScene().name;
    }

    public void GetPoints() {
        if (coralineImage.fillAmount < 1) {
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
        if (coralineImage.fillAmount < 1)
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

    public void destroyRandomSquare()
    {
        // if (coralineImage.fillAmount == 1)
        // {
        //     int randomRow = Random.Range(1, 5);
        //     int randomColumn = Random.Range(1, 7);
        //     selectRandomSquare.randomDestroySquare(randomColumn, randomRow);
        //     board.DestroyMatches();
        //     coralineImage.fillAmount = 0;
        //     points = 0;
        //     TargetBar = 0;
        // }

        if (coralineImage.fillAmount == 1 && infoLock.GetCoralineBondUnlocked() < 1)
        {
            int randomRow = Random.Range(1, 5);
            int randomColumn = Random.Range(1, 7);
            selectRandomSquare.randomDestroySquare(randomColumn, randomRow);
            board.DestroyMatches();
            coralineImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
        else if(coralineImage.fillAmount == 1 && infoLock.GetCoralineBondUnlocked() >= 1 && infoLock.GetCoralineBondUnlocked() < 2){
            int randomRow = Random.Range(1, 2);
            int randomColumn = Random.Range(1, 4);
            selectRandomSquare.randomDestroySquare(randomColumn, randomRow);

            int randomRow2 = Random.Range(3, 5);
            int randomColumn2 = Random.Range(5, 7);
            selectRandomSquare.randomDestroySquare(randomColumn2, randomRow2);
            
            board.DestroyMatches();
            coralineImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
        else if(coralineImage.fillAmount == 1 && infoLock.GetCoralineBondUnlocked() >= 2 && infoLock.GetCoralineBondUnlocked() < 3){
            int randomRow = Random.Range(1, 2);
            int randomColumn = Random.Range(1, 2);
            selectRandomSquare.randomDestroySquare(randomColumn, randomRow);

            int randomRow2 = Random.Range(3, 4);
            int randomColumn2 = Random.Range(3, 4);
            selectRandomSquare.randomDestroySquare(randomColumn2, randomRow2);

            int randomRow3 = Random.Range(5, 6);
            int randomColumn3 = Random.Range(5, 7);
            selectRandomSquare.randomDestroySquare(randomColumn3, randomRow3);

            board.DestroyMatches();
            coralineImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
        else if(coralineImage.fillAmount == 1 && infoLock.GetCoralineBondUnlocked() >= 3){
            int randomRow = Random.Range(1, 2);
            int randomColumn = Random.Range(1, 2);
            selectRandomSquare.randomDestroySquare(randomColumn, randomRow);

            int randomRow2 = Random.Range(3, 4);
            int randomColumn2 = Random.Range(3, 4);
            selectRandomSquare.randomDestroySquare(randomColumn2, randomRow2);

            int randomRow3 = Random.Range(5, 5);
            int randomColumn3 = Random.Range(5, 6);
            selectRandomSquare.randomDestroySquare(randomColumn3, randomRow3);

            int randomRow4 = Random.Range(6, 6);
            int randomColumn4 = Random.Range(7, 7);
            selectRandomSquare.randomDestroySquare(randomColumn4, randomRow4);

            board.DestroyMatches();
            coralineImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }


    }
}
