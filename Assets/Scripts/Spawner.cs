using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool spawn_enemy = true;
    public int spawn_limit;
    public int spawn_left;

    public Enemy enemy;
    public Transform enemy_Fly;

    private float spawner_cooldown__remaining;
    private Game_Controler game_controler;
    [SerializeField] private Transform spawner;
    [SerializeField] private float spawner_cooldown = 1;

    void Start()
    {
        game_controler = GameObject.Find("Game_Controler").GetComponent<Game_Controler>();
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
                if(game_controler.wave >= 2 && spawn_left % 2 == 0)
                {
                    Instantiate(enemy_Fly, spawner);
                }
            }
            else
            {
                spawn_enemy = false;
            }
        }
    }
}
