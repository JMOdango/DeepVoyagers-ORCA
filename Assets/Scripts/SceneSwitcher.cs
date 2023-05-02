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

    public void enterMenu()
    {
        SceneManager.LoadScene("MainMenu");
        FindObjectOfType<simpleAudioManager>().Play("MenuButtons");
    }

    public void enterArea1()
    {
        SceneManager.LoadScene("Area1_LevelSelection");
    }

    public void ReturnArea1()
    {
        SceneManager.LoadScene("Area1_LevelSelection");
    }

    public void ReturnArea2()
    {
        SceneManager.LoadScene("Area2_LevelSelection");
    }

    public void ReturnArea3()
    {
        SceneManager.LoadScene("Area3_LevelSelection");
    }

    public void ReturnArea4()
    {
        SceneManager.LoadScene("Area4_LevelSelection");
    }

    public void ReturnArea5()
    {
        SceneManager.LoadScene("Area5_LevelSelection");
    }

    public void ReturnArea6()
    {
        SceneManager.LoadScene("Area6_LevelSelection");
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

    public void Logout()
    {
        SceneManager.LoadScene("Login");
        PlayFabClientAPI.ForgetAllCredentials();
    }

    public void EnterBondCutscene(string cutscene)
    {
        SceneManager.LoadScene(cutscene);
    }
}
