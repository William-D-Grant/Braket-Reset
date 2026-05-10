/***************************************************************
* Filename:       	ClassAbstract.cs                           *
* Authors:        	Noah Stern                                 *
* Version Authors:	Noah Stern                                 *
* Current Version:  0.0.2                                      *
* Previous Version: 0.0.1                                      *
* Creation Date:  	April 28, 2026                             *
* Last Modified:  	April 30, 2026                             *
* Due Date:       	May 14th, 2026                             *
* Course:         	CPSC 323                                   *
* Professor Name: 	Professor Jacklitsch                       *
* Project:        	Braket Reset                               *
* Purpose:        	An abstract class for the Blox's potential *
*                   classes it could be, used as a template    *
*                   for all different Blox classes             *
* Version Changes:	Commented everything                       *
****************************************************************/
using UnityEngine;

public abstract class ClassAbstract
{

    //The class' name
    public string className;

    //The class' maximum health points
    public float classMaxHP;

    //The class' speed
    public int classSPD;

    //The class' attack
    public int classATK;

    //The class's defense
    public int classDEF;

    //The class' tile movement
    public int classTM;

    //The class' hype generation
    public int classHype;

    //The class' range of their attack
    public int classRange;

    //The class' luck 
    public int classLuck;

    //The array of the class' abilities
    public string[] abilityArray;

    //The Blox's team
    public Team team;

    //The Blox's model
    public GameObject bloxObject;


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: CreateClass                                                     */
    /* Description: A method meant to be overridden in classes like FighterClass or   */
    /*              TankClass to get the class's stats                                */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public abstract void CreateClass();

}//end ClassAbstract
