using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DianeSkills : MonoBehaviour
{


    private Board board;

    public Image dianeImage;
    public float fillSpeed = 0.5f;
    public double TargetBar = 0;
    double points;

    public FindMatches selectRandomColumn;
    public FindMatches selectRandomRow;
    void Start()
    {
        dianeImage.fillAmount = 0;
        board = FindObjectOfType<Board>();
        selectRandomRow = FindObjectOfType<FindMatches>();
        selectRandomColumn = FindObjectOfType<FindMatches>();

    }

    void Update()
    {
        if (dianeImage.fillAmount < TargetBar)
        {
            dianeImage.fillAmount += fillSpeed * Time.deltaTime;
        }
    }

    public void GetPoints()
    {
        if (dianeImage.fillAmount < 1)
        {
            points += Random.Range(0.04f, 0.08f);
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
        if (dianeImage.fillAmount == 1)
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


    }

}
