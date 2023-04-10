using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    public UnitHealth _playerHealth = new UnitHealth(100, 100);
    public gameOverScreen _gameoverScreen;

    void Awake ()
    {
        if (gameManager != null && gameManager != this)
            Destroy(this);
        else
            gameManager = this;
    }

    private void Update()
    {
        if (_playerHealth.Health == 0)
        {
            _gameoverScreen.Setup();
        }
    }
}
