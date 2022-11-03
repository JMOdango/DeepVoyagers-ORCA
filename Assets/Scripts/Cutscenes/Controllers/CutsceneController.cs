using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CutsceneController : MonoBehaviour
{
    public GameScene currentScene;
    public TextBoxController textBox;
    public SpriteSwitcher backgroundController;
    public ChooseController chooseController;
    public AudioController audioController;
    private State state = State.IDLE;

    private enum State
    {
        IDLE, ANIMATE, CHOOSE
    }

    void Start()
    {
        if (currentScene is StoryScene)
        {
            StoryScene storyScene = currentScene as StoryScene;
            textBox.PlayScene(storyScene);
            backgroundController.SetImage(storyScene.background);
            PlayAudio(storyScene.sentences[0]);
        }
    }

    void Update()
    {
       
    }

    public void nextText(){
        if (state == State.IDLE)
        {
            if (textBox.IsCompleted())
            {   
                textBox.StopTyping();
                if (textBox.IsLastSentence())
                {
                    PlayScene((currentScene as StoryScene).nextScene);
                    enterLevel();
                }
                else
                {   
                    textBox.PlayNextSentence();
                    PlayAudio((currentScene as StoryScene).sentences[textBox.GetSentenceIndex()]);
                }
            }
            else
            {
                textBox.SpeedUp();
            }
        }  
    }

    public void enterLevel(){
        if((currentScene as StoryScene).nextScene == null){
            SceneManager.LoadScene("OrcaGame");
        }
    }

    public void skipCutscene(){
        SceneManager.LoadScene("OrcaGame");
    }

    public void PlayScene(GameScene scene)
    {
        StartCoroutine(SwitchScene(scene));
    }

    private IEnumerator SwitchScene(GameScene scene)
    {
        state = State.ANIMATE;
        currentScene = scene;
        textBox.Hide();
        yield return new WaitForSeconds(1f);
        if (scene is StoryScene)
        {
            StoryScene storyScene = scene as StoryScene;
            backgroundController.SwitchImage(storyScene.background);
            PlayAudio(storyScene.sentences[0]);
            yield return new WaitForSeconds(1f);
            textBox.ClearText();
            textBox.Show();
            yield return new WaitForSeconds(1f);
            textBox.PlayScene(storyScene);
            state = State.IDLE;
        }
        else if (scene is ChooseScene)
        {
            state = State.CHOOSE;
            chooseController.SetupChoose(scene as ChooseScene);
        }
    }

    private void PlayAudio(StoryScene.Sentence sentence){
        audioController.PlayAudio(sentence.music, sentence.sound);
    }

    public void StopAudio(){
        audioController.StopAudio();
    }
}