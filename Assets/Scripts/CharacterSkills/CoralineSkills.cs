using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoralineSkills : MonoBehaviour
{
    public FindMatches selectRandomSquare;
    private Board board;
    public Image coralineImage;
    public float fillSpeed = 0.5f;
    public double TargetBar = 0;
    double points;
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

    public void GetPoints() {
        if (coralineImage.fillAmount < 1) {

            points += Random.Range(0.04f, 0.08f);
            increaseBar(points);
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
