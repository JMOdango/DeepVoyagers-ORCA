using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MariSkills : MonoBehaviour
{

    public FindMatches selectRandomColumn;
    private Board board;

    public Image mariImage;
    public float fillSpeed = 0.5f;
    public double TargetBar = 0;
    double points;
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

    public void GetPoints()
    {
        if ( mariImage.fillAmount < 1)
        {
            points += Random.Range(0.04f, 0.08f);
            increaseBar(points);

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
