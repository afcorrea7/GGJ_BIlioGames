using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSize : MonoBehaviour
{
    [SerializeField] float maximumSize;

    public void IncreaseSize(float increaseFactor){
        Vector2 currentScale = new Vector2(transform.localScale.x, transform.localScale.y);
        currentScale += new Vector2(increaseFactor, increaseFactor);
        //compare only one of the axis since they increase at the same rate
        if(currentScale.x <= maximumSize){
            //allow sizing further if the maximum size cap is not met yet
            Debug.Log("Size before increase: "+ transform.localScale);
            transform.localScale = currentScale;
            Debug.Log("Size after increase: "+ transform.localScale);
        }
    }
}
