using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
     public void BacktoAreaSelection() 
    {
        SceneManager.LoadScene("AreaSelection");
        FindObjectOfType<simpleAudioManager>().Play("MenuButtons");
    }
}
