using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmaeraBlockedArrea : MonoBehaviour
{
    private Camera mainCamera;
    public BoxCollider2D boundsCollider;
    private void Start()
    {
        // Pobierz komponent kamery
        mainCamera = Camera.main;


        // Pobierz lub dodaj komponent BoxCollider2D
        boundsCollider = GetComponent<BoxCollider2D>();
        if (boundsCollider == null)
        {
            boundsCollider = gameObject.AddComponent<BoxCollider2D>();
        }

        // Ustaw rozmiary BoxCollider2D na rozmiary kamery
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = mainCamera.orthographicSize * 2f;
        boundsCollider.size = new Vector2(cameraHeight * screenAspect, cameraHeight);

        // Ustaw pozycjê BoxCollider2D na œrodek ekranu
        Vector3 cameraPosition = mainCamera.transform.position;
        boundsCollider.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, boundsCollider.transform.position.z);
    }
    
}
