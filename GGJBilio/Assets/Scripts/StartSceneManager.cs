using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StartSceneManager : MonoBehaviour
{
    [SerializeField] private Animator introAnimator;  // Animator del panel hijo del Canvas
    [SerializeField] private Animator spriteAnimator; // Animator del sprite fuera del Canvas
    [SerializeField] private string introAnimationName = "TransitionOut2"; // Nombre de la animaci�n del panel
    [SerializeField] private string spriteAnimationTrigger = "BubbleBorn"; // Trigger de la animaci�n del sprite

    void Start()
    {
        // Iniciar el flujo de la escena
        StartCoroutine(StartSceneFlow());
    }

    private IEnumerator StartSceneFlow()
    {

        // Asegurarte de que el Animator no es nulo
        if (introAnimator != null)
        {
            // Esperar a que comience la animaci�n esperada
            while (!introAnimator.GetCurrentAnimatorStateInfo(0).IsName(introAnimationName))
            {
                yield return null;
            }

            // Esperar a que termine la animaci�n
            while (introAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f &&
                        introAnimator.GetCurrentAnimatorStateInfo(0).IsName(introAnimationName))
            {
                yield return null; // Continuar esperando hasta que la animaci�n finalice
            }
        }
        // Reproducir la animaci�n del sprite fuera del Canvas
        if (spriteAnimator != null)
        {
            spriteAnimator.SetTrigger(spriteAnimationTrigger);
            Debug.Log("Sprite animation triggered!");
        }
    }
}
