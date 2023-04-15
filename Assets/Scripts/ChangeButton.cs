using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeButton : MonoBehaviour
{
    public Button button;
    public Sprite ButtonChange;
    public void ChangeSprite()
    {
    // getting Image component of soundButton and changing it
        button = GetComponent<Button>();
        button.image.sprite = ButtonChange;
        Debug.Log ("Changed");
    }

}
