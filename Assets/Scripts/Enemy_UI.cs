using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_UI : MonoBehaviour
{
    Enemy enemy;
    [SerializeField] Vector3 off_set;
    [SerializeField] Slider health;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        health.value = enemy.health / enemy.health_max;
        health.gameObject.SetActive(enemy.health < enemy.health_max);
        health.transform.position = Camera.main.WorldToScreenPoint(enemy.transform.position + off_set);
    }
}
