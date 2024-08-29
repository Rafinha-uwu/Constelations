using UnityEngine;

public class CEunice : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 5f;
    public float followDelay = 0.5f;

    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        if (target != null)
        {
            // Calculate the target position with delay
            Vector3 targetPosition = target.position;
            targetPosition.z = transform.position.z;

            Vector3 desiredPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, followDelay, followSpeed);

            // Move towards the desired position
            transform.position = desiredPosition;
        }
    }
}
