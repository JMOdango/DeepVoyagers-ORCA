using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoreBar : MonoBehaviour
{
    public Slider slider;
    public int fillSpeed = 1;
    public int targetProgress = 0;
    float points;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    private void Start()
    {
        SetMaxScore(Random.Range(10000, 20000));
        SetStartValue(0);
    }
    void Update()
    {
        if (slider.value < targetProgress)
        {
            slider.value += (fillSpeed* Time.deltaTime);
            
        }
    }
    

    private void SetMaxScore(int score) {
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
