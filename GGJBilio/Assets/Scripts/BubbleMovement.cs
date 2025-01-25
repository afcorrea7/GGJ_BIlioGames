using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    [SerializeField] float bubbleVerticalSpeed = 2f; // velocidad hacia arriba que se incrementa?
    public float maxVerticalSpeed = 5; //max speed increases with each speed zone entered
    [SerializeField] float bubbleHorizontalSpeed = 10f; //velocidad de movimiento horizontal que se incrementa cada cierto numero de puntaje?

    private Rigidbody2D thisRB;

    void Start(){
        thisRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
        CapVerticalSpeed();
    }

    void Movement()
    {
        Vector3 movement = new Vector3(0f, bubbleVerticalSpeed * Time.deltaTime, 0f);
        //bubbleVerticalSpeed += Time.deltaTime * 0.1f;

        float horizontalMovement = Input.GetAxis("Horizontal");
        movement.x = horizontalMovement * bubbleHorizontalSpeed * Time.deltaTime;

        transform.position += movement;
    }

    //max
    void CapVerticalSpeed(){
        if(thisRB.velocity.y > maxVerticalSpeed){
            thisRB.velocity = new Vector2(thisRB.velocity.x, maxVerticalSpeed);
        }
    }
}
