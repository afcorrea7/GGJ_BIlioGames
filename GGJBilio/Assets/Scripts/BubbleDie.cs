using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleDie : MonoBehaviour
{
    public delegate void OnPlayerLose(); // Define el evento de perder
    public static event OnPlayerLose PlayerLost;

    private Animator animator;
    private Rigidbody2D rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
           rb.velocity = Vector2.zero;

            if (animator != null)
            {
                animator.SetTrigger("Death");
            }
            StartCoroutine(DelayedInvoke());
        }
    }
    private IEnumerator DelayedInvoke()
    {
        yield return new WaitForSeconds(1f);
        PlayerLost?.Invoke();
    }
}
