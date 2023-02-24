using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
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
    public int speedMod;
    private Rigidbody MyRigidbody;
    //defines Object spawnpoint
    public float startX;
    public float startZ;


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

        ChooseDirection(); // intial call to direction function
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;
            //
            switch (walkDirection)//direction check and edge handle
            {
                case 0:
                    MyRigidbody.velocity = new Vector3(0, 0, moveSpeed + speedMod);
                    if (transform.position.z > maxWalkPoint.z)
                    {
                        transform.position = new Vector3(startX, transform.position.y, startZ);
                    }
                    break;
                case 1:
                    MyRigidbody.velocity = new Vector3(moveSpeed + speedMod, 0, 0);
                    if (transform.position.x > maxWalkPoint.x)
                    {
                        transform.position = new Vector3(startX, transform.position.y, startZ);
                    }
                    break;
                case 2:
                    MyRigidbody.velocity = new Vector3(0, 0, -moveSpeed - speedMod);
                    if (transform.position.z < minWalkPoint.z)
                    {
                        transform.position = new Vector3(startX, transform.position.y, startZ);
                    }
                    break;
                case 3:
                    MyRigidbody.velocity = new Vector3(-moveSpeed - speedMod, 0, 0);
                    if (transform.position.x < minWalkPoint.x)
                    {
                        transform.position = new Vector3(startX, transform.position.y, startZ);
                    }
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
        walkDirection = Random.Range(0, 3);//randomizes walk direction
        speedMod = Random.Range(0, 2); //randomizes walk distance
        isWalking = true;
        walkCounter = walkTime;
    }
}
