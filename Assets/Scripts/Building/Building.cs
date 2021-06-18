using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] Transform building_this;

    [SerializeField] GameObject building_next;

    public int lvl;

    private bool buy = false;

    private Player player;

    Game_Controler game_controler;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        game_controler = GameObject.Find("Game_Controler").GetComponent<Game_Controler>();
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (Input.GetKey("u") && player.coin >= 10 * lvl && !buy)
            {
                Instantiate(building_next, building_this.position, building_this.rotation);
                buy = true;
                player.coin -= 10 * lvl;
                game_controler.score += 20 * lvl;
                Destroy(this.gameObject);
            }
        }
    }
}
