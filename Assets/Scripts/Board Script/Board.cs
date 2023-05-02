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
    public GameObject oilSpillPrefab;
    private bool[,] blankSpaces;
    public BackgroundTile[,] oilSpill;
    public GameObject[] dots;
    public GameObject destroyEffect;
    public GameObject[,] allDots;
    public DotController currentDot;
    private FindMatches findAllMatches;
    public TextMeshProUGUI moves;
    public scoreBar ScoreBar;
    [SerializeField]
    public MovesLeft MovesLeft;
    public RandomizeTrash goals;
    public TextGoal setGoalHere;
    public GivePointsToChar givePoints;
    public ObjectPool pool;
    public int oilCounter;
    public int mechanicCounter;
    public int playerMoves;
    private int i;
    private int j;
    public int firstScore = 0;
    public int x;
    public int numberOfTrashDestroyed;
    private int mechanicDotNumber;

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
    public bool hasOilSpill;
    public bool hasMechanics;
    public int trashDestroyed;
    public string whatTrash;

    public tileType[] boardLayout;

    // Start is called before the first frame update
    void Start()
    {
        oilSpill = new BackgroundTile[width, height];
        setGoalHere = FindObjectOfType<TextGoal>();
        delay = new WaitForSeconds(refillDelay);
        CheckRefillMatchesDelay = new WaitForSeconds(checkRefillMatchesDelay);
        DestroyEffectDelay = new WaitForSeconds(destroyEffectDelay);
        goals = FindObjectOfType<RandomizeTrash>();
        findAllMatches = FindObjectOfType<FindMatches>();
        blankSpaces = new bool[width, height];
        allDots = new GameObject[width, height];
        levelMechanics();
        SetUp();
    }

    private void Update()
    {
        setGoalHere.checkGoalComplete();

    }
    public void generateBlank() {
        for (int i = 0; i < boardLayout.Length; i++)
        {
            if (boardLayout[i].tileClass == Tileclass.Blank) {
                blankSpaces[boardLayout[i].x, boardLayout[i].y] = true;
            }
        }

    }

    public void generateOilSpill() {
        for (int i = 0; i < boardLayout.Length; i++)
        {
            if (boardLayout[i].tileClass == Tileclass.Breakable)
            {
                Vector2 tempPosition = new Vector2(boardLayout[i].x, boardLayout[i].y);
                GameObject tile = Instantiate(oilSpillPrefab,tempPosition, Quaternion.identity);
                oilSpill[boardLayout[i].x, boardLayout[i].y] = tile.GetComponent<BackgroundTile>();
                oilCounter++;
            }
        }
    }
    public void levelMechanics() {
        Scene scene = SceneManager.GetActiveScene();
        switch (scene.name)
        {
            case "Level1":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                ScoreBar.maxScore = 2000;
                break;
            case "Level2":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                ScoreBar.maxScore = 2500;
                break;
            case "Level3":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                ScoreBar.maxScore = 3000;
                break;
            case "Level4":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                mechanicDotNumber = 5;
                goals.mechanicArrayPlace = 5;
                hasMechanics = true;
                ScoreBar.maxScore = 3500;
                break;
            case "Level5":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                mechanicDotNumber = 5;
                goals.mechanicArrayPlace = 5;
                hasMechanics = true;
                ScoreBar.maxScore = 4000;
                break;
            case "Area2_level1":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                ScoreBar.maxScore = 2500;
                break;
            case "Area2_level2":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                ScoreBar.maxScore = 3000;
                break;
            case "Area2_level3":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                mechanicDotNumber = 5;
                goals.mechanicArrayPlace = 7;
                ScoreBar.maxScore = 3500;
                hasMechanics = true;
                break;
            case "Area2_level4":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                mechanicDotNumber = 5;
                goals.mechanicArrayPlace = 7;
                ScoreBar.maxScore = 4000;
                hasMechanics = true;
                break;
            case "Area2_level5":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                mechanicDotNumber = 5;
                goals.mechanicArrayPlace = 7;
                ScoreBar.maxScore = 4500;
                hasMechanics = true;
                break;
            case "Area3_level1":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                ScoreBar.maxScore = 3500;
                break;
            case "Area3_level2":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                ScoreBar.maxScore = 4000;
                break;
            case "Area3_level3":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                ScoreBar.maxScore = 4500;
                hasOilSpill = true;
                break;
            case "Area3_level4":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                ScoreBar.maxScore = 5000;
                hasOilSpill = true;
                break;
            case "Area3_level5":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                ScoreBar.maxScore = 5500;
                hasOilSpill = true;
                break;
            case "Area4_level1":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                mechanicDotNumber = 5;
                goals.mechanicArrayPlace = 6;
                hasMechanics = true;
                ScoreBar.maxScore = 3700;
                break;
            case "Area4_level2":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                mechanicDotNumber = 5;
                goals.mechanicArrayPlace = 6;
                hasMechanics = true;
                ScoreBar.maxScore = 3900;
                break;
            case "Area4_level3":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                mechanicDotNumber = 5;
                goals.mechanicArrayPlace = 6;
                ScoreBar.maxScore = 4100;
                hasMechanics = true;
                break;
            case "Area4_level4":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                mechanicDotNumber = 5;
                goals.mechanicArrayPlace = 6;
                ScoreBar.maxScore = 4300;
                hasMechanics = true;
                break;
            case "Area4_level5":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                mechanicDotNumber = 5;
                goals.mechanicArrayPlace = 6;
                ScoreBar.maxScore = 4500;
                hasMechanics = true;
                break;
            case "Area5_level1":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                hasOilSpill = true;
                ScoreBar.maxScore = 3900;
                break;
            case "Area5_level2":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                mechanicDotNumber = 5;
                goals.mechanicArrayPlace = 6;
                hasMechanics = true;
                ScoreBar.maxScore = 4200;
                break;
            case "Area5_level3":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                mechanicDotNumber = 5;
                goals.mechanicArrayPlace = 7;
                hasMechanics = true;
                ScoreBar.maxScore = 4500;
                break;
            case "Area5_level4":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                mechanicDotNumber = 5;
                goals.mechanicArrayPlace = 6;
                ScoreBar.maxScore = 4800;
                hasMechanics = true;
                hasOilSpill = true;
                break;
            case "Area5_level5":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                mechanicDotNumber = 5;
                goals.mechanicArrayPlace = 6;
                ScoreBar.maxScore = 5100;
                hasMechanics = true;
                hasOilSpill = true;
                break;
            case "Final_level1":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                mechanicDotNumber = 5;
                goals.mechanicArrayPlace = 6;
                ScoreBar.maxScore = 3700;
                hasMechanics = true;
                hasOilSpill = true;
                break;
            case "Final_level2":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                mechanicDotNumber = 5;
                goals.mechanicArrayPlace = 7;
                ScoreBar.maxScore = 4700;
                hasMechanics = true;
                hasOilSpill = true;
                break;
            case "Final_level3":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                mechanicDotNumber = 5;
                goals.mechanicArrayPlace = 6;
                ScoreBar.maxScore = 5700;
                hasMechanics = true;
                hasOilSpill = true;
                break;
            case "Final_level4":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                hasOilSpill = true;
                ScoreBar.maxScore = 6700;
                break;
            case "Final_level5":
                MovesLeft.Moves = playerMoves;
                moves.text = MovesLeft.Moves.ToString();
                mechanicDotNumber = 5;
                goals.mechanicArrayPlace = 7;
                ScoreBar.maxScore = 7700;
                hasMechanics = true;
                hasOilSpill = true;
                break;
        }
    }
    private void SetUp() {
        generateBlank();
        generateOilSpill();
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

                    if (hasMechanics) {
                        int randomNumber = Random.Range(0, 8);

                        if (randomNumber == 5 && j >= 2) {
                            mechanicCounter++;
                            GameObject dot = Instantiate(dots[mechanicDotNumber], tempPosition, Quaternion.identity);
                            dot.GetComponent<DotController>().row = j;
                            dot.GetComponent<DotController>().column = i;
                            dot.transform.parent = this.transform;
                            dot.name = "Mechanic";
                            allDots[i, j] = dot;
                        }

                        if ((randomNumber < 5 || randomNumber > 5) || (randomNumber == 5 && j < 2)) {
                            int dotToUse = Random.Range(0, 5);
                            int maxIterations = 0;
                            if (dotToUse == 5) {
                                dotToUse = 4;
                            }
                            while (MatchesAt(i, j, dots[dotToUse]) && maxIterations < 100)
                            {
                                dotToUse = Random.Range(0, 4);
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

                    if (!hasMechanics) {
                        int dotToUse = Random.Range(0, 5);
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
                    //int dotToUse = Random.Range(0, dots.Length);

                    //int maxIterations = 0;
                    //while (MatchesAt(i, j, dots[dotToUse]) && maxIterations < 100)  
                    //{
                    //    dotToUse = Random.Range(0, dots.Length);
                    //    maxIterations++;
                    //}
                    //maxIterations = 0;
                    //GameObject dot = Instantiate(dots[dotToUse], tempPosition, Quaternion.identity);
                    //dot.GetComponent<DotController>().row = j;
                    //dot.GetComponent<DotController>().column = i;
                    //dot.transform.parent = this.transform;
                    //dot.name = "( " + i + "," + j + ")";
                    //allDots[i, j] = dot;
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

        } else if (column <= 1 || row <= 1)
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
        if (allDots[column, row].GetComponent<DotController>().isMatched || allDots[column, row].GetComponent<DotController>().isBottom)
        {
            if (findAllMatches.currentMatches.Count == 4 || findAllMatches.currentMatches.Count == 7) {
                findAllMatches.checkBombs();
            }
            if (oilSpill[column,row] != null)
            {
                oilSpill[column, row].takeDamage(1);
            }
            dotReuse(column,row);
            StartCoroutine(DestroyReuse(column,row));
            givePoints.checkInstantiate();
            trashDestroyed++;
            setGoalHere.minusCollect(whatTrash);
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

    private bool mechanicIsBottom() {
        for (int i = 0; i < width; i++)
        {
            if (allDots[i,0] != null)
            {
                if (allDots[i,0].GetComponent<DotController>().isMechanic) {
                    return true;
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
        yield return new WaitForSeconds(.4f);

        while (mechanicIsBottom())
        {
            currentState = GameState.wait;
            yield return CheckRefillMatchesDelay;
            checkMechanic();
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
        if (!allDots[column, row].GetComponent<DotController>().isMechanic && !allDots[column, row].GetComponent<DotController>().isBottom) {
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

        if (allDots[column, row].GetComponent<DotController>().isMechanic && !allDots[column, row].GetComponent<DotController>().isBottom)
        {
            setGoalHere.minusCollect(allDots[column, row].GetComponent<DotController>().tag);
            Destroy(allDots[column, row]);
        }
        if (allDots[column, row].GetComponent<DotController>().isMechanic && allDots[column, row].GetComponent<DotController>().isBottom)
        {
            Destroy(allDots[column, row]);
        }
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

    public void checkMechanic() {
        for (int i = 0; i < width; i++)
        {
            if (allDots[i,0] != null)
            {
                if (allDots[i, 0].GetComponent<DotController>().isMechanic) {
                    allDots[i, 0].GetComponent<DotController>().isBottom = true;
                    setGoalHere.minusCollect(allDots[i, 0].GetComponent<DotController>().tag);
                    //StartCoroutine(DestroyReuse(i,0));
                    //StartCoroutine(DecreaseRowCo2());
                }
            }
        }
    }
}
