using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLogic : MonoBehaviour
{
    private Transform player;
    private int _colisions = 0;
    [SerializeField] float speed = 1f;
    private SpriteRenderer _sprite;
    private bool _canAttack;
    bool _canAttackEnemy = false;
    float _attackCooldownEnemy;
    private float _attackCooldown;
    [SerializeField] GameObject _ammoPrefab;
    [SerializeField] Transform _positionFire;
    [SerializeField] float distance;
    [SerializeField] GameObject _blood;
    private playerController playerController;

    int _trollDamage = 10;
    bool _trollCanAttack = true;


    void Start()
    {
        player = GameObject.Find("Player").transform;
        _sprite = GetComponent<SpriteRenderer>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
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

        if (!_canAttackEnemy)
        {
            _attackCooldownEnemy -= Time.deltaTime;

            if (_attackCooldownEnemy <= 0f)
            {
                _canAttackEnemy = true;
            }
        }


        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < distance)
        {
            if (_canAttackEnemy)
            {
                Shoot();
                _canAttackEnemy = false;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WeaponAxe"))
        {
            if (_sprite.color == Color.white)
            {
                _sprite.color = Color.red;

                if (_canAttack == true)
                    _colisions++;

                _canAttack = false;
                _attackCooldown = 2f;

                if (_colisions >= 3)
                {
                    Destroy(gameObject);
                    GameObject bloodObject = Instantiate(_blood, gameObject.transform.position, Quaternion.identity);
                    Destroy(bloodObject, 2f);
                }     
            }
        }

        if (collision.CompareTag("Player") && _trollCanAttack == true)
        {
            GameManager.gameManager._playerHealth.DmgUnit(_trollDamage);
            _trollCanAttack = !_trollCanAttack;
            Invoke("TrollCanAttackReset", 2f);
        }
    }

    void TrollCanAttackReset()
    {
        _trollCanAttack = true;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(_ammoPrefab, _positionFire.position, _positionFire.rotation);

        Vector2 shootingDirection = (player.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = shootingDirection * 4f;

        _attackCooldownEnemy = 3f;
    }
}





