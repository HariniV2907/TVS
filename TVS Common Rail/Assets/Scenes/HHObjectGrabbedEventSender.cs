using UnityEngine;
using Oculus.Interaction;

public class HHObjectGrabbedEventSender : OneGrabFreeTransformer, ITransformer
{
    // Boolean variable to track grab state
    private bool isGrabbed = false;

    public delegate void ObjectGrabbed(GameObject source);
    public event ObjectGrabbed onObjectGrabbed;
    public delegate void ObjectMoved(GameObject source);
    public event ObjectMoved onObjectMoved;
    public delegate void ObjectReleased(GameObject source);
    public event ObjectReleased onObjectReleased;

    public new void Initialize(IGrabbable grabbable)
    {
        base.Initialize(grabbable);
    }

    public new void BeginTransform()
    {
        base.BeginTransform();
        isGrabbed = true; // Update grab state
        onObjectGrabbed?.Invoke(gameObject);
    }

    public new void UpdateTransform()
    {
        base.UpdateTransform();
        onObjectMoved?.Invoke(gameObject);
    }

    public new void EndTransform()
    {
        base.EndTransform();
        isGrabbed = false; // Update grab state
        onObjectReleased?.Invoke(gameObject);
    }

    // Method to check if the object is grabbed
    public bool IsGrabbed()
    {
        return isGrabbed;
    }
}