using UnityEngine;

public class HHLiftAnimation : MonoBehaviour
{
    public GameObject childObject; // Reference to the child GameObject
    private Animator childAnimator; // Reference to the Animator component of the child GameObject
    private bool isLifted = false; // Flag to track if the parent GameObject is lifted

    void Start()
    {
        // Get the Animator component of the child GameObject
        childAnimator = childObject.GetComponent<Animator>();
        // Disable the child Animator by default
        childAnimator.enabled = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object is being lifted and has not already been lifted
        if (!isLifted && collision.gameObject.CompareTag("HollowScrew"))
        {
            // Enable the child Animator
            childAnimator.enabled = true;
            // Trigger the animation of the child GameObject
            childAnimator.SetTrigger("StartAnimation");
            // Set the flag to true to prevent repeated triggering
            isLifted = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Check if the object is being lifted and the collision ends
        if (isLifted && collision.gameObject.CompareTag("HollowScrew"))
        {
            // Pause the animation by disabling the child Animator
            childAnimator.enabled = false;
        }
    }
}