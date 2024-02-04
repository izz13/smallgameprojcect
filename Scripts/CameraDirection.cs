using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDirection : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float distance = 15f, height = 15f;

    void FindPlayer()
    {
        Vector3 cameraPosition = new Vector3(player.position.x, player.position.y + height, player.position.z - distance);
        transform.position = cameraPosition;
        Vector3 cameraDirection = player.position - transform.position;
        transform.rotation = Quaternion.LookRotation(cameraDirection, Vector3.up);
    }

    private void Update()
    {
        FindPlayer();
    }
}
