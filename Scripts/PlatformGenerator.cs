using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public bool destroy = false;//boolean to see if the platformGenerator gameObject should be destroyed


    private void Update()
    {
        if (destroy)//checking if destroy is True every Frame
        {
            Destroy(this.gameObject);//This will destroy the gameObject that this script is attached to
        }
    }

}
