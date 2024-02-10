using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDirection : MonoBehaviour
{
    [SerializeField] // allows the variable to get the value from Unity
    Transform player; // get the Transform value of the player

    [SerializeField]
    float distance = 15f, height = 15f; // create new float variables distance and height, and those have defalut value of 15f.

    void FindPlayer() // method that adjust the camera position
    {
        Vector3 cameraPosition = new Vector3(player.position.x, player.position.y + height, player.position.z - distance); // declare vector 3 variable for the camera position, which stores value that is calculated based on the player position. 
        transform.position = cameraPosition; // set the position of the camera to the cameraPosition value
        Vector3 cameraDirection = player.position - transform.position; // declare vector3 variable which stores direction of the camera
        transform.rotation = Quaternion.LookRotation(cameraDirection, Vector3.up); //rotate the camera according to the value in the camera direction. Quaternion.LookRotation: returns a rotation that is alligned towards the camera direction.
    }

    private void Update() // method that update the cameradirection every frame
    {
        FindPlayer(); // call findplayer method
    }
}
