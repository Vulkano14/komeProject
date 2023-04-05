using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLogic : MonoBehaviour
{
    private Transform player;
    private int _colisions = 0;
    [SerializeField]private float speed = 1f;
    private SpriteRenderer _sprite;
    private bool _canAttack;
    private float _attackCooldown;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        _sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // oblicz wektor kierunku do gracza
        Vector3 direction = (player.position - transform.position).normalized;

        // porusz przeciwnikiem w kierunku gracza
        transform.position += direction * speed * Time.deltaTime;

        if (!_canAttack)
        {
            _attackCooldown -= Time.deltaTime;

            if (_attackCooldown <= 0f)
            {
                _canAttack = true;
                _sprite.color = Color.white;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _sprite.color = Color.red;

            if (_canAttack == true)
                _colisions++;


            _canAttack = false;
            _attackCooldown = 2f;

            if (_colisions >= 3)
                Destroy(gameObject);
        }      
    }
}

