//This script controls the player's movement

//using UnityEngine.InputSystem
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //these values are to restrict the player inside the set x and z coordinates
    public float xRange;
    public float zRange;

    //used for smooth movement
    public float MoveSmoothTime;

    //how fast the player should move
    public float MoveSpeed;

    //character controller
    private CharacterController Controller;

    //used for the physics engine to slow down the player
    private Vector3 CurrentMoveVelocity;
    private Vector3 MoveDampVelocity;


    //defines character controller object to use
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
    
        //gets player input and converts to movement
        Vector3 PlayerInput = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical")
        };
        

        if (PlayerInput.magnitude > 1f)
        {
            PlayerInput.Normalize();
        }

        //transforms the players input so that it stays relative to the camera
        Vector3 MoveVector = transform.TransformDirection(PlayerInput);

        //defines the vector the player will move in
        CurrentMoveVelocity = Vector3.SmoothDamp(
            CurrentMoveVelocity,
            MoveVector * MoveSpeed,
            ref MoveDampVelocity,
            MoveSmoothTime
        );

        //moves the player
        Controller.Move(CurrentMoveVelocity * Time.deltaTime);



        //keeps player within allowed game space
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        } else if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        else if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

    }
}
