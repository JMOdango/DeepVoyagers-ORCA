using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
    public static ButtonController buttonController;
    public GameObject staminaRequirementScreen;
    private int levelNo;
    public int sceneIndex;

    void Start()
    {
        staminaRequirementScreen.SetActive(false);
    }

    public void StaminaRequirement() 
    {
        staminaRequirementScreen.SetActive(true);
    }

    public void OpenScene(){
        SceneManager.LoadScene(sceneIndex);
    }
}
