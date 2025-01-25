using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPassengers : MonoBehaviour
{
    [SerializeField] float weight;
    [SerializeField] int scoreIncrease;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            BecomeChild(other.gameObject);
            IncreaseParentSize(other.gameObject);
            Score.Instance.AddScore(scoreIncrease);
        }
    }

    //When the collectable touches the player, it will become a child
    void BecomeChild(GameObject bubbleParent){
        PassengerHandler passengerHandler = bubbleParent.transform.parent.GetComponent<PassengerHandler>();
        passengerHandler.BoardPassenger(transform);
    }

    //Tell the bubble to increase its size by 'weight' amount
    void IncreaseParentSize(GameObject bubble){
        BubbleSize bubbleSize = bubble.GetComponent<BubbleSize>();
        bubbleSize.IncreaseSize(weight); 
    }
    
}
