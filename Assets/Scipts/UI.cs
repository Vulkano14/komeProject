using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] Text _playerHealthText;
    [SerializeField] GameObject _particleEfectHP;

    [SerializeField] Text _waveTextChange;
    [SerializeField] GameObject _effectParticleText;
    GameObject _effectInstanitiePrefab;
    Animator _animator;
    spawner _waveNumber;

    int _health;
    int _currentHealth;
    int x = 1;

    void Start()
    {
        _currentHealth = GameManager.gameManager._playerStatistics.Health;
        _animator = GameObject.Find("Wave").GetComponent<Animator>();
        _waveNumber = GameObject.Find("Spawner").GetComponent<spawner>();
    }

    void Update()
    {
        _health = GameManager.gameManager._playerStatistics.Health;

        if (_currentHealth != _health)
        {
            _playerHealthText.text = GameManager.gameManager._playerStatistics.Health.ToString();
            GameObject particelEfectHP = Instantiate(_particleEfectHP, _playerHealthText.transform.position, Quaternion.identity);
            Destroy(particelEfectHP, 2f);
            _currentHealth = _health;
        }

        CheckWaveChange();
    }

    void CheckWaveChange()
    {
        if (_waveNumber.wave >= x)
        {
            x++;
            StartCoroutine(ChangeText());
        }
    }

    IEnumerator ChangeText()
    {
        _waveTextChange.text = "Wave: " + _waveNumber.wave;
        _animator.SetBool("textChange", true);
        yield return new WaitForSeconds(0.5f);
        _effectInstanitiePrefab = Instantiate(_effectParticleText, _waveTextChange.transform.position, Quaternion.identity);
        _animator.SetBool("textChange", false);
        yield return new WaitForSeconds(4);
        Destroy(_effectInstanitiePrefab);
    }
}
