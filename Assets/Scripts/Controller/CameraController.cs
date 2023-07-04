using UnityEngine;
using Cinemachine;

/// <summary>
/// An add-on module for Cinemachine Virtual Camera that locks the camera's Y co-ordinate
/// </summary>
[SaveDuringPlay]
[AddComponentMenu("")] // Hide in menu
public class CameraController : CinemachineExtension
{
    [Tooltip("Lock the camera's Y position to this value")]
    public float m_MinYPosition = 0;
    public float m_MaxYPosition = 500;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Finalize && state.RawPosition.y < m_MinYPosition)
        {
            var pos = state.RawPosition;
            pos.y = m_MinYPosition;
            state.RawPosition = pos;
        }
        if (stage == CinemachineCore.Stage.Finalize && state.RawPosition.y > m_MaxYPosition)
        {
            var pos = state.RawPosition;
            pos.y = m_MaxYPosition;
            state.RawPosition = pos;
        }
    }
}