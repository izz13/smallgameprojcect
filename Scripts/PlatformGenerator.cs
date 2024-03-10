using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public bool destroy = false;


    private void Update()
    {
        if (destroy)
        {
            Destroy(this.gameObject);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log(other);
    //    player = other.gameObject.GetComponent<Mover>();
    //    if (player != null)
    //    {
    //        //Debug.Log("Hit Player");
    //        player.playerHitGeneratePlatform = true;
    //        Destroy(this.gameObject);

    //    }

    //}
}
