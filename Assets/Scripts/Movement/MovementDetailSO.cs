using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementDetails_", menuName = "Scriptable Objects/Movement/Movement Details")]
public class MovementDetailSO : ScriptableObject
{
    #region Header MOVEMENT DETAILS
    [Space(10)]
    [Header("MOVEMENT DETAILS")]
    #endregion Header MOVEMENT DETAILS
    #region Tooltip
    [Tooltip("The minimum movement speed")]
    #endregion
    public float minMoveSpeed = 8f;
    #region Tooltip
    [Tooltip("The maximum movement speed")]
    #endregion
    public float maxMoveSpeed = 8f;
    #region Tooltip
    [Tooltip("If there is a roll movement - this is the roll speed")]
    #endregion
    public float rollSpeed;//for player
    #region Tooltip
    [Tooltip("If there is a roll movement - this is the roll distance")]
    #endregion
    public float rollDistance;//for player
    #region Tooltip
    [Tooltip("If there is a roll movement - this is the cooldown time in seconds between the roll actions")]
    #endregion
    public float rollCooldownTime;//for player
    public float GetMoveSpeed()
    {
        if (minMoveSpeed == maxMoveSpeed)
        {
            return minMoveSpeed;
        }
        else
        {
            return Random.Range(minMoveSpeed, maxMoveSpeed);
        }
    }
    #region Validation
#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckPositiveRange(this, nameof(minMoveSpeed), minMoveSpeed, nameof(maxMoveSpeed), maxMoveSpeed, false);

        if (rollDistance != 0f || rollSpeed != 0 || rollCooldownTime != 0)
        {
            HelperUtilities.ValidateCheckPositiveValue(this, nameof(rollDistance), rollDistance, false);
            HelperUtilities.ValidateCheckPositiveValue(this, nameof(rollSpeed), rollSpeed, false);
            HelperUtilities.ValidateCheckPositiveValue(this, nameof(rollCooldownTime), rollCooldownTime, false);
        }
    }
#endif
    #endregion
}
