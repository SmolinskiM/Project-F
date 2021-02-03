using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float health;
    [SerializeField] int damage;
    [SerializeField] Transform target;
    [SerializeField] Player player;
    [SerializeField] SpriteRenderer enemy;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemy = GetComponent<SpriteRenderer>();
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
            Destroy(gameObject);
        }
    }

    public void Take_damage(float attack_damage)
    {
        health -= attack_damage;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            player.health -= damage;
        }
    }
}
