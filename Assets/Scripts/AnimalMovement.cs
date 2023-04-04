using UnityEngine;

public class AnimalMovement : MonoBehaviour
{   
    public int walkDir = 0;
    // RANDOM DIRECTIONAL MOVEMENT
    // invoke box collider object to contain sprite movement to map
    public Collider Walkarea;
    private bool atEdge;
    // define box collider value
    private Vector3 minWalkPoint;
    private Vector3 maxWalkPoint;
    //define sprite movement values and states
    public float moveSpeed;
    public bool isWalking;
    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;
    private int walkDirection;
    private float lastDirection;
    public int speedMod;
    private Rigidbody MyRigidbody;
    //defines Object spawnpoint
    public float startX;
    public float startY;
    public float startZ;
    //WAYPOING BASED MOVEMENT
    public GameObject[] waypoints;
    public GameObject player;
    public bool isWaypoint;
    int current = 0;
    float WPradius = 1;


    // Start is called before the first frame update
    void Start()
    {
        //sets initial values and calles
        //Spawnpoint = transform.postion; 
        walkDirection= 0;//initialize to face screen
        MyRigidbody = GetComponent<Rigidbody>();
        waitCounter = waitTime;
        walkCounter = walkTime;

        minWalkPoint = Walkarea.bounds.min;
        maxWalkPoint = Walkarea.bounds.max;

        SpawnLitter litter = GameObject.Find("LitterParent").GetComponent<SpawnLitter>();
         waypoints = litter.litterArr; 
        ChooseDirection(); // intial call to direction function
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;
            switch (walkDirection)//direction check and edge handle, case 5 and 4 repeat to widen range for waypoing selection
            {

                case 0:
                    MyRigidbody.velocity = new Vector3(0, startY, moveSpeed + speedMod);
                    if (transform.position.z > maxWalkPoint.z)
                    {
                        transform.position = new Vector3(startX, startY, startZ);
                    }
                    break;
                case 1:
                    MyRigidbody.velocity = new Vector3(moveSpeed + speedMod, startY, 0);
                    if (transform.position.x > maxWalkPoint.x)
                    {
                        transform.position = new Vector3(startX, startY, startZ);
                    }
                    break;
                case 2:
                    MyRigidbody.velocity = new Vector3(0, startY, -moveSpeed - speedMod);
                    if (transform.position.z < minWalkPoint.z)
                    {
                        transform.position = new Vector3(startX, startY, startZ);
                    }
                    break;
                case 3:
                    MyRigidbody.velocity = new Vector3(-moveSpeed - speedMod, startY, 0);
                    if (transform.position.x < minWalkPoint.x)
                    {
                        transform.position = new Vector3(startX, startY, startZ);
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
                    Vector3 newPosition = new Vector3(waypoints[current].transform.position.x, transform.position.y, waypoints[current].transform.position.z);
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
        //RNG generation
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
        
        
    }
}
