using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
using UnityEngine;

public class BubbleDie : MonoBehaviour
{
    public static event Action OnPlayerLost;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto colisionado tiene la etiqueta "Obstacle"
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Dispara el evento de perder
            OnPlayerLost?.Invoke();
            Debug.Log("El jugador ha perdido.");
        }
    }
}
