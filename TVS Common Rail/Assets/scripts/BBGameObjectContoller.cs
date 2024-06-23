using UnityEngine;

public class BBGameObjectController : MonoBehaviour
{
    public GameObject[] gameObjects; // Array to hold the game objects
    public int currentIndex = 0; // Index to keep track of the current active game object

    public void ToggleNextGameObject()
    {
        // Disable all game objects
        foreach (GameObject obj in gameObjects)
        {
            obj.SetActive(false);
        }

        // Enable the next game object
        if (currentIndex < gameObjects.Length)
        {
            gameObjects[currentIndex].SetActive(true);
            currentIndex++;
        }
        else
        {
            // If currentIndex exceeds the array length, reset it to 0
            currentIndex = 0;
            gameObjects[currentIndex].SetActive(true);
        }
    }
}

