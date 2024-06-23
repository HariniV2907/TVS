using UnityEngine;

public class BBSmoothMovementOnCollision : MonoBehaviour
{
    public Transform fromLocation; // Starting position of the object
    public Transform toLocation; // Target position where the object should move
    public Transform toRotation; // Target rotation of the object
    public GameObject gameObjectToMove; // GameObject to be moved
    public GameObject triggerGameObject; // GameObject with the collider that triggers movement
    public float movementSpeed = 0.05f; // Speed of movement from "from" to "to" location
    public float rotationSpeed = 1000f; // Speed of rotation in the x-axis

    private bool isMoving = false;

    private void Start()
    {
        if (gameObjectToMove == null || triggerGameObject == null || fromLocation == null || toLocation == null)
        {
            Debug.LogError("One or more GameObject references not set!");
            enabled = false; // Disable the script if GameObject references are not set
        }
    }

    private void Update()
    {
        // If trigger GameObject triggers movement and object is not already moving, start moving
        if (isMoving)
        {
            MoveAndRotate();
        }
        else
        {
            // If not moving, pause at the current position
            gameObjectToMove.transform.position = fromLocation.position;
        }
    }

    private void MoveAndRotate()
    {
        // Move the object towards the target position
        float step = movementSpeed * Time.deltaTime;
        gameObjectToMove.transform.position = Vector3.MoveTowards(gameObjectToMove.transform.position, toLocation.position, step);

        // Rotate the object towards the specified rotation (only around the x-axis)
        float rotationStep = rotationSpeed * Time.deltaTime;
        Quaternion targetRotation = Quaternion.Euler(toRotation.eulerAngles.x, 0f, 0f); // Target rotation only around the x-axis
        gameObjectToMove.transform.rotation = Quaternion.RotateTowards(gameObjectToMove.transform.rotation, targetRotation, rotationStep);

        // Check if the object has reached the target position
        if (Vector3.Distance(gameObjectToMove.transform.position, toLocation.position) < 0.001f)
        {
            isMoving = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if trigger GameObject triggers movement
        if (other.gameObject == triggerGameObject)
        {
            isMoving = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if trigger GameObject exits the collider
        if (other.gameObject == triggerGameObject)
        {
            isMoving = false;
        }
    }
}