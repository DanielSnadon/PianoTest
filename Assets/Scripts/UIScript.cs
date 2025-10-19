using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject gameUI;

    public GameObject menuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameUI.activeSelf)
            {
                showMenuUI();
            }
            else
            {
                showGameUI();
            }
            
        }
    }
    public void showGameUI()
    {
        gameUI.SetActive(true);
        menuUI.SetActive(false);
    }

    public void showMenuUI()
    {
        gameUI.SetActive(false);
        menuUI.SetActive(true);
    }

}
