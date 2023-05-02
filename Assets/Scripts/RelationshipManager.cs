using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;

public class Relationship{
    public int gary, 
    coraline,
    pam, 
    diane,
    malachi,
    oscar,
    mari;

    public Relationship(
        int gary,
        int coraline, 
        int pam, 
        int diane, 
        int malachi, 
        int oscar, 
        int mari
    ){
        this.gary = gary;
        this.coraline = coraline;
        this.pam = pam;
        this.diane = diane;
        this.malachi = malachi;
        this.oscar = oscar;
        this.mari = mari;
    }
}

public class RelationshipManager : MonoBehaviour
{
    public static RelationshipManager relationship;
    public SelectLoungeChara selectLoungeChara;
    InventoryUI inventoryUI;
    public RelationshipManager[] relationshipManager;
    
    [SerializeField]
    private int garyRelationship, coralineRelationship, pamRelationship, dianeRelationship, malachiRelationship, oscarRelationship, mariRelationship;

    public Relationship ReturnClass(){
        return new Relationship(garyRelationship, 
        coralineRelationship, 
        pamRelationship, 
        dianeRelationship, 
        malachiRelationship, 
        oscarRelationship, 
        mariRelationship
        );
    }
    // Start is called before the first frame update
    public void Start(){

    }

    public void Awake(){
        if(relationship == null)
        {
            relationship = this;
        }
        else
        {
            if(relationship != this){
                Destroy(this.gameObject);
            }
        }
        GetRelationships();
    }

    public void Update(){

    }

    public void SetGary(int garybondpoints){
        garyRelationship = garybondpoints;
    }

    public void SetCoraline(int coralinebondpoints){
        coralineRelationship = coralinebondpoints;
    }

    public void SetPam(int pambondpoints){
        pamRelationship = pambondpoints;
    }

    public void SetDiane(int dianebondpoints){
        dianeRelationship = dianebondpoints;
    }

    public void SetMalachi(int malachibondpoints){
        malachiRelationship = malachibondpoints;
    }

    public void SetOscar(int oscarbondpoints){
        oscarRelationship = oscarbondpoints;
    }

    public void SetMari(int maribondpoints){
        mariRelationship = maribondpoints;
    }

    public int GetGary(){
        return garyRelationship;
    }

    public int GetCoraline(){
        return coralineRelationship;
    }
    public int GetPam(){
        return pamRelationship;
    }
    public int GetDiane(){
        return dianeRelationship;
    }
    public int GetMalachi(){
        return malachiRelationship;
    }
    public int GetOscar(){
        return oscarRelationship;
    }

    public int GetMari(){
        return mariRelationship;
    }

    public void SetCount(Relationship relationship){
        garyRelationship = relationship.gary;
        coralineRelationship = relationship.coraline;
        pamRelationship = relationship.pam;
        dianeRelationship = relationship.diane;
        malachiRelationship = relationship.malachi;
        oscarRelationship = relationship.oscar;
        mariRelationship = relationship.mari;
    }

    public void SaveRelationships(){
        List<Relationship> relationships = new List<Relationship>();
        foreach (var relationship in relationshipManager){
            relationships.Add(relationship.ReturnClass());
        }
        var request = new UpdateUserDataRequest{
            Data = new Dictionary<string, string>{
                {"Relationship", JsonConvert.SerializeObject(relationships)}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, 
            error => Debug.LogError(error.GenerateErrorReport())
        );
    }

    public void OnDataSend(UpdateUserDataResult result){
        Debug.Log("User data successfully sent.");
    }

    public void GetRelationships(){
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnInventoryDataReceived, 
        error => Debug.LogError(error.GenerateErrorReport()));
    }

    void OnInventoryDataReceived(GetUserDataResult result){
        Debug.Log("Received inventory data");
        if(result.Data != null && result.Data.ContainsKey("Relationship")){List<Relationship> relationships = JsonConvert.DeserializeObject<List<Relationship>>(result.Data["Relationship"].Value);
            for(int i = 0; i < relationshipManager.Length; i++){
                relationshipManager[i].SetCount(relationships[i]);
            }
        }
    }
}
