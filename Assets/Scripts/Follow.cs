using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform objectTofollow;
    public Transform thisObject;

    public bool followRotation;
    public Vector2 rotationOffset;
    public bool followPosition;
    public Vector2 positionOffset;

    private void Start()
    {
        thisObject = this.transform;
    }

    private void Update()
    {
        if (followRotation) 
        {
            thisObject.rotation = objectTofollow.rotation*Quaternion.Euler(rotationOffset);
        }

        if (followPosition) 
        {
            thisObject.position = objectTofollow.position + (Vector3)positionOffset;
        }
    }


}
