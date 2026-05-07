using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum TileType
    {
        Normal,
        Wall,
        Damage,
        Slow,
        Hazard,
        Spawn
    }

    [SerializeField]
    public GameObject tileObject;

    public TileType _tileType;

    [SerializeField]
    public Vector3 location;
}
