//this script defines behavior for the litter objects

using UnityEngine;

public class LitterController : MonoBehaviour
{
    //defines the score manager object to access to update the score text field
    private ScoreManager scoreManager;

    private void Start()
    {
        //finds the score manager of the canvas object
        scoreManager = GameObject.Find("Canvas").GetComponent<ScoreManager>();
    }

    //defines how litter behaves in collisions
    private void OnTriggerEnter(Collider collision)
    {
        //defines what to do when a player collides with the litter
        //another else-if can be added for collisons with other game entities
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("A player found me!");
            scoreManager.score += 1f;
            scoreManager.sendScore();
            
        } else
        {
            //a debug message to test collisons with other object types
            Debug.Log("I hit a " + collision.tag);
        }

        
    }
}
