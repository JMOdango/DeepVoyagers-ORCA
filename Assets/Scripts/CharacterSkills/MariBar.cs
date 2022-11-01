using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MariBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image mariBar;
    public float fillSpeed = 0.5f;
    public double TargetBar = 0;
    void Start()
    {
        mariBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (mariBar.fillAmount < TargetBar) {
            mariBar.fillAmount +=  fillSpeed * Time.deltaTime;
        }

    }

    public void increaseBar(double score) {
        TargetBar = score;
    }
}
