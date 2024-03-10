using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    Mover player;

    [SerializeField]
    Transform[] platforms;

    [SerializeField]
    Transform currentPlatform;

    float generatePlatformBuffer = 5f;

    int i = 0;




    // Start is called before the first frame update
    void Start()
    {
        player.PlayerStart();

    }

    void GeneratePlatform(ref int i)
    {
        if (player.playerHitGeneratePlatform)
        {
            Transform p = Instantiate(platforms[i]);
            Transform furtherstPlatform = currentPlatform.GetChild(0);
            for(int x = 0; x < currentPlatform.childCount; x ++)
            {
                if(currentPlatform.GetChild(x).tag == "Platform")
                {
                    if(currentPlatform.GetChild(x).transform.position.z > furtherstPlatform.position.z)
                    {
                        furtherstPlatform = currentPlatform.GetChild(x);
                    }
                }
            }
            Vector3 distanceVector = new Vector3(0f, 0f, furtherstPlatform.position.z + furtherstPlatform.localScale.z/2 + generatePlatformBuffer);
            p.position += distanceVector;
            player.playerHitGeneratePlatform = false;
            currentPlatform = p;
            i++;

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
        GeneratePlatform(ref i);
        if (i > 1)
        {
            i = 0;
        }

    }
    private void FixedUpdate()
    {
        player.Move();
    }
}
