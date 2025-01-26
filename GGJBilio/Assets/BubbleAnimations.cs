using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleAnimations : MonoBehaviour
{
    private Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Wall")){
            CallBounceAnimation();
        }
    }

    public void CallBounceAnimation(){
        animator.SetTrigger("Bounce");
    }
}
