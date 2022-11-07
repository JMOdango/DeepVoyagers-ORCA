using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalSelect : MonoBehaviour
{
    //Character Panels
     public GameObject CardHolder;
     public GameObject GaryCard;
     public GameObject DianeCard;

     int character = 1;
   
   public void OpenGary()
    {
       character = 1;
       SelectCharacter(character);
    }

    public void OpenDiane()
    {
        character = 4;
        SelectCharacter(character);
    }

    void SelectCharacter(int character)
    {

    switch (character) 
    {
    case 1:
        GaryCard.SetActive(true);
        DianeCard.SetActive(false);
        break;
    case 4:
        DianeCard.SetActive(true);
        break;
    }

    }

}
