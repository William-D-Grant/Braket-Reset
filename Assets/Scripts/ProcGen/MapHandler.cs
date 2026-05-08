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

    public Tile[] FindTilesNearUnit(ClassVitals referenceUnit)
    {
        Tile[] nearbyTiles = new Tile[4];
        int tileNumber = 0;
        for (int i = (int)(referenceUnit._currPos.x - 1); i <= (int)(referenceUnit._currPos.x + 1); i++)
        {
            if (i != referenceUnit._currPos.x)
            {
                nearbyTiles[tileNumber] = tileGrid[i, (int)(referenceUnit._currPos.y)];
            }
        }
        for (int j = (int)(referenceUnit._currPos.y - 1); j <= (int)(referenceUnit._currPos.y + 1); j++)
        {
            if (j != referenceUnit._currPos.y)
            {
                nearbyTiles[tileNumber] = tileGrid[(int)(referenceUnit._currPos.x), j];
            }
        }
        return nearbyTiles;
    }
}
