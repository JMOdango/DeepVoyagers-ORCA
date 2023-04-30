using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SelectLoungeChara : MonoBehaviour
{
  InventoryManager inventory;
  RelationshipManager relationship;
  LevelManager level;
  public GameObject iconholder;
  public GameObject talkingsection;
  public GameObject giftingsection;
  public GameObject bondstats;
  public GameObject Inventory;

  public GameObject GarySprite;
  public GameObject CoralineSprite;
  public GameObject PamSprite;
  public GameObject DianeSprite;
  public GameObject MalachiSprite;
  public GameObject OscarSprite;
  public GameObject MariSprite;

  public GameObject GaryConvo;
  public GameObject CoralineConvo;
  public GameObject PamConvo;
  public GameObject DianeConvo;
  public GameObject MalachiConvo;
  public GameObject OscarConvo;
  public GameObject MariConvo;
  
  public GameObject GaryButtons;
  public GameObject CoralineButtons;
  public GameObject PamButtons;
  public GameObject DianeButtons;
  public GameObject MalachiButtons;
  public GameObject OscarButtons;
  public GameObject MariButtons;

  public GameObject GaryHearts;
  public GameObject CoralineHearts;
  public GameObject PamHearts;
  public GameObject DianeHearts;
  public GameObject MalachiHearts;
  public GameObject OscarHearts;
  public GameObject MariHearts;

  public GameObject[] GaryHeartsList;
  public GameObject[] CoralineHeartsList;
  public GameObject[] PamHeartsList;
  public GameObject[] DianeHeartsList;
  public GameObject[] MalachiHeartsList;
  public GameObject[] OscarHeartsList;
  public GameObject[] MariHeartsList;

  public int character = 1;
  public ItemShopCloseUp item;
     
  public Animator notifanim;
  public TextMeshProUGUI notif;

  [SerializeField]
  private int garybondpoints, coralinebondpoints, pambondpoints, dianebondpoints, 
  malachibondpoints, oscarbondpoints, maribondpoints;

  public const int firstthreshold = 15;
  public const int secondthreshold = 45;
  public const int thirdthreshold = 150;

  public Button[] GaryConvos;
  public Button[] CoralineConvos; 
  public Button[] PamConvos;
  public Button[] DianeConvos;
  public Button[] MalachiConvos;
  public Button[] OscarConvos;
  public Button[] MariConvos;     
  public Button[] CharactersUnlocked;
    

  void Start()
  {
    ItemShopCloseUp item = gameObject.GetComponent<ItemShopCloseUp>();
    TempBondPoints bondpoints = gameObject.GetComponent<TempBondPoints>();
    notifanim.SetBool("playNotif",false);

    for(int i = 0; i < 3; i++){
      GaryConvos[i].interactable = false;
      CoralineConvos[i].interactable = false;
      PamConvos[i].interactable = false;
      DianeConvos[i].interactable = false;
      MalachiConvos[i].interactable = false;
      OscarConvos[i].interactable = false;
      MariConvos[i].interactable = false;
    }

    for(int i = 0; i < CharactersUnlocked.Length; i++){
      CharactersUnlocked[i].interactable = false;
    }
  }

  void Update(){
    SetRelationship();
    UnlockCharacter();
    UnlockConvos();
  }

  public void UnlockConvos(){
    //Gary
    if (garybondpoints >= firstthreshold)
    {
      GaryHeartsList[0].SetActive(true);
      GaryConvos[0].interactable = true;
    }
    if (garybondpoints >= secondthreshold)
    {
      GaryHeartsList[1].SetActive(true);
      GaryConvos[1].interactable = true;
    }
    if (garybondpoints >= thirdthreshold)
    {
      GaryHeartsList[2].SetActive(true);
      GaryConvos[2].interactable = true;
    }
    //Coraline
    if (coralinebondpoints >= firstthreshold)
    {
      CoralineHeartsList[0].SetActive(true);
      CoralineConvos[0].interactable = true;
    }
    if (coralinebondpoints >= secondthreshold)
    {
      CoralineHeartsList[1].SetActive(true);
      CoralineConvos[1].interactable = true;
    }
    if (coralinebondpoints >= thirdthreshold)
    {
      CoralineHeartsList[2].SetActive(true);
      CoralineConvos[2].interactable = true;
    }
    //Pam 
    if (pambondpoints >= firstthreshold)
    {
      PamHeartsList[0].SetActive(true);
      PamConvos[0].interactable = true;
    }
    if (pambondpoints >= secondthreshold)
    {
      PamHeartsList[1].SetActive(true);
      PamConvos[1].interactable = true;
    }
    if (pambondpoints >= thirdthreshold)
    {
      PamHeartsList[2].SetActive(true);
      PamConvos[2].interactable = true;
    }
    //Diane 
    if (dianebondpoints >= firstthreshold)
    {
      DianeHeartsList[0].SetActive(true);
      DianeConvos[0].interactable = true;
    }
    if (dianebondpoints >= secondthreshold)
    {
      DianeHeartsList[1].SetActive(true);
      DianeConvos[1].interactable = true;
    }
    if (dianebondpoints >= thirdthreshold)
    {
      DianeHeartsList[2].SetActive(true);
      DianeConvos[2].interactable = true;
    }
    //Malachi 
    if (malachibondpoints >= firstthreshold)
    {
      MalachiHeartsList[0].SetActive(true);
      MalachiConvos[0].interactable = true;
    }
    if (malachibondpoints >= secondthreshold)
    {
      MalachiHeartsList[1].SetActive(true);
      MalachiConvos[1].interactable = true;
    }
    if (malachibondpoints >= thirdthreshold)
    {
      MalachiHeartsList[2].SetActive(true);
      MalachiConvos[2].interactable = true;
    }
    //Oscar 
    if (oscarbondpoints >= firstthreshold)
    {
      OscarHeartsList[0].SetActive(true);
      OscarConvos[0].interactable = true;
    }
    if (oscarbondpoints >= secondthreshold)
    {
      OscarHeartsList[1].SetActive(true);
      OscarConvos[1].interactable = true;
    }
    if (oscarbondpoints >= thirdthreshold)
    {
      OscarHeartsList[2].SetActive(true);
      OscarConvos[2].interactable = true;
    }
    //Mari 
    if (maribondpoints >= firstthreshold)
    {
      MariHeartsList[0].SetActive(true);
      MariConvos[0].interactable = true;
    }
    if (maribondpoints >= secondthreshold)
    {
      MariHeartsList[1].SetActive(true);
      MariConvos[1].interactable = true;
    }
    if (maribondpoints >= thirdthreshold)
    {
      MariHeartsList[2].SetActive(true);
      MariConvos[2].interactable = true;
    }
  }

  public void UnlockCharacter(){
    if(LevelManager.level.GetArea2Unlocked() >= 1){
      CharactersUnlocked[0].interactable = true;

      // temp code so I can interact with all characters upon only unlocking area 2
      CharactersUnlocked[1].interactable = true;
      CharactersUnlocked[2].interactable = true;
      CharactersUnlocked[3].interactable = true;
      CharactersUnlocked[4].interactable = true;
      CharactersUnlocked[5].interactable = true;
      CharactersUnlocked[6].interactable = true;

    }
    if(LevelManager.level.GetArea3Unlocked() >= 1){
      CharactersUnlocked[1].interactable = true;
    }
    if(LevelManager.level.GetArea4Unlocked() >= 1){
      CharactersUnlocked[2].interactable = true;
    }
    if(LevelManager.level.GetArea5Unlocked() >= 1){
      CharactersUnlocked[3].interactable = true;
    }
    if(LevelManager.level.GetFinalAreaUnlocked() >= 1){
      CharactersUnlocked[4].interactable = true;
    }
    if(LevelManager.level.GetSecretArea1Unlocked() >= 1){
      CharactersUnlocked[5].interactable = true;
    }
    if(LevelManager.level.GetSecretArea2Unlocked() >= 1){
      CharactersUnlocked[6].interactable = true;
    }
  }

  public void ExitCharacter()
  {
    GarySprite.SetActive(false);
    CoralineSprite.SetActive(false);
    PamSprite.SetActive(false);
    DianeSprite.SetActive(false);
    MalachiSprite.SetActive(false);
    OscarSprite.SetActive(false);
    MariSprite.SetActive(false);
  }

    public void ExitSection()
    {
        bondstats.SetActive(false);
        iconholder.SetActive(true);
    }

    public void ExitConvo()
    {
       GaryConvo.SetActive(false);
       CoralineConvo.SetActive(false);
       PamConvo.SetActive(false);
       DianeConvo.SetActive(false);
       MalachiConvo.SetActive(false);
       OscarConvo.SetActive(false);
       MariConvo.SetActive(false);
    }

    public void RemoveButtons()
    {
       GaryButtons.SetActive(false);
       CoralineButtons.SetActive(false);
       PamButtons.SetActive(false);
       DianeButtons.SetActive(false);
       MalachiButtons.SetActive(false);
       OscarButtons.SetActive(false);
       MariButtons.SetActive(false);
    }

    public void RemoveHearts()
    {
       GaryHearts.SetActive(false);
       CoralineHearts.SetActive(false);
       PamHearts.SetActive(false);
       DianeHearts.SetActive(false);
       MalachiHearts.SetActive(false);
       OscarHearts.SetActive(false);
       MariHearts.SetActive(false);
    }

    ///open character sprite

    public void InteractGary()
    {
      ExitCharacter();
      RemoveButtons();
      RemoveHearts();
      character = 1;
      GarySprite.SetActive(true);
      GaryButtons.SetActive(true);
    }

    public void InteractCoraline()
    {
      ////
      ExitCharacter();
      RemoveButtons();
      RemoveHearts();
      character = 2;
      CoralineSprite.SetActive(true);
      CoralineButtons.SetActive(true);
    }

    public void InteractPam()
    {
      ExitCharacter();
      RemoveButtons();
      RemoveHearts();
      character = 3;
      PamSprite.SetActive(true);
      PamButtons.SetActive(true);
    }

    public void InteractDiane()
    {
      ExitCharacter();
      RemoveButtons();
      RemoveHearts();
      character = 4;
      DianeSprite.SetActive(true);
      DianeButtons.SetActive(true);
    }

    public void InteractMalachi()
    {
      ExitCharacter();
      RemoveButtons();
      RemoveHearts();
      character = 5;
      MalachiSprite.SetActive(true);
      MalachiButtons.SetActive(true);
    }

    public void InteractOscar()
    {
      ExitCharacter();
      RemoveButtons();
      RemoveHearts();
      character = 6;
      OscarSprite.SetActive(true);
      OscarButtons.SetActive(true);
    }

    public void InteractMari()
    {
      ExitCharacter();
      RemoveButtons();
      RemoveHearts();
      character = 7;
      MariSprite.SetActive(true);
      MariButtons.SetActive(true);
    }

    ///open talk buttons dedicated to the character
   
    public void TalkToGary()
    {
      ExitConvo();
      character = 1;
      TalkToCharacter(character);
    }

    public void TalkToCoraline()
    {
      ExitConvo();
      character = 2;
      TalkToCharacter(character);
    }

    public void TalkToPam()
    {
      ExitConvo();
      character = 3;
      TalkToCharacter(character);
    }

    public void TalkToDiane()
    {
      ExitConvo();
      character = 4;
      TalkToCharacter(character);
    }

    public void TalkToMalachi()
    {
      ExitConvo();
      character = 5;
      TalkToCharacter(character);
    }

    public void TalkToOscar()
    {
      ExitConvo();
      character = 6;
      TalkToCharacter(character);
    }

    public void TalkToMari()
    {
      ExitConvo();
      character = 7;
      TalkToCharacter(character);
    }

    //

    public void TalkToCharacter(int character)
    {
       iconholder.SetActive(false);
       bondstats.SetActive(true);
       
       talkingsection.SetActive(true);
       giftingsection.SetActive(false);
      
      RemoveHearts();
      ExitConvo();

      switch (character) 
      {
      case 1:
          GaryHearts.SetActive(true);
          GaryConvo.SetActive(true);
          break;
      case 2:
          CoralineHearts.SetActive(true);
          CoralineConvo.SetActive(true);
          break;
      case 3:
          PamHearts.SetActive(true);
          PamConvo.SetActive(true);
          break;
      case 4:
          DianeHearts.SetActive(true);
          DianeConvo.SetActive(true);
          break;
      case 5:
          MalachiHearts.SetActive(true);
          MalachiConvo.SetActive(true);
          break;
      case 6:
          OscarHearts.SetActive(true);
          OscarConvo.SetActive(true);
          break;
      case 7:
          MariHearts.SetActive(true);
          MariConvo.SetActive(true);
          break;
      }
    }

    public void GiftToGary()
    {
      ExitConvo();
      character = 1;
      GiftToCharacter(character);
    }

    public void GiftToCoraline()
    {
      ExitConvo();
      character = 2;
      GiftToCharacter(character);
    }

    public void GiftToPam()
    {
      ExitConvo();
      character = 3;
      GiftToCharacter(character);
    }

    public void GiftToDiane()
    {
      ExitConvo();
      character = 4;
      GiftToCharacter(character);
    }

    public void GiftToMalachi()
    {
      ExitConvo();
      character = 5;
      GiftToCharacter(character);
    }

    public void GiftToOscar()
    {
      ExitConvo();
      character = 6;
      GiftToCharacter(character);
    }

    public void GiftToMari()
    {
      ExitConvo();
      character = 7;
      GiftToCharacter(character);
    }

    public void GiftToCharacter(int character)
    {
       iconholder.SetActive(false);
       bondstats.SetActive(true);
       talkingsection.SetActive(false);
       giftingsection.SetActive(true);
    
      RemoveHearts();
    

      switch (character) 
      {
      case 1:
          GaryHearts.SetActive(true);
      break;
      case 2:
          CoralineHearts.SetActive(true);
      break;
      case 3:
          PamHearts.SetActive(true);
      break;
      case 4:
          DianeHearts.SetActive(true);
      break;
      case 5:
          MalachiHearts.SetActive(true);
      break;
      case 6:
          OscarHearts.SetActive(true);
      break;
      case 7:
          MariHearts.SetActive(true);
      break;
      }
    }

    public void GotoInventory()
    {
        Inventory.SetActive(true);
    }

    public void CloseInventory()
    {
        Inventory.SetActive(false);
    }

    
    public const int giftpoints = 3;
    

    public void SetRelationship(){
        garybondpoints = RelationshipManager.relationship.GetGary();
        coralinebondpoints = RelationshipManager.relationship.GetCoraline();
        pambondpoints = RelationshipManager.relationship.GetPam();
        dianebondpoints = RelationshipManager.relationship.GetDiane();
        malachibondpoints = RelationshipManager.relationship.GetMalachi();
        oscarbondpoints = RelationshipManager.relationship.GetOscar();
        maribondpoints = RelationshipManager.relationship.GetMari();
    }
    
    public void GiveGift(int character) //this is where to increase the relationship points
    {
      character = this.character;
      switch (character) 
    {
      case 1:
       if (item.chosengift == "map")
       {
        garybondpoints += giftpoints; 
        RelationshipManager.relationship.SetGary(garybondpoints);
        RelationshipManager.relationship.SaveRelationships();

        notif.text = "Relationship Increased!";
        notifanim.SetBool("playNotif",true); 
        InventoryManager.inventory.ReduceInventory(item.chosengift);
        item.CloseCloseUp();
       }
       else
       {
        notif.text = "No Increase";
        notifanim.SetBool("playNotif",true); 
        InventoryManager.inventory.ReduceInventory(item.chosengift);
        item.CloseCloseUp();
       }
        break;

    case 2:
       if (item.chosengift == "crystals")
       {
        coralinebondpoints += giftpoints; 
        RelationshipManager.relationship.SetCoraline(coralinebondpoints);
        RelationshipManager.relationship.SaveRelationships();
                                       
        notif.text = "Relationship Increased!";
        notifanim.SetBool("playNotif",true); 
        InventoryManager.inventory.ReduceInventory(item.chosengift);
        item.CloseCloseUp();
       }
       else
       {
        notif.text = "No Increase";
        notifanim.SetBool("playNotif",true); 
        InventoryManager.inventory.ReduceInventory(item.chosengift);
        item.CloseCloseUp();
       }
        break;
    case 3:
      if (item.chosengift == "stufftoy")
       {
        pambondpoints += giftpoints; 
        RelationshipManager.relationship.SetCoraline(pambondpoints);
        RelationshipManager.relationship.SaveRelationships();
        
        PamHeartsList[0].SetActive(true);

        notif.text = "Relationship Increased!";
        notifanim.SetBool("playNotif",true); 
        InventoryManager.inventory.ReduceInventory(item.chosengift);
        item.CloseCloseUp();
       }
      else
       {
        notif.text = "No Increase";
        notifanim.SetBool("playNotif",true); 
        InventoryManager.inventory.ReduceInventory(item.chosengift);
        item.CloseCloseUp();
       }
        break;
    case 4:
       if (item.chosengift == "waterproofcamera")
       {
        dianebondpoints += giftpoints; 
        RelationshipManager.relationship.SetCoraline(dianebondpoints);
        RelationshipManager.relationship.SaveRelationships();
        
        DianeHeartsList[0].SetActive(true);
        notif.text = "Relationship Increased!";
        notifanim.SetBool("playNotif",true); 
        InventoryManager.inventory.ReduceInventory(item.chosengift);
        item.CloseCloseUp();
       }
       else
       {
        notif.text = "No Increase";
        notifanim.SetBool("playNotif",true); 
        InventoryManager.inventory.ReduceInventory(item.chosengift);
        item.CloseCloseUp();
       }
        break;
    case 5:
       if (item.chosengift == "toyfigure")
       {
        malachibondpoints += giftpoints; 
        RelationshipManager.relationship.SetCoraline(malachibondpoints);
        RelationshipManager.relationship.SaveRelationships();
        
        MalachiHeartsList[0].SetActive(true);
        notif.text = "Relationship Increased!";
        notifanim.SetBool("playNotif",true);
        InventoryManager.inventory.ReduceInventory(item.chosengift);
        item.CloseCloseUp();
       }
        else
       {
        notif.text = "No Increase";
        notifanim.SetBool("playNotif",true); 
        InventoryManager.inventory.ReduceInventory(item.chosengift);
        item.CloseCloseUp();
       }
        break;
    case 6:
       if (item.chosengift == "historybook")
       {
        oscarbondpoints += giftpoints; 
        RelationshipManager.relationship.SetCoraline(oscarbondpoints);
        RelationshipManager.relationship.SaveRelationships();
        
        OscarHeartsList[0].SetActive(true);
        notif.text = "Relationship Increased!";
        notifanim.SetBool("playNotif",true);
        InventoryManager.inventory.ReduceInventory(item.chosengift);
        item.CloseCloseUp();
       }
       else
       {
        notif.text = "No Increase";
        notifanim.SetBool("playNotif",true); 
        InventoryManager.inventory.ReduceInventory(item.chosengift);
        item.CloseCloseUp();
       }
        break;
    case 7:
      if (item.chosengift == "seaweed")
       {
        maribondpoints += giftpoints; 
        RelationshipManager.relationship.SetCoraline(maribondpoints);
        RelationshipManager.relationship.SaveRelationships();
        
        MariHeartsList[0].SetActive(true);
        notif.text = "Relationship Increased!";
        notifanim.SetBool("playNotif",true);
        InventoryManager.inventory.ReduceInventory(item.chosengift);
        item.CloseCloseUp();
       }
        else
       {
        notif.text = "No Increase";
        notifanim.SetBool("playNotif",true); 
        InventoryManager.inventory.ReduceInventory(item.chosengift);
        item.CloseCloseUp();
       }
        break;
    }
    }
}
