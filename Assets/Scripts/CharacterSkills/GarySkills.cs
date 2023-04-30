using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GarySkills : MonoBehaviour
{
    InfoLockManager infoLock;
    public FindMatches selectRandomRow;
    private Board board;
    public Image garyImage;
    public float fillSpeed = 0.5f;
    public double TargetBar = 0;
    double points;
    string level;

    // Start is called before the first frame update
    void Start()
    {
        garyImage.fillAmount = 0;
        board = FindObjectOfType<Board>();
        selectRandomRow = FindObjectOfType<FindMatches>();
        infoLock = FindObjectOfType<InfoLockManager>();
    }
    void Update()
    {
        if (garyImage.fillAmount < TargetBar)
        {
            garyImage.fillAmount += fillSpeed * Time.deltaTime;
        }
    
    }

    void Awake(){
        level = SceneManager.GetActiveScene().name;
    }

    public void GetPoints()
    {
        if (garyImage.fillAmount < 1)
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
        if (garyImage.fillAmount < 1)
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

    public void destroyRandomRow()
    {
        if (garyImage.fillAmount == 1 && infoLock.GetGaryBondUnlocked() < 1)
        {
            int randomRow = Random.Range(0, 6);
            selectRandomRow.randomDestroyRow(randomRow);
            board.DestroyMatches();
            garyImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
        else if(garyImage.fillAmount == 1 && infoLock.GetGaryBondUnlocked() >= 1 && infoLock.GetGaryBondUnlocked() < 2){
            int randomRow = Random.Range(0, 3);
            int randomRow2 = Random.Range(4, 6);
            selectRandomRow.randomDestroyRow(randomRow);
            selectRandomRow.randomDestroyRow(randomRow2);
            board.DestroyMatches();
            garyImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
        else if(garyImage.fillAmount == 1 && infoLock.GetGaryBondUnlocked() >= 1 && infoLock.GetGaryBondUnlocked() < 2){
            int randomRow = Random.Range(0, 3);
            int randomRow2 = Random.Range(4, 6);
            selectRandomRow.randomDestroyRow(randomRow);
            selectRandomRow.randomDestroyRow(randomRow2);
            board.DestroyMatches();
            garyImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
        else if(garyImage.fillAmount == 1 && infoLock.GetGaryBondUnlocked() >= 2  && infoLock.GetGaryBondUnlocked() < 3){
            int randomRow = Random.Range(0, 2);
            int randomRow2 = Random.Range(3, 4);
            int randomRow3 = Random.Range(5, 6);
            selectRandomRow.randomDestroyRow(randomRow);
            selectRandomRow.randomDestroyRow(randomRow2);
            selectRandomRow.randomDestroyRow(randomRow3);
            board.DestroyMatches();
            garyImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
        else if(garyImage.fillAmount == 1 && infoLock.GetGaryBondUnlocked() >= 3){
            int randomRow = Random.Range(0, 1);
            int randomRow2 = Random.Range(2, 3);
            int randomRow3 = Random.Range(4, 5);
            int randomRow4 = Random.Range(6, 6);
            selectRandomRow.randomDestroyRow(randomRow);
            selectRandomRow.randomDestroyRow(randomRow2);
            selectRandomRow.randomDestroyRow(randomRow3);
            selectRandomRow.randomDestroyRow(randomRow4);
            board.DestroyMatches();
            garyImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
    }
}