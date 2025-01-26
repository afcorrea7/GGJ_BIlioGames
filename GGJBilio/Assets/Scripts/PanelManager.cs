using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject hudPanel;  // El HUD que quieres manejar
    private bool isPaused = false;

    // Lista de paneles
    private List<GameObject> panels = new List<GameObject>();

    void Start()
    {
        // Añadir los paneles a la lista
        panels.Add(losePanel);
        panels.Add(pausePanel);
        panels.Add(hudPanel);
    }

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
        ActivatePanel(losePanel);
    }

    // Función de pausa
    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f;
            ActivatePanel(pausePanel);
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
        DeactivateAllPanels();  // Desactiva todos los paneles
        hudPanel.SetActive(true);  // Activa el HUD
        Debug.Log("Volví al juego");
    }

    // Método para activar un panel y desactivar los demás
    private void ActivatePanel(GameObject panelToActivate)
    {
        DeactivateAllPanels();  // Primero desactivamos todos
        panelToActivate.SetActive(true);  // Activamos el panel específico
    }

    // Método para desactivar todos los paneles
    private void DeactivateAllPanels()
    {
        foreach (var panel in panels)
        {
            panel.SetActive(false);  // Desactivamos todos los paneles
        }
    }
}
