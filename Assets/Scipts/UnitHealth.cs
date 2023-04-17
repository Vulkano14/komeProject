using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth
{
    int _currentHealth;
    int _currentMaxHealth;
    int _damagePlayer;

    public int Health
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
        }
    }

    public int MaxHealth
    {
        get
        {
            return _currentMaxHealth;
        }
        set
        {
            _currentMaxHealth = value;
        }
    }

    public int DamagePlayer
    {
        get
        {
            return _damagePlayer;
        }

        set
        {
            _damagePlayer = value;
        }
    }

    public UnitHealth(int health, int maxHealth, int damage)
    {
        _currentHealth = health;
        _currentMaxHealth = maxHealth;
        _damagePlayer = damage;
        
    }

    public void DmgUnit(int dmgAmount)
    {
        if (_currentHealth > 0)
            _currentHealth -= dmgAmount;
    }
}
