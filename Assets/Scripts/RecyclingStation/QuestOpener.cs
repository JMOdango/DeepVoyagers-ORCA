using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestOpener : MonoBehaviour
{
    public GameObject questWindow1;
    public GameObject questWindow2;
    public GameObject questWindow3;
    public void CloseQuests()
    {
        questWindow1.SetActive(false);
        questWindow2.SetActive(false);
        questWindow3.SetActive(false);
    }

    public void OpenQuest1()
    {
      CloseQuests();
      questWindow1.SetActive(true);
    }

    public void OpenQuest2()
    {
      CloseQuests();
      questWindow2.SetActive(true);
    }

    public void OpenQuest3()
    {
      CloseQuests();
      questWindow3.SetActive(true);
    }
}
