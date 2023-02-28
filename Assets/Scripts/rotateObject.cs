using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObject : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            player.eulerAngles.y,
            transform.eulerAngles.z
        );
    }
}
