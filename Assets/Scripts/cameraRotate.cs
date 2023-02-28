//this script allows any object that adds it as a component to stay facing the camera

using UnityEngine.InputSystem; //this is to import the new InputSystem, will need to be used for gamepad integration
using UnityEngine;

public class cameraRotate : MonoBehaviour
{
    bool rtLeft;
    bool rtRight;
    void OnCameraRotateLeft(InputValue value)
    {
        rtLeft = value.isPressed;
    }

    void OnCameraRotateRight(InputValue value)
    {
        rtRight = value.isPressed;
    }

   //updates with every frame
    void Update()
    {    
        //values flipped for holofil
        if (rtRight)
        {
            transform.Rotate(Vector3.up, 50 * Time.deltaTime);
        }
        if (rtLeft)
        {
            transform.Rotate(Vector3.up, -50 * Time.deltaTime);
        }
    }
}
