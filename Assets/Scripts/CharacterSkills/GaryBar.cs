using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GaryBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image garyBar;
    public float fillSpeed = 0.5f;
    public double TargetBar = 0;
    void Start()
    {
        garyBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (garyBar.fillAmount < TargetBar)
        {
            garyBar.fillAmount += fillSpeed * Time.deltaTime;
        }

    }

    public void increaseBar(double score)
    {
        TargetBar = score;
    }
}
