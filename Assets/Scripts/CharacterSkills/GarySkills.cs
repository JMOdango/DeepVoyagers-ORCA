using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GarySkills : MonoBehaviour
{

    public FindMatches selectRandomRow;
    private Board board;
    public Image garyImage;
    public float fillSpeed = 0.5f;
    public double TargetBar = 0;
    double points;
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

    public void GetPoints()
    {
        if (garyImage.fillAmount < 1)
        {
            points += Random.Range(0.04f, 0.08f);
            increaseBar(points);

        }
    }
    public void increaseBar(double score)
    {
        TargetBar = score;
    }

    public void destroyRandomRow()
    {
        if (garyImage.fillAmount == 1)
        {
            int randomRow = Random.Range(0, 6);
            selectRandomRow.randomDestroyRow(randomRow);
            board.DestroyMatches();
            garyImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }


    }
}
