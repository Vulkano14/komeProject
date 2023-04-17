using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
     Vector2 startPosition;
     Vector2 moveDirection = Vector2.zero;
     Rigidbody2D _rb;
     BoxCollider2D boundsCollider;
     Animator _animator;
     [SerializeField] enemyLogic _enemyLogic;

    float speed = 5f;
    bool _characterRotated = true;

    [SerializeField] GameObject _character;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        boundsCollider = FindObjectOfType<cmaeraBlockedArrea>().boundsCollider;
        _animator = GetComponent<Animator>();
        _enemyLogic = GetComponent<enemyLogic>();
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

        SwordAttack();
    }

    void FixedUpdate()
    {
        _rb.velocity = moveDirection * speed;

        if (moveDirection.x > 0 && _characterRotated)
            CharacterRotated();

        else if (moveDirection.x < 0 && !_characterRotated)
            CharacterRotatedUndo();

        float xPosition = Mathf.Clamp(_rb.position.x, boundsCollider.bounds.min.x + 0.5f, boundsCollider.bounds.max.x - 0.5f);
        float yPosition = Mathf.Clamp(_rb.position.y, boundsCollider.bounds.min.y + 0.5f, boundsCollider.bounds.max.y - 0.5f);
        _rb.position = new Vector2(xPosition, yPosition);
    }

    void SwordAttack()
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WeaponAxe"))
        {

        }
    }
}