using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   

    public void LoadSceneAfterDelay(float delay)
    {
        Invoke("LoadScene", delay);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(2);
    }
}
