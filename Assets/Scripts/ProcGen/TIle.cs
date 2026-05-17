/****************************************************************
* Filename:       	Tile.cs                                     *
* Authors:        	William Grant                               *
* Version Authors:	William Grant                               *
* Current Version:  0.4.0                                       *
* Previous Version: 0.3.2                                       *
* Creation Date:  	May 6, 2026                                 *
* Last Modified:  	May 11, 2026                                *
* Due Date:       	May 17th, 2026                              *
* Course:         	CPSC 323                                    *
* Professor Name: 	Professor Jacklitsch                        *
* Project:        	Braket Reset                                *
* Purpose:        	Tracks each tile on a map, their position   *
*                   on the grid, the type of tile it is, and    *
*                   allowed neighbors to spawn.                 *
* Version Changes:	Refactored for WFC                          *
****************************************************************/
using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Potential neighbor tiles
    //# Taken from Game Dev Garnet's "Easy City Generator Tutorial for Unity!"  on May 11, 2026. https://www.youtube.com/watch?v=iJ_GnGD5BZA
    public Tile[] upNeighbors;
    public Tile[] downNeighbors;
    public Tile[] rightNeighbors;
    public Tile[] leftNeighbors;

    //Type of tiles, to be used in effects
    public enum TileType
    {
        Normal,
        Wall,
        Damage,
        Slow,
        Hazard,
        Spawn
    }

    // Current tile type for this tile
    public TileType _tileType;

    // Position on the tileGrid
    public Vector2 position;
}
