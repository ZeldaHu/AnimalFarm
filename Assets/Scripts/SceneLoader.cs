using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    // Reloads the scene
    public void ReloadScene()
    {
        SceneManager.LoadScene(0); // Load the scene with the specified name
    }
}
