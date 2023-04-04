using UnityEngine;


public class playerAnimation : MonoBehaviour
{
    
    private float x;
    private float y;

    [SerializeField] private Animator anim;
    [SerializeField] private playerMovement move;
    // Update is called once per frame
    void Update()
    {
        //val checks on player movement sctipt output values.
        x = move.xval;
        y = move.yval;

        if (!isPlaying()) // check for animation in progress
        {
            if (y != 0.0 || x != 0.0) //check for movement cmd
            {
                if (y == -1) // if cmd is towards cam
                { 
                    anim.Play("rangerAway", 0, 0.0f); 
                }
                if (y == 1) { anim.Play("rangerFwd", 0, 0.0f); };//if cmd is away from cam
            } 
        }
    }

    bool isPlaying()
    {
        return anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
    }
}

