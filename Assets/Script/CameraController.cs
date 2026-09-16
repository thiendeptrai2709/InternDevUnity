using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class CameraController : MonoBehaviour
{
    private CinemachineFreeLook freeLookCamera;

    private void Awake()
    {
        freeLookCamera = GetComponent<CinemachineFreeLook>();
    }

    private void Update()
    {
        if (InputManager.Instance.IsLeftClickHeld)
        {
            freeLookCamera.m_XAxis.m_InputAxisValue = InputManager.Instance.LookInput.x;
            freeLookCamera.m_YAxis.m_InputAxisValue = InputManager.Instance.LookInput.y;
        }
        else
        {
            freeLookCamera.m_XAxis.m_InputAxisValue = 0f;
            freeLookCamera.m_YAxis.m_InputAxisValue = 0f;
        }
    }
}