using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrashCollectionManager : MonoBehaviour
{
    public static TrashCollectionManager trashCollectionManager;
    InventoryManager inventory;
    [SerializeField]
    private int storePlastic, storeOrganic, storeMetal, storeGlass, storeFabric;
    [SerializeField]
    private int storeFertilizer, storeBirdFeeder, storeClotheBag, storePenHolder, storePlasticPot;
    public TextMeshProUGUI plasticValueText, organicValueText, metalValueText, glassValueText, fabricValueText;
  
    private void Awake(){
        if(trashCollectionManager == null)
        {
            trashCollectionManager = this;
        }
        else
        {
            if(trashCollectionManager != this){
                Destroy(this.gameObject);
            }
        }
        plasticValueText.text = storePlastic.ToString();
        organicValueText.text = storeOrganic.ToString();
        metalValueText.text = storeMetal.ToString();
        glassValueText.text = storeGlass.ToString();
        fabricValueText.text = storeFabric.ToString();
    }

    void Update()
    {
        SetProjects();
        plasticValueText.text = storePlastic.ToString();
        organicValueText.text = storeOrganic.ToString();
        metalValueText.text = storeMetal.ToString();
        glassValueText.text = storeGlass.ToString();
        fabricValueText.text = storeFabric.ToString();
    }

    public void SetPlastic(int plastic)
    {
        storePlastic = plastic;
        return;
    }

    public void SetOrganic(int organic)
    {
        storeOrganic = organic;
        return;
    }

    public void SetMetal(int metal)
    {
        storeMetal = metal;
        return;
    }

    public void SetGlass(int glass)
    {
        storeGlass = glass;
        return;
    }

    public void SetFabric(int fabric)
    {
        storeFabric = fabric;
        return;
    }

    public int GetPlasticLeft(){
        return storePlastic;
    }
    
    public int GetOrganicLeft(){
        return storeOrganic;
    }

    public int GetMetalLeft(){
        return storeMetal;
    }

    public int GetGlassLeft(){
        return storeGlass;
    }

    public int GetFabricLeft(){
        return storeFabric;
    }

    public void SetProjects(){
        storeFertilizer = InventoryManager.inventory.GetFertilizerCount();
        storeBirdFeeder = InventoryManager.inventory.GetBirdFeederCount();
        storeClotheBag = InventoryManager.inventory.GetClotheBagCount();
        storePenHolder = InventoryManager.inventory.GetPenHolderCount();
        storePlasticPot = InventoryManager.inventory.GetPlasticPotCount();
    }

    public int GetFertilizerLeft(){
        return storeFertilizer;
    }
    
    public int GetBirdFeederLeft(){
        return storeBirdFeeder;
    }

    public int GetClotheBagLeft(){
        return storeClotheBag;
    }

    public int GetPenHolderLeft(){
        return storePenHolder;
    }

    public int GetPlasticPotLeft(){
        return storePlasticPot;
    }
};
