using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewChooseScene", menuName = "Data/New Choose Scene")]
[System.Serializable]
public class ChooseScene : GameScene
{
    public List<ChooseLabel> labels;
    
    [System.Serializable]
    public struct ChooseLabel
    {
        public string text;
        public StoryScene nextScene;
        public Speaker character;
        public bool liked; 
    }

    public void LikedByCharacter(ChooseLabel chooseLabel){
        if(chooseLabel.liked == true){

        }
    }
}
