using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AStarTest : MonoBehaviour
{
    private InstantiatedRoom instantiatedRoom;
    private Grid grid;
    private Tilemap frontTileMap;
    private Tilemap pathTileMap;
    private Vector3Int startGridPosition;
    private Vector3Int endGridPosition;
    private TileBase startPathTile;
    private TileBase finishPathTile;

    private Vector3Int noValue = new Vector3Int(9999, 9999, 9999);
    private Stack<Vector3> pathStack;

    private void OnEnable()
    {
        StaticEventHandler.OnRoomChanged += StaticEventHandler_OnRoomChanged;
    }

    private void OnDisable()
    {
        StaticEventHandler.OnRoomChanged -= StaticEventHandler_OnRoomChanged;
    }

    private void Start()
    {
        startPathTile = GameResources.Instance.preferredEnemyPathTile;
        finishPathTile = GameResources.Instance.enemyUnwalkableCollisionTilesArray[0];
    }

    private void Update()
    {
        if (instantiatedRoom == null || startPathTile == null || finishPathTile == null || grid == null || pathTileMap == null) return;

        if (Input.GetKeyDown(KeyCode.I))
        {
            ClearPath();
            SetStartPosition();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            ClearPath();
            SetEndPosition();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            DisplayPath();
        }
    }

    private void SetStartPosition()
    {
        if (startGridPosition == noValue)
        {
            startGridPosition = grid.WorldToCell(HelperUtilities.GetMouseWorldPosition());

            if (!IsPositionWithinBounds(startGridPosition))
            {
                startGridPosition = noValue;
                return;
            }

            pathTileMap.SetTile(startGridPosition, startPathTile);

        }
        else
        {
            pathTileMap.SetTile(startGridPosition, null);
            startGridPosition = noValue;
        }
    }
    private void SetEndPosition()
    {
        if (endGridPosition == noValue)
        {
            endGridPosition = grid.WorldToCell(HelperUtilities.GetMouseWorldPosition());

            if (!IsPositionWithinBounds(endGridPosition))
            {
                endGridPosition = noValue;
                return;
            }

            pathTileMap.SetTile(endGridPosition, finishPathTile);

        }
        else
        {
            pathTileMap.SetTile(endGridPosition, null);
            endGridPosition = noValue;
        }
    }

    private bool IsPositionWithinBounds(Vector3Int position)
    {
        if (position.x < instantiatedRoom.room.templateLowerBounds.x || position.x > instantiatedRoom.room.templateUpperBounds.x 
            || position.y < instantiatedRoom.room.templateLowerBounds.y || position.y > instantiatedRoom.room.templateUpperBounds.y)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void ClearPath()
    {
        if (pathStack == null) return;
        foreach (Vector3 worldPosition in pathStack)
        {
            pathTileMap.SetTile(grid.WorldToCell(worldPosition), null);
        }
        pathStack = null;

        endGridPosition = noValue;
        startGridPosition = noValue;
    }

    private void DisplayPath()
    {
        if (startGridPosition == noValue || endGridPosition == noValue) return;

        pathStack = AStar.BuildPath(instantiatedRoom.room, startGridPosition, endGridPosition);
        Debug.Log(":)");
        if (pathStack == null) return;

        foreach (Vector3 worldPosition in pathStack)
        {
            Debug.Log("dens");
            pathTileMap.SetTile(grid.WorldToCell(worldPosition), startPathTile);
        }
    }
    private void StaticEventHandler_OnRoomChanged(RoomChangedEventArgs roomChangedEventArgs)
    {
        pathStack = null;
        instantiatedRoom = roomChangedEventArgs.room.instantiatedRoom;
        frontTileMap = instantiatedRoom.transform.Find("Grid/Tilemap4_Front").GetComponent<Tilemap>();
        grid = instantiatedRoom.transform.GetComponentInChildren<Grid>();
        startGridPosition = noValue;
        endGridPosition = noValue;

        SetUpPathTilemap();
    }

    private void SetUpPathTilemap()
    {
        Transform tilemapCloneTransform = instantiatedRoom.transform.Find("Grid/Tilemap4_Front(Clone)");
        if (tilemapCloneTransform == null)
        {
            pathTileMap = Instantiate(frontTileMap, grid.transform);
            pathTileMap.GetComponent<TilemapRenderer>().sortingOrder = 2;
            pathTileMap.GetComponent<TilemapRenderer>().material = GameResources.Instance.litMaterial;
            pathTileMap.gameObject.tag = "Untagged";
        }
        else
        {
            pathTileMap = instantiatedRoom.transform.Find("Grid/Tilemap4_Front(Clone)").GetComponent<Tilemap>();
            pathTileMap.ClearAllTiles();
        }
    }
}
