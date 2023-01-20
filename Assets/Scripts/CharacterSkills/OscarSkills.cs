using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OscarSkills : MonoBehaviour
{

    private Board board;

    public Image oscarImage;
    public float fillSpeed = 0.5f;
    public double TargetBar = 0;
    double points;


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
    void Start()
    {
        oscarImage.fillAmount = 0;
        board = FindObjectOfType<Board>();
        checkChars();
        checkInstantiate();
    }

    void Update()
    {
        if (oscarImage.fillAmount < TargetBar)
        {
            oscarImage.fillAmount += fillSpeed * Time.deltaTime;
        }
    }

    public void GetPoints()
    {
        if (oscarImage.fillAmount < 1)
        {
            points += Random.Range(0.04f, 0.08f);
            increaseBar(points);
            board.getPoints = false;
        }
    }
    public void increaseBar(double score)
    {
        TargetBar = score;
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
    public void givePoints()
    {
        if (isCoraline)
        {
            coraline.GetPoints();
        }
        if (isGary)
        {
            gary.GetPoints();
        }
        if (isMari)
        {
            mari.GetPoints();
        }

        if (isPam)
        {
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

    public void giveCharPoints() {
        if (oscarImage.fillAmount == 1)
        {
            givePoints();
            oscarImage.fillAmount = 0;
            points = 0;
            TargetBar = 0;
        }
    }

    public void checkChars() {
        for (int i = 0; i < party.party.Length; i++)
        {
            if (party.party[i] == "Coraline")
            {
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
}
