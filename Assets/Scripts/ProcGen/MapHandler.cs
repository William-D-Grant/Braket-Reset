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
        _combatHandler.ClearCurrentBlox();
        List<GameObject> playerTeam = _combatHandler.PlayerList();
        Debug.Log(playerTeam[0].name);
        int playerCount = 0;
        List<GameObject> enemyTeam = _combatHandler.EnemyList();
        int enemyCount = 0;

        //TEST
        foreach (GameObject blox in playerTeam)
        {
            blox.SetActive(false);
        }

        foreach (GameObject blox in enemyTeam)
        {
            blox.SetActive(false);
        }
        //TEST

        for (int j = 0; j < tileGrid.GetLength(0); j++)
        {
            for (int i = 0; i < tileGrid.GetLength(1); i++)
            {
                if (tileGrid[i,j]._tileType == Tile.TileType.Spawn)
                {
                    Debug.Log("spawning");
                    Debug.Log(tileGrid[i, j].name);
                    Debug.Log(playerTeam[0].name);
                    if (j == 0)
                    {
                        //NEW CODE BUT ALSO KINDA OLD IVE DONE THIS BEFORE I THINK
                        GameObject bloxSpawned = playerTeam[playerCount];
                        bloxSpawned.transform.position = tileGrid[i, j].transform.position + new Vector3(0, playerOffset + 0.2f, 0);
                        bloxSpawned.SetActive(true);
                        unitGrid[i, j] = bloxSpawned;
                        ClassVitals bloxVitals = bloxSpawned.GetComponent<ClassVitals>();
                        bloxVitals._currPos = new Vector2(i, j);
                        bloxVitals._team = Team.Player;
                        playerCount++;
                        _combatHandler.AddCurrentBlox(bloxSpawned);
                        //NEW CODE

                        /*
                        //GameObject bloxSpawned = playerTeam[playerCount].gameObject;
                        //bloxSpawned.transform.position = tileGrid[i, j].transform.position = new Vector3(0, playerOffset + 0.2f, 0);
                        //bloxSpawned.transform.SetParent(transform);
                        //playerTeam[playerCount].GetComponent<ClassVitals>()._currPos = new Vector2(i, j);
                        GameObject bloxSpawned = Instantiate(playerTeam[playerCount], tileGrid[i, j].transform.position + new Vector3(0, playerOffset + 0.2f, 0), Quaternion.identity, transform);
                        
                        unitGrid[i, j] = bloxSpawned;        //^change to a blox prefab
                        //bloxSpawned.GetComponent<ClassVitals>().InitializeBlox(playerTeam[playerCount].GetComponent<ClassVitals>().
                        bloxSpawned.GetComponent<ClassVitals>()._currPos = new Vector2(i, j);
                        bloxSpawned.GetComponent<ClassVitals>()._team = Team.Player;
                        //            playerTeam[playerCount] = bloxSpawned;
                        // test code -> unitGrid[i, j] = Instantiate(testPlayer, tileGrid[i, j].location + new Vector3(0, playerOffset + 0.2f, 0), Quaternion.identity, transform);
                        playerCount++;
                        _combatHandler.AddCurrentBlox(bloxSpawned);
                        */
                    }
                    else
                    {

                        //NEW CODE BUT ALSO KINDA OLD IVE DONE THIS BEFORE I THINK
                        GameObject bloxSpawned = enemyTeam[enemyCount];
                        bloxSpawned.transform.position = tileGrid[i, j].transform.position + new Vector3(0, playerOffset + 0.2f, 0);
                        bloxSpawned.SetActive(true);
                        unitGrid[i, j] = bloxSpawned;
                        ClassVitals bloxVitals = bloxSpawned.GetComponent<ClassVitals>();
                        bloxVitals._currPos = new Vector2(i, j);
                        bloxVitals._team = Team.Enemy;
                        enemyCount++;
                        _combatHandler.AddCurrentBlox(bloxSpawned);
                        //NEW CODE

                        /*
                        //GameObject bloxSpawned = enemyTeam[enemyCount].gameObject;
                        //bloxSpawned.transform.position = tileGrid[i, j].transform.position = new Vector3(0, playerOffset + 0.2f, 0);
                        //bloxSpawned.transform.SetParent(transform);
                        //enemyTeam[enemyCount].GetComponent<ClassVitals>()._currPos = new Vector2(i, j);
                        GameObject bloxSpawned = Instantiate(enemyTeam[enemyCount], tileGrid[i, j].transform.position + new Vector3(0, playerOffset + 0.2f, 0), Quaternion.identity, transform);
                        unitGrid[i, j] = bloxSpawned;        //^change to a blox prefab
                        bloxSpawned.GetComponent<ClassVitals>()._currPos = new Vector2(i, j);
                        bloxSpawned.GetComponent<ClassVitals>()._team = Team.Enemy;
                        //              enemyTeam[enemyCount] = bloxSpawned;
                        // test code -> unitGrid[i, j] = Instantiate(testEnemy, tileGrid[i, j].location + new Vector3(0, playerOffset + 0.2f, 0), Quaternion.identity, transform);
                        enemyCount++;
                        _combatHandler.AddCurrentBlox(bloxSpawned);
                        */
                    }
                    
                }
            }
        }

        //_combatHandler.RegisterDefeatEvent();
    }

    public void ChangePosition(GameObject referenceUnit, Vector2 newPosition)
    {
        unitGrid[(int)referenceUnit.GetComponent<ClassVitals>()._currPos.x, (int)referenceUnit.GetComponent<ClassVitals>()._currPos.y] = null;
        referenceUnit.GetComponent<ClassVitals>()._currPos = newPosition;
        unitGrid[(int)newPosition.x, (int)newPosition.y] = referenceUnit;
    }


    public Tile[] FindTilesNearUnit(ClassVitals referenceUnit)
    {
        Tile[] nearbyTiles = new Tile[4];
        Debug.Log(referenceUnit._currPos);
        //int tileNumber = 0;
        if (referenceUnit._currPos.x - 1 >= 0)
        {
            nearbyTiles[0] = tileGrid[(int)referenceUnit._currPos.x - 1, (int)referenceUnit._currPos.y];
        }
        if (referenceUnit._currPos.x + 1 < 9)
        {
            nearbyTiles[1] = tileGrid[(int)referenceUnit._currPos.x + 1, (int)referenceUnit._currPos.y];
        }
        if (referenceUnit._currPos.y - 1 >= 0)
        {
            nearbyTiles[2] = tileGrid[(int)referenceUnit._currPos.x, (int)referenceUnit._currPos.y - 1];
        }
        if (referenceUnit._currPos.y + 1 < 9)
        {
            nearbyTiles[3] = tileGrid[(int)referenceUnit._currPos.x, (int)referenceUnit._currPos.y + 1];

        }
        /*for (int j = (int)referenceUnit._currPos.x - 1; j <= (int)referenceUnit._currPos.x + 1; j++)
        {
            if (j != referenceUnit._currPos.x && j >= 0 && j < 9)
            {
                nearbyTiles[tileNumber] = tileGrid[j, (int)(referenceUnit._currPos.y)];
            }
        }
        for (int i = (int)referenceUnit._currPos.y - 1; i <= (int)referenceUnit._currPos.y + 1; i++)
        {
            if (i != referenceUnit._currPos.y && i >= 0 && i < 9)
            {
                nearbyTiles[tileNumber] = tileGrid[(int)(referenceUnit._currPos.x), i];
            }
        }*/
        return nearbyTiles;
    }

    public List<Tile> FindAttackTilesNearTile(Tile referenceTile)
    {
        List<Tile> nearbyTiles = new List<Tile>();
        //int tileNumber = 0;
        if (referenceTile.position.x - 1 >= 0)
        {
            if (unitGrid[(int)referenceTile.position.x - 1, (int)referenceTile.position.y] == null)
            {
                nearbyTiles.Add(tileGrid[(int)referenceTile.position.x - 1, (int)referenceTile.position.y]);
            }
            else if (unitGrid[(int)referenceTile.position.x - 1, (int)referenceTile.position.y].GetComponent<ClassVitals>()._team == Team.Player)
            {
                nearbyTiles.Add(tileGrid[(int)referenceTile.position.x - 1, (int)referenceTile.position.y]);
            }
        }
        if (referenceTile.position.x + 1 < 9)
        {
            if (unitGrid[(int)referenceTile.position.x + 1, (int)referenceTile.position.y] == null)
            {
                nearbyTiles.Add(tileGrid[(int)referenceTile.position.x + 1, (int)referenceTile.position.y]);
            }
            else if (unitGrid[(int)referenceTile.position.x + 1, (int)referenceTile.position.y].GetComponent<ClassVitals>()._team == Team.Player)
            {
                nearbyTiles.Add(tileGrid[(int)referenceTile.position.x + 1, (int)referenceTile.position.y]);
            }
        }
        if (referenceTile.position.y - 1 >= 0)
        {
            if (unitGrid[(int)referenceTile.position.x, (int)referenceTile.position.y - 1] == null)
            {
                nearbyTiles.Add(tileGrid[(int)referenceTile.position.x, (int)referenceTile.position.y - 1]);
            }
            else if (unitGrid[(int)referenceTile.position.x, (int)referenceTile.position.y - 1].GetComponent<ClassVitals>()._team == Team.Player)
            {
                nearbyTiles.Add(tileGrid[(int)referenceTile.position.x, (int)referenceTile.position.y - 1]);
            }
        }
        if (referenceTile.position.y + 1 < 9)
        {
            if (unitGrid[(int)referenceTile.position.x, (int)referenceTile.position.y + 1] == null)
            {
                nearbyTiles.Add(tileGrid[(int)referenceTile.position.x, (int)referenceTile.position.y + 1]);
            }
            else if (unitGrid[(int)referenceTile.position.x, (int)referenceTile.position.y + 1].GetComponent<ClassVitals>()._team == Team.Player)
            {
                nearbyTiles.Add(tileGrid[(int)referenceTile.position.x, (int)referenceTile.position.y + 1]);
            }
        }
        return nearbyTiles;
    }

    public void Populate()
    {
        _combatHandler.PopulateTurns();
    }


}
