using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    Mover player;

    [SerializeField]
    Transform juhyunPlatform;

    [SerializeField]
    Transform currentPlatform;

    float generatePlatformBuffer = 5f;




    // Start is called before the first frame update
    void Start()
    {
        player.PlayerStart();

    }

    void GeneratePlatform()
    {
        if (player.playerHitGeneratePlatform)
        {
            Transform p = Instantiate(juhyunPlatform);
            Vector3 distanceVector = new Vector3(0f, 0f, player.distanceFromEdge + player.transform.position.z + generatePlatformBuffer);
            p.position += distanceVector;
            player.playerHitGeneratePlatform = false;

        }

    }


    // Update is called once per frame
    void Update()
    {
        player.PlayerUpdate();
        if (player.playerReset)
        {
            player.PlayerStart();
            player.playerReset = false;
        }
        GeneratePlatform();
    }
    private void FixedUpdate()
    {
        player.Move();
    }
}
