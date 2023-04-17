using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void returnToStart()
    { 
        SceneManager.LoadScene(0);
    }
}
