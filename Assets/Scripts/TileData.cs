using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class TileData : ScriptableObject
{
    public TileBase tile;

    public int moveDifficulty;
    public int rangeMultiplier;

    public bool emptyTile;
}
