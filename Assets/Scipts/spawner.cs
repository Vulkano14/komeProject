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
        // Sprawdzamy, czy up³yn¹³ czas spawnu kolejnego przeciwnika
        if (Time.time >= nextSpawnTime)
        {
            // Losujemy pozycjê przeciwnika w zakresie widocznoœci kamery
            Vector3 randomPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.value, Random.value, 1f));

            // Tworzymy now¹ instancjê przeciwnika w wylosowanej pozycji
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

            // Ustawiamy czas spawnu kolejnego przeciwnika
            nextSpawnTime = Time.time + spawnRate;
        }
    }
}
