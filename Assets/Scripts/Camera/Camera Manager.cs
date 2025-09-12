using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// This is the general camera manager that controls the camera in the scene.
/// It should implement a bunch of interfaces to allow for people to choose which
/// camera behaviors they want, and uses the camera target script to move from
/// target to target.
/// 
/// REM-i
/// </summary>
public class CameraManager : MonoBehaviour
{
    #region Vars

    [Tooltip("This is the targetting script we use.")]
    [SerializeField, Header("Camera Vars")]
    private CameraTarget _target;

    // The position we use for the camera to move forward
    private Transform _targetPosition;

    [Tooltip("A list of the camera behavior interfaces to use.")]
    [SerializeField]
    private List<ICameraBehavior> _behaviors;

    #endregion

    #region Methods

    /// <summary>
    /// Check for all the dependencies you need for the script to work
    /// </summary>
    private void Awake()
    {
        if (_behaviors == null)
        {
            Debug.LogError("No camera behaviors found, camera script will not work.");
        }

        if (_target == null)
        {
            Debug.LogWarning("No camera target found, is this a mistake?");
            _target = GetComponent<CameraTarget>();
        }
    }

    /// <summary>
    /// This will handle all of the camera target behaviors as time goes on.
    /// </summary>
    private void LateUpdate()
    {
        // Don't bother if we have no target
        if (_target == null || _behaviors != null)
        {
            return;
        }

        // Set the initial target
        _targetPosition = _target.Position;

        // Set our current position
        Vector3 positionToMoveTo = transform.position;

        // Run through each interface to modify the behavior
        foreach (var b in _behaviors)
        {
            b.GetTargetPosition(positionToMoveTo, _targetPosition);
        }

        // Move the camera
        transform.position = positionToMoveTo;
    }

    #endregion
}
