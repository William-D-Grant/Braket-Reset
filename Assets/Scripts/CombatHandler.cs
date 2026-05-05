/***************************************************************
* Filename:       	CombatHandler.cs                           *
* Authors:        	Noah Stern                                 *
* Version Authors:	Noah Stern                                 *
* Current Version:  0.0.1                                      *
* Previous Version: 0.0.0                                      *
* Creation Date:  	May 4, 2026                                *
* Last Modified:  	May 4, 2026                                *
* Due Date:       	May 14th, 2026                             *
* Course:         	CPSC 323                                   *
* Professor Name: 	Professor Jacklitsch                       *
* Project:        	Braket Reset                               *
* Purpose:        	Handles a single combat between the player *
*                   and an enemy                               *
* Version Changes:	Created and finished                       *
****************************************************************/

using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public class CombatHandler : MonoBehaviour
{
    //The RunManager responsible for this run
    private RunManager _runManager;

    //The current round (rounds are made up of turns)
    private int _round = 1;

    //The list of Blox in the order they'll take turns in
    private List<ClassVitals> _turnList;

    //What turn it is in the round
    private int _turn = 0;


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: Start                                                           */
    /* Description: Sets the RunManager and determines turn order                     */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    private void Start()
    {
        _runManager = RunManager._singletonInstance;

        PopulateTurns();
    }//end Start

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: PopulateTurns                                                   */
    /* Description: Determines the turn order of the Blox by their speed values       */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    //OrderByDescending taken from Bernard Vander Beken on https://stackoverflow.com/questions/5344805/linq-orderby-descending-query
    public void PopulateTurns()
    {
        //Clears the turn list
        _turnList.Clear();

        //Adds both the player's and the enemy's teams of Blox into the turn order
        _turnList.AddRange(_runManager.playerTeam);
        _turnList.AddRange(_runManager.enemyTeam);

        //Sorts the turn list by the Blox's speed value
        _turnList = _turnList.OrderByDescending(blox => blox.GetSpeed()).ToList();

    }//end Populate turns


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: ShiftTurn                                                       */
    /* Description: Changes the turn to the next blox, returns if that blox is a      */
    /*              player or an enemy                                                */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public Team ShiftTurn()
    {
        //Update the turn number
        _turn++;

        //If the turn number is higher than the number of blox in _turnList, then reset the turn order
        if(_turn > _turnList.Count)
        {
            _turn = 0;
            _round++;
        }

        return _turnList[_round].GetTeam();
    }//end shiftTurn


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: CurrentUnit                                                     */
    /* Description: Returns what Blox is currently taking their turn                  */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public ClassVitals CurrentUnit()
    {
        return _turnList[_turn];
    }//end currentUnit


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: DefeatUnit                                                      */
    /* Description: Removes a Blox from the turn order and checks if a team won or not*/
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void DefeatUnit(ClassVitals killedUnit)
    {
        //remove the blox from the turn order
        _turnList.Remove(killedUnit);


        //If the Blox was on the Player's team, remove it from their team
        if (killedUnit.GetTeam() == Team.Player)
        {
            _runManager.playerTeam.Remove(killedUnit);
        }//end if
        else 
        { //If the Blox was on the Enemy's team, remove it from their team
            _runManager.enemyTeam.Remove(killedUnit);
        }//end else
        
        //If the player won, end the combat
        if(CheckVictor() == Team.Player)
        {
            _runManager.EndCombat();
        }//end if
        else
        {//If the enemy won, end the Run
            _runManager.EndRun();
        }//end if else

    }//end DefeatUnit


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: CheckVictor                                                     */
    /* Description: Checks if either the player or enemy has one by checking counts   */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public Team CheckVictor()
    {
        //If the player ran out of Blox, return the enemy won
        if(_runManager.playerTeam.Count == 0)
        {
            return Team.Enemy;
        }//end if
        //If the enemy ran out of Blox, return the player won
        else if (_runManager.enemyTeam.Count == 0)
        {
            return Team.Player;
        }

        //If neither team won, then return that neither won
        return Team.Neither;

    }//end CheckVictor

    /*i dont know what to do with these, are they just gettors?
    public void PlayerList()
    {

    }

    public void EnemyList()
    {

    }*/

}

