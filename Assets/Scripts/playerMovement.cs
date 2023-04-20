//This script controls the player's movement

using UnityEngine.InputSystem;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //the box collider that defines the map edge
    public Collider Walkarea;

    // define box collider value
    private Vector3 minWalkPoint;
    private Vector3 maxWalkPoint;

    public float xval;
    public float yval;


    //used for smooth movement
    public float MoveSmoothTime;

    //how fast the player should move
    public float MoveSpeed;

    //character controller
    private CharacterController Controller;

    //used for the physics engine to slow down the player
    private Vector3 CurrentMoveVelocity;
    private Vector3 MoveDampVelocity;

    //input from input system
    private Vector2 moveVal;
    private Vector3 PlayerInput;

    void OnMove(InputValue value)
    {
        moveVal = value.Get<Vector2>();
    }
    //logic to get inputs that rotate the character
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

    //defines character controller object to use
    void Start()
    {
        Controller = GetComponent<CharacterController>();
        minWalkPoint = Walkarea.bounds.min;
        maxWalkPoint = Walkarea.bounds.max;
    }

    // Update is called once per frame
    void Update()
    {
        if (rtRight)
        {
            transform.Rotate(Vector3.up, 50 * Time.deltaTime);
        }
        if (rtLeft)
        {
            transform.Rotate(Vector3.up, -50 * Time.deltaTime);
        }

        //gets player input and converts to movement
        PlayerInput.x = -moveVal.x; //flipped for holofil
        PlayerInput.y = 0f;
        PlayerInput.z = moveVal.y;

        xval = PlayerInput.x;
        yval = PlayerInput.z;
        

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
        if (transform.position.x > maxWalkPoint.x)
        {
            transform.position.x = maxWalkPoint.x;
        } else if (transform.position.x < minWalkPoint.x)
        {
            transform.position.x = minWalkPoint.x;
        }

        if (transform.position.z > maxWalkPoint.z)
        {
            transform.position.z = maxWalkPoint.z;
        }
        else if (transform.position.z < minWalkPoint.z)
        {
            ransform.position.z = minWalkPoint.z;
        }

        if ((rtLeft) || (rtRight) || (moveVal.y != 0 || moveVal.x != 0))
        {
            GameVariables.anyInput = true;
        }
        else
        {
            GameVariables.anyInput = false;
        }


    }
}