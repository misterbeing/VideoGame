using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ResetTransform._resetTransform();
    }
}
