using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTrainingScene : MonoBehaviour
{
    [SerializeField]
    private string trainingSceneName = "Training"; // Default scene name for training

    public void LoadScene()
    {
        SceneManager.LoadScene(trainingSceneName);
    }
}
