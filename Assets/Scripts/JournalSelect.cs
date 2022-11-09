using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalSelect : MonoBehaviour
{
    //Character Panels
     public GameObject CardHolder;
     
     public GameObject GaryCard;
     public GameObject CoralineCard;
     public GameObject PamCard;
     public GameObject DianeCard;
     public GameObject MalachiCard;
     public GameObject OscarCard;
     public GameObject MariCard;

     int character = 1;
   
   public void OpenGary()
    {
       character = 1;
       SelectCharacter(character);
    }

    public void OpenCoraline()
    {
       character = 2;
       SelectCharacter(character);
    }

    public void OpenPam()
    {
       character = 3;
       SelectCharacter(character);
    }

    public void OpenDiane()
    {
        character = 4;
        SelectCharacter(character);
    }

    public void OpenMalachi()
    {
       character = 5;
       SelectCharacter(character);
    }

    public void OpenOscar()
    {
       character = 6;
       SelectCharacter(character);
    }

    public void OpenMari()
    {
       character = 7;
       SelectCharacter(character);
    }

    void SelectCharacter(int character)
    {
    
    GaryCard.SetActive(false);
    CoralineCard.SetActive(false);
    PamCard.SetActive(false);
    DianeCard.SetActive(false);
    MalachiCard.SetActive(false);
    OscarCard.SetActive(false);
    MariCard.SetActive(false);
    

    switch (character) 
    {
    case 1:
        GaryCard.SetActive(true);
        break;
    case 2:
        CoralineCard.SetActive(true);
        break;
    case 3:
        PamCard.SetActive(true);
        break;
    case 4:
        DianeCard.SetActive(true);
        break;
    case 5:
        MalachiCard.SetActive(true);
        break;
    case 6:
        OscarCard.SetActive(true);
        break;
    case 7:
        MariCard.SetActive(true);
        break;
    }

    }

}
