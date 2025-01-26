using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealEndingExecuter : MonoBehaviour
{
    [SerializeField] Transform endingPoint;
    [SerializeField] float dragToSpeed = 5f;
    [SerializeField] Transform bubbleTransform;

    void OnEnable(){
        RealEndingEvent.OnRealEnding += DragBubbleToPoint;
    } 

    void DragBubbleToPoint(){
        Debug.Log("Dragging bubble to end point");
        bubbleTransform.position = Vector2.MoveTowards(bubbleTransform.position, endingPoint.position, dragToSpeed*Time.deltaTime);
    }

    void OnDisable(){
        RealEndingEvent.OnRealEnding += DragBubbleToPoint;
    } 
}
