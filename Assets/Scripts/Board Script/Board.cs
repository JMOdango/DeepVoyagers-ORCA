using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;

public enum GameState
{
    wait,
    move
}

public enum Tileclass { 
    Breakable,
    Blank,
    Normal
}

[System.Serializable]
public class tileType {
    public int x;
    public int y;
    public Tileclass tileClass;
}
public class Board : MonoBehaviour
{
    public GameState currentState = GameState.move;
    public int width;
    public int height;
    public int offSet;
    public GameObject tilePrefab;
    private bool[,] blankSpaces;
    public GameObject[] dots;
    public GameObject destroyEffect;
    public GameObject[,] allDots;
    public DotController currentDot;
    private FindMatches findAllMatches;
    public TextMeshProUGUI moves;
    public TextMeshProUGUI[] numberToCollect; // stores the texts that needs to be changed -JM 
    public scoreBar ScoreBar;
    [SerializeField]
    public MovesLeft MovesLeft;
    public RandomizeTrash goals;
    public GivePointsToChar givePoints;
    public ObjectPool pool;
    private int i;
    private int j;
    public int firstScore = 0;
    public int x;
    public int numberOfTrashDestroyed;

    public float refillDelay = 1f;
    private float checkRefillMatchesDelay = .75f;
    private float destroyEffectDelay = 1.2f;
    private WaitForSeconds delay;
    private WaitForSeconds CheckRefillMatchesDelay;
    private WaitForSeconds DestroyEffectDelay;

    public bool destroyed = false;
    public bool getPoints = false;
    public bool isDeadlocked = false;
    public bool completeOrFailed = false;
    public int trashDestroyed;
    public string whatTrash;

    [Header("Assign Here Amount of Trash to be Collected, Number of Moves")] //-JM
    public int assignGoal1;
    public int assignGoal2;
    public int assignGoal3;
    public int assignMoves;

    public enum GoalsForThisLevel {one, two, three}; //Pick how many goals the level has. This will hide the text and icon of other goals that are not needed. -JM
    public GoalsForThisLevel goalAmount = GoalsForThisLevel.one;

    public tileType[] boardLayout;

    // Start is called before the first frame update
    void Start()
    {
        

        delay = new WaitForSeconds(refillDelay);
        CheckRefillMatchesDelay = new WaitForSeconds(checkRefillMatchesDelay);
        DestroyEffectDelay = new WaitForSeconds(destroyEffectDelay);
        goals = FindObjectOfType<RandomizeTrash>();
        // MovesLeft.Moves = Random.Range(15,25); //randomize amount of moves

        // these are a public variable where you write down manually the amount you want to collect -JM
        MovesLeft.Moves = assignMoves;
        MovesLeft.TrashCollected1 = assignGoal1;
        MovesLeft.TrashCollected2 = assignGoal2;
        MovesLeft.TrashCollected3 = assignGoal3;
        
        moves.text = MovesLeft.Moves.ToString();

        switch(goalAmount.ToString()){
            case "one": 
                numberToCollect[0].text = MovesLeft.TrashCollected1.ToString(); 
                numberToCollect[1].text = "";
                numberToCollect[2].text = "";
            break;
            case "two": 
                numberToCollect[0].text = MovesLeft.TrashCollected1.ToString(); 
                numberToCollect[1].text = MovesLeft.TrashCollected2.ToString(); 
                numberToCollect[2].text = "";
            break;
            case "three": 
                numberToCollect[0].text = MovesLeft.TrashCollected1.ToString(); 
                numberToCollect[1].text = MovesLeft.TrashCollected2.ToString(); 
                numberToCollect[2].text = MovesLeft.TrashCollected3.ToString(); 
            break;
        }

        findAllMatches = FindObjectOfType<FindMatches>();
        blankSpaces = new bool[width, height];
        allDots = new GameObject[width, height];
        SetUp();

    }

