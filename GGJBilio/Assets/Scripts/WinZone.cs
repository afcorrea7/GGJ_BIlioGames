using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    [SerializeField] Collider2D bubbleColl;
    [SerializeField]public Rigidbody2D bubbleRB;
    [SerializeField] public BubbleMovement bubbleMovementScript;

    public static event Action OnPlayerWin;
    

    void OnTriggerEnter2D(Collider2D other){
        StopPlayerMovement();
        DeactivateThisCollider();
        OnPlayerWin?.Invoke();
    }

    //the player will stop movement once it reaches the goal
    void StopPlayerMovement(){
        bubbleRB.gravityScale = 0;
        bubbleRB.velocity = Vector2.zero;
        bubbleColl.sharedMaterial = null;
        bubbleMovementScript.enabled = false;
    }

    void DeactivateThisCollider(){
        GetComponent<Collider2D>().enabled = false;
    }
}
