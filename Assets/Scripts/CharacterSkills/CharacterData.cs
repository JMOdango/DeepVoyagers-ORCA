using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[SerializeField]
public class CharacterData : ScriptableObject
{
    private double mariPoints;

    
    public double MariPoints
    {
        get { return mariPoints; }
        set { mariPoints = value; }
    }

    private double garyPoints;
    
    public double GaryPoints
    {
        get { return garyPoints; }
        set { garyPoints = value; }
    }

    private double coralinePoints;

    public double CoralinePoints
    {
        get { return coralinePoints; }
        set { coralinePoints = value; }
    }

    private double pamPoints;
    public double PamPoints
    {
        get { return pamPoints; }
        set { pamPoints = value; }
    }


}
