using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoreBar : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        SetMaxScore(Random.Range(5000, 10000)); ;
    }
    public void SetMaxScore(int score)
    {
        slider.maxValue = score;
    }
    public void SetScore(float score)
    {
        slider.value = score;
    }

    public void SetStartValue(int score)
    {
        slider.value = score;
    }
}
