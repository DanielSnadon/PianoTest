using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenScript : MonoBehaviour
{
    public float slideSpeed = 15.0f;
    public bool isDisappearing = false;
    public GameObject startScreenBackground;
    public Text mainText;
    public Text author;
    public Text subText;
    private float yBorder = 1500;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            tabPressed();
        }

        if (isDisappearing)
        {
            startScreenBackground.transform.Translate(Vector2.up * slideSpeed * Time.deltaTime);
            mainText.color = new Color(mainText.color.r, mainText.color.g, mainText.color.b, mainText.color.a - 0.002f);
            subText.color = new Color(subText.color.r, subText.color.g, subText.color.b, subText.color.a - 0.005f);
            author.color = new Color(author.color.r, author.color.g, author.color.b, author.color.a - 0.02f);
            if (startScreenBackground.transform.position.y > yBorder)
            {
                Destroy(gameObject);
            }
        }
    }
    
    void tabPressed()
    {
        isDisappearing = true;
    }
}
