using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GravityZone : MonoBehaviour
{
    [SerializeField] private float speedIncrease; // Incremento de velocidad inmediato
    [SerializeField] private float gravityIncrease; // Incremento de gravedad
    [SerializeField] private float duration; // Duración del incremento gradual (en segundos)


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Buscar el script BubbleMovement en el objeto o en su jerarquía de padres
        BubbleMovement bubbleMovement = other.GetComponentInParent<BubbleMovement>();
        Rigidbody2D rb = other.GetComponentInParent<Rigidbody2D>();

        if (bubbleMovement != null && rb != null)
        {
            // Cambiar la maxVerticalSpeed de inmediato
            bubbleMovement.maxVerticalSpeed += speedIncrease;

            // Iniciar la corutina para incrementar la gravedad gradualmente
            StartCoroutine(IncreaseGravityGradually(rb));
        }
        else
        {
            Debug.LogWarning("No se encontró el script BubbleMovement o Rigidbody en el objeto o su padre.");
        }
    }

    private IEnumerator IncreaseGravityGradually(Rigidbody2D rb)
    {
        float elapsedTime = 0f;
        float initialGravity = rb.gravityScale; // Gravedad inicial

        // Mientras no haya transcurrido el tiempo total
        while (elapsedTime < duration)
        {
            // Incrementar la gravedad de forma gradual
            rb.gravityScale = Mathf.Lerp(initialGravity, initialGravity + gravityIncrease, elapsedTime / duration);

            // Incrementar el tiempo transcurrido
            elapsedTime += Time.deltaTime;

            // Esperar el siguiente frame
            yield return null;
        }

        // Asegurarse de que la gravedad final sea exactamente el valor deseado
        rb.gravityScale = initialGravity + gravityIncrease;

        Debug.Log($"Gravedad final: {rb.gravityScale}");
    }

}
