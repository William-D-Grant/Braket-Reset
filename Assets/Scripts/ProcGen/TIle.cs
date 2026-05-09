using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Tile[] upNeighbors;
    public Tile[] downNeighbors;
    public Tile[] rightNeighbors;
    public Tile[] leftNeighbors;

    public enum TileType
    {
        Normal,
        Wall,
        Damage,
        Slow,
        Hazard,
        Spawn
    }

    public TileType _tileType;
}
