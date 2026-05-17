/***************************************************************
* Filename:       	RunManager.cs                              *
* Authors:        	Noah Stern                                 *
* Version Authors:	Noah Stern                                 *
* Current Version:  0.5.0                                      *
* Previous Version: 0.4.2                                      *
* Creation Date:  	May 4, 2026                                *
* Last Modified:  	May 16, 2026                               *
* Due Date:       	May 14th, 2026                             *
* Course:         	CPSC 323                                   *
* Professor Name: 	Professor Jacklitsch                       *
* Project:        	Braket Reset                               *
* Purpose:        	Handle all information for a singular run, *
*                   healing the player between fights, ending  *
*                   runs, and getting the enemy team           *
* Version Changes:	Updated EndCombat, completely changed its  *
*                   logic and outcomes                         *
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
    private ClassAbstract[] _bloxPrefabs = new ClassAbstract[9];

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

    //A bool for if the player has done the tutorial yet
    public bool _isTutorial = true;


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: Awake                                                           */
    /* Description: Makes RunManager a singleton, readies all prefabs                 */
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
        _bloxPrefabs[8] = new TestingClass();
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
                case BloxClass.Test:
                    bloxGameObject = _bloxPrefabs[8].bloxObject;
                    break;
                default:
                    bloxGameObject = _bloxPrefabs[2].bloxObject;
                    break;

            }
            /*ClassVitals bloxVitals = bloxGameObject.GetComponent<ClassVitals>();
            //bloxVitals._team = Team.Player;
            bloxVitals.InitializeBlox(bloxClass, Team.Player);  //was commented
            //if (bloxVitals == null)
            Debug.Log("Resulting Vitals is " + bloxVitals);
            playerTeam.Add(bloxGameObject);*/

            GameObject bloxInstance = Instantiate(bloxGameObject);
            DontDestroyOnLoad(bloxInstance);
            ClassVitals bloxVitals = bloxInstance.GetComponent<ClassVitals>();
            bloxVitals.InitializeBlox(bloxClass, Team.Player);
            bloxInstance.SetActive(false);
            playerTeam.Add(bloxInstance);
        }//end foreach

    }//end CreatePlayerTeam

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
                case BloxClass.Test:
                    enemyBloxGameObject = _bloxPrefabs[8].bloxObject;
                    break;
                default:
                    enemyBloxGameObject = _bloxPrefabs[2].bloxObject;
                    break;
            }

            /*ClassVitals enemyBloxClassVitals = enemyBloxGameObject.GetComponent<ClassVitals>();

            //enemyBloxClassVitals._team = Team.Enemy;

            enemyTeam.Add(enemyBloxGameObject);*/

            GameObject bloxInstance = Instantiate(enemyBloxGameObject);
            DontDestroyOnLoad(bloxInstance);
            ClassVitals bloxVitals = bloxInstance.GetComponent<ClassVitals>();
            bloxVitals.InitializeBlox(enemyBloxClass, Team.Enemy);
            bloxInstance.SetActive(false);
            enemyTeam.Add(bloxInstance);
        }//end foreach

    }//end SelectEnemies


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: EndCombat                                                       */
    /* Description: Ends the current combat, and checks if the run is over or if the  */
    /*              player needs to fight the warden                                  */
    /* Parameters: Team whoLost: the team who lost the last fight                     */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void EndCombat(Team whoLost)
    {
        if (whoLost == Team.Enemy)
        {
            //Increment what battle the player is one
            _bracketNumber++;

            WinLossTracker._singletonInstance.SetPlayerWin(true);
            WinLossTracker._singletonInstance.UpdateWinLoss(EnemyTeamSelector._singletonInstance.currentEnemyTeam.enemyName);

            //If the player fought the warden, end the run
            if (_bracketNumber == 8)
            {
                EndRun();
                SceneManager.LoadScene("PostCombatDialogueRoom");
                return;
            }

            //Get the upgrades handler (I'm sorry for my sins)
            UpgradesHandler upgradesHandler = FindFirstObjectByType<UpgradesHandler>();

            //If the player fought everyone, fight the warden
            if (_bracketNumber == 7)
            {
                //EndRun(playerWon);
                //return;
                HealPlayer();
                EnemyTeamSelector._singletonInstance.BuildWarden();
                //SelectEnemies();
                foreach (GameObject blox in playerTeam)
                {
                    foreach (AbilityInstance ability in blox.GetComponent<ClassVitals>()._currAbilities)
                    {
                        ability.SetCooldown(0);
                    }
                }
                upgradesHandler.ShowUpgradeScreen();
                return;
            }//end if

            //Heal the player and get the next opponent otherwise
            HealPlayer();
            //SelectEnemies();
            foreach (GameObject blox in playerTeam)
            {
                foreach (AbilityInstance ability in blox.GetComponent<ClassVitals>()._currAbilities)
                {
                    ability.SetCooldown(0);
                }
            }
            upgradesHandler.ShowUpgradeScreen();
        }
        else if (whoLost == Team.Player)
        {
            WinLossTracker._singletonInstance.SetPlayerWin(false);
            EndRun();
            SceneManager.LoadScene("PostCombatDialogueRoom");
        }
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

        //Resets the current opponent
        _bracketNumber = 0;

        playerTeam.Clear();
        enemyTeam.Clear();
        EnemyTeamSelector._singletonInstance.ResetBracket();
    }//end EndRun

}//end RunManager
