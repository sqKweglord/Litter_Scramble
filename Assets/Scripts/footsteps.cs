using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    public AudioSource footstep1;
    

    //Enables the footstep sound
    //Needs to be reconfigured for controller
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            footstep1.enabled = true;
        }
        else
        {
            footstep1.enabled = false;
        }
    }
}