    public void generateBlank() {
        for (int i = 0; i < boardLayout.Length; i++)
        {
            if (boardLayout[i].tileClass == Tileclass.Blank ) {
                blankSpaces[boardLayout[i].x, boardLayout[i].y] = true;
            }
        }
    
    }
    private void SetUp() {
        generateBlank();
        for (i = 0; i < width; i++)
        {
            for (j = 0; j < height; j++)
            {
                if (!blankSpaces[i, j])
                {
                    Vector2 tempPosition = new Vector2(i, j);
                    GameObject backgroundTile = Instantiate(tilePrefab, new Vector3(i, j), Quaternion.identity) as GameObject;
                    backgroundTile.transform.parent = this.transform;
                    backgroundTile.name = "( " + i + "," + j + ")";
                    int dotToUse = Random.Range(0, dots.Length);

                    int maxIterations = 0;
                    while (MatchesAt(i, j, dots[dotToUse]) && maxIterations < 100)  
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
    }

    private bool MatchesAt(int column, int row, GameObject piece)
    {
        if (column > 1 && row > 1) {
            if (allDots[column - 1, row] != null && allDots[column - 2, row] != null)
            {
                if (allDots[column - 1, row].tag == piece.tag && allDots[column - 2, row].tag == piece.tag)
                {
                    return true;
                }
            }

            if (allDots[column, row - 1] != null && allDots[column, row - 2] != null)
            {
                if (allDots[column, row - 1].tag == piece.tag && allDots[column, row - 2].tag == piece.tag)
                {
                    return true;
                }
            }
            
        }else if (column <= 1 || row <= 1)
        {
            if (row > 1)
            {
                if (allDots[column, row - 1] != null && allDots[column, row - 2] != null) {
                    if (allDots[column, row - 1].tag == piece.tag && allDots[column, row - 2].tag == piece.tag)
                    {
                        return true;
                    }
                }
               
            }
            if (column > 1)
            {
                if (allDots[column - 1, row] != null && allDots[column - 2, row] != null) {
                    if (allDots[column - 1, row].tag == piece.tag && allDots[column - 2, row].tag == piece.tag)
                    {
                        return true;
                    }
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
            dotReuse(column,row);
            StartCoroutine(DestroyReuse(column,row));
            givePoints.checkInstantiate();

            trashDestroyed++;

            // if (whatTrash == goals.whatToCollect) {
            //     if (MovesLeft.TrashCollected1 > 0)
            //     {
            //         MovesLeft.TrashCollected1--;
            //         numberToCollect[0].text = MovesLeft.TrashCollected1.ToString();
            //     }
                
            // } 
            // initial code changed it to the one below -JM

            if (whatTrash == goals.goalToCollect[0]) {
                if (MovesLeft.TrashCollected1 > 0)
                {
                    MovesLeft.TrashCollected1--;
                    numberToCollect[0].text = MovesLeft.TrashCollected1.ToString();
                }
                
            }

            if (whatTrash == goals.goalToCollect[1]) {
                if (MovesLeft.TrashCollected2 > 0)
                {
                    MovesLeft.TrashCollected2--;
                    numberToCollect[1].text = MovesLeft.TrashCollected2.ToString();
                }
                
            }

            if (whatTrash == goals.goalToCollect[2]) {
                if (MovesLeft.TrashCollected3 > 0)
                {
                    MovesLeft.TrashCollected3--;
                    numberToCollect[2].text = MovesLeft.TrashCollected3.ToString();
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
            x += (trashDestroyed * 100);
            givePoints.givePoints();
            ScoreBar.SetScore(x); 
            destroyed = false;
        }
        FindObjectOfType<simpleAudioManager>().Play("DestroyObject");
        findAllMatches.currentMatches.Clear();
        StartCoroutine(DecreaseRowCo2());
        numberOfTrashDestroyed += trashDestroyed;
        trashDestroyed = 0;
        x = 0;
    }


    private IEnumerator DecreaseRowCo2() {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (!blankSpaces[i,j] && allDots[i,j] == null) {
                    for (int k = j+1; k < height; k++)
                    {
                        if (allDots[i,k] != null) {
                            allDots[i, k].GetComponent<DotController>().row = j;
                            allDots[i, k] = null;
                             break;
                        }
                    }
                }
            }
        }
        yield return (delay);
        StartCoroutine(FillBoardCo());
    }
   

    private void RefillBoard()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j =0; j < height; j++)
            {
                if (allDots[i,j] == null && !blankSpaces[i,j])
                {
                    
                    GameObject trashToRefill = ObjectPool.instance.getPooledObject();
                    if (trashToRefill != null) {
                        Vector2 tempPosition = new Vector2(i, j + offSet);
                        trashToRefill.SetActive(true);
                        allDots[i, j] = trashToRefill;
                        trashToRefill.transform.position = tempPosition;
                        trashToRefill.transform.parent = this.transform;
                        trashToRefill.name = "( " + i + "," + j + ")";
                        trashToRefill.GetComponent<DotController>().row = j;
                        trashToRefill.GetComponent<DotController>().column = i;
                        pool.shufflePool();
                    }
                }
            }
        }
        getPoints = false;
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
        
        if (completeOrFailed == false) {
            RefillBoard();
        }
      
        yield return new WaitForSeconds (.8f);
            while (MatchesOnBoard())
            {
            currentState = GameState.wait;
            yield return CheckRefillMatchesDelay;
            DestroyMatches();

            }
        findAllMatches.currentMatches.Clear();
        currentDot = null;
        

        if (DeadLocked()) {
            isDeadlocked = true;
            Debug.Log("DEADLOCKED!!");
        }
        yield return delay;
        currentState = GameState.move;

    }

 

    public void dotReuse(int column, int row) {
        allDots[column, row].SetActive(false);
        allDots[column, row].GetComponent<DotController>().isMatched = false;
        allDots[column, row].GetComponent<DotController>().isRowBomb = false;
        allDots[column, row].GetComponent<DotController>().isColumnBomb = false;
        allDots[column, row].GetComponent<DotController>().isColorBomb = false;
        allDots[column, row].GetComponent<DotController>().isAdjacentBomb = false;
        pool.pooledObjects.Add(allDots[column, row]);
        allDots[column, row].name = allDots[column, row].tag;
        allDots[column, row].transform.parent = this.pool.transform;
        DestoryChild(allDots[column, row]);
    }


    private IEnumerator DestroyReuse(int column, int row) {
        GameObject destroy = DestroyPool.instance.getPooledObject();
        if (destroy != null)
        {
            destroy.transform.position = allDots[column, row].transform.position;
            destroy.SetActive(true);
        }
        yield return DestroyEffectDelay;
        destroy.SetActive(false);
    }
    public void DestoryChild(GameObject dotsWithChild) {

        for (var i = dotsWithChild.transform.childCount - 1; i >= 0; i--)
        {
                Destroy(dotsWithChild.transform.GetChild(i).gameObject);
        }
    }

    private void SwitchPieces(int column, int row, Vector2 direction) {


        GameObject holder = allDots[column + (int)direction.x, row + (int)direction.y] as GameObject;
        allDots[column + (int)direction.x, row + (int)direction.y] = allDots[column, row];
        allDots[column, row] = holder;
    }

    private bool CheckForMatches() {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (allDots[i,j]!= null) {
                    if (i < width - 2)
                    {
                        if (allDots[i + 1, j] != null & allDots[i + 2, j] != null)
                        {
                            if (allDots[i + 1, j].tag == allDots[i, j].tag && allDots[i + 2, j].tag == allDots[i, j].tag)
                            {
                                return true;
                            }
                        }
                    }
                    if (j < height - 2)
                    {
                        if (allDots[i, j + 1] != null && allDots[i, j + 2] != null)
                        {
                            if (allDots[i, j + 1].tag == allDots[i, j].tag && allDots[i, j + 2].tag == allDots[i, j].tag)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
        }
        return false;
    }

    private bool SwitchAndCheck(int column, int row, Vector2 direction) {
        SwitchPieces(column, row, direction);
        if (CheckForMatches()) {
            SwitchPieces(column,row,direction);
            return true;
        }
        SwitchPieces(column, row, direction);
        return false;
    }

    private bool DeadLocked() {

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (allDots[i, j] != null) {
                    if (i < width - 1) {
                        if (SwitchAndCheck(i,j,Vector2.right)) {
                            return false;
                        }
                    }
                    if (j < height - 1)
                    {
                        if (SwitchAndCheck(i,j,Vector2.up)) {
                            return false;
                        }
                    }
                }
            }
        }
        return true;
    }
}
