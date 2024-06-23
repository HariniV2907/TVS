using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;

    // Function to transition to a new scene
    public void TransitionToScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
