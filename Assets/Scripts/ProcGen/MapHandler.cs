using System.Collections.Generic;
using UnityEngine;

public class MapHandler : MonoBehaviour
{
    public Tile[,] tileGrid = new Tile[9, 9];
    public GameObject[,] unitGrid = new GameObject[9, 9];
    public GameObject testPlayer;
    public GameObject testEnemy;
    public float playerOffset;

    [SerializeField]
    private CombatHandler _combatHandler; 

    public void PlaceUnits()
    {
        List<ClassVitals> playerTeam = _combatHandler.PlayerList();
        int playerCount = 0;
        List<ClassVitals> enemyTeam = _combatHandler.EnemyList();
        int enemyCount = 0;

        for (int j = 0; j < tileGrid.GetLength(0); j++)
        {
            for (int i = 0; i < tileGrid.GetLength(1); i++)
            {
                Debug.Log(tileGrid[i, j]._tileType);
                Debug.Log(tileGrid[i, j].transform.position);
                if (tileGrid[i,j]._tileType == Tile.TileType.Spawn)
                {
                    Debug.Log("spawning");
                    Debug.Log(tileGrid[i, j].name);
                    if (j == 0)
                    {
                        GameObject bloxSpawned = playerTeam[playerCount].gameObject;
                        bloxSpawned.transform.position = tileGrid[i, j].transform.position = new Vector3(0, playerOffset + 0.2f, 0);
                        bloxSpawned.transform.SetParent(transform);
                        playerTeam[playerCount]._currPos = new Vector2(i, j);
                        //GameObject bloxSpawned = Instantiate(playerTeam[playerCount]._bloxObject, tileGrid[i, j].transform.position + new Vector3(0, playerOffset + 0.2f, 0), Quaternion.identity, transform);
                        unitGrid[i, j] = bloxSpawned;        //^change to a blox prefab
                        // test code -> unitGrid[i, j] = Instantiate(testPlayer, tileGrid[i, j].location + new Vector3(0, playerOffset + 0.2f, 0), Quaternion.identity, transform);
                        playerCount++;
                    }
                    else
                    {
                        GameObject bloxSpawned = enemyTeam[enemyCount].gameObject;
                        bloxSpawned.transform.position = tileGrid[i, j].transform.position = new Vector3(0, playerOffset + 0.2f, 0);
                        bloxSpawned.transform.SetParent(transform);
                        enemyTeam[enemyCount]._currPos = new Vector2(i, j);
                        //GameObject bloxSpawned = Instantiate(enemyTeam[enemyCount]._bloxObject, tileGrid[i, j].transform.position + new Vector3(0, playerOffset + 0.2f, 0), Quaternion.identity, transform);
                        unitGrid[i, j] = bloxSpawned;        //^change to a blox prefab
                        // test code -> unitGrid[i, j] = Instantiate(testEnemy, tileGrid[i, j].location + new Vector3(0, playerOffset + 0.2f, 0), Quaternion.identity, transform);
                        enemyCount++;
                    }
                    
                }
            }
        }
    }


    public Tile[] FindTilesNearUnit(ClassVitals referenceUnit)
    {
        Tile[] nearbyTiles = new Tile[4];
        int tileNumber = 0;
        for (int i = Mathf.Clamp((int)(referenceUnit._currPos.x - 1), 0, 9); i <= (int)(referenceUnit._currPos.x + 1); i++)
        {
            if (i != referenceUnit._currPos.x)
            {
                nearbyTiles[tileNumber] = tileGrid[i, (int)(referenceUnit._currPos.y)];
            }
        }
        for (int j = Mathf.Clamp((int)(referenceUnit._currPos.y - 1), 0, 9); j <= (int)(referenceUnit._currPos.y + 1); j++)
        {
            if (j != referenceUnit._currPos.y)
            {
                nearbyTiles[tileNumber] = tileGrid[(int)(referenceUnit._currPos.x), j];
            }
        }
        return nearbyTiles;
    }

    public void Populate()
    {
        _combatHandler.PopulateTurns();
    }


}
