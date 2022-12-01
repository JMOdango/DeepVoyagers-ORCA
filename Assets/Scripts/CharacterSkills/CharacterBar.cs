using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBar : MonoBehaviour
{
    public GameObject garybar;
    public GameObject maribar;
    public GameObject coralinebar;
    public PamBar pambar;
    double points;
    SpawnCharacters charList;
    private void Start()
    {
        garybar = GameObject.Find("GaryBar");
        //garybar = FindObjectOfType<GaryBar>();
        //maribar = FindObjectOfType<MariBar>();
        //coralinebar = FindObjectOfType<CoralineBar>();
        //pambar = FindObjectOfType<PamBar>();

        //garybar = GameObject.Find("GaryBar");

    }
    //public void callMariBar(double score) {
    //    maribar.increaseBar(score);
    //}
    //public void callGaryBar(double score)
    //{
    //    garybar.increaseBar(score);
    //}
    //public void callCoralineBar(double score) {
    //   coralinebar.increaseBar(score);
    //}

    //public void callPamBar(double score) {
    //    pambar.increaseBar(score);
    //}

    //public void giveCharacterPoints()
    //{
    //    if (maribar.TargetBar < 1)
    //    {
    //        points += Random.Range(0.01f, 0.05f);
    //        callMariBar(points);
    //    }
    //    if (garybar.TargetBar < 1)
    //    {
    //        points += Random.Range(0.01f, 0.05f);
    //        callGaryBar(points);
    //    }
    //    if (coralinebar.TargetBar < 1)
    //    {
    //        points += Random.Range(0.01f, 0.05f);
    //       callCoralineBar(points);
    //    }
    //    if (pambar.TargetBar < 1)
    //    {
    //        points += Random.Range(0.01f, 0.05f);
    //        callPamBar(points);

    //    }
    //}
}
