using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score Instance; // Referencia est�tica al ScoreManager
    private TextMeshProUGUI scoreText; // El texto en el Canvas donde se mostrar� el puntaje

    private int currentScore = 0; // Puntaje actual

    // Aseguramos que solo haya una instancia del ScoreManager
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruimos la nueva
        }
    }

    void Start(){
        scoreText = GetComponentInChildren<TextMeshProUGUI>();
    }

    // M�todo para agregar puntaje
    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        UpdateScoreUI();
    }

    // Actualizamos el texto en el Canvas con el puntaje actual
    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }
}
