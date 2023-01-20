using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacters : MonoBehaviour
{
    Board board;
    public GameObject[] allChars;
    public GameObject canvas;
    [SerializeField]
    private PartyObject partList;
    public Transform[] chars = new Transform[3];
    private void Start()
    {
        board = FindObjectOfType<Board>();

            for (int i = 0; i < partList.party.Length; i++)
            {
                for (int j = 0; j < allChars.Length; j++)
                {
                
                    if (allChars[j].CompareTag(partList.party[i]))
                    {
                        GameObject characters = Instantiate(allChars[j], canvas.transform);
                        characters.transform.position = chars[i].transform.position;
                    }
                }
            }
       }
    }

    

