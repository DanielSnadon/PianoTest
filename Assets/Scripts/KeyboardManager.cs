using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class KeyboardManager : MonoBehaviour
{
    public TextMeshPro button1;
    public TextMeshPro button2;
    public TextMeshPro button3;
    public TextMeshPro button4;

    private Color dePressedCollor;
    private Color pressedCollor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dePressedCollor = new Color(0, 0, 0, 0.9f);
        pressedCollor = new Color(255, 0, 0, 0.9f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            button1.color = pressedCollor;
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            button1.color = dePressedCollor;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            button2.color = pressedCollor;
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            button2.color = dePressedCollor;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            button3.color = pressedCollor;
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            button3.color = dePressedCollor;
        }
        
        if (Input.GetKeyDown(KeyCode.V))
        {
            button4.color = pressedCollor;
        }
        else if (Input.GetKeyUp(KeyCode.V))
        {
            button4.color = dePressedCollor;
        }
    }
}
