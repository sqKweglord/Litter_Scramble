using UnityEngine;

public class AnimalMovement : MonoBehaviour
{   
    public int walkDir = 0;
    // RANDOM DIRECTIONAL MOVEMENT
    // invoke box collider object to contain sprite movement to map
    public Collider Walkarea;
    // define box collider value
    private Vector3 minWalkPoint, maxWalkPoint;
    //define sprite movement values and states
    private int excludeLitter = 0, walkDirection;
    public float moveSpeed, walkTime, waitTime;
    public bool isWalking;
    private float walkCounter, waitCounter, lastDirection;
    public int speedMod;
    private Rigidbody MyRigidbody;
    //defines Object spawnpoint
    public float startX, startY, startZ;
    //WAYPOING BASED MOVEMENT
    public GameObject[] waypoints;
    public GameObject player;
    public bool isWaypoint;
    public int current = 0;
    float WPradius = 1;
    private Vector3 newPosition, startPosition, vector1, vector2, vector3, vector4;


    // Start is called before the first frame update
    void Start()
    {
        //sets initial values and calles
        //Spawnpoint = transform.postion; 
        walkDirection= 0;//initialize to face screen
        MyRigidbody = GetComponent<Rigidbody>();
        waitCounter = waitTime;
        walkCounter = walkTime;

        startPosition = new Vector3(startX, startY, startZ);

        minWalkPoint = Walkarea.bounds.min;
        maxWalkPoint = Walkarea.bounds.max;

        vector1 = new Vector3(0, startY, moveSpeed + speedMod);
        vector2 = new Vector3(moveSpeed + speedMod, startY, 0);
        vector3 = new Vector3(0, startY, -moveSpeed - speedMod);
        vector4 = new Vector3(-moveSpeed - speedMod, startY, 0);

        SpawnLitter litter = GameObject.Find("LitterParent").GetComponent<SpawnLitter>();
         waypoints = litter.litterArr; 
        ChooseDirection(); // intial call to direction function
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(current);
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;
            switch (walkDirection)//direction check and edge handle, case 5 and 4 repeat to widen range for waypoing selection
            {

                case 0:
                    MyRigidbody.velocity = vector1;
                    if (transform.position.z > maxWalkPoint.z)
                    {
                        transform.position = startPosition;
                    }
                    break;
                case 1:
                    MyRigidbody.velocity = vector2;
                    if (transform.position.x > maxWalkPoint.x)
                    {
                        transform.position = startPosition;
                    }
                    break;
                case 2:
                    MyRigidbody.velocity = vector3;
                    if (transform.position.z < minWalkPoint.z)
                    {
                        transform.position = startPosition;
                    }
                    break;
                case 3:
                    MyRigidbody.velocity = vector4;
                    if (transform.position.x < minWalkPoint.x)
                    {
                        transform.position = startPosition;
                    }
                    break;
                default:
                    if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
                    {
                        current = Random.Range(0, waypoints.Length);
                        if (current >= waypoints.Length)
                        {
                            current = 0;
                        }
                    }
                    newPosition.x = waypoints[current].transform.position.x;
                    newPosition.y = waypoints[current].transform.position.y;
                    newPosition.z = waypoints[current].transform.position.z;
                    transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * moveSpeed);
                    break;
            }

            if (walkCounter < 0)//begins walk sequence again
            {
                isWalking = false;
                waitCounter = waitTime;
            }


        }
        else //stops movement and chooses new direction
        {
            waitCounter -= Time.deltaTime;

            MyRigidbody.velocity = Vector3.zero;

            if (waitCounter < 0) {
                ChooseDirection();
            }
        }

    }
    
    public void ChooseDirection() 
    {
        excludeLitter++;
        lastDirection = walkDirection;
        walkDirection = Random.Range(0, 5);//randomizes walk direction
        speedMod = Random.Range(0, 2); //randomizes walk distance
        isWalking = true;
        walkCounter = walkTime;
        if (walkDirection == lastDirection) { 
            if(walkDirection == 3)
            {
                walkDirection = 0;
            }
            else 
            { 
                walkDirection++;
            }
        }
        walkDir = walkDirection;
        if (excludeLitter < 2)
        {   
            if(walkDirection == 4 || walkDirection == 5)
            {
                walkDirection = 3;
            }

        }

    }
}
