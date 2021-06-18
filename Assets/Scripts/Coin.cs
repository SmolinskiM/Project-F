using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Game_Controler game_controler;

    void Start()
    {
        game_controler = GameObject.Find("Game_Controler").GetComponent<Game_Controler>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            collider.GetComponent<Player>().coin += 1;
            game_controler.score += 10;
            Destroy(gameObject);
        }
    }
}
