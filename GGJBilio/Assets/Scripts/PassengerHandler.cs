using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerHandler : MonoBehaviour
{
    [SerializeField] Transform passengerGroup;

    public void BoardPassenger(Transform passenger, float offset){
        passenger.parent = passengerGroup;
        passenger.transform.localPosition = Vector2.zero;

        //translate the passengerGroup position by a little bit to accomodate for the new bubble size
        passengerGroup.localPosition = new Vector2(passengerGroup.localPosition.x - (offset/3), 0f);
    }
}
