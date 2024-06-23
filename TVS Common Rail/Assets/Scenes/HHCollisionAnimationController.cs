using UnityEngine;

public class HHCollisionAnimationController : MonoBehaviour
{
    public string targetTag; // Tag of the object to check for collision
    public Animation anim; // Reference to the animation to play

    private bool isColliding = false;

    private void Start()
    {
        if (anim == null)
        {
            Debug.LogError("Animation reference not set!");
            enabled = false; // Disable the script if animation reference is not set
        }
    }

    private void Update()
    {
        // If collision detected and animation is not playing, start animation
        if (isColliding && !anim.isPlaying)
        {
            anim.Play();
        }
        // If collision not detected and animation is playing, pause animation
        else if (!isColliding && anim.isPlaying)
        {
            anim.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if collision is with the target object
        if (collision.gameObject.CompareTag(targetTag))
        {
            isColliding = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if collision with target object has ended
        if (collision.gameObject.CompareTag(targetTag))
        {
            isColliding = false;
        }
    }
}
