using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTransform : MonoBehaviour
{
    public Transform initialTransform;
    public Vector3 initialPosition;
    public delegate void resetTransform();
    public static resetTransform _resetTransform;

    public bool reset;
    void OnEnable()
    {
        initialTransform = this.transform;
        initialPosition = transform.localPosition;
        _resetTransform += _ResetTransform;
    }

    private void Update()
    {
        if(reset) 
        {
            _ResetTransform();
            reset = false;
        }
    }
    public void _ResetTransform()
    {
        this.transform.position = initialPosition;
        //this.transform.rotation = initialTransform.rotation;    
    }
}
