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

}
