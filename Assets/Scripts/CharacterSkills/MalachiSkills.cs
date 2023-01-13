using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MalachiSkills : MonoBehaviour
{
  

    private Board board;

    public Image malachiImage;
    public float fillSpeed = 0.5f;
    public double TargetBar = 0;
    double points;

    public scoreBar ScoreBar;
    public int pointGive = 250;
    void Start()
    {
        malachiImage.fillAmount = 0;
        board = FindObjectOfType<Board>();
        ScoreBar = FindObjectOfType<scoreBar>();

    }

    void Update()
    {
        if (malachiImage.fillAmount < TargetBar)
        {
            malachiImage.fillAmount += fillSpeed * Time.deltaTime;
        }
    }

    public void GetPoints()
    {
        if (malachiImage.fillAmount < 1)
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

    public void giveScore() {
        if (malachiImage.fillAmount == 1)
        {
            ScoreBar.SetScore(pointGive);
            malachiImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
    }
}
