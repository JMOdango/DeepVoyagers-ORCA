using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TempPlayerInventory: MonoBehaviour
{
    public static TempPlayerInventory tempPlayerInventory;
    TrashCollectionManager trashCollectionManager;
    public TextMeshProUGUI plasticValueText, organicValueText, metalValueText, glassValueText, fabricValueText;
    [SerializeField]
    private int plasticLeft, organicLeft, metalLeft, glassLeft, fabricLeft;
    public int player_shells;
    public int player_coins;
    public int Fertilizer=3;
    public int BirdFeeder=3;
    public int ClotheBag=3;
    public int PenHolder=3;
    public int PlasticPot=3;

    private void Awake(){
        if(tempPlayerInventory == null)
        {
            tempPlayerInventory = this;
        }
        else
        {
            if(tempPlayerInventory != this){
                Destroy(this.gameObject);
            }
        }
        plasticValueText.text = plasticLeft.ToString();
        organicValueText.text = organicLeft.ToString();
        metalValueText.text = metalLeft.ToString();
        glassValueText.text = glassLeft.ToString();
        fabricValueText.text = fabricLeft.ToString();
    }

    void Update()
    {
        plasticLeft = TrashCollectionManager.trashCollectionManager.GetPlasticLeft();
        organicLeft = TrashCollectionManager.trashCollectionManager.GetOrganicLeft();
        metalLeft = TrashCollectionManager.trashCollectionManager.GetMetalLeft();
        glassLeft = TrashCollectionManager.trashCollectionManager.GetGlassLeft();
        fabricLeft = TrashCollectionManager.trashCollectionManager.GetFabricLeft();
    }
}
