using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    [SerializeField] float bubbleVerticalSpeed = 2f; // velocidad hacia arriba que se incrementa?
    [SerializeField] ForceMode2D movementForceMode;
    public float maxVerticalSpeed = 5; //max speed increases with each speed zone entered
    [SerializeField] float bubbleHorizontalSpeed = 10f; //velocidad de movimiento horizontal que se incrementa cada cierto numero de puntaje?
    [SerializeField] float horizontalSpeedReductionFactor = 0.1f; // Factor para reducir la velocidad horizontal al aumentar el tama�o


    private Rigidbody2D thisRB;
    private BubbleSize bubbleSizeScript;
    private bool sizeIncreased = false;
    void Start()
    {
        thisRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
        CapVerticalSpeed();
    }

    void Movement()
    {
        //Vector3 movement = new Vector3(0f, bubbleVerticalSpeed * Time.deltaTime, 0f);
        //bubbleVerticalSpeed += Time.deltaTime * 0.1f;
        float bubbleSize = transform.localScale.x;
 
        float horizontalMovement = Input.GetAxis("Horizontal");

        Vector2 force = new Vector2(horizontalMovement * bubbleHorizontalSpeed, 0);

        thisRB.AddForce(force, movementForceMode);

        //Disallow exceeding maximum speed
        CapMovementSpeed();
    }

    void CapMovementSpeed(){
        float maxSpeed = 5f; // Adjust maximum speed as needed
        thisRB.velocity = new Vector2(
        Mathf.Clamp(thisRB.velocity.x, -maxSpeed, maxSpeed),
        thisRB.velocity.y
        );
    }
    //max
    void CapVerticalSpeed()
    {
        if (thisRB.velocity.y > maxVerticalSpeed)
        {
            thisRB.velocity = new Vector2(thisRB.velocity.x, maxVerticalSpeed);
        }
    }
    public void DecreaseHorizontalSpeed()
    {
        sizeIncreased = true;
        bubbleHorizontalSpeed -= horizontalSpeedReductionFactor;  
        bubbleHorizontalSpeed = Mathf.Max(bubbleHorizontalSpeed, 0);  // Asegura que la velocidad no sea negativa
        Debug.Log("Horizontal speed reduced to: " + bubbleHorizontalSpeed);
    }
}
