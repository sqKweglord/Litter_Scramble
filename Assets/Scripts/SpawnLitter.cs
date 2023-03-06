using System.Collections;
using UnityEngine;

public class SpawnLitter : MonoBehaviour
{
    public GameObject ObjectToSpawn;

    public int NumofSpawns;
    public GameObject[] litterArr;

    private levelTimer timer;

    private Sprite[] spriteArray;

    private SpriteRenderer render;

    // sets the timer variable, litter sprites, and initial litter spawns
    void Start()
    {
        //sets the array of sprites for the level
        spriteArray = Resources.LoadAll<Sprite>("recycle_items");

        //gets the sprite renderer of the prefab
        render = ObjectToSpawn.GetComponent<SpriteRenderer>();

        //gets the timer
        timer = GameObject.Find("TimerManager").GetComponent<levelTimer>();

        //initialize litterArr size
        litterArr = new GameObject[NumofSpawns];

        //sets initial litter
        for (int i = 0; i < NumofSpawns; i++)
        {
            litterArr[i] = Spawn();
        }

    }

    void Update()
    {
        if (timer.currentTime != 0)
        {
            if (checkNull(litterArr))
            {
                bubbleSort(litterArr);
                for (int i = 0; i < litterArr.Length; i++)
                {
                    if (litterArr[i] == null)
                    {
                        litterArr[i] = Spawn();
                    }
                }
            }
        }
    }

    //generates the spawn location and spawns the object there
    public GameObject Spawn()
    {
        Vector3 location;
        do
        {
            location = GenLocation();
        } while (!EmptySpace(location));

        return ObjectSpawn(ObjectToSpawn, location);

    }

    //spawns the provided object at a provided location
    private GameObject ObjectSpawn(GameObject litter, Vector3 location)
    {
        //chnages the sprite to a random sprite
        render.sprite = spriteArray[Random.Range(0, spriteArray.Length)];
        //instantiates the litter
        return Instantiate(litter, location, transform.rotation, transform);
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
            return !CheckForTag(collider, "Environment");
        }
    }

    //checks if the provided array contains the provided tag
    private bool CheckForTag(Collider[] colliders, string tag)
    {
        bool hasTag = false;
        for (int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].CompareTag(tag))
            {
                hasTag = true;
                break;
            }
        }
        return hasTag;
    } 

    //methods for array

    //checks if array contains null
    private bool checkNull(GameObject[] arr)
    {
        bool hasNull = false;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == null)
                {
                    hasNull = true;
                    break;
                }
        }
        return hasNull;
    }

    static void bubbleSort(GameObject[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n - i - 1; j++)
                if (arr[j] == null)
                {
                    // swap temp and arr[i]
                    GameObject temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
    }
}
