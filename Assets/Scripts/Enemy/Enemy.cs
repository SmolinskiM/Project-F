using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int wave;

    public float health;
    public float health_max = 10;
    
    Player player;
    Transform target;
    [SerializeField] int damage;
    [SerializeField] float speed; 
    [SerializeField] Transform coin;
    [SerializeField] Transform enemy_pref;
    [SerializeField] SpriteRenderer enemy;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemy = GetComponent<SpriteRenderer>();
        health_max = 10 + 5 * (wave - 1);
        health = health_max;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (target.position.x - transform.position.x < 0)
        {
            enemy.flipX = true;
        }
        else
        {
            enemy.flipX = false;
        }

        if(health <= 0)
        {
            Instantiate(coin, enemy_pref.position, enemy_pref.rotation);
            Destroy(gameObject);
        }
    }

    public void Take_damage(float attack_damage)
    {
        if (gameObject.name == "Enemy_Fly(Clone)")
        {
            health = 1;
        }
        health -= attack_damage;
    }

    void OnCollisionStay2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            player.Being_attacked(damage);
        }
    }
}
