using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool spawn_enemy = true;
    public int spawn_limit;
    public int spawn_left;

    public Enemy enemy;

    private float spawner_cooldown__remaining;
    [SerializeField] private Transform spawner;
    [SerializeField] private float spawner_cooldown = 1;

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
