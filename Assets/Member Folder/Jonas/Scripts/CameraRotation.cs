using UnityEngine;
using Cinemachine;
using Sirenix.OdinInspector;

public class CameraRotation : MonoBehaviour
{
    [ShowInInspector]
    private float rotationSpeed = 50f;
    private CinemachineOrbitalTransposer orbitalTransposer;

    private void Start()
    {
        orbitalTransposer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineOrbitalTransposer>();
    }

    private void Update()
    {
        float rotateLeftInput = Input.GetKey(KeyCode.Q) ? -1.0f : 0.0f;
        float rotateRightInput = Input.GetKey(KeyCode.E) ? 1.0f : 0.0f;

        float rotationAmount = (rotateRightInput + rotateLeftInput) * rotationSpeed * Time.deltaTime;

        orbitalTransposer.m_XAxis.Value += rotationAmount;
    }
}
