using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Controler_UI : MonoBehaviour
{
    [SerializeField] Game_Controler game_controler;

    [SerializeField] Text wave;
    void Start()
    {
        game_controler = GetComponent<Game_Controler>();
    }

    void Update()
    {
        wave.text = "Wave: " + game_controler.wave;
    }
}
