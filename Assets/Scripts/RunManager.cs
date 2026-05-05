/***************************************************************
* Filename:       	RunManager.cs                              *
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
* Purpose:        	Handle all information for a singular run, *
*                   healing the player between fights, ending  *
*                   runs, and getting the enemy team           *
* Version Changes:	Created and finished                       *
****************************************************************/

using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class RunManager : MonoBehaviour
{
    //Make it a singleton
    public static RunManager _singletonInstance { get; private set; }

    //The VictoryHandler to handle when the player wins
    //private VictoryHandler _victoryHandler;

    //The LossHandler to handle when the player loses
    //private LossHandler _lossHandler;

    //The EnemyTeam selector to hold all possible enemy teams, an retrieve team being fought
    private EnemyTeamSelector _enemyTeamSelector;

    //The player's selection of Blox
    private List<ClassAbstract> _playerSelection;

    //The player's Blox
    public List<ClassVitals> playerTeam { get; private set; }

    //The enemy's Blox
    public List<ClassVitals> enemyTeam { get; private set; }

    //The player's current match
    private int _bracketNumber;

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: Awake                                                           */
    /* Description: Makes RunManager a singleton                                      */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    private void Awake()
    {
        if (_singletonInstance == null)
        {
            _singletonInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }//end void

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: HealPlayer                                                      */
    /* Description: Heals the player's Blox after battle and clears their statuses    */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void HealPlayer()
    {
        foreach(ClassVitals blox in playerTeam)
        {
            blox.HealBlox(20);
            blox.ClearStatus();
        }//end foreach

    }//end HealPlayer


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: SelectEnemies                                                   */
    /* Description: Gets the next enemy's team of Blox                                */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void SelectEnemies()
    {
        //Clear the current enemy team
        enemyTeam = new List<ClassVitals>();

        //Make a temporary enemy team so we can access the enemy blox information from the EnemyTeam class
        EnemyTeam tempEnemyTeam = _enemyTeamSelector.GetRandomTeam();

        //Loop through every Blox in the next enemy team and add them to _enemyTeam
        foreach (ClassAbstract enemyClassName in tempEnemyTeam.enemyBlox)
        {
            ClassVitals enemyBlox = new ClassVitals(enemyClassName, Team.Enemy);

            enemyTeam.Add(enemyBlox);
        }//end foreach

    }//end SelectEnemies


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: EndCombat                                                       */
    /* Description: Ends the current combat, and checks if the run is over            */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void EndCombat()
    {
        //Increment what battle the player is one
        _bracketNumber++;

        //If the palyer fought everyone, end the run
        if(_bracketNumber == 7)
        {
            EndRun();
            return;
        }//end if

        //Heal the player and get the next opponent otherwise
        HealPlayer();
        SelectEnemies();

    }//end EndCombat


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: EndRun                                                          */
    /* Description: Ends the current run, clears all neccessary information           */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void EndRun()
    {
        //Call the victoryhandler to handle winning
        //_victoryHandler.HandleWin();

        //Resets the current opponent
        _bracketNumber = 0;

        //Clears the player's blox choices, blox, the enemy team, and resets all possible opponents
        _playerSelection.Clear();
        playerTeam.Clear();
        enemyTeam.Clear();
        _enemyTeamSelector.ResetBracket();
    }//end EndRun

}
