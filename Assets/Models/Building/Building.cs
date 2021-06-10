using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Transform building_this;

    public GameObject building_next;

    public int lvl;

    private bool buy = false;

    private Player player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
                Destroy(this.gameObject);
            }
        }
    }
}
