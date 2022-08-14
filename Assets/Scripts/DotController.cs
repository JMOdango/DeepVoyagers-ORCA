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
    private GameObject otherDot;
    private GameManager manager;

    [SerializeField]
    private MovesLeft movesLeft;

    private Vector2 firstTouch;
    private Vector2 finalTouch;
    private Vector2 tempPos;
    public float swipeAngle = 0;
    public float swipeResist = 1f;
    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();
        manager = FindObjectOfType<GameManager>();
        findAllMatches = FindObjectOfType<FindMatches>();
        //targetX = (int)transform.position.x;
        //targetY = (int)transform.position.y;
        // row = targetY;
        //column = targetX;
        // previousRow = row;
        // previousColumn = column;
    }

    // Update is called once per frame
    void Update()
    {
        //findMatches();
        if (isMatched)
        {
            SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
            mySprite.color = new Color(1f, 1f, 1f, .2f);
        }

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
        if (movesLeft.Moves == 0)
        {
            manager.gameOver();
        }

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
        if (movesLeft.Moves > 0) {
            movesLeft.Moves--;
            board.moves.text = movesLeft.Moves.ToString();
        }
        isMoving = false;
    }
    public IEnumerator CheckMoveCo()
    {
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
                board.currentState = GameState.move;
            }
            else
            {
                board.DestroyMatches();

            }
            otherDot = null;
        }

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
