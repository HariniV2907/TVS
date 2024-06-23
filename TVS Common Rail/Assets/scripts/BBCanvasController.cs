using UnityEngine;
using UnityEngine.UI;

public class BBCanvasController : MonoBehaviour
{
    public GameObject[] canvasElements; // Array to hold the canvas elements
    private int currentIndex = 0; // Index to keep track of the current active canvas element

    void Start()
    {
        // Ensure that all canvas elements are disabled at start
        DisableAllCanvasElements();
    }

    public void ShowNextCanvasElement()
    {
        // Check if there are canvas elements to show
        if (canvasElements.Length == 0)
        {
            Debug.LogWarning("No canvas elements assigned to show.");
            return;
        }

        // Hide the current canvas element
        canvasElements[currentIndex].SetActive(false);

        // Increment the index and loop back to the beginning if necessary
        currentIndex = (currentIndex + 1) % canvasElements.Length;

        // Show the next canvas element
        canvasElements[currentIndex].SetActive(true);
    }

    private void DisableAllCanvasElements()
    {
        // Disable all canvas elements at start
        foreach (GameObject element in canvasElements)
        {
            element.SetActive(false);
        }
    }
}

