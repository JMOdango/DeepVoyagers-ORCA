using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;

public class Level
{
    public int area1, area2, area3, area4, area5, area6;

    public Level(
        int area1,
        int area2, 
        int area3, 
        int area4, 
        int area5,
        int area6
    ){
        this.area1 = area1;
        this.area2 = area2;
        this.area3 = area3;
        this.area4 = area4;
        this.area5 = area5;
        this.area6 = area6;
    }
}

public class LevelManager : MonoBehaviour
{
    public static LevelManager level;
    public LevelManager[] levelManager;
    
    [SerializeField]
    private int area1Unlocked, area2Unlocked, area3Unlocked, area4Unlocked, area5Unlocked, area6Unlocked;

    public Level ReturnClass(){
        return new Level(area1Unlocked,
        area2Unlocked,
        area3Unlocked,
        area4Unlocked,
        area5Unlocked,
        area6Unlocked
        );
    }

    public void Start(){

    }

    public void Awake(){
        if(level == null)
        {
            level = this;
        }
        else
        {
            if(level != this){
                Destroy(this.gameObject);
            }
        }
        GetLevels();
        unlockLevel1(1);
    }

    public void Update(){
        
    }

    public void unlockLevel1(int unlocked){
        switch(unlocked){
            case 1: area1Unlocked = 1; break;
            case 2: area1Unlocked = 2; break;
            case 3: area1Unlocked = 3; break;
            case 4: area1Unlocked = 4; break;
            case 5: area1Unlocked = 5; break;
        }
    }

    public void unlockLevel2(int unlocked){
        switch(unlocked){
            case 1: area2Unlocked = 1; break;
            case 2: area2Unlocked = 2; break;
            case 3: area2Unlocked = 3; break;
            case 4: area2Unlocked = 4; break;
            case 5: area2Unlocked = 5; break;
            case 6: area2Unlocked = 6; break;
            case 7: area2Unlocked = 7; break;
        }
    }

    public void unlockLevel3(int unlocked){
        switch(unlocked){
            case 1: area3Unlocked = 1; break;
            case 2: area3Unlocked = 2; break;
            case 3: area3Unlocked = 3; break;
            case 4: area3Unlocked = 4; break;
            case 5: area3Unlocked = 5; break;
            case 6: area3Unlocked = 6; break;
            case 7: area3Unlocked = 7; break;
            case 8: area3Unlocked = 8; break;
            case 9: area3Unlocked = 9; break;
            case 10: area3Unlocked = 10; break;
        }
    }

    public void unlockLevel4(int unlocked){
        switch(unlocked){
            case 1: area4Unlocked = 1; break;
            case 2: area4Unlocked = 2; break;
            case 3: area4Unlocked = 3; break;
            case 4: area4Unlocked = 4; break;
            case 5: area4Unlocked = 5; break;
            case 6: area4Unlocked = 6; break;
            case 7: area4Unlocked = 7; break;
            case 8: area4Unlocked = 8; break;
            case 9: area4Unlocked = 9; break;
            case 10: area4Unlocked = 10; break;
        }
    }
        
    public void unlockLevel5(int unlocked){
        switch(unlocked){
            case 1: area5Unlocked = 1; break;
            case 2: area5Unlocked = 2; break;
            case 3: area5Unlocked = 3; break;
            case 4: area5Unlocked = 4; break;
            case 5: area5Unlocked = 5; break;
            case 6: area5Unlocked = 6; break;
            case 7: area5Unlocked = 7; break;
            case 8: area5Unlocked = 8; break;
            case 9: area5Unlocked = 9; break;
            case 10: area5Unlocked = 10; break;
        }
    }

        public void unlockLevel6(int unlocked){
        switch(unlocked){
            case 1: area6Unlocked = 1; break;
            case 2: area6Unlocked = 2; break;
            case 3: area6Unlocked = 3; break;
            case 4: area6Unlocked = 4; break;
            case 5: area6Unlocked = 5; break;
            case 6: area6Unlocked = 6; break;
            case 7: area6Unlocked = 7; break;
            case 8: area6Unlocked = 8; break;
            case 9: area6Unlocked = 9; break;
            case 10: area6Unlocked = 10; break;
            case 11: area6Unlocked = 11; break;
            case 12: area6Unlocked = 12; break;
        }
    }

    public void SetCount(Level level){
        area1Unlocked = level.area1;
        area2Unlocked = level.area2;
        area3Unlocked = level.area3;
        area4Unlocked = level.area4;
        area5Unlocked = level.area5;
        area6Unlocked = level.area5;
    }

    public int GetArea1Unlocked(){
        return area1Unlocked;
    }

    public int GetArea2Unlocked(){
        return area2Unlocked;
    }

    public int GetArea3Unlocked(){
        return area3Unlocked;
    }

    public int GetArea4Unlocked(){
        return area4Unlocked;
    }

    public int GetArea5Unlocked(){
        return area5Unlocked;
    }

    public int GetArea6Unlocked(){
        return area5Unlocked;
    }

    public void SaveLevels(){
        List<Level> levels = new List<Level>();
        foreach (var level in levelManager){
            levels.Add(level.ReturnClass());
        }
        var request = new UpdateUserDataRequest{
            Data = new Dictionary<string, string>{
                {"Level", JsonConvert.SerializeObject(levels)}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, 
            error => Debug.LogError(error.GenerateErrorReport())
        );
    }

    public void OnDataSend(UpdateUserDataResult result){
        Debug.Log("User data successfully sent.");
    }

    public void GetLevels(){
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnInventoryDataReceived, 
        error => Debug.LogError(error.GenerateErrorReport()));
    }

    void OnInventoryDataReceived(GetUserDataResult result){
        Debug.Log("Received inventory data");
        if(result.Data != null && result.Data.ContainsKey("Level")){List<Level> levels = JsonConvert.DeserializeObject<List<Level>>(result.Data["Level"].Value);
            for(int i = 0; i < levelManager.Length; i++){
                levelManager[i].SetCount(levels[i]);
            }
        }
    }
}
   
