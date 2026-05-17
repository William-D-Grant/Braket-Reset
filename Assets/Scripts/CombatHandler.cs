/***************************************************************
* Filename:       	CombatHandler.cs                           *
* Authors:        	Noah Stern                                 *
* Version Authors:	Noah Stern                                 *
* Current Version:  0.2.2                                      *
* Previous Version: 0.2.1                                      *
* Creation Date:  	May 4, 2026                                *
* Last Modified:  	May 16, 2026                               *
* Due Date:       	May 17th, 2026                             *
* Course:         	CPSC 323                                   *
* Professor Name: 	Professor Jacklitsch                       *
* Project:        	Braket Reset                               *
* Purpose:        	Handles a single combat between the player *
*                   and an enemy                               *
* Version Changes:	Updated EndCombat ending logic             *
****************************************************************/

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
//using UnityEditor.Experimental.GraphView;

public class CombatHandler : MonoBehaviour
{
    //The RunManager responsible for this run
    private RunManager _runManager;

    //The current round (rounds are made up of turns)
    private int _round = 1;

    //The list of Blox in the order they'll take turns in
    private List<GameObject> _turnList = new List<GameObject>();

    //What turn it is in the round
    private int _turn = 0;

    [SerializeField]
    //Player controller to pass turn to
    private PlayerController _playerController;

    [SerializeField]
    //Player controller to pass turn to
    private EnemyController _enemyHandler;

    public List<GameObject> _currentPlayerBlox = new List<GameObject>();
    private List<GameObject> _currentEnemyBlox = new List<GameObject>();

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: Start                                                           */
    /* Description: Sets the RunManager                                               */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    private void Start()
    {
        _runManager = RunManager._singletonInstance;

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
        Debug.Log("Populating Turns");
        //Clears the turn list
        _turnList.Clear();

        Debug.Log(_runManager.playerTeam[0]);

        _turnList.AddRange(_currentPlayerBlox);

        _turnList.AddRange(_currentEnemyBlox);

        //Sorts the turn list by the Blox's speed value
        _turnList = _turnList.OrderByDescending(blox => blox.GetComponent<ClassVitals>().GetSpeed()).ToList();

        _turn = -1;
        _round = 1;
        Debug.Log("At other debugs");
        Debug.Log(_turnList.Count);
        Debug.Log(_turnList[0]);

        ShiftTurn();

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
    public void ShiftTurn()
    {
        //Update the turn number
        _turn++;

        Debug.Log("Shifting turn");

        //If the turn number is higher than the number of blox in _turnList, then reset the turn order
        if(_turn >= _turnList.Count)
        {
            Debug.Log("Resetting Turns");
            _turn = 0;
            _round++;
            for(int i = 0; i < _turnList.Count; i++)
            {
                _turnList[i].GetComponent<ClassVitals>().TurnTick();
                _turnList = _turnList.OrderByDescending(blox => blox.GetComponent<ClassVitals>().GetSpeed()).ToList();
            }

            }

        Debug.Log("Checking if unity is player");
        Debug.Log(_turnList[_turn].GetComponent<ClassVitals>().GetTeam());
        if (_turnList[_turn].GetComponent<ClassVitals>().GetTeam() == Team.Player)
        {
            Debug.Log("Enabling Player");
            _playerController.EnablePlayer(_turnList[_turn]);
        }

        if (_turnList[_turn].GetComponent<ClassVitals>().GetTeam() == Team.Enemy)
        {
            Debug.Log("Enabling Enemmy");
            _enemyHandler.EnableEnemy(_turnList[_turn]);
        }

    }//end shiftTurn


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: CurrentUnit                                                     */
    /* Description: Returns what Blox is currently taking their turn                  */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public GameObject CurrentUnit()
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
        _turnList.Remove(killedUnit.gameObject);


        //If the Blox was on the Player's team, remove it from their team
        if (killedUnit.GetTeam() == Team.Player)
        {
            _currentPlayerBlox.Remove(killedUnit.gameObject);
            //_runManager.playerTeam.Remove(killedUnit.gameObject);
        }//end if
        else 
        { //If the Blox was on the Enemy's team, remove it from their team
            _currentEnemyBlox.Remove(killedUnit.gameObject);
            Destroy(killedUnit.gameObject);
            //_runManager.enemyTeam.Remove(killedUnit.gameObject);
        }//end else
        Debug.LogWarning("Player count: " + _currentPlayerBlox.Count);
        Debug.LogWarning("Enemy count: " + _currentEnemyBlox.Count);
        //If the player won, end the combat
        if (CheckVictor() == Team.Player)
        {
            _runManager.EndCombat(killedUnit.GetTeam());
        }//end if
        else if (CheckVictor() == Team.Enemy)
        {//If the enemy won, end the Run
            _runManager.EndCombat(killedUnit.GetTeam());
        }

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
        if(_currentPlayerBlox.Count == 0)  //was runManager.playerTeam.Count
        {
            Debug.LogWarning("EnemyWon");
            return Team.Enemy;
        }//end if
        //If the enemy ran out of Blox, return the player won
        else if (_currentEnemyBlox.Count == 0)
        {
            Debug.LogWarning("PlayerWon");
            return Team.Player;
        }

        //If neither team won, then return that neither won
        return Team.Neither;

    }//end CheckVictor


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: PlayerList                                                      */
    /* Description: A gettor for the player's current list of Blox in this run        */
    /* Parameters: N/A                                                                */
    /* Return Value: List<GameObject> _runManager.playerTeam: the player's team of    */
    /*               Blox                                                             */
    /*                                                                                */
    /**********************************************************************************/
    public List<GameObject> PlayerList()
    {
        return _runManager.playerTeam;
    }//end PlayerList


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: EnemyList                                                       */
    /* Description: A gettor for the enemy's current list of Blox                     */
    /* Parameters: N/A                                                                */
    /* Return Value: List<GameObject> _runManager.enemyTeam: the enemy's team of      */
    /*               Blox                                                             */
    /**********************************************************************************/
    public List<GameObject> EnemyList()
    {
        return _runManager.enemyTeam;
    }//end EnemyList



    /**********************************************************************************/
    /*                                                                                */
    /* Function name: AddCurrentBlox                                                  */
    /* Description: Adds a blox to the player's or the enemy's team, also registers   */
    /*              the onDefeated action to every blox                               */
    /* Parameters: GameObject blox: the blox being added to a team                    */
    /* Return Value: N/A                                                              */
    /**********************************************************************************/
    public void AddCurrentBlox(GameObject blox)
    {
        //If its the player's Blox, add it to the player's team
        if (blox.GetComponent<ClassVitals>().GetTeam() == Team.Player)
        {
            _currentPlayerBlox.Add(blox);
        }//end if
        else //otherwise, add it to the enemy's team
        {
            _currentEnemyBlox.Add(blox);
        }//end else

        _turnList.Add(blox);

        //add an onDefeated event
        blox.GetComponent<ClassVitals>().onDefeated += DefeatUnit;
    }//end AddCurrentBlox


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: ClearCurrentBlox                                                */
    /* Description: Clears the turnlist, the player's and the enemy's list of blox    */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /**********************************************************************************/
    public void ClearCurrentBlox()
    {
        _turnList.Clear();
        _currentPlayerBlox.Clear();
        _currentEnemyBlox.Clear();

        _turn = -1;
        _round = 1;
    }//end ClearCurrentBlox

}//end CombatHandler

