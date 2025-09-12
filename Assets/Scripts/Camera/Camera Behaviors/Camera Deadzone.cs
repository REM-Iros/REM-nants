using UnityEngine;

/// <summary>
/// This script handles deadzone behavior for the camera, only moving
/// the camera when the player gets out of the deadzone.
/// 
/// REM-i
/// </summary>
public class CameraDeadzone : ICameraBehavior
{
    #region Vars

    [Tooltip("This is the deadzone x value for the camera to work with.")]
    [SerializeField, Header("Deadzone Vars")]
    private float _xDeadzone;

    [Tooltip("This is the deadzone y value for the camera to work with.")]
    [SerializeField] 
    private float _yDeadzone;

    #endregion

    #region Methods

    public Vector2 GetTargetPosition(Vector2 position, Transform target)
    {
        // The distance we need to travel to reach destination
        float xTravel = 0f;
        float yTravel = 0f;

        // Distance between each point
        float xDist = position.x - target.position.x;
        float yDist = position.y - target.position.y;



        return new Vector2(xTravel, yTravel);
    }

    #endregion
}
