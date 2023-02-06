//this script allows any object that adds it as a component to stay facing the camera
//the values will need to be flipped for the Holofil since it will go in reverse

using UnityEngine.InputSystem; //this is to import the new InputSystem, will need to be used for gamepad integration
using UnityEngine;

public class cameraRotate : MonoBehaviour
{
   //updates with every frame
    void Update()
    {    
        //if (Input.GetKeyDown(KeyCode.E)) this line will only read a single key press 
        if (Input.GetKey(KeyCode.E)) //this line will send input while the key is held
        {
            transform.Rotate(Vector3.up, 25 * Time.deltaTime); //this line allows for a smooth rotation
            //transform.Rotate(Vector3.up, 90); //if this line was used it would snap 90 degrees
        }

        //else if (Input.GetKeyDown(KeyCode.Q))
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -25 * Time.deltaTime);
            //transform.Rotate(Vector3.up, -90);
        }
    }

}
