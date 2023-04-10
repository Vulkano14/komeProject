using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 4f;
    private float nextSpawnTime;
    private BoxCollider2D boundsCollider;
    public short scoreNumber = 0;

    public int _numberEnemy = 10;
    [SerializeField] Slider slider;

    private void Start()
    {
        boundsCollider = FindObjectOfType<cmaeraBlockedArrea>().boundsCollider;
        slider.maxValue = _numberEnemy;
        slider.minValue = 0;
    }
    void Update()
    {
        if (Time.time >= nextSpawnTime && _numberEnemy > 0)
        {
            int edgeIndex = Random.Range(0, 4);
            Vector3 randomPosition = Vector3.zero;


            switch (edgeIndex)
            {
                case 0: // up
                    randomPosition = new Vector3(Random.Range(boundsCollider.bounds.min.x, boundsCollider.bounds.max.x), boundsCollider.bounds.max.y, 0f);
                    break;

                case 1: // down
                    randomPosition = new Vector3(Random.Range(boundsCollider.bounds.min.x, boundsCollider.bounds.max.x), boundsCollider.bounds.min.y, 0f);
                    break;

                case 2: // left
                    randomPosition = new Vector3(boundsCollider.bounds.min.x, Random.Range(boundsCollider.bounds.min.y, boundsCollider.bounds.max.y), 0f);
                    break;

                case 3: // right
                    randomPosition = new Vector3(boundsCollider.bounds.max.x, Random.Range(boundsCollider.bounds.min.y, boundsCollider.bounds.max.y), 0f);
                    break;     
            }

            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
            nextSpawnTime = Time.time + spawnRate;
            scoreNumber++;
            _numberEnemy--;
        }

        slider.value = _numberEnemy;
    }
}
