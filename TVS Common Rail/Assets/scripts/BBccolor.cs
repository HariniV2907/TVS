using UnityEngine;

public class BBccolor : MonoBehaviour
{
    public GameObject objectToChange; // The GameObject whose color will be changed
    public Color newColor = Color.red; // The new color to set

    // Function to change the color of the specified object
    public void ChangeObjectColor()
    {
        if (objectToChange != null)
        {
            Renderer renderer = objectToChange.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = newColor;
            }
            else
            {
                Debug.LogWarning("The specified GameObject does not have a Renderer component.");
            }
        }
        else
        {
            Debug.LogWarning("No GameObject specified to change color.");
        }
    }
}
