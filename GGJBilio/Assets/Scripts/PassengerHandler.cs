using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerHandler : MonoBehaviour
{
    [SerializeField] Transform passengerGroup;

    public void BoardPassenger(Transform passenger){
        passenger.parent = passengerGroup;
        passenger.transform.localPosition = Vector2.zero;
    }
}
