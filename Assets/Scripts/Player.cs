using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int coin;
    public int resist;

    public float health;
    public float speed = 10;
    public float jump_height = 10;
    public float health_max;
    public float attack_range;
    public float attack_damage;
    public float time_btw_attack;

    private Rigidbody2D rb;
    private LayerMask enemy_layer;
    private Transform attack_point;
    private float start_time_btw_attack;

    void Start()
    {
        health = health_max;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move_x = Input.GetAxisRaw("Horizontal");    

        rb.velocity = new Vector2(move_x * speed, rb.velocity.y);
        

        if (Input.GetKey("a"))
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if(Input.GetKey("d"))
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetKeyDown("w"))
        {
            rb.velocity = new Vector2(0, jump_height);
        }
    }
}
