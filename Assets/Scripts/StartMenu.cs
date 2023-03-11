using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
        //for quiting in the editor, otherwise it'll look like its doing nothing
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
