using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleDie : MonoBehaviour
{
    public delegate void OnPlayerLose(); // Define el evento de perder
    public static event OnPlayerLose PlayerLost;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto colisionado tiene la etiqueta "Obstacle"
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Dispara el evento de perder
            PlayerLost?.Invoke();
            Debug.Log("El jugador ha perdido.");
        }
    }
}
