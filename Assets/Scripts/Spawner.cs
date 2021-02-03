using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int spawn_left = 5;
    public bool spawn_enemy = true;
    private float spawner_cooldown__remaining;
    [SerializeField] private Transform spawner;
    [SerializeField] private float spawner_cooldown = 1;
    [SerializeField] private Enemy enemy;

    void Start()
    {
        
    }
    
    void Update()
    {
        if(spawner_cooldown__remaining > 0)
        {
            spawner_cooldown__remaining -= Time.deltaTime;
        }
        else
        {
            if(spawn_left > 0)
            {
                Instantiate(enemy, spawner);
                spawn_left--;
                spawner_cooldown__remaining = spawner_cooldown;
            }
            else
            {
                spawn_enemy = false;
            }
        }
    }
}
