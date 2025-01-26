using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RealEndingEvent : MonoBehaviour
{
    public static event Action OnRealEnding;

    public void ToggleOnRealEnding(){
        OnRealEnding?.Invoke();
    }

}
