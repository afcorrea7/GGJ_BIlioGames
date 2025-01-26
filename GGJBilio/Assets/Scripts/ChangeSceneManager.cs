using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject transitionPanel;
    [SerializeField] private Animator startButtonAnimator;
    private string sceneToLoad;

    // Este m�todo te permitir� cambiar la escena desde un bot�n
    public void SetSceneToLoad(string sceneName)
    {
        sceneToLoad = sceneName;
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnStartButtonPressed()
    {
        // Reproducir animaci�n de presionar el bot�n
        startButtonAnimator.SetTrigger("Pressed");

        // Iniciar la animaci�n de la cortinilla
        StartCoroutine(TransitionToScene());
    }
    // Corutina para manejar la transici�n y cargar la escena
    private IEnumerator TransitionToScene()
    {
        // Play transition animation
        transitionPanel.SetActive(true);
        Animator transitionAnimator = transitionPanel.GetComponent<Animator>();
        transitionAnimator.SetTrigger("StartTransition");


        //wait the animation time duration
        yield return new WaitForSeconds(3f); // Ajusta el tiempo seg�n la duraci�n de la animaci�n

        // Cambiar de escena
        LoadSceneByName(sceneToLoad);
    }

}
