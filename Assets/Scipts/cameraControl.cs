using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    [SerializeField] Transform _target;
    float _smoothCamera = 0.125f;

    private void LateUpdate()
    {
        Vector3 targetPosition = _target.position;
        Vector3 smoothMoved = Vector3.Lerp(transform.position, targetPosition, _smoothCamera);
        transform.position = new Vector3(smoothMoved.x, smoothMoved.y, -5f);
    }
}
