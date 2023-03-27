using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{

    public int pagenumber = 1;
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;
    public GameObject page5;

    public GameObject TutorialPage;

    void Start()
    {
        DisableTutorialPages();
        page1.SetActive(true);
    }

    public void BackButton()
    {
      if (pagenumber == 1)
        {
            OpenPage(1);
        }
     else
        {
            pagenumber--;
            OpenPage(pagenumber);
        }
    }

    public void ForwardButton()
    {
        if (pagenumber == 5)
        {
            OpenPage(1);
            pagenumber = 1;
        }
     else
        {
            pagenumber++;
            OpenPage(pagenumber);
        }
    }

    public void OpenPage(int pagenumber)
    {
        switch(pagenumber)
        {
            case 1:
               DisableTutorialPages();
               page1.SetActive(true);
               break;
            case 2:
               DisableTutorialPages();
               page2.SetActive(true);
               break;
            case 3:
               DisableTutorialPages();
               page3.SetActive(true);
               break;
            case 4:
               DisableTutorialPages();
               page4.SetActive(true);
               break;
            case 5:
               DisableTutorialPages();
               page5.SetActive(true);
               break;
            default:
               DisableTutorialPages();
               page1.SetActive(true);
               break;
        }
    }

    public void DisableTutorialPages()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);
        page5.SetActive(false);
    }

    public void CloseTutorial()
    {
        TutorialPage.SetActive(false);
    }

    public void OpenTutorial()
    {
        TutorialPage.SetActive(true);
    }
     
}
