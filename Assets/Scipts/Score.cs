using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text score;
    private spawner spawnerScript;
    void Start()
    {
        score = GetComponent<Text>();
        spawnerScript = FindObjectOfType<spawner>();
    }

    void Update()
    {
        score.text = "Score: " + spawnerScript.scoreNumber;

    }
}
