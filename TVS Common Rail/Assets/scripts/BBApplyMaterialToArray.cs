using UnityEngine;

public class BBApplyMaterialToArray : MonoBehaviour
{
    public Material materialToApply; // The material to apply to objects in the array
    public GameObject[] objectsToApplyMaterial; // Array of GameObjects to apply the material to

    // Start is called before the first frame update
    void Start()
    {
        ApplyMaterialToObjects();
    }

    // Apply the material to all objects in the array
    public void ApplyMaterialToObjects()
    {
        foreach (GameObject obj in objectsToApplyMaterial)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = materialToApply;
            }
            else
            {
                Debug.LogWarning("Object " + obj.name + " does not have a Renderer component.");
            }
        }
    }

    // Public function to call ApplyMaterialToObjects
    public void ApplyMaterial()
    {
        ApplyMaterialToObjects();
    }
}
