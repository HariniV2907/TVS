using UnityEngine;

public class HHSnapModelToPosition : MonoBehaviour {
    public GameObject[] objectsToSnapTo;
    public GameObject[] objectsToDisable;

    bool isSnapped = false;

    void OnCollisionStay(Collision col)
    {
        if (!isSnapped)
        {
            foreach (GameObject objToSnapTo in objectsToSnapTo)
            {
                if (col.gameObject == objToSnapTo)
                {
                    isSnapped = true;

                    // Disable objectsToDisable GameObjects
                    foreach (GameObject objToDisable in objectsToDisable)
                    {
                        if (objToDisable != null)
                            objToDisable.SetActive(false);
                    }
                    break;
                }
            }
        }
    }

    void Update()
    {
        // Snap to objectsToSnapTo's position and rotation while continuously colliding
        if (isSnapped)
        {
            foreach (GameObject objToSnapTo in objectsToSnapTo)
            {
                transform.position = objToSnapTo.transform.position;
                transform.rotation = objToSnapTo.transform.rotation;
            }

            // Re-enable objectsToDisable GameObjects once the object starts moving
            if (GetComponent<Rigidbody>().velocity.magnitude > 0.01f)
            {
                foreach (GameObject objToDisable in objectsToDisable)
                {
                    if (objToDisable != null)
                        objToDisable.SetActive(true);
                }

                isSnapped = false; // Reset snapping
            }
        }
    }
}
