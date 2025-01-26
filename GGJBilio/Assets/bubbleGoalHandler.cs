using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleGoalHandler : MonoBehaviour
{
    //prevent the bubble from bouncing once it reaches the goal
    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.CompareTag("Win Zone")){
            GetComponent<Collider2D>().sharedMaterial = null;
        }
    }
}
