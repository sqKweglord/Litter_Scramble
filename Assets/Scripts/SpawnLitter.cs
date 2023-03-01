using UnityEngine;

public class SpawnLitter : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    levelTimer timer;

    //used for spawning a dynamic number of litter every 5 seconds
    private int spawnedCount = 0;
    private int spawnedMax = 5;


    // sets the timer variable
    void Start()
    {
        timer = GameObject.Find("TimerManager").GetComponent<levelTimer>();
    }

    void Update()
    {
        if ((timer.currentTime != 0) && (Mathf.Ceil(timer.currentTime) % 5 == 0))
        {
            if (spawnedCount < spawnedMax)
            {
                Spawn();
                spawnedCount++; 
            } 
        } else
        {
            if (spawnedCount != 0)
            {
                spawnedCount = 0;
                spawnedMax = Random.Range(2, 4);
            }
        }
    }

    //generates the spawn location and spawns the object there
    public void Spawn()
    {
        Vector3 location;
        do
        {
            location = GenLocation();
        } while (!EmptySpace(location));

        ObjectSpawn(ObjectToSpawn, location);

    }

    //spawns the provided object at a provided location
    private void ObjectSpawn(GameObject litter, Vector3 location)
    {
        Instantiate(litter, location, transform.rotation, transform);
    }

    //returns a vector of the spawn location
    private Vector3 GenLocation()
    {
        float xrange = 14.5f;
        float zrange = 14.5f;
        float y_val = 1f;

        return new Vector3(Random.Range(-xrange, xrange), y_val, Random.Range(-zrange, zrange));  
    }

    //checks if the generated position doesnt have a tree
    private bool EmptySpace(Vector3 location)
    {
        Collider[] collider = Physics.OverlapSphere(location, 1);

        if (collider.Length == 0)
        {
            return true;
        } else 
        {
            //return false;
            return !CheckArray(collider, "Environment");
        }
    }

    //checks if the provided array contains the provided tag
    private bool CheckArray(Collider[] colliders, string tag)
    {
        bool hasTag = false;
        for (int i = 0; i < colliders.Length; i++)
        {

            if(colliders[i].CompareTag(tag))
            {
                Debug.Log("collider has environment tag");
                hasTag = true;
                break;
            }
        }
        return hasTag;
    } 
}
