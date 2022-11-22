using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
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
            }
            else if(clicked.characterClicked != "Coraline" && isCoraline == false)
            {
                characters[0].SetActive(false);
            }

            if (clicked.characterClicked == "Diane" && isDiane == false)
            {
                characters[1].SetActive(true);
                characters[1].transform.position = currentCard;
            }
            else if (clicked.characterClicked != "Diane" && isDiane == false)
            {
                characters[1].SetActive(false);
            }

            if (clicked.characterClicked == "Gary" && isGary == false)
            {
                characters[2].SetActive(true);
                characters[2].transform.position = currentCard;
            }
            else if (clicked.characterClicked != "Gary" && isGary == false)
            {
                characters[2].SetActive(false);
            }

            if (clicked.characterClicked == "Malachi" && isMalachi == false)
            {
                characters[3].SetActive(true);
                characters[3].transform.position = currentCard;
            }
            else if (clicked.characterClicked != "Malachi" && isMalachi == false)
            {
                characters[3].SetActive(false);
            }

            if (clicked.characterClicked == "Mari" && isMari == false)
            {
                characters[4].SetActive(true);
                characters[4].transform.position = currentCard;
            }
            else if (clicked.characterClicked != "Mari" && isMari == false)
            {
                characters[4].SetActive(false);
            }

            if (clicked.characterClicked == "Oscar" && isOscar == false)
            {
                characters[5].SetActive(true);
                characters[5].transform.position = currentCard;
            }
            else if (clicked.characterClicked != "Oscar" && isOscar == false)
            {
                characters[5].SetActive(false);
            }


            if (clicked.characterClicked == "Pam" && isPam == false)
            {
                characters[6].SetActive(true);
                characters[6].transform.position = currentCard;
            }
            else if (clicked.characterClicked != "Pam" && isPam == false)
            {
                characters[6].SetActive(false);
            }
        }
    }


}
