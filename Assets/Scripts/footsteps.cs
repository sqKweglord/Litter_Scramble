using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    public AudioSource footstep1;
    Vector3 lastPos;  
    public GameObject player;  

    //Enables the footstep sound
    void Update()
    {
        //Detects player movement
        if(player.transform.position != lastPos)
        {
            footstep1.enabled = true;
        }
        
        else
        {
            footstep1.enabled = false;
        }
        //Resets player's last known location
        lastPos = player.transform.position;
    }
}
