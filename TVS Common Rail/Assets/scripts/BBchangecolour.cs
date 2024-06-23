using UnityEngine;

public class BBchangecolour : MonoBehaviour
{
    public GameObject referredObject;
    public GameObject[] objectsToEnable;

    private void OnEnable()
    {
        Debug.Log("OnEnable called");
        if (referredObject != null && referredObject.activeSelf)
        {
            Debug.Log("Referred object is active, enabling objects");
            EnableObjects();
        }
        else
        {
            Debug.Log("Referred object is not active, objects not enabled");
        }
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable called");
        DisableObjects();
    }

    private void EnableObjects()
    {
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(true);
            Debug.Log("Enabled object: " + obj.name);
        }
    }

    private void DisableObjects()
    {
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(false);
            Debug.Log("Disabled object: " + obj.name);
        }
    }
}
