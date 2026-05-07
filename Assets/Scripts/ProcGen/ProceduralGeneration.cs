using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    public Vector2 size;
    public int startPos = 0;
    public List<GameObject> normalTypes;
    public List<GameObject> slowTypes;
    public List<GameObject> wallTypes;
    public List<GameObject> damageTypes;
    public List<GameObject> hazardTypes;
    public GameObject spawnTile;
    public Vector2 offset;

    [SerializeField]
    private MapHandler _mapHandler;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BoardGenerator();
        GenerateDungeon();
        _mapHandler.PlaceUnits();
    }

    void GenerateDungeon()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                Tile currentTile = _mapHandler.tileGrid[i,j];
                currentTile.location = new Vector3(i * offset.x, 0, -j * offset.y);
                Quaternion tileRotation = Quaternion.Euler(0, 90, 0);
                switch (currentTile._tileType)
                {
                    case Tile.TileType.Normal:
                        currentTile.tileObject = Instantiate(normalTypes[Mathf.FloorToInt(Random.Range(0, normalTypes.Count))], currentTile.location, tileRotation, transform);
                        break;

                    case Tile.TileType.Slow:
                        currentTile.tileObject = Instantiate(slowTypes[Mathf.FloorToInt(Random.Range(0, slowTypes.Count))], currentTile.location, tileRotation, transform);
                        break;

                    case Tile.TileType.Wall:
                        currentTile.tileObject = Instantiate(wallTypes[Mathf.FloorToInt(Random.Range(0, wallTypes.Count))], currentTile.location, tileRotation, transform);
                        break;

                    case Tile.TileType.Damage:
                        currentTile.tileObject = Instantiate(damageTypes[Mathf.FloorToInt(Random.Range(0, damageTypes.Count))], currentTile.location, tileRotation, transform);
                        break;

                    case Tile.TileType.Hazard:
                        currentTile.tileObject = Instantiate(hazardTypes[Mathf.FloorToInt(Random.Range(0, hazardTypes.Count))], currentTile.location, tileRotation, transform);
                        break;

                    case Tile.TileType.Spawn:
                        currentTile.tileObject = Instantiate(spawnTile, currentTile.location, tileRotation, transform);
                        break;

                    default:
                        break;
                }

            }
        }
        /* if (GameObject.FindGameObjectsWithTag("Spawn Tile").Length != 6)
        {
            Debug.Log("Reloaded");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } */

    }

    void BoardGenerator()
    {
        _mapHandler.tileGrid = new Tile[(int)size.x , (int)size.y];

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                Tile addingTile = new Tile();
                int tileRandomness = Random.Range(0, 10);

                switch(tileRandomness)
                {
                    case <= 5:
                        addingTile._tileType = Tile.TileType.Normal;
                        break;

                    case <= 7:
                        addingTile._tileType = Tile.TileType.Slow;
                        break;

                    case 8:
                        addingTile._tileType = Tile.TileType.Wall;
                        break;

                    case 9:
                        addingTile._tileType = Tile.TileType.Damage;
                        break;

                    case 10:
                        addingTile._tileType = Tile.TileType.Hazard;
                        break;

                    default:
                        break;
                }
                if ((i == 0 || i == size.x-1) && (j == 3 || j == 4 || j == 5))
                {
                    addingTile._tileType = Tile.TileType.Spawn;
                }
                _mapHandler.tileGrid[i, j] = addingTile;
            }
        }
    }
}
