using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MariSkills : MonoBehaviour
{

    public FindMatches selectRandomColumn;
    private Board board;

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
        if (mariImage.fillAmount == 1) {
            int randomColumn = Random.Range(0, 8);
            selectRandomColumn.randomDestroyColumn(randomColumn);
            board.DestroyMatches();
            mariImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
            
        
    }
}
