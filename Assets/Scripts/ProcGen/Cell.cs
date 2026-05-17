/****************************************************************
* Filename:       	Cell.cs                                     *
* Authors:        	William Grant                               *
* Version Authors:	William Grant                               *
* Current Version:  0.4.0                                       *
* Creation Date:  	May 11, 2026                                *
* Due Date:       	May 17th, 2026                              *
* Course:         	CPSC 323                                    *
* Professor Name: 	Professor Jacklitsch                        *
* Project:        	Braket Reset                                *
* Purpose:        	Keeps track of status of each cell in the   *
*                   grid where a tile will be created for       *
*                   decision on how to collapse.                *
* Version Changes:	Created                                     *
****************************************************************/
//# Taken from Game Dev Garnet's "Easy City Generator Tutorial for Unity!"  on May 11, 2026. https://www.youtube.com/watch?v=iJ_GnGD5BZA
using UnityEngine;

public class Cell : MonoBehaviour
{
    // Whether the cell has been already collapsed
    public bool collapsed;

    // Dynamically filters options for tile placement
    public Tile[] tileOptions;

    public Vector2 arrayPosition;

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: CreateCell()                                                    */
    /* Description: A 'constructor' for this cell to be placed.                       */
    /* Parameters: bool collapseState - Whether this Cell is collapsed                */
    /*             Tile[] tiles - The options to collapse this cell to                */
    /*             Vector2 cellPosition - The grid position the cell is placed at.    */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    //# Taken from Game Dev Garnet's "Easy City Generator Tutorial for Unity!"  on May 11, 2026. https://www.youtube.com/watch?v=iJ_GnGD5BZA
    public void CreateCell(bool collapseState, Tile[] tiles, Vector2 cellPosition)
    {
        collapsed = collapseState;
        tileOptions = tiles;
        arrayPosition = cellPosition;
    }

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: RecreateCell()                                                  */
    /* Description: Used when options need to be regenerated.                         */
    /* Parameters: Tile[] tiles - The options to collapse this cell to                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    //# Taken from Game Dev Garnet's "Easy City Generator Tutorial for Unity!"  on May 11, 2026. https://www.youtube.com/watch?v=iJ_GnGD5BZA
    public void RecreateCell(Tile[] tiles)
    {
        tileOptions = tiles;
    }
}
