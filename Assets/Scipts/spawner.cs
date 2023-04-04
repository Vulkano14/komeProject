using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 4f;
    private float nextSpawnTime;
    private BoxCollider2D boundsCollider;
    public short scoreNumber = 0;

    private void Start()
    {
        boundsCollider = FindObjectOfType<cmaeraBlockedArrea>().boundsCollider;
    }
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            int edgeIndex = Random.Range(0, 4);
            Vector3 randomPosition = Vector3.zero;


            switch (edgeIndex)
            {
                case 0: // górna krawêdŸ
                    randomPosition = new Vector3(Random.Range(boundsCollider.bounds.min.x, boundsCollider.bounds.max.x), boundsCollider.bounds.max.y, 0f);
                    break;

                case 1: // dolna krawêdŸ
                    randomPosition = new Vector3(Random.Range(boundsCollider.bounds.min.x, boundsCollider.bounds.max.x), boundsCollider.bounds.min.y, 0f);
                    break;

                case 2: // lewa krawêdŸ
                    randomPosition = new Vector3(boundsCollider.bounds.min.x, Random.Range(boundsCollider.bounds.min.y, boundsCollider.bounds.max.y), 0f);
                    break;

                case 3: // prawa krawêdŸ
                    randomPosition = new Vector3(boundsCollider.bounds.max.x, Random.Range(boundsCollider.bounds.min.y, boundsCollider.bounds.max.y), 0f);
                    break;

                    
            }

            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

            nextSpawnTime = Time.time + spawnRate;

            scoreNumber++;
        }
    }
}
