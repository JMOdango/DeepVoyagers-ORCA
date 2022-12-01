using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PamSkills : MonoBehaviour
{

    public FindMatches selectRandomPiece;

    private Board board;

    public Image pamImage;
    public float fillSpeed = 0.5f;
    public double TargetBar = 0;
    double points;
    void Start()
    {
        pamImage.fillAmount = 0;
        board = FindObjectOfType<Board>();
        selectRandomPiece = FindObjectOfType<FindMatches>();

    }

    void Update()
    {
        if (pamImage.fillAmount < TargetBar)
        {
            pamImage.fillAmount += fillSpeed * Time.deltaTime;
        }
    }

    public void GetPoints()
    {
        if (pamImage.fillAmount < 1)
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

    public void destroyRandomTrash()
    {
        if (pamImage.fillAmount == 1)
        {
            int randomColumn = Random.Range(0, 8);
            int randomRow = Random.Range(0, 6);
            selectRandomPiece.randomTrashDestroy(randomColumn, randomRow);
            board.DestroyMatches();
            pamImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }


    }

}
