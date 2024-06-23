using UnityEngine;

public class BBEnableAnimationOnCollision : MonoBehaviour
{
    public GameObject objectB; // The GameObject whose animation should be enabled
    private Animation animationB; // Reference to the Animation component of object B

    // Start is called before the first frame update
    void Start()
    {
        // Ensure object B is not null and has an Animation component
        if (objectB != null)
        {
            animationB = objectB.GetComponent<Animation>();
            if (animationB == null)
            {
                Debug.LogWarning("Object B does not have an Animation component.");
            }
        }
        else
        {
            Debug.LogWarning("Object B is not assigned.");
        }
    }

    // Called when the collider of object A touches the collider of object B
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider that touched object B is attached to object A
        if (other.gameObject == objectB)
        {
            // Enable the animation of object B if it has an Animation component
            if (animationB != null)
            {
                animationB.enabled = true;
            }
            else
            {
                Debug.LogWarning("Animation component of Object B is missing.");
            }
        }
    }
}
