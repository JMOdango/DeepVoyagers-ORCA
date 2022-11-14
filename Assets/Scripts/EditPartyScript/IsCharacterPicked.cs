using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCharacterPicked : MonoBehaviour
{
    CharacterClick clicked;
    SelectCharacter selectCharacter;

    public Transform card1;
    public Transform card2;
    public Transform card3;

    List<GameObject> party = new List<GameObject>();
    [SerializeField]
    private PartyObject partyList;
   public  GameObject[] Party = new GameObject[3];
    private void Start()
    {
        clicked = FindObjectOfType<CharacterClick>();
        selectCharacter = FindObjectOfType<SelectCharacter>();
    }
    public void CharacterSelected()
    {
        if (clicked.characterClicked == "Coraline") {
            selectCharacter.isCoraline = true;
            GameObject character = selectCharacter.characters[0];
            for (int i = 0; i < Party.Length; i++) {
                if (Party[i] == null)
                {
                    Party[i] = character;
                    i = i + 2;
                }
            }
            
        }
        if (clicked.characterClicked == "Diane")
        {
            selectCharacter.isDiane = true;
            GameObject character = selectCharacter.characters[1];
            for (int i = 0; i < Party.Length; i++)
            {
                if (Party[i] == null)
                {
                    Party[i] = character;
                    i = i + 2;
                }
            }
        }
        if (clicked.characterClicked == "Gary")
        {
            selectCharacter.isGary = true;
            GameObject character = selectCharacter.characters[2];
            for (int i = 0; i < Party.Length; i++)
            {
                if (Party[i] == null)
                {
                    Party[i] = character;
                    i = i + 2;
                }
            }
        }

        if (clicked.characterClicked == "Malachi")
        {
            selectCharacter.isMalachi = true;
            GameObject character = selectCharacter.characters[3];
            for (int i = 0; i < Party.Length; i++)
            {
                if (Party[i] == null)
                {
                    Party[i] = character;
                    i = i +2;
                }
            }
        }

        if (clicked.characterClicked == "Mari")
        {
            selectCharacter.isMari = true;
            GameObject character = selectCharacter.characters[4];
            for (int i = 0; i < Party.Length; i++)
            {
                if (Party[i] == null)
                {
                    Party[i] = character;
                    i = i + 2;
                }
            }
        }

        if (clicked.characterClicked == "Oscar")
        {
            selectCharacter.isOscar = true;
            GameObject character = selectCharacter.characters[5];
            for (int i = 0; i < Party.Length; i++)
            {
                if (Party[i] == null)
                {
                    Party[i] = character;
                    i = i + 2;
                }
            }
        }

        if (clicked.characterClicked == "Pam")
        {
            selectCharacter.isPam = true;
            GameObject character = selectCharacter.characters[6];
            for (int i = 0; i < Party.Length; i++)
            {
                if (Party[i] == null)
                {
                    Party[i] = character;
                    i = i + 2;
                }
            }
        }

        if (Party[0] != null)
        {
            selectCharacter.currentCard = card2.transform.position;
            
        }
        if (Party[1] != null)
        {
            selectCharacter.currentCard = card3.transform.position;
        }

        for (int i = 0; i < Party.Length; i++) {
            if (Party[0] != null) {
                partyList.party1 = Party[0].tag;
            }
            if (Party[1] != null)
            {
                partyList.party2 = Party[1].tag;
            }
            if (Party[2] != null)
            {
                partyList.party3 = Party[2].tag;
            }
        }
    }
}
