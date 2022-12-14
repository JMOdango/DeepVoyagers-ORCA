using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SelectLoungeChara : MonoBehaviour
{
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

     public TempBondPoints bondpoints;
    

     void Start()
     {
        ItemShopCloseUp item = gameObject.GetComponent<ItemShopCloseUp>();
        TempBondPoints bondpoints = gameObject.GetComponent<TempBondPoints>();
        notifanim.SetBool("playNotif",false);
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
    
    //temporary thresholds in increasing the hearts
    public const int firstthreshold = 9;
    public const int secondthreshold = 21;
    public const int thirdthreshold = 30;

    

    public void GiveGift(int character) //this is where to increase the relationship points
    {
      character = this.character;
      switch (character) 
    {
    case 1:
       if (item.chosengift == "map")
       {
        //increase the temp bond points, can be referenced to the actual gary bond points in the future
        bondpoints.garybondpoints += giftpoints; 
       
        // these if statements can be somewhere else more appropriate
        //temporarily here to show increase of hearts
      
        if (bondpoints.garybondpoints >= firstthreshold)
        {
          GaryHeartsList[0].SetActive(true);
        }
        if (bondpoints.garybondpoints >= secondthreshold)
        {
          GaryHeartsList[1].SetActive(true);
        }
        if (bondpoints.garybondpoints >= thirdthreshold)
        {
          GaryHeartsList[2].SetActive(true);
        }

        //////

        
        notif.text = "Relationship Increased!";
        notifanim.SetBool("playNotif",true); 
       }
       else
       {
        notif.text = "No Increase";
        notifanim.SetBool("playNotif",true); 
       }
        break;

    case 2:
       if (item.chosengift == "crystals")
       {
        //bondpoints.coralinebondpoints += giftpoints; --reference to coralinebondpoints instead

        CoralineHeartsList[0].SetActive(true); //temp, just to show relationship increased
                                               
        notif.text = "Relationship Increased!";
        notifanim.SetBool("playNotif",true); 
       }
       else
       {
        notif.text = "No Increase";
        notifanim.SetBool("playNotif",true); 
       }
        break;
    case 3:
      if (item.chosengift == "stufftoy")
       {
        //bondpoints.pambondpoints += giftpoints; --reference to actual instead
        
        PamHeartsList[0].SetActive(true);

        notif.text = "Relationship Increased!";
        notifanim.SetBool("playNotif",true); 
       }
      else
       {
        notif.text = "No Increase";
        notifanim.SetBool("playNotif",true); 
       }
        break;
    case 4:
       if (item.chosengift == "waterproofcamera")
       {
        //bondpoints.dianebondpoints += giftpoints; --reference to actual instead
        
        DianeHeartsList[0].SetActive(true);
        notif.text = "Relationship Increased!";
        notifanim.SetBool("playNotif",true); 
       }
       else
       {
        notif.text = "No Increase";
        notifanim.SetBool("playNotif",true); 
       }
        break;
    case 5:
       if (item.chosengift == "toyfigure")
       {
        //bondpoints.malachibondpoints += giftpoints; --reference to actual instead
        
        MalachiHeartsList[0].SetActive(true);
        notif.text = "Relationship Increased!";
        notifanim.SetBool("playNotif",true);
       }
        else
       {
        notif.text = "No Increase";
        notifanim.SetBool("playNotif",true); 
       }
        break;
    case 6:
       if (item.chosengift == "historybook")
       {
        //bondpoints.oscarbondpoints += giftpoints; --reference to actual instead
        
        OscarHeartsList[0].SetActive(true);
        notif.text = "Relationship Increased!";
        notifanim.SetBool("playNotif",true);
       }
        else
       {
        notif.text = "No Increase";
        notifanim.SetBool("playNotif",true); 
       }
        break;
    case 7:
      if (item.chosengift == "seaweed")
       {
        //bondpoints.oscarbondpoints += giftpoints; --reference to actual instead
        
        MariHeartsList[0].SetActive(true);
        notif.text = "Relationship Increased!";
        notifanim.SetBool("playNotif",true);
       }
        else
       {
        notif.text = "No Increase";
        notifanim.SetBool("playNotif",true); 
       }
        break;
    }
    }

    

}
