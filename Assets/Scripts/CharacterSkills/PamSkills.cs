using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PamSkills : MonoBehaviour
{
    InfoLockManager infoLock;
    public FindMatches selectRandomPiece;

    private Board board;

    public Image pamImage;
    public float fillSpeed = 0.5f;
    public double TargetBar = 0;
    double points;
    string level;
    void Start()
    {
        pamImage.fillAmount = 0;
        board = FindObjectOfType<Board>();
        selectRandomPiece = FindObjectOfType<FindMatches>();
        infoLock = FindObjectOfType<InfoLockManager>();
    }

    void Update()
    {
        if (pamImage.fillAmount < TargetBar)
        {
            pamImage.fillAmount += fillSpeed * Time.deltaTime;
        }
    }

    void Awake(){
        level = SceneManager.GetActiveScene().name;
    }

    public void GetPoints()
    {
        if (pamImage.fillAmount < 1)
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

    public void ReceivePointsFromOscar(int oscarBondLevel)
    {
        if (pamImage.fillAmount < 1)
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

    public void destroyRandomTrash()
    {
        if (pamImage.fillAmount == 1  && infoLock.GetPamBondUnlocked() < 1)
        {
            
            for (int i = 0; i < 10; i++)
            {
                int randomColumn = Random.Range(0, 8);
                int randomRow = Random.Range(0, 6);
                selectRandomPiece.randomTrashDestroy(randomColumn, randomRow);
            }
            
            board.DestroyMatches();
            pamImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
        else if (pamImage.fillAmount == 1  && infoLock.GetPamBondUnlocked() >= 1 && infoLock.GetPamBondUnlocked() < 2)
        {
            

            for (int i = 0; i < 15; i++)
            {
                int randomColumn = Random.Range(0, 8);
                int randomRow = Random.Range(0, 6);
                selectRandomPiece.randomTrashDestroy(randomColumn, randomRow);
            }
            
            board.DestroyMatches();
            pamImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
        else if (pamImage.fillAmount == 1  && infoLock.GetPamBondUnlocked() >= 2 && infoLock.GetPamBondUnlocked() < 3)
        {
           

            for (int i = 0; i < 20; i++)
            {
                 int randomColumn = Random.Range(0, 8);
                 int randomRow = Random.Range(0, 6);
                selectRandomPiece.randomTrashDestroy(randomColumn, randomRow);
            }
            
            board.DestroyMatches();
            pamImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
        else if (pamImage.fillAmount == 1  && infoLock.GetPamBondUnlocked() >= 3)
        {
            

            for (int i = 0; i < 30; i++)
            {
                int randomColumn = Random.Range(0, 8);
                int randomRow = Random.Range(0, 6);
                selectRandomPiece.randomTrashDestroy(randomColumn, randomRow);
            }
            
            board.DestroyMatches();
            pamImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
    }

}
