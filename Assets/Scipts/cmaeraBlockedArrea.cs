using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmaeraBlockedArrea : MonoBehaviour
{
    Camera mainCamera;
    public BoxCollider2D boundsCollider;
    void Awake()
    {
        mainCamera = Camera.main;
        boundsCollider = GetComponent<BoxCollider2D>();


        if (boundsCollider == null)
            boundsCollider = gameObject.AddComponent<BoxCollider2D>();

        // Set BoxCollider2D sizes to camera sizes
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = mainCamera.orthographicSize * 2f;
        boundsCollider.size = new Vector2(cameraHeight * screenAspect, cameraHeight);

        // Position BoxCollider2D to the center of the screen
        Vector3 cameraPosition = mainCamera.transform.position;
        boundsCollider.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, boundsCollider.transform.position.z);
    }
    
}
