using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    void Update()
    {
        Vector3 cameraArea = Camera.main.WorldToViewportPoint(transform.position);

        if (cameraArea.x < 0 || cameraArea.x > 1 || cameraArea.y < 0 || cameraArea.y > 1)
        {
            Destroy(gameObject);
        }
    }
}
