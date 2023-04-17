using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    public UnitHealth _playerStatistics = new UnitHealth(100, 100, 20);

    public gameOverScreen _gameoverScreen;

    public List<enemyTypes> enemies = new List<enemyTypes>();

    void Awake ()
    {
        if (gameManager != null && gameManager != this)
            Destroy(this);
        else
            gameManager = this;


        enemies.Add(new enemyTypes(50, 5, 0, 5));
        enemies.Add(new enemyTypes(65, 7, 0, 2));
    }

    private void Update()
    {
        if (_playerStatistics.Health == 0)
        {
            _gameoverScreen.Setup();
        }
    }
}
