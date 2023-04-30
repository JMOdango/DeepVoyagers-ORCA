using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FindMatches : MonoBehaviour
{
    TextGoal textgoal;
    private Board board;
    public List<GameObject> currentMatches = new List<GameObject>();
    private WaitForSeconds delayRoutine;
    private TextGoal goal;
    private float delay = .7f;

    // Start is called before the first frame update
    void Start()
    {
        textgoal = FindObjectOfType<TextGoal>();
        board = FindObjectOfType<Board>();
        goal = FindObjectOfType<TextGoal>();
        delayRoutine = new WaitForSeconds(delay);
    }

    private void Update()
    {
        findallmatches();
    }
    public void findallmatches()
    {
        StartCoroutine(FindAllMatchesCo());
    }

    private List<GameObject> isAdjacentBomb(DotController dot1, DotController dot2, DotController dot3) {
        List<GameObject> currentDots = new List<GameObject>();
        if (dot1.isAdjacentBomb)
        {
            currentMatches.Union(getAdjacentPieces(dot1.column,dot1.row));
        }
        if (dot2.isAdjacentBomb)
        {
            currentMatches.Union(getAdjacentPieces(dot2.column, dot2.row));
        }
        if (dot3.isAdjacentBomb)
        {
            currentMatches.Union(getAdjacentPieces(dot3.column, dot3.row));
        }
        return currentDots;
    }
    private List<GameObject> isRowBomb(DotController dot1, DotController dot2, DotController dot3)
    {
        List<GameObject> currentDots = new List<GameObject>();
        if (dot1.isRowBomb)
        {
            currentMatches.Union(GetRowPieces(dot1.row));
        }
        if (dot2.isRowBomb)
        {
            currentMatches.Union(GetRowPieces(dot2.row));
        }
        if (dot3.isRowBomb)
        {
            currentMatches.Union(GetRowPieces(dot3.row));
        }
        return currentDots;
    }

    private List<GameObject> isColumnBomb(DotController dot1, DotController dot2, DotController dot3)
    {
        List<GameObject> currentDots = new List<GameObject>();
        if (dot1.isColumnBomb)
        {
            currentMatches.Union(GetColumnPieces(dot1.column));
        }
        if (dot2.isColumnBomb)
        {
            currentMatches.Union(GetColumnPieces(dot2.column));
        }
        if (dot3.isColumnBomb)
        {
            currentMatches.Union(GetColumnPieces(dot3.column));
        }
        return currentDots;
    }

    private void AddToListandMatch(GameObject dot) {
        if (!currentMatches.Contains(dot))
        {
            currentMatches.Add(dot);
        }
        dot.GetComponent<DotController>().isMatched = true;
        board.whatTrash = dot.GetComponent<DotController>().tag;
    }
    private void getNearbyPieces(GameObject dot1, GameObject dot2, GameObject dot3) {

        AddToListandMatch(dot1);
        AddToListandMatch(dot2);
        AddToListandMatch(dot3);
    }
    public IEnumerator FindAllMatchesCo()
    {
        yield return delayRoutine;

        for (int i = 0; i < board.width; i++)
        {
            for (int j = 0; j < board.height; j++)
            {
                GameObject currentDot = board.allDots[i, j];
               
                if (currentDot != null)
                {
                    DotController currentDotDot = currentDot.GetComponent<DotController>();
                    if (i > 0 && i < board.width - 1)
                    {
                        GameObject leftDot = board.allDots[i - 1, j];
                        
                        GameObject rightDot = board.allDots[i + 1, j];
                        
                        if(leftDot != null && rightDot != null)
                        {
                            DotController leftDotDot = leftDot.GetComponent<DotController>();
                            DotController rightDotDot = rightDot.GetComponent<DotController>();
                            if (!currentDotDot.GetComponent<DotController>().notMatchable)
                            {

                                if (leftDot.tag == currentDot.tag && rightDot.tag == currentDot.tag)
                                {
                                    currentMatches.Union(isRowBomb(leftDotDot, currentDotDot, rightDotDot));
                                    currentMatches.Union(isColumnBomb(leftDotDot, currentDotDot, rightDotDot));
                                    currentMatches.Union(isAdjacentBomb(leftDotDot, currentDotDot, rightDotDot));
                                    getNearbyPieces(leftDot, currentDot, rightDot);
                                }
                            }
                        }
                        
                    }

                    if (j > 0 && j < board.height - 1)
                    {
                        GameObject upDot = board.allDots[i, j+1];
                       
                        GameObject downDot = board.allDots[i, j - 1];
                       
                        if (upDot != null && downDot != null)
                        {
                            DotController upDotDot = upDot.GetComponent<DotController>();
                            DotController downDotDot = downDot.GetComponent<DotController>();
                            if (!currentDotDot.GetComponent<DotController>().notMatchable)
                            {
                                if (upDot.tag == currentDot.tag && downDot.tag == currentDot.tag)
                                {

                                    currentMatches.Union(isColumnBomb(upDotDot, currentDotDot, downDotDot));
                                    currentMatches.Union(isRowBomb(upDotDot, currentDotDot, downDotDot));
                                    currentMatches.Union(isAdjacentBomb(upDotDot, currentDotDot, downDotDot));
                                    getNearbyPieces(upDot, currentDot, downDot);

                                }
                            }
                        }
                    }
                }
            }
        }
    }

    List<GameObject> getAdjacentPieces(int column, int row) {
        List<GameObject> dots = new List<GameObject>();
        for (int i = column - 1; i <=column  ; i++) {
            for (int j = row - 1; j <= row ; j++) {
                if (i >= 0 && i < board.width && j >= 0 && j < board.height) {
                    if (board.allDots[i,j]!= null) {
                        dots.Add(board.allDots[i, j]);
                        board.allDots[i, j].GetComponent<DotController>().isMatched = true;
                    }
                }
            }
        }
        return dots;
    }
    List<GameObject>GetColumnPieces(int column)
    {
        List<GameObject> dots = new List<GameObject>();
        for (int i = 0; i < board.height; i++)
        {
            if (board.allDots[column,i] != null)
            {               
                dots.Add(board.allDots[column, i]);
                board.allDots[column, i].GetComponent<DotController>().isMatched = true;
            }
        }
        return dots;
    }

    List<GameObject> GetRandomPiece(int column, int row) {
        List<GameObject> dots = new List<GameObject>();
        for (int i = 0; i < board.width; i++) {
            for (int j = 0; j < board.height; j++) {
                if (board.allDots[column, row] == board.allDots[i,j]) {
                    if (board.allDots[i, j] != null)
                    {
                        dots.Add(board.allDots[i, j]);
                        board.allDots[i, j].GetComponent<DotController>().isMatched = true;
                    }
                }
            }
        }
        return dots;
    }

    public void matchPiecesOfColor(string color) {
        for (int i = 0; i < board.width; i++) {
            for (int j = 0; j < board.height; j++) {
                if (board.allDots[i,j] != null) {
                    if (board.allDots[i,j].tag == color) {
                        board.allDots[i, j].GetComponent<DotController>().isMatched = true;
                        goal.minusCollect(board.allDots[i,j].GetComponent<DotController>().tag);
                    }
                }
            }
        }

      
    }

    List<GameObject> GetRowPieces(int row)
    {
        List<GameObject> dots = new List<GameObject>();
        for (int i = 0; i < board.width; i++)
        {
            if (board.allDots[i, row] != null)
            {                
                dots.Add(board.allDots[i, row]);
                board.allDots[i, row].GetComponent<DotController>().isMatched = true;
            }
        }
        return dots;
    }
  
    public void checkBombs()
    {
        if(board.currentDot != null)
        {
            if (board.currentDot.isMatched)
            {
                board.currentDot.isMatched = false;
                if ((board.currentDot.swipeAngle > -45 && board.currentDot.swipeAngle <= 45)
                    || (board.currentDot.swipeAngle < -135 || board.currentDot.swipeAngle >= 135))
                {
                    board.currentDot.makeRowBomb();
                }
                else {
                    board.currentDot.makeColumnBomb();
                }
            }else if (board.currentDot.otherDot != null)
            {
                DotController otherDot = board.currentDot.otherDot.GetComponent<DotController>();
                if (otherDot.isMatched)
                {
                    otherDot.isMatched = false;
                    if ((board.currentDot.swipeAngle > -45 && board.currentDot.swipeAngle <= 45)
                   || (board.currentDot.swipeAngle < -135 || board.currentDot.swipeAngle >= 135))
                    {
                        otherDot.makeRowBomb();
                    }
                    else
                    {
                        otherDot.makeColumnBomb();
                    }
                }
            }
        }
    }

    List<GameObject> GetAllGlassPiece() {
        List<GameObject> dots = new List<GameObject>();
        for (int i = 0; i < board.width; i++) {
            for (int j = 0; j < board.height; j++) {
                if (board.allDots[i, j]!= null) {
                    if (board.allDots[i, j].tag == "Trash1" )
                    {
                        dots.Add(board.allDots[i, j]);
                        board.allDots[i, j].GetComponent<DotController>().isMatched = true;
                    }
                }
            }
        }
        return dots;
    }

    List<GameObject> GetAllFabricPiece() {
        List<GameObject> dots = new List<GameObject>();
        for (int i = 0; i < board.width; i++) {
            for (int j = 0; j < board.height; j++) {
                if (board.allDots[i, j]!= null) {
                    if (board.allDots[i, j].tag == "Trash2" )
                    {
                        dots.Add(board.allDots[i, j]);
                        board.allDots[i, j].GetComponent<DotController>().isMatched = true;
                    }
                }
            }
        }
        return dots;
    }


    List<GameObject> GetAllMetalPiece() {
        List<GameObject> dots = new List<GameObject>();
        for (int i = 0; i < board.width; i++) {
            for (int j = 0; j < board.height; j++) {
                if (board.allDots[i, j]!= null) {
                    if (board.allDots[i, j].tag == "Trash3" )
                    {
                        dots.Add(board.allDots[i, j]);
                        board.allDots[i, j].GetComponent<DotController>().isMatched = true;
                    }
                }
            }
        }
        return dots;
    }

    List<GameObject> GetAllOrganicPiece() {
        List<GameObject> dots = new List<GameObject>();
        for (int i = 0; i < board.width; i++) {
            for (int j = 0; j < board.height; j++) {
                if (board.allDots[i, j]!= null) {
                    if (board.allDots[i, j].tag == "Trash4" )
                    {
                        dots.Add(board.allDots[i, j]);
                        board.allDots[i, j].GetComponent<DotController>().isMatched = true;
                    }
                }
            }
        }
        return dots;
    }

    List<GameObject> GetAllPlasticPiece() {
        List<GameObject> dots = new List<GameObject>();
        for (int i = 0; i < board.width; i++) {
            for (int j = 0; j < board.height; j++) {
                if (board.allDots[i, j]!= null) {
                    if (board.allDots[i, j].tag == "Trash5" )
                    {
                        dots.Add(board.allDots[i, j]);
                        board.allDots[i, j].GetComponent<DotController>().isMatched = true;
                    }
                }
            }
        }
        return dots;
    }

    public void randomDestroyColumn(int column) {

        GetColumnPieces(column);
    }

    public void randomDestroyRow(int row) {
        GetRowPieces(row); 
    }

    public void randomDestroySquare(int column, int row) {
        getAdjacentPieces(column, row);
    }

    public void randomTrashDestroy(int column, int row) {
        GetRandomPiece(column,row);
    }

    public void getGlassPieces(){
        GetAllGlassPiece();
    }

    public void getFabricPieces(){
        GetAllFabricPiece();
    }

    public void getMetalPieces(){
        GetAllMetalPiece();
    }

    public void getOrganicPieces(){
        GetAllOrganicPiece();
    }

    public void getPlasticPieces(){
        GetAllPlasticPiece();
    }
}
