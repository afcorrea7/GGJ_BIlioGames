using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static BubbleDie;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
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
        BubbleDie.PlayerLost += ActivateGameOverPanel;
        WinZone.OnPlayerWin += ActivateWinPanel;
    }

    private void OnDisable()
    {
        BubbleDie.PlayerLost -= ActivateGameOverPanel;
        WinZone.OnPlayerWin -= ActivateWinPanel;

    }
    private void ActivateGameOverPanel()
    {
        Time.timeScale = 0f;

        if (losePanel != null)
        {
            losePanel.SetActive(true);
        }
    }

    void ActivateWinPanel(){
        if (winPanel != null){
            winPanel.SetActive(true);
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void PauseGame(){
        Time.timeScale = 0f;
        if (pausePanel != null){
            pausePanel.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        if (pausePanel != null){
            pausePanel.SetActive(false);
        }
        Debug.Log("VOLVI AL JUEG0");
    }
}
