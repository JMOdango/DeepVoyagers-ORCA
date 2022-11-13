using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MariSkills : MonoBehaviour
{

    public FindMatches selectRandomColumn;
    MariBar mariBar;
    public bool isUsed = false;
    private Board board;
    [SerializeField]
    private CharacterData characterData;
    // Start is called before the first frame update
    void Start()
    {
       
        characterData.MariPoints = 0;
        board = FindObjectOfType<Board>();
        mariBar = FindObjectOfType<MariBar>();
        selectRandomColumn = FindObjectOfType<FindMatches>();
        //destroyRandomColumn();
    }
    public void destroyRandomColumn() {
        if (mariBar.mariBar.fillAmount == 1) {
            int randomColumn = Random.Range(0, 8);
            selectRandomColumn.randomDestroyColumn(randomColumn);
            board.DestroyMatches();
            mariBar.mariBar.fillAmount = 0;
            mariBar.TargetBar = 0;
            characterData.MariPoints = 0;
        }
            
        
    }
}
