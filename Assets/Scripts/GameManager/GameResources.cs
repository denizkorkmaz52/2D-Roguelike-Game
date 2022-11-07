using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Audio;

public class GameResources : MonoBehaviour
{
    
    private static GameResources instance;

    public static GameResources Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<GameResources>("GameResources");
            }
            return instance;
        }
    }

    public RoomNodeTypeListSO roomNodeTypeList;
    #region Header PLAYER SELECTION
    [Space(10)]
    [Header("PLAYER SELECTION")]
    #endregion Header PLAYER SELECTION
    #region Tooltip
    [Tooltip("The playerSelection prefab")]
    #endregion Tooltip
    public GameObject playerSelectionPrefab;

    #region Header PLAYER
    [Space(10)]
    [Header("PLAYER")]
    #endregion Header PLAYER
    #region Tooltip
    [Tooltip("The player details list - populate with the playerdetails scriptable objects")]
    #endregion Tooltip
    public List<PlayerDetailsSO> playerDetailsList;

    #region Tooltip
    [Tooltip("The current player scriptable object - this is used to reference the current player between scenes")]
    #endregion Tooltip
    public CurrentPlayerSO currentPlayer;

    #region Header MUSIC
    [Space(10)]
    [Header("MUSIC")]
    #endregion
    #region Tooltip
    [Tooltip("Populate with the music master mixer group")]
    #endregion
    public AudioMixerGroup musicMasterMixerGroup;
    #region Tooltip
    [Tooltip("Main menu music scriptable object")]
    #endregion
    public MusicTrackSO mainMenuMusic;
    #region Tooltip
    [Tooltip("music on full snapshot")]
    #endregion
    public AudioMixerSnapshot musicOnFullSnapshot;
    #region Tooltip
    [Tooltip("music on low snapshot")]
    #endregion
    public AudioMixerSnapshot musicOnLowSnapshot;
    #region Tooltip
    [Tooltip("music off snapshot")]
    #endregion
    public AudioMixerSnapshot musicOffSnapshot;

    #region Header SOUNDS
    [Space(10)]
    [Header("SOUNDS")]
    #endregion Header SOUNDS
    #region Tooltip
    [Tooltip("Populate with the sounds master mixer group")]
    #endregion Tooltip
    public AudioMixerGroup soundsMasterMixerGroup;
    #region Tooltip
    [Tooltip("Door open close sound effect")]
    #endregion Tooltip
    public SoundEffectSO doorOpenCloseSoundEffect;
    #region Tooltip
    [Tooltip("populate with the table flip sound effect")]
    #endregion
    public SoundEffectSO tableFlip;
    #region Tooltip
    [Tooltip("Populate with the chest open sound effect")]
    #endregion
    public SoundEffectSO chestOpen;
    #region Tooltip
    [Tooltip("populate with the health pickup sound effect")]
    #endregion
    public SoundEffectSO healthPickup;
    #region Tooltip
    [Tooltip("populate with the weapon pickup sound effect")]
    #endregion
    public SoundEffectSO weaponPickup;
    #region Tooltip
    [Tooltip("populate with the ammo pickup sound effect")]
    #endregion
    public SoundEffectSO ammoPickup;

    #region Header MATERIALS
    [Space(10)]
    [Header("MATERIALS")]
    #endregion Header MATERIALS
    #region Tooltip
    [Tooltip("Dimmed Material")]
    #endregion Tooltip
    public Material dimmedMaterial;

    #region Tooltip
    [Tooltip("Sprite-Lit Material")]
    #endregion Tooltip
    public Material litMaterial;

    #region Tooltip
    [Tooltip("Populate with the variable lit shader")]
    #endregion Tooltip
    public Shader variableLitShader;

    #region Tooltip
    [Tooltip("populate with the materialize shader")]
    #endregion
    public Shader materializeShader;

    #region Header SPECIAL TILEMAP TILES
    [Space(10)]
    [Header("SPECIAL TILEMAP TILES")]
    #endregion
    #region Tooltip
    [Tooltip("Collision tiles that the enemies can navigate to")]
    #endregion
    public TileBase[] enemyUnwalkableCollisionTilesArray;
    #region Tooltip
    [Tooltip("Preferred path tile for enemy navigation")]
    #endregion
    public TileBase preferredEnemyPathTile;

    #region Header UI
    [Space(10)]
    [Header("UI")]
    #endregion
    #region Tooltip
    [Tooltip("Populate with ammo icon prefab")]
    #endregion
    public GameObject ammoIconPrefab;
    #region Tooltip
    [Tooltip("Populate with heart icon prefab")]
    #endregion
    public GameObject heartIconPrefab;
    #region Tooltip
    [Tooltip("Populate with score prefab")]
    #endregion
    public GameObject scorePrefab;

    #region Header CHESTS
    [Space(10)]
    [Header("CHESTS")]
    #endregion
    #region Tooltip
    [Tooltip("chest item prefab")]
    #endregion
    public GameObject chestItemPrefab;
    #region Tooltip
    [Tooltip("populate with the heart icon sprite")]
    #endregion
    public Sprite heartIcon;
    #region Tooltip
    [Tooltip("populate with the bullet icon sprite")]
    #endregion
    public Sprite bulletIcon;

    #region Header Minimap
    [Space(10)]
    [Header("Minimap")]
    #endregion
    #region Tooltip
    [Tooltip("Minimap skull prefab")]
    #endregion
    public GameObject minimapSkullPrefab;

    #region Validation
