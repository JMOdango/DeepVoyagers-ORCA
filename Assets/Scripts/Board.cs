using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Pool;
public enum GameState
{
    wait,
    move
}
public class Board : MonoBehaviour
{
    
    public GameState currentState = GameState.move;
    public int width;
    public int height;
    public int offSet;
    public GameObject tilePrefab;
    private BackgroundTile[,] allTiles;
    public GameObject[] dots;
    public GameObject destroyEffect;
    public GameObject[,] allDots;
    public DotController currentDot;
    private FindMatches findAllMatches;
    public TextMeshProUGUI moves;
    public TextMeshProUGUI numberToCollect;
    public scoreBar ScoreBar;
    CharacterBar characterBar;
    [SerializeField]
    public MovesLeft MovesLeft;
    [SerializeField]
    private CharacterData characterData;
    public RandomizeTrash toCollect;
    private int i;
    private int j;
    public int firstScore = 0;
    int x;
    
    public bool destroyed = false;
    public int trashDestroyed;
    public string whatTrash;
 
    // Start is called before the first frame update
    void Start()
    {

        characterBar = FindObjectOfType<CharacterBar>();
        toCollect = FindObjectOfType<RandomizeTrash>();
        MovesLeft.Moves = Random.Range(15,25);
        MovesLeft.TrashCollected = Random.Range(10,20);
        moves.text = MovesLeft.Moves.ToString();
        numberToCollect.text = MovesLeft.TrashCollected.ToString();
        findAllMatches = FindObjectOfType<FindMatches>();
        allTiles = new BackgroundTile[width, height];
        allDots = new GameObject[width, height];
        SetUp();
    }

 
    private void SetUp() {
        for (i = 0; i < width; i++)
        {
            for ( j = 0; j < height; j++)
            {
                Vector2 tempPosition = new Vector2(i, j + offSet);
                GameObject backgroundTile = Instantiate(tilePrefab, new Vector3(i ,j , offSet), Quaternion.identity) as GameObject;
                backgroundTile.transform.parent = this.transform;
                backgroundTile.name = "( " + i + "," + j + ")";
                int dotToUse = Random.Range(0, dots.Length);

                int maxIterations = 0;
                while(MatchesAt(i, j, dots[dotToUse]) && maxIterations < 100)
                {
                    dotToUse = Random.Range(0, dots.Length);
                    maxIterations++;
                }
                maxIterations = 0;
                GameObject dot = Instantiate(dots[dotToUse], tempPosition, Quaternion.identity);
                dot.GetComponent<DotController>().row = j;
                dot.GetComponent<DotController>().column = i;
                dot.transform.parent = this.transform;
                dot.name = "( " + i + "," + j + ")";
                allDots[i, j] = dot;
            }
        }
    }



    private bool MatchesAt(int column, int row, GameObject piece)
    {
        if (column > 1 && row > 1) {
            if (allDots[column - 1, row].tag == piece.tag && allDots[column-2, row].tag == piece.tag)
            {
                return true;
            }
            if (allDots[column, row - 1].tag == piece.tag && allDots[column, row - 2].tag == piece.tag)
            {
                return true;
            }
        }else if (column <= 1 || row <= 1)
        {
            if (row > 1)
            {
                if (allDots[column, row - 1].tag == piece.tag && allDots[column, row - 2].tag == piece.tag)
                {
                    return true;
                }
            }
            if (column > 1)
            {
                if (allDots[column - 1, row].tag == piece.tag && allDots[column - 2, row].tag == piece.tag)
                {
                    return true;
                }
            }
        }
        
        return false;
    }

    private void DestroyMatchesAt(int column, int row)
    {
        destroyed = true;
        if (allDots[column,row].GetComponent<DotController>().isMatched)
        {
            if (findAllMatches.currentMatches.Count == 4 || findAllMatches.currentMatches.Count == 7) {
                findAllMatches.checkBombs();
            }
            Destroy(allDots[column, row]);
            GameObject particle =  Instantiate(destroyEffect, allDots[column, row].transform.position, Quaternion.identity);
            Destroy(particle, .85f);
            trashDestroyed++;
            if (whatTrash == toCollect.whatToCollect) {
                if (MovesLeft.TrashCollected > 0)
                {
                    MovesLeft.TrashCollected--;
                    numberToCollect.text = MovesLeft.TrashCollected.ToString();
                }
                
            }
            allDots[column, row] = null;

        }
   
    }

    public void DestroyMatches()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (allDots[i, j] != null)
                {
                    DestroyMatchesAt(i, j);
                  
                }
            }
        }
        if (destroyed)
        {
            x =+ (trashDestroyed * 100);
            characterPoints();
            ScoreBar.SetScore(x); 
            destroyed = false;
        }
        findAllMatches.currentMatches.Clear();
        StartCoroutine(DecreaseRowCo());
    }

   

    private IEnumerator DecreaseRowCo()
    {
        int nullCount = 0;
        for(int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (allDots[i,j] == null)
                {
                    nullCount++;
                }else if (nullCount > 0)
                {
                    allDots[i, j].GetComponent<DotController>().row -= nullCount;
                    allDots[i, j] = null;
                }
            }
            nullCount = 0;
        }
        yield return new WaitForSeconds(.01f);
        StartCoroutine(FillBoardCo());
    }

    private void RefillBoard()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j =0; j < height; j++)
            {
                if (allDots[i,j] == null)
                {
                    Vector2 tempPosition = new Vector2(i, j + offSet);
                    int dotToUse = Random.Range(0, dots.Length);
                    GameObject piece = Instantiate(dots[dotToUse], tempPosition, Quaternion.identity);
                    allDots[i, j] = piece;
                    piece.transform.parent = this.transform;
                    piece.name = "( " + i + "," + j + ")";
                    piece.GetComponent<DotController>().row = j;
                    piece.GetComponent<DotController>().column = i;
                }
            }
        }
    }

    private bool MatchesOnBoard()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (allDots[i,j] != null)
                {
                    if (allDots[i, j].GetComponent<DotController>().isMatched)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private IEnumerator FillBoardCo()
    {
        RefillBoard();
        yield return new WaitForSeconds(.1f);
        while (MatchesOnBoard())
        {
            yield return new WaitForSeconds(.1f);
            DestroyMatches();
        }
        findAllMatches.currentMatches.Clear();
        currentDot = null;
        yield return new WaitForSeconds(.1f);
        currentState = GameState.move;

    }


    public void characterPoints()
    {
        if (characterBar.maribar.TargetBar < 1) {
            characterData.MariPoints += Random.Range(0.01f, 0.05f);
            characterBar.callMariBar(characterData.MariPoints);
        }
        if (characterBar.garybar.TargetBar < 1)
        {
            characterData.GaryPoints += Random.Range(0.01f, 0.05f);
            characterBar.callGaryBar(characterData.GaryPoints);
        }
        if (characterBar.coralinebar.TargetBar < 1) {
            characterData.CoralinePoints += Random.Range(0.01f, 0.05f);
            characterBar.callCoralineBar(characterData.CoralinePoints);
        }
    }
}
