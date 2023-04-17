using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indexEnemy : MonoBehaviour
{
    public int numberEnemy;
    void Awake()
    {
        numberEnemy = int.Parse(gameObject.tag.Substring(gameObject.tag.Length - 1));   // 1 because the list starts at 0 and not at 1
    }


}
