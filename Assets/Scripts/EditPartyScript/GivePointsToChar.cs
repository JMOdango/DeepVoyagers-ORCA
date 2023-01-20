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
    private OscarSkills oscar;
    private MalachiSkills malachi;
    private DianeSkills diane;

    public bool isCoraline = false;
    public bool isGary = false;
    public bool isPam = false;
    public bool isMari = false;
    public bool isOscar = false;
    public bool isDiane = false;
    public bool isMalachi = false;

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
            if (party.party[i] == "Oscar")
            {
                isOscar = true;
            }
            if (party.party[i] == "Malachi")
            {
                isMalachi = true;
            }
        }
    }

    public void checkInstantiate()
    {

        coraline = FindObjectOfType<CoralineSkills>();
        gary = FindObjectOfType<GarySkills>();
        mari = FindObjectOfType<MariSkills>();
        pam = FindObjectOfType<PamSkills>();
        oscar = FindObjectOfType<OscarSkills>();
        malachi = FindObjectOfType<MalachiSkills>();
        diane = FindObjectOfType<DianeSkills>();
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
        if (isOscar)
        {
            oscar.GetPoints();
        }
        if (isMalachi)
        {
            malachi.GetPoints();
        }
        if (isDiane)
        {
            diane.GetPoints();
        }

    }

}
