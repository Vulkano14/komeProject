using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLogic : MonoBehaviour
{
    Transform player;
    Vector3 _direction;
    indexEnemy IndexEnemy;

    SpriteRenderer _sprite;
    [SerializeField] GameObject _blood;

    float _speed = 0.7f;
    bool _trollCanAttack = true;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        _sprite = GetComponent<SpriteRenderer>();
        IndexEnemy = GetComponent<indexEnemy>();
    }

    void Update()
    {
        MoveEnemyTrollToPlayer();

        FlipSpriteEnemyTroll();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _trollCanAttack == true)
        {
            StartCoroutine(TrollAttackAndCooldown());
        }
    }

    IEnumerator TrollAttackAndCooldown()
    {
        _trollCanAttack = false;
        GameManager.gameManager._playerStatistics.DmgUnit(GameManager.gameManager.enemies[IndexEnemy.numberEnemy].Damage);
        yield return new WaitForSeconds(1.5f);
        _trollCanAttack = true;
    }

    void FlipSpriteEnemyTroll()
    {
        if (_direction.x < 0)
        {
            _sprite.flipX = false;

        }
        else if (_direction.x > 0)
        {
            _sprite.flipX = true;
        }
    }

    void MoveEnemyTrollToPlayer()
    {
        _direction = (player.position - transform.position).normalized;
        transform.position += _direction * _speed * Time.deltaTime;
    }
    
}
