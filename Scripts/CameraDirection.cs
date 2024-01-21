using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDirection : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float distance = 15f, height = 15f;

    Vector3 cameraPosition;

    void FindPlayer()
    {
        cameraPosition = new Vector3(player.position.x, player.position.y + height, player.position.z - distance);
        transform.position = cameraPosition;
        Vector3 directionToPlayer = player.position - transform.position;
        transform.rotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);
    }

    void Update()
    {
        FindPlayer();
    }
}
