using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetainParty : MonoBehaviour
{
    public PartyObject partyList;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
