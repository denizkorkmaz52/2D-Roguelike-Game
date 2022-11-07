using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDetails_", menuName = "Scriptable Objects/Weapons/Weapon Details")]
public class WeaponDetailsSO : ScriptableObject
{
    //weapon base details
    #region Header WEAPON BASE DETAILS
    [Space(10)]
    [Header("WEAPON BASE DETAILS")]
    #endregion Header WEAPON BASE DETAILS
    #region Tooltip
    [Tooltip("The weapon name")]
    #endregion
    public string weaponName;
    #region Tooltip
    [Tooltip("The weapon sprite")]
    #endregion
    public Sprite weaponSprite;

    //Weapon configuration
    #region Header WEAPON CONFIGURATIONS
    [Space(10)]
    [Header("WEAPON CONFIGURATIONS")]
    #endregion
    public Vector3 weaponShootPosition;
    #region Tooltip
    [Tooltip("Weapon Current ammo")]
    #endregion
    public AmmoDetailsSO weaponCurrentAmmo;
    #region Tooltip
    [Tooltip("Weapon Shoot Effect SO - contains particle effect parameters used to be in conjuction with the weaponShootEffectPrefab")]
    #endregion
    public WeaponShootEffectSO weaponShootEffect;
    #region Tooltip
    [Tooltip("Weapon firing sound effect SO")]
    #endregion
    public SoundEffectSO weaponFiringSoundEffect;
    #region Tooltip
    [Tooltip("Weapon reload sound effect SO")]
    #endregion
    public SoundEffectSO weaponReloadingSoundEffect;
    //Weapon operating values
    #region Header WEAPON OPERATING VALUES
    [Space(10)]
    [Header("WEAPON OPERATING VALUES")]
    #endregion

    #region Tooltip
    [Tooltip("Select if the weapon has infinite ammo")]
    #endregion
    public bool hasInfiniteAmmo = false;
    #region Tooltip
    [Tooltip("Select if the weapon has infinite clip capacity")]
    #endregion
    public bool hasInfinityClipCapacity = false;
    #region Tooltip
    [Tooltip("The weapon capacity - shots before a reload")]
    #endregion
    public int weaponClipAmmoCapacity = 6;
    #region Tooltip
    [Tooltip("The weapon ammo capacity - the maximum number of rounds that can be held for this weapon")]
    #endregion
    public int weaponAmmoCapacity = 100;
    #region Tooltip
    [Tooltip("Weapon fire rate - 0.2 means 5 shots a second")]
    #endregion
    public float weaponFireRate = 0.2f;
    #region Tooltip
    [Tooltip("time in seconds to hold fire button down before firing")]
    #endregion
    public float weaponPrechargeTime = 0f;
    #region Tooltip
    [Tooltip("This is the weapon reload time in seconds")]
    #endregion
    public float weaponReloadTime = 0f;

    #region Validation
#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEmptyString(this, nameof(weaponName), weaponName);
        HelperUtilities.ValidateCheckNullValue(this, nameof(weaponCurrentAmmo), weaponCurrentAmmo);
        HelperUtilities.ValidateCheckPositiveValue(this, nameof(weaponFireRate), weaponFireRate, false);
        HelperUtilities.ValidateCheckPositiveValue(this, nameof(weaponPrechargeTime), weaponPrechargeTime, true);

        if (!hasInfiniteAmmo)
        {
            HelperUtilities.ValidateCheckPositiveValue(this, nameof(weaponAmmoCapacity), weaponAmmoCapacity, false);
        }
        if (!hasInfinityClipCapacity)
        {
            HelperUtilities.ValidateCheckPositiveValue(this, nameof(weaponClipAmmoCapacity), weaponClipAmmoCapacity, false);
        }
    }
#endif
    #endregion
}
