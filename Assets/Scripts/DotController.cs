using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotController : MonoBehaviour
{

    public int column;
    public int row;
    public int previousColumn;
    public int previousRow;
    public int targetX;
    public int targetY;
    public bool isMatched = false;
    bool isMoving = false;
    private FindMatches findAllMatches;
    private Board board;
    public GameObject otherDot;
    private GameManager manager;

    [SerializeField]
    private MovesLeft movesLeft;

    private Vector2 firstTouch;
    private Vector2 finalTouch;
    private Vector2 tempPos;

    public float swipeAngle = 0;
    public float swipeResist = 1f;

    public bool isColorBomb;
    public bool isColumnBomb;
    public bool isRowBomb;
    public bool isAdjacentBomb;

    public GameObject adjacentMarker;
    public GameObject rowArrow;
    public GameObject columnArrow;
    public GameObject colorBomb;

    // Start is called before the first frame update
    void Start()
    {
        isColumnBomb = false;
        isRowBomb = false;
        isColorBomb = false;
        isAdjacentBomb = false;
        board = FindObjectOfType<Board>();
        manager = FindObjectOfType<GameManager>();
        findAllMatches = FindObjectOfType<FindMatches>();
    }

    //for testing and debug only
    //private void OnMouseOver()
    //{
    //    if (Input.GetMouseButtonDown(1)) {
    //        isColorBomb = true;
    //        GameObject color = Instantiate(colorBomb, transform.position, Quaternion.identity);
    //        color.transform.parent = this.transform;
    //    }
    //}
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRowBomb = true;
            GameObject arrow = Instantiate(rowArrow, transform.position, Quaternion.identity);
            arrow.transform.parent = this.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        targetX = column;
        targetY = row;
        if (Mathf.Abs(targetX - transform.position.x) > .1)
        {
            tempPos = new Vector2(targetX, transform.position.y);
            transform.position = Vector2.Lerp(transform.position, tempPos, .03f);
            if (board.allDots[column, row] != this.gameObject)
            {
                board.allDots[column, row] = this.gameObject;
            }
            findAllMatches.FindAllMatches();
        }
        else
        {
            tempPos = new Vector2(targetX, transform.position.y);
            transform.position = tempPos;
        }

        if (Mathf.Abs(targetY - transform.position.y) > .1)
        {
            tempPos = new Vector2(transform.position.x, targetY);
            transform.position = Vector2.Lerp(transform.position, tempPos, .03f);
            if (board.allDots[column, row] != this.gameObject)
            {
                board.allDots[column, row] = this.gameObject;
            }
            findAllMatches.FindAllMatches();
        }
        else
        {
            tempPos = new Vector2(transform.position.x, targetY);
            transform.position = tempPos;
        }
        //if (movesLeft.Moves == 0)
        //{
        //    manager.gameOver();
        //}

    }

    private void OnMouseDown()
    {
        if (board.currentState == GameState.move)
        {
            firstTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseUp()
    {
        if (board.currentState == GameState.move)
        {
            finalTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CalculateAngle();
        }
        else
        {
            board.currentState = GameState.move;
        }

    
    }

    void CalculateAngle()
    {
        if (Mathf.Abs(finalTouch.y - firstTouch.y) > swipeResist || Mathf.Abs(finalTouch.x - firstTouch.x) > swipeResist)
        {
            swipeAngle = Mathf.Atan2(finalTouch.y - firstTouch.y, finalTouch.x - firstTouch.x) * 180 / Mathf.PI;
            MovePieces();
            board.currentState = GameState.wait;
            board.currentDot = this;
        }
        else {
            board.currentState = GameState.move;
            
        }

    }

    void MovePieces()
    {

        if (manager.GameOver == false || manager.Complete == true)
        {



            if (swipeAngle > -45 && swipeAngle <= 45 && column < board.width - 1)
            {
                //right swipe
                otherDot = board.allDots[column + 1, row];
                previousRow = row;
                previousColumn = column;
                otherDot.GetComponent<DotController>().column -= 1;
                column += 1;
                isMoving = true;
                moved();
            }
            else if (swipeAngle > 45 && swipeAngle <= 135 && row < board.height - 1)
            {
                //up swipe
                otherDot = board.allDots[column, row + 1];
                previousRow = row;
                previousColumn = column;
                otherDot.GetComponent<DotController>().row -= 1;
                row += 1;
                isMoving = true;
                moved();
            }
            else if ((swipeAngle > 135 || swipeAngle <= -135) && column > 0)
            {
                //left swipe
                otherDot = board.allDots[column - 1, row];
                previousRow = row;
                previousColumn = column;
                otherDot.GetComponent<DotController>().column += 1;
                column -= 1;
                isMoving = true;
                moved();
            }
            else if (swipeAngle < -45 && swipeAngle >= -135 && row > 0)
            {
                //down swipe
                otherDot = board.allDots[column, row - 1];
                previousRow = row;
                previousColumn = column;
                otherDot.GetComponent<DotController>().row += 1;
                row -= 1;
                isMoving = true;
                moved();
            }
            StartCoroutine(CheckMoveCo());
        }
    }

    public void moved()
    {
        if (isMoving == true) {
            if (movesLeft.Moves > 0) {
                movesLeft.Moves--;
                board.moves.text = movesLeft.Moves.ToString();
            }
        }
        isMoving = false;
    }
    public IEnumerator CheckMoveCo()
    {
        if (isColorBomb) {
            findAllMatches.matchPiecesOfColor(otherDot.tag);
            isMatched = true;
        } else if(otherDot.GetComponent<DotController>().isColorBomb) {
            findAllMatches.matchPiecesOfColor(this.gameObject.tag);
            otherDot.GetComponent<DotController>().isMatched = true;
        }
        yield return new WaitForSeconds(.3f);
        if (otherDot != null)
        {
            if (!isMatched && otherDot.GetComponent<DotController>().isMatched == false)
            {
                otherDot.GetComponent<DotController>().row = row;
                otherDot.GetComponent<DotController>().column = column;
                row = previousRow;
                column = previousColumn;
                yield return new WaitForSeconds(.3f);
                board.currentDot = null;
                board.currentState = GameState.move;
            }
            else
            {
                board.DestroyMatches();
            }
            //otherDot = null;
        }

    }

    public void makeRowBomb() {
        isRowBomb = true;
        GameObject arrow = Instantiate(rowArrow, transform.position, Quaternion.identity);
        arrow.transform.parent = this.transform;
    }

    public void makeColumnBomb() {
        isColumnBomb = true;
        GameObject arrow = Instantiate(columnArrow, transform.position, Quaternion.identity);
        arrow.transform.parent = this.transform;
    }

    //void findMatches()
    //{
    //    if (column > 0 && column < board.width - 1)
    //    {
    //        GameObject leftDot1 = board.allDots[column - 1, row];
    //        GameObject rightDot1 = board.allDots[column + 1, row];
    //        if (leftDot1 != null && rightDot1 != null && leftDot1 != this.gameObject && rightDot1 != this.gameObject)
    //        {
    //            if (leftDot1.tag == this.gameObject.tag && rightDot1.tag == this.gameObject.tag)
    //            {
    //                leftDot1.GetComponent<DotController>().isMatched = true;
    //                rightDot1.GetComponent<DotController>().isMatched = true;
    //                isMatched = true;
    //            }
    //        }
    //    }
    //    if (row > 0 && row < board.height - 1)
    //    {
    //        GameObject upDot1 = board.allDots[column, row + 1];
    //        GameObject downDot1 = board.allDots[column, row - 1];
    //        if (upDot1 != null && downDot1 != null && upDot1 != this.gameObject && downDot1 != this.gameObject)
    //        {
    //            if (upDot1.tag == this.gameObject.tag && downDot1.tag == this.gameObject.tag && upDot1 != null && downDot1 != null && upDot1 != this.gameObject && downDot1 != this.gameObject)
    //            {
    //                upDot1.GetComponent<DotController>().isMatched = true;
    //                downDot1.GetComponent<DotController>().isMatched = true;
    //                isMatched = true;
    //            }
    //        }
    //    }
    //}
}
