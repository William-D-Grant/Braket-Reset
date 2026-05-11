/***************************************************************
* Filename:       	RunManager.cs                              *
* Authors:        	Noah Stern                                 *
* Version Authors:	Noah Stern                                 *
* Current Version:  0.2.1                                      *
* Previous Version: 0.1.2                                      *
* Creation Date:  	May 4, 2026                                *
* Last Modified:  	May 7, 2026                                *
* Due Date:       	May 14th, 2026                             *
* Course:         	CPSC 323                                   *
* Professor Name: 	Professor Jacklitsch                       *
* Project:        	Braket Reset                               *
* Purpose:        	Handle all information for a singular run, *
*                   healing the player between fights, ending  *
*                   runs, and getting the enemy team           *
* Version Changes:	Adjusted CreatePlayerTeam and SelectEnemies*
*                   to instantiate the teams now               *
****************************************************************/

using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class RunManager : MonoBehaviour
{
    //Make it a singleton
    public static RunManager _singletonInstance { get; private set; }

    //The VictoryHandler to handle when the player wins
    [SerializeField]
    private VictoryHandler _victoryHandler;

    //The LossHandler to handle when the player loses
    [SerializeField]
    private LossHandler _lossHandler;

    [SerializeField]
    private ClassAbstract[] _bloxPrefabs = new ClassAbstract[8];

    //The EnemyTeam selector to hold all possible enemy teams, an retrieve team being fought
    private EnemyTeamSelector _enemyTeamSelector;

    //The player's selection of Blox
    public List<ClassAbstract> playerSelection;

    //The player's Blox
    public List<GameObject> playerTeam { get; private set; }

    //The enemy's Blox
    public List<GameObject> enemyTeam { get; private set; }

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
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _bloxPrefabs[0] = new ClownClass();
        _bloxPrefabs[1] = new CowboyClass();
        _bloxPrefabs[2] = new FighterClass();
        _bloxPrefabs[3] = new PirateClass();
        _bloxPrefabs[4] = new RangerClass();
        _bloxPrefabs[5] = new SageClass();
        _bloxPrefabs[6] = new TankClass();
        _bloxPrefabs[7] = new ThiefClass();
    }//end void


    /*************************************************************************************/
    /*                                                                                   */
    /* Function name: CreatePlayerTeam                                                   */
    /* Description: Creates and instantiates the player's team, gets the enemy           */
    /* Parameters: List<BloxClass> selectedBlox: the classes the player selected         */
    /* Return Value: N/A                                                                 */
    /*                                                                                   */
    /*************************************************************************************/
    public void CreatePlayerTeam(List<BloxClass> selectedBlox)
    {
        playerTeam = new List<GameObject>();
        foreach (BloxClass bloxClass in selectedBlox)
        {
            Debug.Log("Selected Blox is " + bloxClass);
            GameObject bloxGameObject = null;
            switch (bloxClass)
            {
                case BloxClass.Clown:
                    bloxGameObject = _bloxPrefabs[0].bloxObject;
                    break;
                case BloxClass.Cowboy:
                    bloxGameObject = _bloxPrefabs[1].bloxObject;
                    break;
                case BloxClass.Fighter:
                    bloxGameObject = _bloxPrefabs[2].bloxObject;
                    break;
                case BloxClass.Pirate:
                    bloxGameObject = _bloxPrefabs[3].bloxObject;
                    break;
                case BloxClass.Ranger:
                    bloxGameObject = _bloxPrefabs[4].bloxObject;
                    break;
                case BloxClass.Sage:
                    bloxGameObject = _bloxPrefabs[5].bloxObject;
                    break;
                case BloxClass.Tank:
                    bloxGameObject = _bloxPrefabs[6].bloxObject;
                    break;
                case BloxClass.Thief:
                    bloxGameObject = _bloxPrefabs[7].bloxObject;
                    break;
                default:
                    bloxGameObject = _bloxPrefabs[2].bloxObject;
                    break;

            }
            ClassVitals bloxVitals = bloxGameObject.GetComponent<ClassVitals>();
            //bloxVitals._team = Team.Player;
            //bloxVitals.InitializeBlox(bloxClass, Team.Player);
            //if (bloxVitals == null)
            Debug.Log("Resulting Vitals is " + bloxVitals);
            playerTeam.Add(bloxGameObject);
        }//end foreach

    }

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
        foreach(GameObject blox in playerTeam)
        {
            blox.GetComponent<ClassVitals>().HealBlox(20);
            blox.GetComponent<ClassVitals>().ClearStatus();
        }//end foreach

    }//end HealPlayer


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: SelectEnemies                                                   */
    /* Description: Gets and instantiates next enemy's team of Blox                   */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void SelectEnemies()
    {
        //Clear the current enemy team
        enemyTeam = new List<GameObject>();

        //Make a temporary enemy team so we can access the enemy blox information from the EnemyTeam class
        EnemyTeam tempEnemyTeam = EnemyTeamSelector._singletonInstance.GetRandomTeam();

        //Loop through every Blox in the next enemy team and add them to _enemyTeam
        foreach (BloxClass enemyBloxClass in tempEnemyTeam.enemyBlox)
        {
            GameObject enemyBloxGameObject = null;
            switch (enemyBloxClass)
            {
                case BloxClass.Clown:
                    enemyBloxGameObject = _bloxPrefabs[0].bloxObject;
                    break;
                case BloxClass.Cowboy:
                    enemyBloxGameObject = _bloxPrefabs[1].bloxObject;
                    break;
                case BloxClass.Fighter:
                    enemyBloxGameObject = _bloxPrefabs[2].bloxObject;
                    break;
                case BloxClass.Pirate:
                    enemyBloxGameObject = _bloxPrefabs[3].bloxObject;
                    break;
                case BloxClass.Ranger:
                    enemyBloxGameObject = _bloxPrefabs[4].bloxObject;
                    break;
                case BloxClass.Sage:
                    enemyBloxGameObject = _bloxPrefabs[5].bloxObject;
                    break;
                case BloxClass.Tank:
                    enemyBloxGameObject = _bloxPrefabs[6].bloxObject;
                    break;
                case BloxClass.Thief:
                    enemyBloxGameObject = _bloxPrefabs[7].bloxObject;
                    break;
                default:
                    enemyBloxGameObject = _bloxPrefabs[2].bloxObject;
                    break;
            }

            ClassVitals enemyBloxClassVitals = enemyBloxGameObject.GetComponent<ClassVitals>();

            //enemyBloxClassVitals._team = Team.Enemy;

            enemyTeam.Add(enemyBloxGameObject);
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
    public void EndCombat(Team playerWon)
    {
        //Increment what battle the player is one
        _bracketNumber++;

        //If the palyer fought everyone, end the run
        if(_bracketNumber == 7)
        {
            EndRun(playerWon);
            return;
        }//end if

        //Heal the player and get the next opponent otherwise
        HealPlayer();
        SelectEnemies();
        SceneManager.LoadScene("Arena");

    }//end EndCombat


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: EndRun                                                          */
    /* Description: Ends the current run, clears all neccessary information           */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void EndRun(Team winningTeam)
    {
        //Call the victoryhandler to handle winning
        if(winningTeam == Team.Enemy) 
        {
            _lossHandler.ActivateScreen();
        }

        if (winningTeam == Team.Player)
        {
            _victoryHandler.ActivateScreen();
        }

        //Resets the current opponent
        _bracketNumber = 0;

        //Clears the player's blox choices, blox, the enemy team, and resets all possible opponents
        playerSelection.Clear();
        playerTeam.Clear();
        enemyTeam.Clear();
        _enemyTeamSelector.ResetBracket();
    }//end EndRun

}//end RunManager
