using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoralineBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image coralineBar;
    public float fillSpeed = 0.5f;
    public double TargetBar = 0;
    void Start()
    {
        coralineBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (coralineBar.fillAmount < TargetBar)
        {
            coralineBar.fillAmount += fillSpeed * Time.deltaTime;
        }

    }

    public void increaseBar(double score)
    {
        TargetBar = score;
    }
}