#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckNullValue(this, nameof(roomNodeTypeList), roomNodeTypeList);
        HelperUtilities.ValidateCheckNullValue(this, nameof(scorePrefab), scorePrefab);
        HelperUtilities.ValidateCheckNullValue(this, nameof(playerSelectionPrefab), playerSelectionPrefab);
        HelperUtilities.ValidateCheckNullValue(this, nameof(roomNodeTypeList), roomNodeTypeList);
        HelperUtilities.ValidateCheckNullValue(this, nameof(currentPlayer), currentPlayer);
        HelperUtilities.ValidateCheckNullValue(this, nameof(litMaterial), litMaterial);
        HelperUtilities.ValidateCheckNullValue(this, nameof(dimmedMaterial), dimmedMaterial); 
        HelperUtilities.ValidateCheckNullValue(this, nameof(variableLitShader), variableLitShader);
        HelperUtilities.ValidateCheckNullValue(this, nameof(materializeShader), materializeShader);
        HelperUtilities.ValidateCheckNullValue(this, nameof(ammoIconPrefab), ammoIconPrefab);
        HelperUtilities.ValidateCheckNullValue(this, nameof(soundsMasterMixerGroup), soundsMasterMixerGroup);
        HelperUtilities.ValidateCheckNullValue(this, nameof(doorOpenCloseSoundEffect), doorOpenCloseSoundEffect);
        HelperUtilities.ValidateCheckNullValue(this, nameof(tableFlip), tableFlip);
        HelperUtilities.ValidateCheckNullValue(this, nameof(chestOpen), chestOpen);
        HelperUtilities.ValidateCheckNullValue(this, nameof(healthPickup), healthPickup);
        HelperUtilities.ValidateCheckNullValue(this, nameof(ammoPickup), ammoPickup);
        HelperUtilities.ValidateCheckNullValue(this, nameof(weaponPickup), weaponPickup);
        HelperUtilities.ValidateCheckNullValue(this, nameof(heartIconPrefab), heartIconPrefab);
        HelperUtilities.ValidateCheckNullValue(this, nameof(preferredEnemyPathTile), preferredEnemyPathTile);
        HelperUtilities.ValidateCheckNullValue(this, nameof(musicMasterMixerGroup), musicMasterMixerGroup);
        HelperUtilities.ValidateCheckNullValue(this, nameof(mainMenuMusic), mainMenuMusic);
        HelperUtilities.ValidateCheckNullValue(this, nameof(musicOnLowSnapshot), musicOnLowSnapshot);
        HelperUtilities.ValidateCheckNullValue(this, nameof(musicOnFullSnapshot), musicOnFullSnapshot);
        HelperUtilities.ValidateCheckNullValue(this, nameof(musicOffSnapshot), musicOffSnapshot);
        HelperUtilities.ValidateCheckNullValue(this, nameof(heartIcon), heartIcon);
        HelperUtilities.ValidateCheckNullValue(this, nameof(chestItemPrefab), chestItemPrefab);
        HelperUtilities.ValidateCheckNullValue(this, nameof(bulletIcon), bulletIcon);
        HelperUtilities.ValidateCheckNullValue(this, nameof(minimapSkullPrefab), minimapSkullPrefab);
        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(enemyUnwalkableCollisionTilesArray), enemyUnwalkableCollisionTilesArray);
        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(playerDetailsList), playerDetailsList);
        
    }
#endif
    #endregion
}
