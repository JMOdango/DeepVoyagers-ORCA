using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GarySkills : MonoBehaviour
{
    RelationshipManager relationship;
    public const int firstthreshold = 15;
    public const int secondthreshold = 45;
    public const int thirdthreshold = 150;

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
    public void increaseBar(double score)
    {
        TargetBar = score;
    }

    public void destroyRandomRow()
    {
        int GaryBond = RelationshipManager.relationship.GetGary();
        if (garyImage.fillAmount == 1 && GaryBond < secondthreshold)
        {
            int randomRow = Random.Range(0, 6);
            selectRandomRow.randomDestroyRow(randomRow);
            board.DestroyMatches();
            garyImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
        else if(garyImage.fillAmount == 1 && GaryBond >= secondthreshold && GaryBond < thirdthreshold){
            int randomRow = Random.Range(0, 6);
            int randomRow2 = Random.Range(0, 6);
            selectRandomRow.randomDestroyRow(randomRow);
            selectRandomRow.randomDestroyRow(randomRow2);
            board.DestroyMatches();
            garyImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
        else if(garyImage.fillAmount == 1 && GaryBond >= thirdthreshold){
            int randomRow = Random.Range(0, 6);
            int randomRow2 = Random.Range(0, 6);
            int randomRow3 = Random.Range(0, 6);
            selectRandomRow.randomDestroyRow(randomRow);
            selectRandomRow.randomDestroyRow(randomRow2);
            selectRandomRow.randomDestroyRow(randomRow3);
            board.DestroyMatches();
            garyImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }

    }
}
