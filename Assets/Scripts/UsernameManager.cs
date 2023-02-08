using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UsernameManager : MonoBehaviour
{
    public static UsernameManager usernameManager;
    [SerializeField]
    private string DisplayName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Awake()
    {
        if(usernameManager == null)
        {
            usernameManager = this;
        }
        else
        {
            if(usernameManager != this){
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetDisplayName(string displayName)
    {
        DisplayName = displayName;
        return;
    }

    public string GetDisplayName(){
        return DisplayName;
    }
}
