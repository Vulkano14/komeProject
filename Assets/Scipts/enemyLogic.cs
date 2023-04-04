using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLogic : MonoBehaviour
{
    private Transform player;
    public float speed = 1f;

    void Start()
    {
        // znajdü obiekt gracza
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        // oblicz wektor kierunku do gracza
        Vector3 direction = (player.position - transform.position).normalized;

        // porusz przeciwnikiem w kierunku gracza
        transform.position += direction * speed * Time.deltaTime;
    }
}

