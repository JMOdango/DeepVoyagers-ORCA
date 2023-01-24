using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemSkills : MonoBehaviour
{
    [SerializeField]
    public MovesLeft MovesLeft;
    public Board board;
    public ItemShopCloseUp closeup;
    public FindMatches selectPieces;

   

    // Start is called before the first frame update
    void Start()
    {
        board = board.GetComponent<Board>();
        closeup = closeup.GetComponent<ItemShopCloseUp>();
        selectPieces = FindObjectOfType<FindMatches>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    //MysteriousSnack

    public void UseMysteriousSnack()
    {
    MovesLeft.Moves += 3;
    board.moves.text = MovesLeft.Moves.ToString();
    closeup.CloseCloseUp();
    }

    //VoidGem

    public void UseVoidGem()
    {
        int randomColumn = Random.Range(0, 8);
        int randomRow = Random.Range(0, 6);
        selectPieces.randomTrashDestroy(randomColumn, randomRow);
        board.DestroyMatches();
        closeup.CloseCloseUp();
    }

    //UseNet
     
    public void UseNet()
    {
        int randomColumn = Random.Range(1, 7);
        int randomRow = Random.Range(1, 5);
        selectPieces.randomDestroySquare(randomColumn, randomRow);
        board.DestroyMatches();
        closeup.CloseCloseUp();
    }

    //useTrident

    public void UseTrident()
    {
        int randomColumn = Random.Range(0, 8);
        selectPieces.randomDestroyColumn(randomColumn);
        board.DestroyMatches();
    }

    //UseMermaidOrb - get all glass trash 1

    public void UseMermaidOrb()
    {
        int allColumns = board.width;
        int allRows = board.height;
        selectPieces.getGlassPieces();
        board.DestroyMatches();
        closeup.CloseCloseUp();
    }

    //UseBasket - get all fabric trash 2

    public void UseBasket()
    {
        int allColumns = board.width;
        int allRows = board.height;
        selectPieces.getFabricPieces();
        board.DestroyMatches();
        closeup.CloseCloseUp();
    }

    //UseMagnet - get all plastic trash 3

    public void UseMagnet()
    {
        int allColumns = board.width;
        int allRows = board.height;
        selectPieces.getMetalPieces();
        board.DestroyMatches();
        closeup.CloseCloseUp();
    }

    //UsePocketWatch - get all organic trash 4

    public void UsePocketWatch()
    {
        int allColumns = board.width;
        int allRows = board.height;
        selectPieces.getOrganicPieces();
        board.DestroyMatches();
        closeup.CloseCloseUp();
    }

    //UseFungi - get all plastic trash 5

    public void UseFungi()
    {
        int allColumns = board.width;
        int allRows = board.height;
        selectPieces.getPlasticPieces();
        board.DestroyMatches();
        closeup.CloseCloseUp();
    }

    




    
    
}