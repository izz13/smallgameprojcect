using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    Mover player;
    // Start is called before the first frame update
    void Start()
    {
        player.PlayerStart();
    }

    // Update is called once per frame
    void Update()
    {
        player.PlayerUpdate();
        if (player.Reset())
        {
            player.PlayerStart();
        }
    }
    private void FixedUpdate()
    {
        player.Move();
    }
}
