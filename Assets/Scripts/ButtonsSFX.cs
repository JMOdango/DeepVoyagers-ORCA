using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsSFX : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlaySFX(){
        FindObjectOfType<simpleAudioManager>().Play("MenuButtons");
    }
}
