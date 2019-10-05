using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : UnitySingleton<GameController>
{
    [SerializeField] Transform player;

    private void Update()
    {
        if(!GameObject.FindGameObjectWithTag("Player"))
        {
            Instantiate(player, GameObject.FindGameObjectWithTag("Respawn").transform.position, new Quaternion());
        }
    }
}
