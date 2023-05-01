using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoreBar : MonoBehaviour
{
    public Slider slider;
    public int fillSpeed = 1;
    public int targetProgress = 0;
    public int maxScore;
    float points;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    private void Start()
    {
        SetMaxScore(maxScore);
        SetStartValue(0);
    }
    void Update()
    {
        if (slider.value < targetProgress)
        {
            slider.value += (fillSpeed* Time.deltaTime);
            
        }
    }
    

    public void SetMaxScore(int score) {
        slider.maxValue = score;
    }
    
    public void SetScore(int score) {
        targetProgress +=  score;
    }

    public void SetStartValue(int score)
    {
        slider.value = score;
    }
}
