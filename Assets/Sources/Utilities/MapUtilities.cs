﻿using UnityEngine;
using System.Collections;
using Entitas;

public static class MapUtilities {

    /// <summary>
    /// Tile height used to defines all the other static variables
    /// </summary>
    public const float TileHeight = 1f;

    #region Public static helper variables

    public static float TileSize
    {
        get
        {
            return TileHeight / 2f;
        }
    }
    public static float TileWidth
    {
        get
        {
            return TileHeight * (Mathf.Sqrt(3) / 2f);
        }
    }
    public static float TileVerticalDistance
    {
        get
        {
            return TileHeight * 0.75f;
        }
    }
    public static float TileHorizontalDistance
    {
        get
        {
            return TileWidth;
        }
    }

    #endregion

    #region Distances

    /// <summary>
    /// Returns the distance between two tiles
    /// </summary>
    /// <param name="tileEntityA">First tile entity</param>
    /// <param name="tileEntityB">Second tile entity</param>
    /// <returns>Distance between two tiles. -1 if an error occurates.</returns>
    public static float GetDistance(Entity tileEntityA, Entity tileEntityB)
    {
        if (tileEntityA.hasMapPosition && tileEntityB.hasMapPosition)
            return (Mathf.Abs(tileEntityA.mapPosition.Position.x - tileEntityB.mapPosition.Position.x) +
                Mathf.Abs(tileEntityA.mapPosition.Position.y - tileEntityB.mapPosition.Position.y) +
                Mathf.Abs(tileEntityA.mapPosition.Position.z - tileEntityB.mapPosition.Position.z) / 2f);
        return -1f;
    }

    /// <summary>
    /// Returns the distance between two positions
    /// </summary>
    /// <param name="mapPositionA">First position</param>
    /// <param name="mapPositionB">Second position</param>
    /// <returns>Distance between two positions.</returns>
    public static float GetDistance(Vector3 mapPositionA, Vector3 mapPositionB)
    {
        return (Mathf.Abs(mapPositionA.x - mapPositionB.x) +
            Mathf.Abs(mapPositionA.y - mapPositionB.y) +
            Mathf.Abs(mapPositionA.z - mapPositionB.z)) / 2f;
    }

    #endregion

    #region Map directions
    public enum EDirection
    {
        East,
        NorthEast,
        NorthWest,
        West,
        SouthWest,
        SouthEast
    }

    /// <summary>
    /// Directions ordered based on EDirection enum
    /// </summary>
    private static Vector3[] directions {
        get
        {
            return new[] {
                new Vector3(1, -1, 0),
                new Vector3(1, 0, -1),
                new Vector3(0, 1, -1),
                new Vector3(-1, 1, 0),
                new Vector3(-1, 0, 1),
                new Vector3(0, -1, 1)
            };
        }
    }

    /// <summary>
    /// Returns a precomputed direction
    /// </summary>
    /// <param name="direction">Chosen direction</param>
    /// <returns>Direction in Map Position reference</returns>
    public static Vector3 GetDirection(EDirection direction)
    {
        return directions[(int)direction];
    }
    #endregion

    #region Position conversion helpers
    /// <summary>
    /// Returns corresponding world position given a map position
    /// </summary>
    /// <param name="MapPosition">Map Position to convert</param>
    /// <returns>Corresponding World Position</returns>
    public static Vector3 MapToWorldPosition(Vector3 MapPosition)
    {
        Vector3 WorldPosition = new Vector3();

        WorldPosition.x = TileSize * Mathf.Sqrt(3) * (MapPosition.x + (0.5f * MapPosition.z));
        WorldPosition.y = TileSize * 1.5f * MapPosition.z;

        // Here is a -1 factor to have a descending axis instead of ascending
        // Unity axises in 2D :
        //    Y ^ 
        //      |   X
        //       --->

        // With -1 factor
        //         X
        //      --->
        //      |
        //      V Y
        WorldPosition.y *= -1f;

        return WorldPosition;
    }

    public static Vector3 WorldToMapPosition(Vector3 WorldPosition)
    {
        // TODO :
        return Vector3.zero;
    }
    #endregion

    #region Neighbors
    /// <summary>
    /// Returns the neighbor entity in the direction chosen
    /// </summary>
    /// <param name="tileEntity">Origin tile</param>
    /// <param name="direction">Direction to search for</param>
    /// <returns>Neighbor tile</returns>
    public static Entity GetNeighbor(Entity tileEntity, EDirection direction)
    {
        if(tileEntity.hasMapPosition)
            return Pools.sharedInstance.core.map.Map.FindEntityAtMapPosition(tileEntity.mapPosition.Position + GetDirection(direction));
        return null;
    }

    /// <summary>
    /// Returns the neighbor entity in the direction chosen
    /// </summary>
    /// <param name="originPosition">Origin position</param>
    /// <param name="direction">Direction to search for</param>
    /// <returns>Neighbor tile</returns>
    public static Entity GetNeighbor(Vector3 originPosition, EDirection direction)
    {
        return Pools.sharedInstance.core.map.Map.FindEntityAtMapPosition(originPosition + GetDirection(direction));
    }
    #endregion
}
