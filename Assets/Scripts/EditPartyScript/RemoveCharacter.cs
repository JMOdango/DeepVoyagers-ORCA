using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCharacter : MonoBehaviour
{
    CharacterClick clicked;
    SelectCharacter selectCharacter;
    IsCharacterPicked picked;
    SelectionStatus status;
    public Transform card1;
    public Transform card2;
    public Transform card3;

    

    void Awake()
    {
        picked = GameObject.Find("PickCharacter").GetComponent<IsCharacterPicked>();
    }

    private void Start()
    {
        clicked = FindObjectOfType<CharacterClick>();
        selectCharacter = FindObjectOfType<SelectCharacter>();
        status = FindObjectOfType<SelectionStatus>();
    }

    public void Remove_Char1()
    {

        if (picked.slot_coraline == 1 && picked.isempty_char1 == false)
        {
          selectCharacter.characters[0].SetActive(false);
          selectCharacter.isCoraline = false;
        }
        
        if (picked.slot_diane == 1 && picked.isempty_char1 == false)
        {
          selectCharacter.characters[1].SetActive(false);
          selectCharacter.isDiane = false;
        }

        if (picked.slot_gary == 1 && picked.isempty_char1 == false)
        {
        selectCharacter.characters[2].SetActive(false);
        selectCharacter.isGary = false;
        }

        if (picked.slot_malachi == 1 && picked.isempty_char1 == false)
        {
        selectCharacter.characters[3].SetActive(false);
        selectCharacter.isMalachi = false;
        }

        if (picked.slot_mari == 1 && picked.isempty_char1 == false)
        {
        selectCharacter.characters[4].SetActive(false);
        selectCharacter.isMari = false;
        }

        if (picked.slot_oscar == 1 && picked.isempty_char1 == false)
        {
        selectCharacter.characters[5].SetActive(false);
        selectCharacter.isOscar = false;
        }

        if (picked.slot_pam == 1 && picked.isempty_char1 == false)
        {
        selectCharacter.characters[6].SetActive(false);
        selectCharacter.isPam = false;
        }


        // if (picked.isempty_char1 == false)
        // {
        //     picked.isempty_char1 = true;
        // if (picked.slot_coraline == 1 && selectCharacter.isCoraline == true)
        // {
        //  selectCharacter.characters[0].SetActive(false);
        //  selectCharacter.isCoraline = false;
          
        // }
        
        // if (picked.slot_diane == 1 && selectCharacter.isDiane == true)
        // {
        // selectCharacter.characters[1].SetActive(false);
        // selectCharacter.isDiane = false;
        // }

        // if (picked.slot_gary == 1 && selectCharacter.isGary == true)
        // {
        // selectCharacter.characters[2].SetActive(false);
        // selectCharacter.isGary = false;
        // }

        // if (picked.slot_malachi == 1 && selectCharacter.isMalachi == true)
        // {
        // selectCharacter.characters[3].SetActive(false);
        // selectCharacter.isMalachi = false;
        // }

        // if (picked.slot_mari == 1 && selectCharacter.isMari == true)
        // {
        // selectCharacter.characters[4].SetActive(false);
        // selectCharacter.isMari = false;
        // }

        // if (picked.slot_oscar == 1 && selectCharacter.isOscar == true)
        // {
        // selectCharacter.characters[5].SetActive(false);
        // selectCharacter.isOscar = false;
        // }

        // if (picked.slot_pam == 1 && selectCharacter.isPam == true)
        // {
        // selectCharacter.characters[6].SetActive(false);
        // selectCharacter.isPam = false;
        // }

        selectCharacter.currentCard = card1.transform.position;
        picked.slot = 1;
        picked.Party[picked.slot-1] = null;

        status.selected_char1.SetActive(false);
        status.unselected_char1.SetActive(true);

        
        }
  
    

    

    public void Remove_Char2()
    {
       
        if (picked.slot_coraline == 2 && picked.isempty_char2 == false)
        {
         selectCharacter.characters[0].SetActive(false);
         selectCharacter.isCoraline = false;
        }
        
        if (picked.slot_diane == 2 && picked.isempty_char2 == false)
        {
        selectCharacter.characters[1].SetActive(false);
        selectCharacter.isDiane = false;
        }

        if (picked.slot_gary == 2  && picked.isempty_char2 == false)
        {
        selectCharacter.characters[2].SetActive(false);
        selectCharacter.isGary = false;
        }

        if (picked.slot_malachi == 2 && picked.isempty_char2 == false)
        {
        selectCharacter.characters[3].SetActive(false);
        selectCharacter.isMalachi = false;
        }

        if (picked.slot_mari == 2 && picked.isempty_char2 == false)
        {
        selectCharacter.characters[4].SetActive(false);
        selectCharacter.isMari = false;
        }

        if (picked.slot_oscar == 2 && picked.isempty_char2 == false)
        {
        selectCharacter.characters[5].SetActive(false);
        selectCharacter.isOscar = false;
        }

        if (picked.slot_pam == 2 && picked.isempty_char2 == false)
        {
        selectCharacter.characters[6].SetActive(false);
        selectCharacter.isPam = false;
        }


        selectCharacter.currentCard = card2.transform.position;
        picked.slot = 2;
        picked.Party[picked.slot-1] = null;

        status.selected_char2.SetActive(false);
        status.unselected_char2.SetActive(true);

        
        
    }

    public void Remove_Char3()
    {
        
        if (picked.slot_coraline == 3 && picked.isempty_char3 == false)
        {
         selectCharacter.characters[0].SetActive(false);
         selectCharacter.isCoraline = false;
        }
        
        if (picked.slot_diane == 3 && picked.isempty_char3 == false)
        {
        selectCharacter.characters[1].SetActive(false);
        selectCharacter.isDiane = false;
        }

        if (picked.slot_gary == 3 && picked.isempty_char3 == false)
        {
        selectCharacter.characters[2].SetActive(false);
        selectCharacter.isGary = false;
        }

        if (picked.slot_malachi == 3 && picked.isempty_char3 == false)
        {
        selectCharacter.characters[3].SetActive(false);
        selectCharacter.isMalachi = false;
        }

        if (picked.slot_mari == 3 && picked.isempty_char3 == false)
        {
        selectCharacter.characters[4].SetActive(false);
        selectCharacter.isMari = false;
        }

        if (picked.slot_oscar == 3 && picked.isempty_char3 == false)
        {
        selectCharacter.characters[5].SetActive(false);
        selectCharacter.isOscar = false;
        }

        if (picked.slot_pam == 3 && picked.isempty_char3 == false)
        {
        selectCharacter.characters[6].SetActive(false);
        selectCharacter.isPam = false;
        }


        selectCharacter.currentCard = card3.transform.position;
        picked.slot = 3;
        picked.Party[picked.slot-1] = null;

        status.selected_char3.SetActive(false);
        status.unselected_char3.SetActive(true);

        
        
    }
}