using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building_UI : MonoBehaviour
{
    Building building;

    [SerializeField] Vector3 off_set;
    [SerializeField] Image imagine;
    private Game_Controler game_controler;

    void Start()
    {
        building = GetComponent<Building>();
        game_controler = GameObject.Find("Game_Controler").GetComponent<Game_Controler>();
    }

    void Update()
    {
        if(game_controler.is_enemy)
        {
            imagine.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player" && !game_controler.is_enemy)
        {
            imagine.gameObject.SetActive(true);
            imagine.transform.position = Camera.main.WorldToScreenPoint(this.gameObject.transform.position + off_set);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" || game_controler.is_enemy)
        {
            imagine.gameObject.SetActive(false);
            imagine.transform.position = Camera.main.WorldToScreenPoint(this.gameObject.transform.position + off_set);
        }
    }
}
