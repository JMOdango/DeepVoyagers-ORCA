using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipController : MonoBehaviour
{
    public List<Characters> characters;

    [System.Serializable]
    public struct Characters
    {
        public string characterName;
    }
}
