using UnityEngine;
using UnityEngine.SpatialTracking;

public class LockYPoseProvider : TrackedPoseDriver
{
    private Vector3 initialPosition;

    protected override void Awake()
    {
        base.Awake();
        initialPosition = transform.localPosition;
    }

    protected override void SetLocalTransform(Vector3 newPosition, Quaternion newRotation, PoseDataFlags poseFlags)
    {
        // Preserve the initial y-position
        newPosition.y = initialPosition.y;

        // Call the base method with the modified position
        base.SetLocalTransform(newPosition, newRotation, poseFlags);
    }
}
