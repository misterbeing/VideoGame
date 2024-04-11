using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwithPosition : MonoBehaviour
{
    Camera mainCamera;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsObjectOutOfSight(player.position))
        {
            Debug.Log("Object is out of camera sight!");
            mainCamera.transform.position = new Vector3(player.position.x,player.position.y,mainCamera.transform.position.z);
        }
        else
        {
            return;
        }
    }

    private bool IsObjectOutOfSight(Vector3 worldPosition)
    {
        Vector3 viewportPoint = mainCamera.WorldToViewportPoint(worldPosition);
        return viewportPoint.x < 0 || viewportPoint.x > 1 || viewportPoint.y < 0 || viewportPoint.y > 1;

    }
}
