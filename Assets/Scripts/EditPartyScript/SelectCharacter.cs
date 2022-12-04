using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    IsCharacterPicked picked;
    CharacterClick clicked;
    public List<GameObject> characters = new List<GameObject>();
    public GameObject[] allChars;
    public Transform inactiveChars;
    public Transform card1;
    //public Transform card2;
    //public Transform card3;

    public Vector2 currentCard;

    int currentCharacter;
    

    public bool isCoraline = false;
    public bool isDiane = false;
    public bool isGary = false;
    public bool isMalachi = false;
    public bool isMari = false;
    public bool isOscar = false;
    public bool isPam = false;

   

    void Awake()
    {
        picked = GameObject.Find("PickCharacter").GetComponent<IsCharacterPicked>();
    }


    private void Start()
    {
        clicked = FindObjectOfType<CharacterClick>();
        currentCard = card1.transform.position;
        for (int i = 0; i <allChars.Length; i++) {
            GameObject chars = Instantiate(allChars[i]);
            chars.SetActive(false);
            chars.transform.SetParent(inactiveChars);
            characters.Add(chars);
        }

    }

    private void Update()
    {
        clickedCharacter();
    }

    public void clickedCharacter() {
        if (Input.GetMouseButtonDown(0)) {
            if (clicked.characterClicked == "Coraline" && isCoraline == false)
            {
                characters[0].SetActive(true);
                characters[0].transform.position = currentCard;
                
                picked.slot_coraline = picked.slot;

                if (picked.slot_coraline == 1)
                {
                 picked.isempty_char1 = false;
                }
                else if (picked.slot_coraline == 2)
                {
                  picked.isempty_char2 = false;  
                }
                else if (picked.slot_coraline == 3)
                {
                  picked.isempty_char3 = false;  
                }
                
            }
            else if(clicked.characterClicked != "Coraline" && isCoraline == false)
            {
                characters[0].SetActive(false);
            }

            if (clicked.characterClicked == "Diane" && isDiane == false)
            {
                characters[1].SetActive(true);
                characters[1].transform.position = currentCard;
                picked.slot_diane = picked.slot;

                if (picked.slot_diane == 1)
                {
                 picked.isempty_char1 = false;
                }
                else if (picked.slot_diane == 2)
                {
                  picked.isempty_char2 = false;  
                }
                else if (picked.slot_diane == 3)
                {
                  picked.isempty_char3 = false;  
                }
            }
            else if (clicked.characterClicked != "Diane" && isDiane == false)
            {
                characters[1].SetActive(false);
            }

            if (clicked.characterClicked == "Gary" && isGary == false)
            {
                characters[2].SetActive(true);
                characters[2].transform.position = currentCard;
                picked.slot_gary = picked.slot;
                if (picked.slot_gary == 1)
                {
                 picked.isempty_char1 = false;
                }
                else if (picked.slot_gary == 2)
                {
                  picked.isempty_char2 = false;  
                }
                else if (picked.slot_gary == 3)
                {
                  picked.isempty_char3 = false;  
                }
            }
            else if (clicked.characterClicked != "Gary" && isGary == false)
            {
                characters[2].SetActive(false);
            }

            if (clicked.characterClicked == "Malachi" && isMalachi == false)
            {
                characters[3].SetActive(true);
                characters[3].transform.position = currentCard;
                picked.slot_malachi = picked.slot;
                if (picked.slot_malachi == 1)
                {
                 picked.isempty_char1 = false;
                }
                else if (picked.slot_malachi == 2)
                {
                  picked.isempty_char2 = false;  
                }
                else if (picked.slot_malachi == 3)
                {
                  picked.isempty_char3 = false;  
                }
            }
            else if (clicked.characterClicked != "Malachi" && isMalachi == false)
            {
                characters[3].SetActive(false);
            }

            if (clicked.characterClicked == "Mari" && isMari == false)
            {
                characters[4].SetActive(true);
                characters[4].transform.position = currentCard;
                picked.slot_mari = picked.slot;
                if (picked.slot_mari == 1)
                {
                 picked.isempty_char1 = false;
                }
                else if (picked.slot_mari == 2)
                {
                  picked.isempty_char2 = false;  
                }
                else if (picked.slot_mari == 3)
                {
                  picked.isempty_char3 = false;  
                }
            }
            else if (clicked.characterClicked != "Mari" && isMari == false)
            {
                characters[4].SetActive(false);
            }

            if (clicked.characterClicked == "Oscar" && isOscar == false)
            {
                characters[5].SetActive(true);
                characters[5].transform.position = currentCard;
                 picked.slot_oscar = picked.slot;
                if (picked.slot_oscar == 1)
                {
                 picked.isempty_char1 = false;
                }
                else if (picked.slot_oscar == 2)
                {
                  picked.isempty_char2 = false;  
                }
                else if (picked.slot_oscar == 3)
                {
                  picked.isempty_char3 = false;  
                }
            }
            else if (clicked.characterClicked != "Oscar" && isOscar == false)
            {
                characters[5].SetActive(false);
            }

            if (clicked.characterClicked == "Pam" && isPam == false)
            {
                characters[6].SetActive(true);
                characters[6].transform.position = currentCard;
                 picked.slot_pam = picked.slot;
                if (picked.slot_pam == 1)
                {
                 picked.isempty_char1 = false;
                }
                else if (picked.slot_pam == 2)
                {
                  picked.isempty_char2 = false;  
                }
                else if (picked.slot_pam == 3)
                {
                  picked.isempty_char3 = false;  
                }
            }
            else if (clicked.characterClicked != "Pam" && isPam == false)
            {
                characters[6].SetActive(false);
            }

            


            


            


        
        }
    }


}
