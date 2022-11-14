using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLoungeChara : MonoBehaviour
{
     public GameObject iconholder;
     public GameObject talkingsection;
     public GameObject giftingsection;
     public GameObject bondstats;

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

     int character = 1;
     

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
    }

    ///open character sprite

    public void InteractGary()
    {
      ExitCharacter();
      RemoveButtons();
      character = 1;
      GarySprite.SetActive(true);
      GaryButtons.SetActive(true);
    }

    public void InteractCoraline()
    {
      ExitCharacter();
      RemoveButtons();
      character = 2;
      CoralineSprite.SetActive(true);
      CoralineButtons.SetActive(true);
    }

    public void InteractPam()
    {
      ExitCharacter();
      RemoveButtons();
      character = 2;
      PamSprite.SetActive(true);
      PamButtons.SetActive(true);
    }

    public void InteractDiane()
    {
      ExitCharacter();
      RemoveButtons();
      character = 2;
      DianeSprite.SetActive(true);
      DianeButtons.SetActive(true);
    }

    public void InteractMalachi()
    {
      ExitCharacter();
      RemoveButtons();
      character = 2;
      MalachiSprite.SetActive(true);
      MalachiButtons.SetActive(true);
    }

    public void InteractOscar()
    {
      ExitCharacter();
      RemoveButtons();
      character = 2;
      OscarSprite.SetActive(true);
      OscarButtons.SetActive(true);
    }

    public void InteractMari()
    {
      ExitCharacter();
      RemoveButtons();
      character = 2;
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

      ExitConvo();

       switch (character) 
    {
    case 1:
        GaryConvo.SetActive(true);
        break;
    case 2:
        CoralineConvo.SetActive(true);
        break;
    case 3:
        PamConvo.SetActive(true);
        break;
    case 4:
        DianeConvo.SetActive(true);
        break;
    case 5:
        MalachiConvo.SetActive(true);
        break;
    case 6:
        OscarConvo.SetActive(true);
        break;
    case 7:
        MariConvo.SetActive(true);
        break;
    }
     
    }

    public void GiftToCharacter()
    {
        iconholder.SetActive(false);
       bondstats.SetActive(true);
       talkingsection.SetActive(true);
       giftingsection.SetActive(false);
    }


}
