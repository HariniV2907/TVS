using System.Collections;
using UnityEngine;

public class BBColliderScript : MonoBehaviour
{
    public string targetTag = "halo";

    
    public Transform sourceTransform;
    public Transform targetTransform; // Assign the target transform in the inspector

    public GameObject[] objectsToDisable; // Assign objects to disable in the inspector

    public float transformationInterval = 0.1f; // Time interval for continuous transformation

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag) && sourceTransform != null && targetTransform != null)
        {
            // Start coroutine to continuously apply the transformation
            StartCoroutine(ContinuousTransformation());
        }
    }

    private IEnumerator ContinuousTransformation()
    {
        while (true)
        {
            // Transfer the transform values from sourceTransform to targetTransform
            targetTransform.position = sourceTransform.position;
            targetTransform.rotation = sourceTransform.rotation;

            UnityEngine.Debug.Log("The object");

            // Disable specified objects
            DisableObjects();

            yield return new WaitForSeconds(transformationInterval);
        }
    }

    private void DisableObjects()
    {
        // Disable each object in the array
        foreach (var obj in objectsToDisable)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }
}
