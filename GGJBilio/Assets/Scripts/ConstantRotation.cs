using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    public float rotationSpeed = 50f; //it may increase in each passenger picked or each speed zone entered

    void Update()
    {
        // Rotate constantly
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
