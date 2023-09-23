using Sirenix.OdinInspector;
using UnityEngine;

public class RotateTowardsMovementDirection : MonoBehaviour
{
    [ShowInInspector]
    private float rotationSpeed = 20f;
    private Vector3 lastPosition;

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void Update()
    {
        Vector3 movementDirection = transform.position - lastPosition;

        if (movementDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection.normalized, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        lastPosition = transform.position;
    }
}
