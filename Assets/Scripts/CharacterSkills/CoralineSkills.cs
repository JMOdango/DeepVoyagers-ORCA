using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralineSkills : MonoBehaviour
{
    public FindMatches selectRandomSquare;
    CoralineBar coralineBar;
    public bool isUsed = false;
    private Board board;
    [SerializeField]
    private CharacterData characterData;
    // Start is called before the first frame update
    void Start()
    {

        characterData.CoralinePoints = 0;
        board = FindObjectOfType<Board>();
        coralineBar = FindObjectOfType<CoralineBar>();
        selectRandomSquare = FindObjectOfType<FindMatches>();
        //destroyRandomColumn();
    }
    public void destroyRandomSquare()
    {
        if (coralineBar.coralineBar.fillAmount == 1)
        {
            int randomRow = Random.Range(0, 6);
            int randomColumn = Random.Range(0, 8);
            selectRandomSquare.randomDestroySquare(randomColumn, randomRow);
            board.DestroyMatches();
            coralineBar.coralineBar.fillAmount = 0;
            coralineBar.TargetBar = 0;
            characterData.CoralinePoints = 0;
        }


    }
}
