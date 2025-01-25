using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    private GameObject losePanel;

    private void Awake()
    {
        losePanel = GameObject.Find("Lose Panel");
    }
    public void ShowLosePanel()
    {//Llamar el metodo del player donde se define que muere
        Time.timeScale = 0f;

        if (losePanel != null)
        {
            losePanel.SetActive(true);
        }
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
