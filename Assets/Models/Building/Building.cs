using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Transform building_this;

    public GameObject building_next;

    public int lvl;

    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        Debug.Log("sdf");
        if (collider.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("u") && player.coin >= 10 * lvl)
            {
                Instantiate(building_next, building_this.position, building_this.rotation);
                player.coin -= 10 * lvl;
                Destroy(this.gameObject);
            }
        }
    }
}
