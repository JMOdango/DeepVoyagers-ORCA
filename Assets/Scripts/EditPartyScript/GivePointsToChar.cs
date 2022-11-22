using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePointsToChar : MonoBehaviour
{
    [SerializeField]
    private PartyObject party;
    private CoralineSkills coraline;
    private GarySkills gary;
    private MariSkills mari;
    private PamSkills pam;

    public bool isCoraline = false;
    public bool isDiane = false;
    public bool isGary = false;
    public bool isPam = false;
    public bool isMari = false;
    private void Start()
    {
      

        for (int i = 0; i < party.party.Length; i++) {
            if (party.party[i] == "Coraline") {
                isCoraline = true;
            }
            if (party.party[i] == "Diane")
            {
               isDiane = true;
            }
            if (party.party[i] == "Gary")
            {
                isGary = true;
            }
            if (party.party[i] == "Pam")
            {
                isPam = true;
            }
            if (party.party[i] == "Mari")
            {
                isMari = true;
            }
        }
    }

    public void checkInstantiate()
    {

        coraline = FindObjectOfType<CoralineSkills>();
        gary = FindObjectOfType<GarySkills>();
        mari = FindObjectOfType<MariSkills>();
        pam = FindObjectOfType<PamSkills>();
        
    }

    public void givePoints() {
        if (isCoraline) {
            coraline.GetPoints();
        }
        if (isGary) {
            gary.GetPoints();
        }
        if (isMari) {
            mari.GetPoints();
        }

        if (isPam) {
            pam.GetPoints();
        }

    }

}
