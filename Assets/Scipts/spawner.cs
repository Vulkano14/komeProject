using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefab;
    BoxCollider2D boundsCollider;
    Vector3 randomPosition;
    public int _numberEnemy = 0;
    [SerializeField] Slider slider;
    public int wave = 0;
    float _waveCounterNumber = 3f;


    private void Start()
    {
        boundsCollider = FindObjectOfType<cmaeraBlockedArrea>().boundsCollider;
        slider.maxValue = _waveCounterNumber;
        slider.minValue = 0;
        StartCoroutine(CoolDownRespEnemy());
    }

    

    IEnumerator CoolDownRespEnemy()
    {
        WaveCounter();
        Debug.Log("Liczba wrogów w fali: " + _waveCounterNumber);

        int edgeIndex = Random.Range(0, 4);
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

        SpawnEnemy();
        slider.value = _waveCounterNumber;
        yield return new WaitForSeconds(GameManager.gameManager.enemies[0].SpawnRate);
        StartCoroutine(CoolDownRespEnemy());
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab[0], randomPosition, Quaternion.identity);
        _waveCounterNumber--;
        _numberEnemy++;
    }

    void WaveCounter()
    {
        if (_waveCounterNumber <= 0f)
        {
            wave++;

            _waveCounterNumber = _numberEnemy * 1.2f;
            _waveCounterNumber = Mathf.Round(_waveCounterNumber);
            slider.maxValue = _waveCounterNumber;
            Debug.Log("Number fali: " + wave);
        }
    }
}