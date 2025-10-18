using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject gameUI;

    public GameObject menuUI;

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
