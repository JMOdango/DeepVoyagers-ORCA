using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBar : MonoBehaviour
{
    public GaryBar garybar;
    public MariBar maribar;
    public CoralineBar coralinebar;
    public PamBar pambar;
    private void Start()
    {
        garybar = FindObjectOfType<GaryBar>();
        maribar = FindObjectOfType<MariBar>();
        coralinebar = FindObjectOfType<CoralineBar>();
        pambar = FindObjectOfType<PamBar>();

    }
    public void callMariBar(double score) {
        maribar.increaseBar(score);
    }
    public void callGaryBar(double score)
    {
        garybar.increaseBar(score);
    }
    public void callCoralineBar(double score) {
       coralinebar.increaseBar(score);
    }

    public void callPamBar(double score) {
        pambar.increaseBar(score);
    }
}
