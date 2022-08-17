using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
    }
    public void backGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
       
    }

   public void quit()
    {
        Application.Quit();
    }

    public void enterProjectCloseup()
    {
        SceneManager.LoadScene("ProjectCloseup");
    }

    public void enterRequests()
    {
        SceneManager.LoadScene("SelectRequest");
    }

      public void enterRecycling()
    {
        SceneManager.LoadScene("SelectProject");
    }

    public void enterMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void enterArea1()
    {
        SceneManager.LoadScene("Area1_LevelSelection");
    }

    public void Return()
    {
        SceneManager.LoadScene("Area1_LevelSelection");
    }
    public void ReturnToLogin()
    {
        SceneManager.LoadScene("Login");
    }

    public void EnterLounge()
    {
        SceneManager.LoadScene("Lounge");
    }
    public void EnterItemShop()
    {
        SceneManager.LoadScene("ItemShop");
    }
    public void EnterEditParty()
    {
        SceneManager.LoadScene("EditParty");
    }
    public void EnterRecyclingStation()
    {
        SceneManager.LoadScene("RecyclingStation");
    }
    public void EnterJournal()
    {
        SceneManager.LoadScene("Journal");
    }
}
