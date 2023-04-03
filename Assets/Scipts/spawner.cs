using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 4f;
    private float nextSpawnTime;

    void Update()
    {
        // Sprawdzamy, czy up�yn�� czas spawnu kolejnego przeciwnika
        if (Time.time >= nextSpawnTime)
        {
            // Losujemy pozycj� przeciwnika w zakresie widoczno�ci kamery
            Vector3 randomPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.value, Random.value, 1f));

            // Tworzymy now� instancj� przeciwnika w wylosowanej pozycji
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

            // Ustawiamy czas spawnu kolejnego przeciwnika
            nextSpawnTime = Time.time + spawnRate;
        }
    }
}
