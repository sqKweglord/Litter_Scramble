using UnityEngine;

public class SpawnLitter : MonoBehaviour
{
    public GameObject[] litterArr;
    public GameObject[] inactiveLitterArr;

    private levelTimer timer;

    private Transform[] SpawnPoints;
    public GameObject spawns;

    // sets the timer variable, litter sprites, and initial litter spawns
    void Start()
    {
        //gets the timer
        timer = GameObject.Find("TimerManager").GetComponent<levelTimer>();

        //sets the SpawnPoints
        int count = spawns.transform.childCount;
        SpawnPoints = new Transform[count];
        for (int i = 0; i < count; i++)
        {
            SpawnPoints[i] = spawns.transform.GetChild(i);
        }

        //sets initial litter
        for (int i = 0; i < litterArr.Length; i++)
        {
            litterArr[i].GetComponent<LitterController>().index = i;
            litterArr[i].transform.position = getSpawn();
        }

    }

    public void spawnNew(int i)
    {
        GameObject temp = litterArr[i];
        int num = Random.Range(0, inactiveLitterArr.Length);
        litterArr[i] = inactiveLitterArr[num];
        inactiveLitterArr[num] = temp;
        litterArr[i].transform.position = getSpawn();
        litterArr[i].GetComponent<LitterController>().index = i;
        litterArr[i].SetActive(true);  
    }

    private Vector3 getSpawn()
    {
        int spawnPoint;
        Vector3 location;
        do {
            spawnPoint = Random.Range(0, SpawnPoints.Length);
            location = new Vector3(SpawnPoints[spawnPoint].position.x, SpawnPoints[spawnPoint].position.y, SpawnPoints[spawnPoint].position.z);
        } while (!checkSpawnPoint(location));

        return location;
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
}
