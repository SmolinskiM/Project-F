using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_UI : MonoBehaviour
{
    Player player;

    [SerializeField] Slider health;
    [SerializeField] Text coin;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        health.value = player.health / player.health_max;
        coin.text = "X " + player.coin;
    }
}
