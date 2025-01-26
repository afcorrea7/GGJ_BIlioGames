using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject transitionPanel;
    [SerializeField] private Animator startButtonAnimator;
    private string sceneToLoad;

    // Este método te permitirá cambiar la escena desde un botón
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
        // Reproducir animación de presionar el botón
        startButtonAnimator.SetTrigger("Pressed");

        // Iniciar la animación de la cortinilla
        StartCoroutine(TransitionToScene());
    }
    // Corutina para manejar la transición y cargar la escena
    private IEnumerator TransitionToScene()
    {
        // Play transition animation
        transitionPanel.SetActive(true);
        Animator transitionAnimator = transitionPanel.GetComponent<Animator>();
        transitionAnimator.SetTrigger("StartTransition");


        //wait the animation time duration
        yield return new WaitForSeconds(3f); // Ajusta el tiempo según la duración de la animación

        // Cambiar de escena
        LoadSceneByName(sceneToLoad);
    }

}
