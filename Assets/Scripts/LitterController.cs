//this script defines behavior for the litter objects

using UnityEngine;

public class LitterController : MonoBehaviour
{
    //defines the score manager object to access to update the score text field
    private ScoreManager scoreManager;
    private SpawnLitter spawner;
    public int index;

    private void Start()
    {
        //finds the score manager of the canvas object
        scoreManager = GameObject.Find("Canvas").GetComponent<ScoreManager>();
        spawner = GameObject.Find("LitterParent").GetComponent<SpawnLitter>();
    }

    //defines how litter behaves in collisions
    private void OnTriggerEnter(Collider collision)
    {
        //defines what to do when a player collides with the litter
        //another else-if can be added for collisons with other game entities
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            spawner.spawnNew(index);
            //Debug.Log("A player found me!");
            scoreManager.add();
            
        } else if (collision.CompareTag("Animal"))
        {
            //Debug.Log("an animal got me!");
            gameObject.SetActive(false);
            spawner.spawnNew(index);
            scoreManager.sub();
        }
        

        
    }
}
