using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OscarSkills : MonoBehaviour
{
   InfoLockManager infoLock;
    private Board board;

    public Image oscarImage;
    public float fillSpeed = 0.5f;
    public double TargetBar = 0;
    double points;
    string level;


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
        infoLock = FindObjectOfType<InfoLockManager>();
    }

    void Update()
    {
        if (oscarImage.fillAmount < TargetBar)
        {
            oscarImage.fillAmount += fillSpeed * Time.deltaTime;
        }
    }

    void Awake(){
        level = SceneManager.GetActiveScene().name;
    }

    public void GetPoints()
    {
        if (oscarImage.fillAmount < 1)
        {
            switch(level){
                case "Level1": points += Random.Range(0.30f, 0.50f); break;
                case "Level2": points += Random.Range(0.30f, 0.40f); break;
                case "Level3": points += Random.Range(0.20f, 0.40f); break;
                case "Level4": points += Random.Range(0.20f, 0.30f); break;
                case "Level5": points += Random.Range(0.10f, 0.30f); break;
            }
            increaseBar(points);
            board.getPoints = false;
        }
    }
    public void increaseBar(double score)
    {
        TargetBar = score;
    }

    public void ReceivePointsFromOscar(int oscarBondLevel)
    {
        if (oscarImage.fillAmount < 1)
        {
            switch(oscarBondLevel){
                case 3: points +=0.50f; break;
                case 2: points +=0.30f; break;
                case 1: points += 0.20f; break;
                case 0: points += 0.10f; break;
                
            }
            increaseBar(points);
            board.getPoints = false;
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
    public void givePoints()
    {
        if (isCoraline)
        {
            coraline.ReceivePointsFromOscar(infoLock.GetGaryBondUnlocked());
        }
        if (isGary)
        {
            gary.ReceivePointsFromOscar(infoLock.GetGaryBondUnlocked());
        }
        if (isMari)
        {
            mari.ReceivePointsFromOscar(infoLock.GetGaryBondUnlocked());
        }

        if (isPam)
        {
            pam.ReceivePointsFromOscar(infoLock.GetGaryBondUnlocked());
        }
        if (isOscar)
        {
            oscar.ReceivePointsFromOscar(infoLock.GetGaryBondUnlocked());
        }
        if (isMalachi)
        {
            malachi.ReceivePointsFromOscar(infoLock.GetGaryBondUnlocked());
        }
        if (isDiane)
        {
            diane.ReceivePointsFromOscar(infoLock.GetGaryBondUnlocked());
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
