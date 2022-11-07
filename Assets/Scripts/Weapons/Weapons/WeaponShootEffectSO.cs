using UnityEngine;

[CreateAssetMenu(fileName = "WeaponShootEffect_", menuName = "Scriptable Objects/Weapons/Weapon Shoot Effect")]
public class WeaponShootEffectSO : ScriptableObject
{
    #region Header WEAPON SHOOT EFFECT DETAILS
    [Space(10)]
    [Header("WEAPON SHOOT EFFECT DETAILS")]
    #endregion

    #region Tooltip
    [Tooltip("the color gradient for the shoot effect. this gradient show the color of the particles during their lifetime.")]
    #endregion
    public Gradient colorGradient;

    #region Tooltip
    [Tooltip("the length of time the particle system is emitting particles")]
    #endregion
    public float duration = .50f;

    #region Tooltip
    [Tooltip("the start particle size for the particle effect")]
    #endregion
    public float startParticleSize = .25f;

    #region Tooltip
    [Tooltip("the start particle speed for the particle effect")]
    #endregion
    public float startParticleSpeed = 3f;

    #region Tooltip
    [Tooltip("the particle lifetime for the particle effect")]
    #endregion
    public float startLifetime = .5f;

    #region Tooltip
    [Tooltip("the max number of particles to be emitted")]
    #endregion
    public int maxParticleNumber = 100;

    #region Tooltip
    [Tooltip("the number of particles emitted per second. If zero it will just be the burst number")]
    #endregion
    public int emissionRate = 100;

    #region Tooltip
    [Tooltip("How many particles should be emitted in the particle effect burst")]
    #endregion
    public int burstParticleNumber = 20;

    #region Tooltip
    [Tooltip("the gravity on the particles")]
    #endregion
    public float effectGravity = -.01f;

    #region Tooltip
    [Tooltip("the sprite for the particle effect.")]
    #endregion
    public Sprite sprite;

    #region Tooltip
    [Tooltip("the min velocity for the particle over its lifetime")]
    #endregion
    public Vector3 velocityOverLifetimeMin;

    #region Tooltip
    [Tooltip("the max velocity for the particle over its lifetime")]
    #endregion
    public Vector3 velocityOverLifetimeMax;

    #region Tooltip
    [Tooltip("weaponShootEffectPrefab contains the particle system for the shoot effect and is configured by the weaponShootEffectSO")]
    #endregion
    public GameObject weaponShootEffectPrefab;


    #region Validation
#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckPositiveValue(this, nameof(duration), duration, false);
        HelperUtilities.ValidateCheckPositiveValue(this, nameof(startParticleSize), startParticleSize, false);
        HelperUtilities.ValidateCheckPositiveValue(this, nameof(startParticleSpeed), startParticleSpeed, false);
        HelperUtilities.ValidateCheckPositiveValue(this, nameof(startLifetime), startLifetime, false);
        HelperUtilities.ValidateCheckPositiveValue(this, nameof(maxParticleNumber), maxParticleNumber, false);
        HelperUtilities.ValidateCheckPositiveValue(this, nameof(emissionRate), emissionRate, true);
        HelperUtilities.ValidateCheckPositiveValue(this, nameof(burstParticleNumber), burstParticleNumber, true);
        HelperUtilities.ValidateCheckNullValue(this, nameof(weaponShootEffectPrefab), weaponShootEffectPrefab);
    }
#endif
    #endregion
}
