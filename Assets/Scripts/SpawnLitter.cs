using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLitter : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    levelTimer timer;

    //private bool spawned = false;
    private int spawnedCount = 0;
    private int spawnedMax = 1;


    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("TimerManager").GetComponent<levelTimer>();
    }

    void Update()
    {
        if (Mathf.Ceil(timer.currentTime) % 5 == 0)
        {
            if (spawnedCount < spawnedMax)
            {

                Spawn();
                spawnedCount++;
                //spawned = true;
            } 
        } else
        {
            //spawned = false;
            spawnedCount = 0;
            spawnedMax = Random.Range(2, 4);
        }
    }

    private bool emptySpace(Vector3 location)
    {
        
        Collider[] collider = Physics.OverlapSphere(location, 1.5f);

        if (collider.Length == 0)
        {
            Debug.Log("space found");
            return true;
        } else 
        {
            return checkArray(collider, "Environment");
        }
    }

    private bool checkArray(Collider[] colliders, string tag)
    {
        bool hasTag = false;
        for (int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].tag == tag)
            {
                hasTag = true;
                break;
            }
        }
        return hasTag;
    }

    private void objectSpawn(GameObject litter, Vector3 location)
    {
        Debug.Log("spawning");
        Instantiate(litter, location, transform.rotation, transform);
    }

    private Vector3 genLocation()
    {
        Debug.Log("getting location");
        float xrange = 14.5f;
        float zrange = 14.5f;
        float y_val = 1f;

        float x_val = Random.Range(-xrange, xrange);
        float z_val = Random.Range(-zrange, zrange);

        Vector3 spawnPOS = new Vector3(x_val, y_val, z_val);

        if (emptySpace(spawnPOS)) {
            return spawnPOS;
        } else
        {
            return genLocation();
        }
    }
    public void Spawn()
    {
        Vector3 location = genLocation();

        objectSpawn(ObjectToSpawn, location);
        
    }
}
