using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacters : MonoBehaviour
{
    public List<GameObject> spawnChars = new List<GameObject>();

    public GameObject[] allChars;
    public GameObject canvas;
    [SerializeField]
    private PartyObject partList;
    public Transform char1;
    public Transform char2;
    public Transform char3;
    private void Start()
    {
        for (int i = 0; i <allChars.Length; i++) {
            GameObject characters = Instantiate(allChars[i], canvas.transform) as GameObject;
            characters.SetActive(false);
            spawnChars.Add(characters);
        }

        for (int i = 0; i < spawnChars.Count; i++)
        {
            if (partList.party1 == spawnChars[i].tag)
            {
                spawnChars[i].SetActive(true);
                spawnChars[i].transform.position = char1.transform.position;
            }

            if (partList.party2 == spawnChars[i].tag)
            {
                spawnChars[i].SetActive(true);
                spawnChars[i].transform.position = char2.transform.position;
            }

            if (partList.party3 == spawnChars[i].tag)
            {
                spawnChars[i].SetActive(true);
                spawnChars[i].transform.position = char3.transform.position;
            }
        }
    }

    
}
