using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void MoveToScene(int scene)
   {
         SceneManager.LoadScene(scene);
   }  
}
