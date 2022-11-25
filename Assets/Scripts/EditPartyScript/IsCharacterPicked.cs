using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCharacterPicked : MonoBehaviour
{
    CharacterClick clicked;
    SelectCharacter selectCharacter;
    SelectionStatus status;
    public Transform card1;
    public Transform card2;
    public Transform card3;

    public int slot = 0;

    public int slot_coraline = 1;
    public int slot_diane = 1;
    public int slot_gary = 1;
    public int slot_malachi = 1;
    public int slot_mari = 1;
    public int slot_oscar = 1;
    public int slot_pam = 1;

    List<GameObject> party = new List<GameObject>();
    [SerializeField]
    public PartyObject partyList;
    public  GameObject[] Party = new GameObject[3];
    
    

    private void Start()
    {
        clicked = FindObjectOfType<CharacterClick>();
        selectCharacter = FindObjectOfType<SelectCharacter>();
        status = FindObjectOfType<SelectionStatus>();
    }
    public void CharacterSelected()
    {
        if (clicked.characterClicked == "Coraline") {
            selectCharacter.isCoraline = true;
            GameObject character = selectCharacter.characters[0];
            slot_coraline = slot;
            // for (int i = 0; i < Party.Length; i++) {
            //     if (Party[i] == null)
            //     {
            //         Party[i] = character;
            //         i = i + 2;
            //     }
            // }

            
            Party[slot-1] = character;
            
            
            
        }
        if (clicked.characterClicked == "Diane")
        {
            selectCharacter.isDiane = true;
            GameObject character = selectCharacter.characters[1];
            slot_diane = slot;
            // for (int i = 0; i < Party.Length; i++)
            // {
            //     if (Party[i] == null)
            //     {
            //         Party[i] = character;
            //         i = i + 2;
            //     }
            // }

            
                    Party[slot-1] = character;
                

        }
        if (clicked.characterClicked == "Gary")
        {
            selectCharacter.isGary = true;
            GameObject character = selectCharacter.characters[2];
            slot_gary = slot;
            // for (int i = 0; i < Party.Length; i++)
            // {
            //     if (Party[i] == null)
            //     {
            //         Party[i] = character;
            //         i = i + 2;
            //     }
            // }

                    Party[slot-1] = character;
                
        }

        if (clicked.characterClicked == "Malachi")
        {
            selectCharacter.isMalachi = true;
            GameObject character = selectCharacter.characters[3];
            slot_malachi = slot;
            // for (int i = 0; i < Party.Length; i++)
            // {
            //     if (Party[i] == null)
            //     {
            //         Party[i] = character;
            //         i = i +2;
            //     }
            // }

           
                    Party[slot-1] = character;
                
        }

        if (clicked.characterClicked == "Mari")
        {
            selectCharacter.isMari = true;
            GameObject character = selectCharacter.characters[4];
            slot_mari = slot;
            // for (int i = 0; i < Party.Length; i++)
            // {
            //     if (Party[i] == null)
            //     {
            //         Party[i] = character;
            //         i = i + 2;
            //     }
            // }

            
                    Party[slot-1] = character;
                
        }

        if (clicked.characterClicked == "Oscar")
        {
            selectCharacter.isOscar = true;
            GameObject character = selectCharacter.characters[5];
            slot_oscar = slot;
            // for (int i = 0; i < Party.Length; i++)
            // {
            //     if (Party[i] == null)
            //     {
            //         Party[i] = character;
            //         i = i + 2;
            //     }
            // }

            
                    Party[slot-1] = character;
                
        }

        if (clicked.characterClicked == "Pam")
        {
            selectCharacter.isPam = true;
            GameObject character = selectCharacter.characters[6];
            slot_pam = slot;
            // for (int i = 0; i < Party.Length; i++)
            // {
            //     if (Party[i] == null)
            //     {
            //         Party[i] = character;
            //         i = i + 2;
            //     }
            // }

            Party[slot-1] = character;
                
        }

         

        if (Party[0] != null)
        {
            selectCharacter.currentCard = card2.transform.position;
            slot = 2;
            
        }
        if (Party[1] != null)
        {
            selectCharacter.currentCard = card3.transform.position;
            slot = 3;
        }

         if (Party[2] != null)
        {
            selectCharacter.currentCard = card1.transform.position;
            slot = 1;
        }


        for (int i = 0; i < Party.Length; i++) {

            if (Party[i] != null) {
                partyList.party[i] = Party[i].tag;
            }
            
        }

           if (Party[0] != null)
            {
                status.selected_char1.SetActive(true);
                status.unselected_char1.SetActive(false);
            }

            if (Party[1] != null)
            {
                status.selected_char2.SetActive(true);
                status.unselected_char2.SetActive(false);
            }

            if (Party[2] != null)
            {
                status.selected_char3.SetActive(true);
                status.unselected_char3.SetActive(false);
            }
    }


    public void savechanges()
    {
       
        for (int i = 0; i < Party.Length; i++)
            {
                    if (Party[i] != null) {
                    partyList.party[i] = Party[i].tag;
                    }
                    else{
                    partyList.party[i]= "Untagged";
                    
                    }
                    
            }

        for (int i = 0; i < Party.Length; i++)
            {
                    
                    print(partyList.party[i]);
                   
            }
    }
}
