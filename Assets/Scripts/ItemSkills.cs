using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemSkills : MonoBehaviour
{
    [SerializeField]
    public MovesLeft MovesLeft;
    public Board board;
    // Start is called before the first frame update
    void Start()
    {
        board = board.GetComponent<Board>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseMysteriousSnack()
    {
     
    MovesLeft.Moves += 3;
    board.moves.text = MovesLeft.Moves.ToString();
    }
}