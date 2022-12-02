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

    public bool isempty_char1 = false;
    public bool isempty_char2 = false;
    public bool isempty_char3 = false;

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
        if (isempty_char1 == false)
        {
        if (picked.slot_coraline == 1 && selectCharacter.isCoraline == true)
        {
         selectCharacter.characters[0].SetActive(false);
         selectCharacter.isCoraline = false;
          
        }
        
        if (picked.slot_diane == 1 && selectCharacter.isDiane == true)
        {
        selectCharacter.characters[1].SetActive(false);
        selectCharacter.isDiane = false;
        }

        if (picked.slot_gary == 1 && selectCharacter.isGary == true)
        {
        selectCharacter.characters[2].SetActive(false);
        selectCharacter.isGary = false;
        }

        if (picked.slot_malachi == 1 && selectCharacter.isMalachi == true)
        {
        selectCharacter.characters[3].SetActive(false);
        selectCharacter.isMalachi = false;
        }

        if (picked.slot_mari == 1 && selectCharacter.isMari == true)
        {
        selectCharacter.characters[4].SetActive(false);
        selectCharacter.isMari = false;
        }

        if (picked.slot_oscar == 1 && selectCharacter.isOscar == true)
        {
        selectCharacter.characters[5].SetActive(false);
        selectCharacter.isOscar = false;
        }

        if (picked.slot_pam == 1 && selectCharacter.isPam == true)
        {
        selectCharacter.characters[6].SetActive(false);
        selectCharacter.isPam = false;
        }

        selectCharacter.currentCard = card1.transform.position;
        picked.slot = 1;
        picked.Party[picked.slot-1] = null;

        status.selected_char1.SetActive(false);
        status.unselected_char1.SetActive(true);
        }
  
    }

    public void Remove_Char2()
    {
        if (isempty_char2 == false)
        {
        if (picked.slot_coraline == 2 && selectCharacter.isCoraline == true)
        {
         selectCharacter.characters[0].SetActive(false);
         selectCharacter.isCoraline = false;
        }
        
        if (picked.slot_diane == 2 && selectCharacter.isDiane == true)
        {
        selectCharacter.characters[1].SetActive(false);
        selectCharacter.isDiane = false;
        }

        if (picked.slot_gary == 2  && selectCharacter.isGary == true)
        {
        selectCharacter.characters[2].SetActive(false);
        selectCharacter.isGary = false;
        }

        if (picked.slot_malachi == 2 && selectCharacter.isMalachi == true)
        {
        selectCharacter.characters[3].SetActive(false);
        selectCharacter.isMalachi = false;
        }

        if (picked.slot_mari == 2 && selectCharacter.isMari == true)
        {
        selectCharacter.characters[4].SetActive(false);
        selectCharacter.isMari = false;
        }

        if (picked.slot_oscar == 2 && selectCharacter.isOscar == true)
        {
        selectCharacter.characters[5].SetActive(false);
        selectCharacter.isOscar = false;
        }

        if (picked.slot_pam == 2 && selectCharacter.isPam == true)
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
    }

    public void Remove_Char3()
    {
        if (isempty_char3 == false) {
        if (picked.slot_coraline == 3 && selectCharacter.isCoraline == true)
        {
         selectCharacter.characters[0].SetActive(false);
         selectCharacter.isCoraline = false;
        }
        
        if (picked.slot_diane == 3 && selectCharacter.isDiane == true)
        {
        selectCharacter.characters[1].SetActive(false);
        selectCharacter.isDiane = false;
        }

        if (picked.slot_gary == 3 && selectCharacter.isGary == true)
        {
        selectCharacter.characters[2].SetActive(false);
        selectCharacter.isGary = false;
        }

        if (picked.slot_malachi == 3 && selectCharacter.isMalachi == true)
        {
        selectCharacter.characters[3].SetActive(false);
        selectCharacter.isMalachi = false;
        }

        if (picked.slot_mari == 3 && selectCharacter.isMari == true)
        {
        selectCharacter.characters[4].SetActive(false);
        selectCharacter.isMari = false;
        }

        if (picked.slot_oscar == 3 && selectCharacter.isOscar == true)
        {
        selectCharacter.characters[5].SetActive(false);
        selectCharacter.isOscar = false;
        }

        if (picked.slot_pam == 3 && selectCharacter.isPam == true)
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
}