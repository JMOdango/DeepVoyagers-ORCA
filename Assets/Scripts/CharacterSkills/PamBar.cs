using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PamBar : MonoBehaviour
{

    public Image pamBar;
    public float fillSpeed = 0.5f;
    public double TargetBar = 0;
    void Start()
    {
        pamBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (pamBar.fillAmount < TargetBar)
        {
            pamBar.fillAmount += fillSpeed * Time.deltaTime;
        }

    }

    public void increaseBar(double score)
    {
        TargetBar = score;
    }
}
