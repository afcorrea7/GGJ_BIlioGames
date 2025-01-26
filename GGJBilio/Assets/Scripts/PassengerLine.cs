using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerLine : MonoBehaviour
{
    [SerializeField] Transform bubble; //the object that changes size
    private List<Transform> passengers = new List<Transform>();
    private float radiusOffset = 0; //Distance from the bubble's edge to the passengers line



    public void PositionPassengers() {
        if (passengers.Count > 0){
            // Get the bubble's radius
            float bubbleRadius = bubble.localScale.x / 2f;
            float adjustedRadius = bubbleRadius - radiusOffset;

            // Calculate angle increment for even spacing
            float angleIncrement = 360f / passengers.Count;

            // Position each fish
            for (int i = 0; i < passengers.Count; i++)
            {
                float angle = i * angleIncrement * Mathf.Deg2Rad; // Convert to radians

                // Calculate fish position on the circle
                float x = Mathf.Cos(angle) * adjustedRadius;
                float y = Mathf.Sin(angle) * adjustedRadius;

                // Set fish position relative to the FishParent
                passengers[i].localPosition = new Vector3(x, y, 0);
            }
        }
    }
}
