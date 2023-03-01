using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLitter : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    levelTimer timer;

    private bool spawned = false;


    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("TimerManager").GetComponent<levelTimer>();
    }

    void Update()
    {
        if (Mathf.Ceil(timer.currentTime) % 10 == 0)
        {
            if (!spawned)
            {
                Spawn();
                spawned = true;
            }
        } else
        {
            spawned = false;
        }
    }

    private bool emptySpace(Vector3 location)
    {
        
        Collider[] collider = Physics.OverlapSphere(location, 1);

        if (collider.Length == 0)
        {
            Debug.Log("space found");
            return true;
        } else
        {
            Debug.Log("no space found");
            return false;
        }
        
        //return true;
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
