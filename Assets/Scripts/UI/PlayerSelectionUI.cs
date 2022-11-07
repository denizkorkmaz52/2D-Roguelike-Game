using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerSelectionUI : MonoBehaviour
{
    #region Tooltip
    [Tooltip("populte with the sprite renderer on child game object WeaponAnchorPosition/WeaponRotationPoint/Hand")]
    #endregion
    public SpriteRenderer playerHandSpriteRenderer;
    #region Tooltip
    [Tooltip("populte with the sprite renderer on child game object HandNoWeapon")]
    #endregion
    public SpriteRenderer playerHandNoWeaponSpriteRenderer;
    #region Tooltip
    [Tooltip("populte with the sprite renderer on child game object WeaponAnchorPosition/WeaponRotationPoint/Weapon")]
    #endregion
    public SpriteRenderer playerWeaponSpriteRenderer;
    #region Tooltip
    [Tooltip("populte with the animator component")]
    #endregion
    public Animator animator;

    #region Validation
#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckNullValue(this, nameof(playerHandNoWeaponSpriteRenderer), playerHandNoWeaponSpriteRenderer);
        HelperUtilities.ValidateCheckNullValue(this, nameof(playerHandSpriteRenderer), playerHandSpriteRenderer);
        HelperUtilities.ValidateCheckNullValue(this, nameof(playerWeaponSpriteRenderer), playerWeaponSpriteRenderer);
        HelperUtilities.ValidateCheckNullValue(this, nameof(animator), animator);
    }
#endif
    #endregion
}
