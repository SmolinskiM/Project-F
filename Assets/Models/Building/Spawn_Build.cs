using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Build : MonoBehaviour
{
    public GameObject build;

    public Transform spawner;

    void Start()
    {
        Instantiate(build, spawner.position, spawner.rotation);
    }
}
