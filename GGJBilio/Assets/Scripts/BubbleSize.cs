using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BubbleSize : MonoBehaviour
{
    [SerializeField] float maximumSize;
    [SerializeField] float massIncreaseFactor = 1f;
    [SerializeField] float cameraSizeIncrease = 0.2f;
    [SerializeField] float smoothTime = 0.3f;


    private Rigidbody2D rb;
    private BubbleMovement bubbleMovementScript;
    private CinemachineVirtualCamera virtualCamera;
    private float targetOrthographicSize;
    private float currentOrthographicSize;


    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        bubbleMovementScript = GetComponentInParent<BubbleMovement>();
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();

        if (virtualCamera == null)
        {
            Debug.LogError("Cinemachine Virtual Camera not found in the scene!");
        }
        currentOrthographicSize = virtualCamera.m_Lens.OrthographicSize;
    }

    public void IncreaseSize(float increaseFactor){
        Vector2 currentScale = new Vector2(transform.localScale.x, transform.localScale.y);
        currentScale += new Vector2(increaseFactor, increaseFactor);
        //compare only one of the axis since they increase at the same rate
        if(currentScale.x <= maximumSize){
            //allow sizing further if the maximum size cap is not met yet
            Debug.Log("Size before increase: "+ transform.localScale);
            transform.localScale = currentScale;
            Debug.Log("Size after increase: "+ transform.localScale);

            rb.mass += increaseFactor * massIncreaseFactor;
            Debug.Log("New mass: " + rb.mass);

            bubbleMovementScript.DecreaseHorizontalSpeed();
            Debug.Log("Size increased: " + transform.localScale);

            if (virtualCamera != null)
            {
                // Acceder al componente de lentes (Lens) de la cámara virtual
                var lens = virtualCamera.m_Lens;

                // Establecer el tamaño objetivo de la cámara
                targetOrthographicSize = lens.OrthographicSize + cameraSizeIncrease;
                StartCoroutine(SmoothCameraSizeChange());
            }

        }

    }
    // Coroutine para suavizar el cambio de tamaño de la cámara
    private IEnumerator SmoothCameraSizeChange()
    {
        float elapsedTime = 0f;

        // Suavizamos el tamaño de la cámara entre el valor actual y el objetivo
        while (elapsedTime < smoothTime)
        {
            currentOrthographicSize = Mathf.Lerp(currentOrthographicSize, targetOrthographicSize, (elapsedTime / smoothTime));
            virtualCamera.m_Lens.OrthographicSize = currentOrthographicSize;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegúrate de que el tamaño final sea exactamente el objetivo
        virtualCamera.m_Lens.OrthographicSize = targetOrthographicSize;
    }
}
