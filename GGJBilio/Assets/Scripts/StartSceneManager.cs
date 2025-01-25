using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartSceneManager : MonoBehaviour
{
    [SerializeField] private Animator introAnimator;  // Animador para la animación inicial

    void Start()
    {
        // Iniciar el flujo de la escena
        StartCoroutine(StartSceneFlow());
        //podemos hacer uqe eljugador comienze quieto?
    }

    private IEnumerator StartSceneFlow()
    {
        // Reproducir la animación inicial
        if (introAnimator != null)
        {
            introAnimator.SetTrigger("PlayIntro");
            yield return new WaitForSeconds(introAnimator.GetCurrentAnimatorStateInfo(0).length);
        }

 
    }

}
