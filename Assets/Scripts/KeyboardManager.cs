using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class KeyboardManager : MonoBehaviour
{
    public TextMeshPro button1;
    public TextMeshPro button2;
    public TextMeshPro button3;
    public TextMeshPro button4;
    private float disappearingColorSpeed = 1.1f;
    private float minimumLetterTransparency = 0.01f;

    void Start()
    {
    }
    void Update()
    {
        checkButton();
        decreaseColors();
    }

    private void decreaseColors()
    {
        if (button1.color.b > 0)
        {
            float temp = button1.color.r /disappearingColorSpeed;
            button1.color = new Color(temp, temp, temp, Math.Abs(minimumLetterTransparency + temp));
        }

        if (button2.color.b > 0)
        {
            float temp = button2.color.r / disappearingColorSpeed;
            button2.color = new Color(temp, temp, temp, Math.Abs(minimumLetterTransparency + temp));
        }

        if (button3.color.b > 0)
        {
            float temp = button3.color.r / disappearingColorSpeed;
            button3.color = new Color(temp, temp, temp, Math.Abs(minimumLetterTransparency + temp));
        }

        if (button4.color.b > 0)
        {
            float temp = button4.color.r / disappearingColorSpeed;
            button4.color = new Color(temp, temp, temp, Math.Abs(minimumLetterTransparency + temp));
        }
    }

    private void checkButton()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            button1.color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            button2.color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            button3.color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            button4.color = Color.white;
        }
    }
}
