using UnityEngine;

public class MapHandler : MonoBehaviour
{
    public Tile[,] tileGrid;
    public GameObject[,] unitGrid = new GameObject[9, 9];
    public GameObject testPlayer;
    public GameObject testEnemy;
    public float playerOffset;

    public void PlaceUnits()
    {
        for (int i = 0; i < tileGrid.GetLength(0); i++)
        {
            for (int j = 0; j < tileGrid.GetLength(1); j++)
            {
                if (tileGrid[i,j]._tileType == Tile.TileType.Spawn)
                {
                    if (i == 0)
                    {
                        unitGrid[i, j] = Instantiate(testPlayer, tileGrid[i, j].location + new Vector3(0, playerOffset + 0.2f, 0), Quaternion.identity, transform);
                    }
                    else
                    {
                        unitGrid[i, j] = Instantiate(testEnemy, tileGrid[i, j].location + new Vector3(0, playerOffset + 0.2f, 0), Quaternion.identity, transform);
                    }
                    
                }
            }
        }
    }
}
