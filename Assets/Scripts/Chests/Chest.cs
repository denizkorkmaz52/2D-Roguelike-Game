using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(MaterializeEffect))]
public class Chest : MonoBehaviour, IUseable
{
    #region Tooltip
    [Tooltip("Set this to the color to be used for the materialization effect")]
    #endregion
    [ColorUsage(false, true)]
    [SerializeField] private Color materializeColor;
    #region Tooltip
    [Tooltip("Set this to the time is will take to materialize the chest")]
    #endregion
    [SerializeField] private float materializeTime = 3f;
    #region Tooltip
    [Tooltip("Populate with itemSpawnPoint transform")]
    #endregion
    [SerializeField] private Transform itemSpawnPoint;
    private int healthPercent;
    private WeaponDetailsSO weaponDetails;
    private int ammoPercent;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private MaterializeEffect materializeEffect;
    private bool isEnabled = false;
    private ChestState chestState = ChestState.closed;
    private GameObject chestItemObject;
    private ChestItem chestItem;
    private TextMeshPro messageTMP;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        materializeEffect = GetComponent<MaterializeEffect>();
        messageTMP = GetComponent<TextMeshPro>();
    }
    public void Initialise(bool shouldMaterialize, int healthPercent, WeaponDetailsSO weaponDetails, int ammoPercent)
    {
        this.ammoPercent = ammoPercent;
        this.healthPercent = healthPercent;
        this.weaponDetails = weaponDetails;

        if (shouldMaterialize)
        {
            StartCoroutine(MaterializeChest());
        }
        else
        {
            EnableChest();
        }
    }

    private IEnumerator MaterializeChest()
    {
        SpriteRenderer[] spriteRendererArray = new SpriteRenderer[] { spriteRenderer };
        yield return StartCoroutine(materializeEffect.MaterializeRoutine(GameResources.Instance.materializeShader, materializeColor, materializeTime,
            spriteRendererArray, GameResources.Instance.litMaterial));
        EnableChest();
    }

    private void EnableChest()
    {
        isEnabled = true;
    }

    public void UseItem()
    {
        if (!isEnabled) return;

        switch (chestState)
        {
            case ChestState.closed:
                OpenChest();
                break;
            case ChestState.healthItem:
                CollectHealthItem();
                break;
            case ChestState.ammoItem:
                CollectAmmoItem();
                break;
            case ChestState.weaponItem:
                CollectWeaponItem();
                break;
            case ChestState.empty:
                return;
            default:
                return;
        }
    }

    private void OpenChest()
    {
        animator.SetBool(Settings.use, true);

        SoundEffectManager.Instance.PlaySoundEffect(GameResources.Instance.chestOpen);

        if (weaponDetails != null)
        {
            if (GameManager.Instance.GetPlayer().IsWeaponHeldByPlayer(weaponDetails))
                weaponDetails = null;
        }
        UpdateChestState();
    }

    private void UpdateChestState()
    {
        if (healthPercent != 0)
        {
            chestState = ChestState.healthItem;
            InstantiateHealthItem();
        }
        else if (ammoPercent != 0)
        {
            chestState = ChestState.ammoItem;
            InstantiateAmmoItem();
        }
        else if (weaponDetails != null)
        {
            chestState = ChestState.weaponItem;
            InstantiateWeaponItem();
        }
        else
        {
            chestState = ChestState.empty;
        }
    }

    private void InstantiateItem()
    {
        chestItemObject = Instantiate(GameResources.Instance.chestItemPrefab, this.transform);
        
        chestItem = chestItemObject.GetComponent<ChestItem>();
    }
    private void InstantiateHealthItem()
    {
        InstantiateItem();

        chestItem.Initialise(GameResources.Instance.heartIcon, healthPercent.ToString() + "%", itemSpawnPoint.position, materializeColor);
    }

    private void CollectHealthItem()
    {
 
        if (chestItem == null || !chestItem.isItemMaterialized)
            return;
        GameManager.Instance.GetPlayer().health.AddHealth(healthPercent);

        SoundEffectManager.Instance.PlaySoundEffect(GameResources.Instance.healthPickup);

        healthPercent = 0;

        Destroy(chestItemObject);

        UpdateChestState();
    }

    private void InstantiateAmmoItem()
    {
        InstantiateItem();

        chestItem.Initialise(GameResources.Instance.bulletIcon, ammoPercent.ToString() + "%", itemSpawnPoint.position, materializeColor);
    }
    private void CollectAmmoItem()
    {
        if (chestItem == null || !chestItem.isItemMaterialized)
            return;

        Player player = GameManager.Instance.GetPlayer();

        player.reloadWeaponEvent.CallReloadWeaponEvent(player.activeWeapon.GetCurrentWeapon(), ammoPercent);

        SoundEffectManager.Instance.PlaySoundEffect(GameResources.Instance.ammoPickup);

        ammoPercent = 0;

        Destroy(chestItemObject);

        UpdateChestState();
    }

    private void InstantiateWeaponItem()
    {
        InstantiateItem();

        chestItem.GetComponent<ChestItem>().Initialise(weaponDetails.weaponSprite, weaponDetails.weaponName, itemSpawnPoint.position, materializeColor);
    }

    private void CollectWeaponItem()
    {
        if (chestItem == null || !chestItem.isItemMaterialized)
            return;

        if (!GameManager.Instance.GetPlayer().IsWeaponHeldByPlayer(weaponDetails))
        {
            GameManager.Instance.GetPlayer().AddWeaponToPlayer(weaponDetails);

            SoundEffectManager.Instance.PlaySoundEffect(GameResources.Instance.weaponPickup);
        }
        else
        {
            StartCoroutine(DisplayMessage("Weapon\nAlready\nEquipped", 5f));
        }

        weaponDetails = null;

        Destroy(chestItemObject);

        UpdateChestState();
    }

    private IEnumerator DisplayMessage(string text, float displayTime)
    {
        messageTMP.text = text;
        yield return new WaitForSeconds(displayTime);
        messageTMP.text = "";
    }
}
