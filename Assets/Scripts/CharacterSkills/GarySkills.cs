using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarySkills : MonoBehaviour
{

    public FindMatches selectRandomRow;
    GaryBar garyBar;
    public bool isUsed = false;
    private Board board;
    [SerializeField]
    private CharacterData characterData;
    // Start is called before the first frame update
    void Start()
    {

        characterData.GaryPoints = 0;
        board = FindObjectOfType<Board>();
        garyBar = FindObjectOfType<GaryBar>();
        selectRandomRow = FindObjectOfType<FindMatches>();
        //destroyRandomColumn();
    }
    public void destroyRandomRow()
    {
        if (garyBar.garyBar.fillAmount == 1)
        {
            int randomRow = Random.Range(0, 6);
            selectRandomRow.randomDestroyRow(randomRow);
            board.DestroyMatches();
            garyBar.garyBar.fillAmount = 0;
            garyBar.TargetBar = 0;
            characterData.GaryPoints = 0;
        }


    }
}
