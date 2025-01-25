using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static BubbleDie;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject pausePanel;

    private bool isPaused = false;

    void Update()
    {
        // Detecta si el jugador presiona la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    private void OnEnable()
    {
        BubbleDie.PlayerLost += OnPlayerLost;
    }

    private void OnDisable()
    {
        BubbleDie.PlayerLost -= OnPlayerLost;
    }
    private void OnPlayerLost()
    {
        Time.timeScale = 0f;

        if (losePanel != null)
        {
            losePanel.SetActive(true);
        }

    }
    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            if (pausePanel != null)
                pausePanel.SetActive(true);
        }
        else
        {
            ResumeGame();
        }
    }
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        if (pausePanel != null)
            pausePanel.SetActive(false);
        Debug.Log("vOLVI AL JUEG0");

    }
}
