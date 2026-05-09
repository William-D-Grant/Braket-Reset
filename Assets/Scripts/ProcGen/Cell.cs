using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool collapsed;
    public Tile[] tileOptions;
    public Vector2 arrayPosition;

    public void CreateCell(bool collapseState, Tile[] tiles, Vector2 cellPosition)
    {
        collapsed = collapseState;
        tileOptions = tiles;
        arrayPosition = cellPosition;
    }

    public void RecreateCell(Tile[] tiles)
    {
        tileOptions = tiles;
    }
}
