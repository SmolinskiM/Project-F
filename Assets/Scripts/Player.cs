using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool immortality;

    public int coin;
    public int resist;
    public float health;
    public float speed = 10;
    public float jump_height = 10;
    public float health_max;
    public float attack_range;
    public float attack_damage;
    public float attack_cooldown;

    [SerializeField] private float immortality_time;
    [SerializeField] private float immortality_time_reamining;
    [SerializeField] private bool is_ground;
    private Rigidbody2D rb;
    float move_x;
    private float attack_cooldown_remaining;
    [SerializeField] LayerMask enemy_layer;
    [SerializeField] Transform attack_point;
    
    void Start()
    {
        health = health_max;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move_x = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(move_x * speed, rb.velocity.y);


        if (Input.GetKey("a"))
        {
            GetComponent<SpriteRenderer>().flipX = true;

            if (transform.position.x - attack_point.transform.position.x < 0)
            {
                attack_point.transform.Translate(-2.34f, 0, 0);
            }
        }
        if (Input.GetKey("d"))
        {
            GetComponent<SpriteRenderer>().flipX = false;

            if (transform.position.x - attack_point.transform.position.x > 0)
            {
                attack_point.transform.Translate(2.34f, 0, 0);
            }
        }
        if (Input.GetKeyDown("w") && is_ground)
        {
            rb.velocity = new Vector2(0, jump_height);
            is_ground = false;
        }

        if (Input.GetKey(KeyCode.Space) && attack_cooldown_remaining <= 0)
        {
            Attack();
            attack_cooldown_remaining = attack_cooldown;
        }

        if (attack_cooldown_remaining > 0)
        {
            attack_cooldown_remaining -= Time.deltaTime;
        }

        if(immortality_time_reamining > 0)
        {
            immortality_time_reamining -= Time.deltaTime;
        }
        else
        {
            immortality = false;
        }
    }

    void Attack()
    {
        Collider2D[] hit_enemy = Physics2D.OverlapCircleAll(attack_point.position, attack_range, enemy_layer);

        foreach(Collider2D enemy in hit_enemy)
        {
            enemy.GetComponent<Enemy>().Take_damage(attack_damage);
        }
    }

    public void Being_attacked(float damage)
    {
        if(!immortality)
        {
            immortality_time_reamining = immortality_time;
            health -= damage;
            immortality = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Ground")
        {
            is_ground = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attack_point == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attack_point.position, attack_range);
    }
}