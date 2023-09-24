using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [ShowInInspector, Range(1f, 10f)]
    private float moveSpeed = 5f;
    private Transform playerTransform;
    private Transform cameraTransform;

    private void Start()
    {
        playerTransform = GetComponent<Transform>();
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(horizontalInput, 0, verticalInput).normalized;
        Vector3 adjustedMovement = Quaternion.Euler(0, cameraTransform.rotation.eulerAngles.y, 0) * moveDir;

        playerTransform.Translate(adjustedMovement * moveSpeed * Time.deltaTime);
    }
}