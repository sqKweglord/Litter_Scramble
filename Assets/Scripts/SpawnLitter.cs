using System.Collections;
using UnityEngine;

public class SpawnLitter : MonoBehaviour
{
    public GameObject[] ObjectsToSpawn;

    public int NumofSpawns;
    public GameObject[] litterArr;

    private levelTimer timer;

    private Transform[] SpawnPoints;
    public GameObject spawns;

    // sets the timer variable, litter sprites, and initial litter spawns
    void Start()
    {

        ObjectsToSpawn = Resources.LoadAll<GameObject>("litter_prefabs");

        //gets the timer
        timer = GameObject.Find("TimerManager").GetComponent<levelTimer>();

        //sets the SpawnPoints
        int count = spawns.transform.childCount;
        SpawnPoints = new Transform[count];
        for (int i = 0; i < count; i++)
        {
            SpawnPoints[i] = spawns.transform.GetChild(i);
        }

        //initialize litterArr size
        litterArr = new GameObject[NumofSpawns];

        //sets initial litter
        for (int i = 0; i < NumofSpawns; i++)
        {
            litterArr[i] = Spawn();
            litterArr[i].AddComponent<LitterController>();
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
                        litterArr[i].AddComponent<LitterController>();
                    }
                }
            }
        }
    }

    public GameObject Spawn()
    {
        int spawnPoint;
        Vector3 location;
        do {
            spawnPoint = Random.Range(0, SpawnPoints.Length);
            location = new Vector3(SpawnPoints[spawnPoint].position.x, SpawnPoints[spawnPoint].position.y, SpawnPoints[spawnPoint].position.z);
        } while (!checkSpawnPoint(location));
       
        checkSpawnPoint(location);
        int litter = Random.Range(0, ObjectsToSpawn.Length);
        return ObjectSpawn(ObjectsToSpawn[litter], location);

    }
 
    //spawns the provided object at a provided location
    private GameObject ObjectSpawn(GameObject litter, Vector3 location)
    {
        //instantiates the litter
        return Instantiate(litter, location, transform.rotation, transform);
    }

    private bool checkSpawnPoint(Vector3 point)
    {
        Collider[] colliders = Physics.OverlapSphere(point, 1);
        if (colliders.Length == 0)
        {
            return true;
        } else
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].CompareTag("litter"))
                {
                    return false;
                }
            }

            return true;
        }
    }


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
