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
        Vector3 playerViewportPos = mainCamera.WorldToViewportPoint(player.position);
        if (IsObjectOutOfSight(player.position))
        {
            Debug.Log("Object is out of camera sight!");
            //mainCamera.transform.position = new Vector3(player.position.x, player.position.y, mainCamera.transform.position.z);
            if(playerViewportPos.x <0.5)
            {
                Debug.Log("player is on left side");
                mainCamera.transform.position = new Vector3(player.position.x-7, player.position.y+3f, mainCamera.transform.position.z);
            }

            else if(playerViewportPos.y <0.5) 
            {
                mainCamera.transform.position = new Vector3(player.position.x + 7, player.position.y + 3f, mainCamera.transform.position.z);
            }

            else
            {
                mainCamera.transform.position = new Vector3(player.position.x, player.position.y, mainCamera.transform.position.z);
            }
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
