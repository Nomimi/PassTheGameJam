using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Holder : MonoBehaviour
{
    public GameObject[]  enemyArray;
    int totalEnemy = 0;

    private void Awake()
    {
        totalEnemy = transform.childCount;

        enemyArray = new GameObject[totalEnemy];

        for (int i = 0; i < totalEnemy; i++)
        {
            enemyArray[i] = transform.GetChild(i).gameObject;
        }
    }

}