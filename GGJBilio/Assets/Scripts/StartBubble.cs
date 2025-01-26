using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartBubble : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public void BubbleOn()
    {
        if (player != null) {
            Debug.Log("Player activated");
            // Activar el objeto (si está desactivado)
            player.SetActive(true);
        }
        else
        {
            Debug.LogWarning("BubbleDeactivate");

        }


    }
}
