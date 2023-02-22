using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectProject : MonoBehaviour
{
    public GameObject RecycleCloseup;
    public GameObject ProjectSelection;
    //Project Panels
     public GameObject OrganicFertilizer;
     public GameObject PenHolder;
     public GameObject PlasticPot;
     public GameObject BirdFeeder;
     public GameObject ClotheBag;


public void ReturnToSelection()
    {
        RecycleCloseup.SetActive(false);
        OrganicFertilizer.SetActive(false);
        PenHolder.SetActive(false);
        PlasticPot.SetActive(false);
        BirdFeeder.SetActive(false);
        ClotheBag.SetActive(false);
    }

public void GoToSelection()
    {
        ProjectSelection.SetActive(true);
    }

public void BackToRequests()
    {
        ProjectSelection.SetActive(false);
    }

//Projects
public void OpenOrganicFertilizer()
    {
        OrganicFertilizer.SetActive(true);
        RecycleCloseup.SetActive(true);
    }

public void OpenPenHolder()
    {
        PenHolder.SetActive(true);
        RecycleCloseup.SetActive(true);
    }

public void OpenPlasticPot()
    {
        PlasticPot.SetActive(true);
        RecycleCloseup.SetActive(true);
    }

public void OpenBirdFeeder()
    {
        BirdFeeder.SetActive(true);
        RecycleCloseup.SetActive(true);
    }

public void OpenClotheBag()
    {
        ClotheBag.SetActive(true);
        RecycleCloseup.SetActive(true);
    }

}
