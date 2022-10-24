using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FindMatches : MonoBehaviour
{

    private Board board;
    public List<GameObject> currentMatches = new List<GameObject>();
  
    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();
    }


    public void FindAllMatches()
    {
        StartCoroutine(FindAllMatchesCo());
    }
    private IEnumerator FindAllMatchesCo()
    {
        yield return new WaitForSeconds(.2f);

        for (int i = 0; i < board.width; i++)
        {
            for (int j = 0; j < board.height; j++)
            {
                GameObject currentDot = board.allDots[i, j];
                if (currentDot != null)
                {
                    if(i > 0 && i < board.width - 1)
                    {
                        GameObject leftDot = board.allDots[i - 1, j];
                        GameObject rightDot = board.allDots[i + 1, j];
                        if(leftDot != null && rightDot != null)
                        {
                            if(leftDot.tag == currentDot.tag && rightDot.tag == currentDot.tag)
                            {
                                if (currentDot.GetComponent<DotController>().isRowBomb
                                    || leftDot.GetComponent<DotController>().isRowBomb
                                    || rightDot.GetComponent<DotController>().isRowBomb) {
                                    currentMatches.Union(GetRowPieces(j));
                                }
                                if (currentDot.GetComponent<DotController>().isColumnBomb)
                                {
                                    currentMatches.Union(GetColumnPieces(i));
                                }
                                if (leftDot.GetComponent<DotController>().isColumnBomb)
                                {
                                    currentMatches.Union(GetColumnPieces(i-1));
                                }
                                if (rightDot.GetComponent<DotController>().isColumnBomb)
                                {
                                    currentMatches.Union(GetColumnPieces(i + 1));
                                }

                                if (!currentMatches.Contains(leftDot))
                                {     
                                    currentMatches.Add(leftDot);
                                }
                                leftDot.GetComponent<DotController>().isMatched = true;
                                if (!currentMatches.Contains(rightDot))
                                {   
                                    currentMatches.Add(rightDot);
                                }
                                rightDot.GetComponent<DotController>().isMatched = true;
                                if (!currentMatches.Contains(currentDot))
                                {   
                                    currentMatches.Add(currentDot);
                                }
                                currentDot.GetComponent<DotController>().isMatched = true;

                                board.whatTrash = currentDot.GetComponent<DotController>().tag;
                            }
                        }
                        
                    }

                    if (j > 0 && j < board.height - 1)
                    {
                        GameObject upDot = board.allDots[i, j+1];
                        GameObject downDot = board.allDots[i, j - 1];
                        if (upDot != null && downDot != null)
                        {
                            if (upDot.tag == currentDot.tag && downDot.tag == currentDot.tag)
                            {

                                if (currentDot.GetComponent<DotController>().isColumnBomb
                                  || upDot.GetComponent<DotController>().isColumnBomb
                                  || downDot.GetComponent<DotController>().isColumnBomb)
                                {
                                    currentMatches.Union(GetColumnPieces(i));
                                }
                                if (currentDot.GetComponent<DotController>().isRowBomb)
                                {
                                    currentMatches.Union(GetRowPieces(j));
                                }
                                if (upDot.GetComponent<DotController>().isRowBomb)
                                {
                                    currentMatches.Union(GetRowPieces(j+1));
                                }
                                if (downDot.GetComponent<DotController>().isRowBomb)
                                {
                                    currentMatches.Union(GetRowPieces(j-1));
                                }


                                if (!currentMatches.Contains(upDot))
                                {  
                                    currentMatches.Add(upDot);
                                }
                                upDot.GetComponent<DotController>().isMatched = true;

                                if (!currentMatches.Contains(downDot))
                                {       
                                    currentMatches.Add(downDot);
                                }
                                downDot.GetComponent<DotController>().isMatched = true;

                                if (!currentMatches.Contains(currentDot))
                                {                                    
                                    currentMatches.Add(currentDot);
                                }
                                currentDot.GetComponent<DotController>().isMatched = true;

                                board.whatTrash = currentDot.GetComponent<DotController>().tag;
                            }
                        }
                       
                    }
                }
            }
        }
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
}
