using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PamSkills : MonoBehaviour
{

    public FindMatches selectRandomPiece;
    PamBar pamBar;
    public bool isUsed = false;
    private Board board;
    [SerializeField]
    private CharacterData characterData;
    void Start()
    {

        characterData.MariPoints = 0;
        board = FindObjectOfType<Board>();
        pamBar = FindObjectOfType<PamBar>();
        selectRandomPiece = FindObjectOfType<FindMatches>();
        //destroyRandomColumn();
    }
    public void destroyRandomTrash()
    {
        if (pamBar.pamBar.fillAmount == 1)
        {
            int randomColumn = Random.Range(0, 8);
            int randomRow = Random.Range(0, 6);
            selectRandomPiece.randomTrashDestroy(randomColumn, randomRow);
            board.DestroyMatches();
            pamBar.pamBar.fillAmount = 0;
            pamBar.TargetBar = 0;
        }


    }

}
