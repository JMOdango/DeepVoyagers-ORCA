using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    private Board board;
    public float backgroundOffset;
    private RandomizeTrash randomTrash;
    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();
        randomTrash = FindObjectOfType<RandomizeTrash>();
        if (board != null)
        {
            moveBackground(board.width - 1, board.height - 1);
        }
    }

    void moveBackground(float x, float y) {

        Vector3 tempPosition = new Vector3(x / 2, y / 2, backgroundOffset);
        transform.position = tempPosition;
        //randomTrash.spawnTrash();
    }
}
