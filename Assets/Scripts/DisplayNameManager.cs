using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayNameManager : MonoBehaviour
{
    UsernameManager usernameManager;
    public TextMeshProUGUI displayNameText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Awake()
    {
        displayNameText.text = UsernameManager.usernameManager.GetDisplayName();
    }
}
