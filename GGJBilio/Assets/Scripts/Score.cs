using System.Collections;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score Instance; // Referencia estática al ScoreManager

    [SerializeField] private TextMeshProUGUI scoreText; // El texto en el Canvas donde se mostrará el puntaje actual
    [SerializeField] private TextMeshProUGUI finalScoreText; // El texto en el Canvas donde se mostrará el puntaje final
    [SerializeField] private TextMeshProUGUI finalScoreText2; // El texto en el Canvas donde se mostrará el puntaje final

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

    // Método para agregar puntaje
    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        UpdateScoreUI();
    }

    // Actualizamos el texto en el Canvas con el puntaje actual y final
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = currentScore.ToString();
        }

        if (finalScoreText != null)
        {
            finalScoreText.text = currentScore.ToString();
            finalScoreText2.text = currentScore.ToString();
        }
    }

    // Método opcional para mostrar el puntaje final explícitamente (si es necesario)
    public void ShowFinalScore()
    {
        if (finalScoreText != null)
        {
            finalScoreText.text = currentScore.ToString();
            finalScoreText.gameObject.SetActive(true); // Asegúrate de que el texto esté activo
            finalScoreText2.gameObject.SetActive(true); // Asegúrate de que el texto esté activo
        }
    }
}