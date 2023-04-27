using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MovesLeft : ScriptableObject
{
    private int moves;

    public int Moves
    {
        get { return moves; }
        set { moves = value; }
    }

    private int trashCollected1;
    private int trashCollected2;
    private int trashCollected3;

    public int TrashCollected1
    {
        get { return trashCollected1; }
        set { trashCollected1 = value; }
    }

    public int TrashCollected2
    {
        get { return trashCollected2; }
        set { trashCollected2 = value; }
    }

    public int TrashCollected3
    {
        get { return trashCollected3; }
        set { trashCollected3 = value; }
    }

}
