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
        StartCoroutine(MoveToEndPoint());
    }

    IEnumerator MoveToEndPoint() {
        Debug.Log("Distance: "+Vector2.Distance(bubbleTransform.position, endingPoint.position));
        while (Vector2.Distance(bubbleTransform.position, endingPoint.position) > 0.1f)
        {
            bubbleTransform.position = Vector2.MoveTowards(bubbleTransform.position, endingPoint.position, dragToSpeed * Time.deltaTime);
            yield return null; //Wait for the next frame
        }
    }

    void OnDisable(){
        RealEndingEvent.OnRealEnding += DragBubbleToPoint;
    } 
}
