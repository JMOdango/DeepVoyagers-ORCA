using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTile : MonoBehaviour
{
    Board board;
    public GameObject[] dots;
    public int hitPoints;
    private SpriteRenderer sprite;

    private void Start()
    {
        board = FindObjectOfType<Board>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (hitPoints <= 0) {
            Destroy(gameObject);
            board.oilCounter--;
        }
    }

    public void takeDamage(int damage) {
        hitPoints -= damage;
        makeLighter();
    }

    public void makeLighter() {
        Color color = sprite.color;
        float newAlpha = color.a * .7f;

        sprite.color = new Color(color.r, color.g, color.b, newAlpha);
    }
}
