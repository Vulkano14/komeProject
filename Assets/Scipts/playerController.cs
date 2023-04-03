using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 5f;

    private Vector2 startPosition;
    private Vector2 moveDirection = Vector2.zero;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                startPosition = Camera.main.ScreenToWorldPoint(touch.position);

            else if (touch.phase == TouchPhase.Moved)
            {
                Vector2 currentTouchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                moveDirection = (currentTouchPosition - startPosition).normalized;
            }
            else if (touch.phase == TouchPhase.Ended)
                moveDirection = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveDirection * speed;
    }
}