using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOverScreen : MonoBehaviour
{
    void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Setup()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
