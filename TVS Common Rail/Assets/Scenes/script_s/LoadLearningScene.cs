using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLearningScene : MonoBehaviour
{
    [SerializeField]
    private string learningSceneName = "LearningScene"; // Default scene name for learning

    public void LoadScene()
    {
        SceneManager.LoadScene(learningSceneName);
    }
}
