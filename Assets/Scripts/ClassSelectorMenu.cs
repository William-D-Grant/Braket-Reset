/***************************************************************
* Filename:       	ClassSelectorMenu.cs                       *
* Authors:        	Noah Stern                                 *
* Version Authors:	Noah Stern                                 *
* Current Version:  0.0.1                                      *
* Previous Version: 0.0.0                                      *
* Creation Date:  	May 7, 2026                                *
* Last Modified:  	May 7, 2026                                *
* Due Date:       	May 17th, 2026                             *
* Course:         	CPSC 323                                   *
* Professor Name: 	Professor Jacklitsch                       *
* Project:        	Braket Reset                               *
* Purpose:        	Handles setting up the player's team of    *
*                   Blox based on their choices, and loads the *
*                   first battle of each run                   *
* Version Changes:	Created and finished                       *
****************************************************************/

using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;

public class ClassSelectorMenu : MonoBehaviour
{
    //The list of the player's choices
    public List<BloxClass> playerSelection { get; private set; } = new List<BloxClass>();

    //The size of the player's team, set to a constant 3
    private const int _teamSize = 3;

    //The RunManager used to store the player's selected Blox
    [SerializeField]
    private RunManager _runManager;

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: SelectClass                                                     */
    /* Description: Takes a string from a UI button, compares it to the switch, and   */
    /*              creates the necessary ClassAbstract and adds it to the player's   */
    /*              selected classes. If the player has chosen enough Blox, start the */
    /*              run.                                                              */
    /* Parameters: string selectedClass: the string of the class the player chose     */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void SelectClass(string selectedClass)
    {
        //Create a playerBlox to represent the new blox being added
        BloxClass playerBloxClass;
        
        //A switch to run through every possible outcome of Blox class
        switch (selectedClass)
        {
            case "FIGHTER":
                playerBloxClass = BloxClass.Fighter;
                break;

            case "TANK":
                playerBloxClass = BloxClass.Tank;
                break;

            case "RANGER":
                playerBloxClass = BloxClass.Ranger;
                break;

            case "THIEF":
                playerBloxClass = BloxClass.Thief;
                break;

            case "SAGE":
                playerBloxClass = BloxClass.Sage;
                break;

            case "CLOWN":
                playerBloxClass = BloxClass.Clown;
                break;

            case "COWBOY":
                playerBloxClass = BloxClass.Cowboy;
                break;

            case "PIRATE":
                playerBloxClass = BloxClass.Pirate;
                break;

            case "TEST":
                playerBloxClass = BloxClass.Test;
                break;

            default:
                playerBloxClass = BloxClass.Fighter;
                break;

        }//end switch

        //Add the new blox into the player's current selected Blox
        playerSelection.Add(playerBloxClass);
        Debug.Log("Added" + playerBloxClass);

        //If the player has chosen enough Blox (3), start the game
        if(playerSelection.Count == _teamSize)
        {
            FinishedSelection();
        }//end if

    }//end SelectClass


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: FinishedSelection                                               */
    /* Description: Creates the player's team of blox in RunManager's singleton       */
    /*              instance, gets the first battle's enemy, and loads the first fight*/
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void FinishedSelection()
    {
        //Create the player's current team
        RunManager._singletonInstance.CreatePlayerTeam(playerSelection);

        //Get the first fight's enemy
        RunManager._singletonInstance.SelectEnemies();

        //Load the first fight
        SceneManager.LoadScene("DialogueRoom");
    }//end FinishedSelection


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: ToMainMenu                                                      */
    /* Description: Brings the player back to the main menu                           */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void ToMainMenu()
    {
        playerSelection = new List<BloxClass>();
        SceneManager.LoadScene("MainMenu");
    }//end ToMainMenu

}//end ClassSelectorMenu
