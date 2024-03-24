using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    Mover player;

    [SerializeField]
    List<Transform> platforms;//a list to hold the platform prefabs(Juhyun Platforms and Daeun Platforms)
    //Do you know the difference between a list and an array?

    [SerializeField]
    Transform currentPlatform;//this the current platform that the player is on

    float generatePlatformBuffer = 5f;//set a distance between the last platform in the currentPlatform transform and the first platform in the new generated platform

    int i = 0;//iterator value for each platform in platform list

    //for i in range(5):
    //for(int i = 0; i < 5; i++)



    // Start is called before the first frame update
    void Start()
    {
        player.PlayerStart();

    }

    void GeneratePlatform(ref int i)
    {
        if (player.playerHitGeneratePlatform)//if player hit the generate platform trigger with it's ray is True
        {
            Transform platform = platforms[i];
            Debug.Log(platform.gameObject);
            Transform p = Instantiate(platform);//create the platform in the game using the platfroms[i] platorm
            Transform furtherstPlatform = currentPlatform.GetChild(0);//checking to see what is the last platform in the currentPlatform prefab
            for(int x = 0; x < currentPlatform.childCount; x ++)//going through each platform in currentplatform
            {
                if(currentPlatform.GetChild(x).tag == "Platform")
                {
                    if(currentPlatform.GetChild(x).transform.position.z > furtherstPlatform.position.z)//checking if the platforms[x] platform is further away than furthurstPlatform
                    {
                        furtherstPlatform = currentPlatform.GetChild(x);//make platforms[x] platform to be the new furthestPlatform
                    }
                }
            }
            Vector3 distanceVector = new Vector3(0f, 0f, furtherstPlatform.position.z + furtherstPlatform.localScale.z / 2 + generatePlatformBuffer);//creating a vector3 distance on where I want the new platform to be placed
            p.position += distanceVector;//position of the new platform to be itself plus the distanceVector
            player.playerHitGeneratePlatform = false;//generate platform to be false
            currentPlatform = p;//set the new platform to be the current platform
            i++;//increase the platform iterator

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
        if (i > platforms.Count - 1)//if the iterator is over the length of the list set it back to zero
        {
            i = 0;
        }
        GeneratePlatform(ref i);

    }
    private void FixedUpdate()
    {
        player.Move();
    }
}
