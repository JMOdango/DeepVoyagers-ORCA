using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MariSkills : MonoBehaviour
{

    public FindMatches selectRandomColumn;
    private Board board;
    InfoLockManager infoLock;
    public Image mariImage;
    public float fillSpeed = 0.5f;
    public double TargetBar = 0;
    double points;
    string level;
    // Start is called before the first frame update
    void Start()
    {
        mariImage.fillAmount = 0;
        board = FindObjectOfType<Board>();
        selectRandomColumn = FindObjectOfType<FindMatches>();
        infoLock = FindObjectOfType<InfoLockManager>();
    }

    void Update()
    {
        if (mariImage.fillAmount < TargetBar)
        {
            mariImage.fillAmount += fillSpeed * Time.deltaTime;
        }   
    }

    void Awake(){
        level = SceneManager.GetActiveScene().name;
    }

    public void GetPoints()
    {
        if ( mariImage.fillAmount < 1)
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
        if (mariImage.fillAmount < 1)
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


    public void destroyRandomColumn() {

        if (mariImage.fillAmount == 1  && infoLock.GetMariBondUnlocked() < 1) {
            int randomColumn = Random.Range(0, 8);
            selectRandomColumn.randomDestroyColumn(randomColumn);
            board.DestroyMatches();
            mariImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
       else if (mariImage.fillAmount == 1  && infoLock.GetMariBondUnlocked() >= 1 && infoLock.GetMariBondUnlocked() < 2) {
            int randomColumn = Random.Range(0, 4);
            selectRandomColumn.randomDestroyColumn(randomColumn);

            int randomColumn2 = Random.Range(5, 8);
            selectRandomColumn.randomDestroyColumn(randomColumn2);
            board.DestroyMatches();
            mariImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
        else if (mariImage.fillAmount == 1  && infoLock.GetMariBondUnlocked() >= 2 && infoLock.GetMariBondUnlocked() < 3) {
            int randomColumn = Random.Range(0, 3);
            selectRandomColumn.randomDestroyColumn(randomColumn);

            int randomColumn2 = Random.Range(4, 5);
            selectRandomColumn.randomDestroyColumn(randomColumn2);

            int randomColumn3 = Random.Range(6, 8);
            selectRandomColumn.randomDestroyColumn(randomColumn3);
            board.DestroyMatches();
            mariImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
        else if (mariImage.fillAmount == 1  && infoLock.GetMariBondUnlocked() >=  3) {
            int randomColumn = Random.Range(0, 2);
            selectRandomColumn.randomDestroyColumn(randomColumn);

            int randomColumn2 = Random.Range(3, 4);
            selectRandomColumn.randomDestroyColumn(randomColumn2);

            int randomColumn3 = Random.Range(5, 6);
            selectRandomColumn.randomDestroyColumn(randomColumn3);

            int randomColumn4 = Random.Range(7, 8);
            selectRandomColumn.randomDestroyColumn(randomColumn4);
            board.DestroyMatches();
            mariImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
    }
}
