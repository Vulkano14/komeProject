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
    private Animator _animator;
    [SerializeField]GameObject _character;
    bool _characterRotated = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boundsCollider = FindObjectOfType<cmaeraBlockedArrea>().boundsCollider;
        _animator = GetComponent<Animator>();
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

        swordAttack();
    }

    void FixedUpdate()
    {
        rb.velocity = moveDirection * speed;

        if (moveDirection.x > 0 && _characterRotated)
            CharacterRotated();

        else if (moveDirection.x < 0 && !_characterRotated)
            CharacterRotatedUndo();

        float xPosition = Mathf.Clamp(rb.position.x, boundsCollider.bounds.min.x + 0.5f, boundsCollider.bounds.max.x - 0.5f);
        float yPosition = Mathf.Clamp(rb.position.y, boundsCollider.bounds.min.y + 0.5f, boundsCollider.bounds.max.y - 0.5f);
        rb.position = new Vector2(xPosition, yPosition);
    }

    void swordAttack()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x > Screen.width / 2)
                    _animator.SetBool("attack", true);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                _animator.SetBool("attack", false);
            }
        }
    }

    void CharacterRotated()
    {
        _characterRotated = false;
        _character.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    void CharacterRotatedUndo()
    {
        _characterRotated = true;
        _character.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}