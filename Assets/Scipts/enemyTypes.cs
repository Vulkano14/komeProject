using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTypes
{
    public int Health { get; set; }
    public int Damage { get; set; }
    public int ShootDamage { get; set; }
    public int SpawnRate { get; set; }



    public enemyTypes(int _health, int _damage, int _shootDamage, int _spawnRate)
    {
        Health = _health;
        Damage = _damage;
        ShootDamage = _shootDamage;
        SpawnRate = _spawnRate;
    }
}

