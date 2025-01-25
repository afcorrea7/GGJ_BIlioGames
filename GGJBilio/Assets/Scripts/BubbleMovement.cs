using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    [SerializeField] float bubbleVerticalSpeed = 2f; // velocidad hacia arriba que se incrementa?
    [SerializeField] float bubbleHorizontalSpeed = 10f; //velocidad de movimiento horizontal que se incrementa cada cierto numero de puntaje?

    [SerializeField] float xLimit = 10f;
    private void Update()
    {
        Movement();
        ScreenLimits();
        
    }
    void Movement()
    {
        Vector3 movement = new Vector3(0f, bubbleVerticalSpeed * Time.deltaTime, 0f);
        bubbleVerticalSpeed += Time.deltaTime * 0.1f;

        float horizontalMovement = Input.GetAxis("Horizontal");
        movement.x = horizontalMovement * bubbleHorizontalSpeed * Time.deltaTime;

        transform.position += movement;
    }
    void ScreenLimits()
    {
      transform.position = new Vector3(
    Mathf.Clamp(transform.position.x, -xLimit, xLimit),
    transform.position.y,
    transform.position.z
    );

    }
}
