using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 5f;

    private Vector2 startPosition;
    private Vector2 moveDirection = Vector2.zero;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private BoxCollider2D boundsCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boundsCollider = FindObjectOfType<cmaeraBlockedArrea>().boundsCollider;
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

        if (moveDirection.x > 0)
            spriteRenderer.flipX = true;
        else if (moveDirection.x < 0)
            spriteRenderer.flipX = false;

        float xPosition = Mathf.Clamp(rb.position.x, boundsCollider.bounds.min.x + 0.5f, boundsCollider.bounds.max.x - 0.5f);
        float yPosition = Mathf.Clamp(rb.position.y, boundsCollider.bounds.min.y + 0.5f, boundsCollider.bounds.max.y - 0.5f);
        rb.position = new Vector2(xPosition, yPosition);
    }


    //public GameObject sword; // obiekt miecza
    //public Transform swordSpawnPoint; // pozycja, z kt�rej wystrzelony zostanie miecz
    //public float swordAttackDuration = 0.5f; // czas trwania animacji ataku mieczem
    //public float swordAttackCooldown = 1f; // czas odnowienia ataku mieczem
    //private bool canAttack = true; // flaga, kt�ra m�wi, czy posta� mo�e atakowa� mieczem

    //void swordAttack()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        Touch touch = Input.GetTouch(0);

    //        if (touch.phase == TouchPhase.Began)
    //        {
    //            // Sprawd�, czy gracz dotkn�� prawej strony ekranu
    //            if (touch.position.x > Screen.width / 2)
    //            {
    //                // Sprawd�, czy posta� mo�e atakowa� mieczem
    //                if (canAttack)
    //                {
    //                    // Stw�rz nowy obiekt miecza na pozycji swordSpawnPoint i obr�� go zgodnie z kierunkiem ruchu postaci
    //                    GameObject newSword = Instantiate(sword, swordSpawnPoint.position, Quaternion.identity);
    //                    newSword.transform.rotation = Quaternion.LookRotation(Vector3.forward, moveDirection);

    //                    // Uruchom animacj� ataku mieczem i ustaw canAttack na false
    //                    StartCoroutine(SwordAttackCoroutine());
    //                }
    //            }
    //        }
    //    }
    //}
}