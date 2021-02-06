using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controler : MonoBehaviour
{
    public int wave;
    public bool is_enemy;
    public bool shop_enable;

    float free_time;
    float delta_time;
    [SerializeField] float free_time_remaining;

    [SerializeField] Spawner spawner_L;
    [SerializeField] Spawner spawner_R;

    void Start()
    {
        is_enemy = true;
        free_time = 10;
        free_time_remaining = 0;
    }

    void Update()
    {
        if(!is_enemy)
        {
            if (free_time_remaining <= 0)
            {
                spawner_L.spawn_limit += 2;
                spawner_L.spawn_left = spawner_L.spawn_limit;
                spawner_L.spawn_enemy = true;

                spawner_R.spawn_limit += 2;
                spawner_R.spawn_left = spawner_R.spawn_limit;
                spawner_R.spawn_enemy = true;

                free_time_remaining = free_time;
                is_enemy = true;
                wave++;
            }
            else
            {
                free_time_remaining -= Time.deltaTime;
            }
        }

        delta_time += (Time.deltaTime - delta_time) * 0.1f;
        float fps = 1.0f / delta_time;
        Debug.Log(fps);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(!spawner_L.spawn_enemy && spawner_L.spawn_left == 0 && !spawner_R.spawn_enemy && spawner_R.spawn_left == 0)
        {
            if(collision.tag == "Enemy")
            {
                is_enemy = true;
            }
            else
            {
                is_enemy = false;
            }
        }
    }
}
