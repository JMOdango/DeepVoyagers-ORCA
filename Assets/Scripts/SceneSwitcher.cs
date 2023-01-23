using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
public class SceneSwitcher : MonoBehaviour
{
    InventoryManager inventory;

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        FindObjectOfType<simpleAudioManager>().Play("MenuButtons");
    }
    
    public void backGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        FindObjectOfType<simpleAudioManager>().Play("MenuButtons");
    }

   public void quit()
    {
        Application.Quit();
    }

    public void enterProjectCloseup()
    {
        SceneManager.LoadScene("ProjectCloseup");
        FindObjectOfType<simpleAudioManager>().Play("MenuButtons");
    }

    public void enterRequests()
    {
        SceneManager.LoadScene("SelectRequest");
        FindObjectOfType<simpleAudioManager>().Play("MenuButtons");
    }

      public void enterRecycling()
    {
        SceneManager.LoadScene("SelectProject");
        FindObjectOfType<simpleAudioManager>().Play("MenuButtons");
    }

    public void enterMenu()
    {
        SceneManager.LoadScene("MainMenu");
        FindObjectOfType<simpleAudioManager>().Play("MenuButtons");
    }

    public void enterArea1()
    {
        SceneManager.LoadScene("Area1_LevelSelection");
    }

    public void Return()
    {
        SceneManager.LoadScene("Area1_LevelSelection");
    }

    public void EnterLounge()
    {
        SceneManager.LoadScene("Lounge");
        FindObjectOfType<simpleAudioManager>().Play("MenuButtons");
    }
    public void EnterItemShop()
    {
        SceneManager.LoadScene("ItemShop");
        FindObjectOfType<simpleAudioManager>().Play("MenuButtons");
    }
    public void EnterEditParty()
    {
        SceneManager.LoadScene("EditParty");
        FindObjectOfType<simpleAudioManager>().Play("MenuButtons");
    }
    public void EnterRecyclingStation()
    {
        SceneManager.LoadScene("RecyclingStation");
        FindObjectOfType<simpleAudioManager>().Play("MenuButtons");
    }
    public void EnterJournal()
    {
        SceneManager.LoadScene("Journal");
        FindObjectOfType<simpleAudioManager>().Play("MenuButtons");
    }

    public void Logout()
    {
        SceneManager.LoadScene("Login");
        PlayFabClientAPI.ForgetAllCredentials();
    }
}
