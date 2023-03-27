using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoralineSkills : MonoBehaviour
{
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
        if (coralineImage.fillAmount == 1)
        {
            int randomRow = Random.Range(1, 5);
            int randomColumn = Random.Range(1, 7);
            selectRandomSquare.randomDestroySquare(randomColumn, randomRow);
            board.DestroyMatches();
            coralineImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
    }
}
