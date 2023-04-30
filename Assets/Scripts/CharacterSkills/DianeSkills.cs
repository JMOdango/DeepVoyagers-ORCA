using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class DianeSkills : MonoBehaviour
{

    InfoLockManager infoLock;
    private Board board;

    public Image dianeImage;
    public float fillSpeed = 0.5f;
    public double TargetBar = 0;
    double points;
    string level;

    public FindMatches selectRandomColumn;
    public FindMatches selectRandomRow;
    void Start()
    {
        dianeImage.fillAmount = 0;
        board = FindObjectOfType<Board>();
        selectRandomRow = FindObjectOfType<FindMatches>();
        selectRandomColumn = FindObjectOfType<FindMatches>();
        infoLock = FindObjectOfType<InfoLockManager>();

    }

    void Update()
    {
        if (dianeImage.fillAmount < TargetBar)
        {
            dianeImage.fillAmount += fillSpeed * Time.deltaTime;
        }
    }

    void Awake(){
        level = SceneManager.GetActiveScene().name;
    }

    public void GetPoints()
    {
        if (dianeImage.fillAmount < 1)
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

    public void ReceivePointsFromOscar(int oscarBondLevel)
    {
        if (dianeImage.fillAmount < 1)
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


    public void destroyRandomColumn()
    {
        if (dianeImage.fillAmount == 1 && infoLock.GetDianeBondUnlocked() < 1)
        {
            int randomColumn = Random.Range(0, 8);
            selectRandomColumn.randomDestroyColumn(randomColumn);
            int randomRow = Random.Range(0, 6);
            selectRandomRow.randomDestroyRow(randomRow);
            board.DestroyMatches();
            dianeImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
        else if (dianeImage.fillAmount == 1 && infoLock.GetDianeBondUnlocked() >= 1 && infoLock.GetDianeBondUnlocked() < 2)
        {
            int randomColumn = Random.Range(0, 4);
            selectRandomColumn.randomDestroyColumn(randomColumn);
            int randomRow = Random.Range(0, 3);
            selectRandomRow.randomDestroyRow(randomRow);

            int randomColumn2 = Random.Range(5, 8);
            selectRandomColumn.randomDestroyColumn(randomColumn2);
            int randomRow2 = Random.Range(4, 6);
            selectRandomRow.randomDestroyRow(randomRow2);

            board.DestroyMatches();
            dianeImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
        else if (dianeImage.fillAmount == 1 && infoLock.GetDianeBondUnlocked() >= 2 && infoLock.GetDianeBondUnlocked() < 3)
        {
            int randomColumn = Random.Range(0, 2);
            selectRandomColumn.randomDestroyColumn(randomColumn);
            int randomRow = Random.Range(0, 2);
            selectRandomRow.randomDestroyRow(randomRow);

            int randomColumn2 = Random.Range(3, 4);
            selectRandomColumn.randomDestroyColumn(randomColumn2);
            int randomRow2 = Random.Range(3, 4);
            selectRandomRow.randomDestroyRow(randomRow2);

            int randomColumn3 = Random.Range(5, 8);
            selectRandomColumn.randomDestroyColumn(randomColumn3);
            int randomRow3 = Random.Range(5, 6);
            selectRandomRow.randomDestroyRow(randomRow3);


            board.DestroyMatches();
            dianeImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
        else if (dianeImage.fillAmount == 1 && infoLock.GetDianeBondUnlocked() >= 3)
        {
            int randomColumn = Random.Range(0, 1);
            selectRandomColumn.randomDestroyColumn(randomColumn);
            int randomRow = Random.Range(0, 1);
            selectRandomRow.randomDestroyRow(randomRow);

            int randomColumn2 = Random.Range(2, 3);
            selectRandomColumn.randomDestroyColumn(randomColumn2);
            int randomRow2 = Random.Range(2, 3);
            selectRandomRow.randomDestroyRow(randomRow2);

            int randomColumn3 = Random.Range(4, 5);
            selectRandomColumn.randomDestroyColumn(randomColumn3);
            int randomRow3 = Random.Range(4, 5);
            selectRandomRow.randomDestroyRow(randomRow3);

            int randomColumn4 = Random.Range(6, 8);
            selectRandomColumn.randomDestroyColumn(randomColumn4);
            int randomRow4 = Random.Range(5, 6);
            selectRandomRow.randomDestroyRow(randomRow4);

            board.DestroyMatches();
            dianeImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
    }

}
