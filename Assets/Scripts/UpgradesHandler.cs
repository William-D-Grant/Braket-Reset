/***************************************************************
* Filename:       	UpgradesHandler.cs                         *
* Authors:        	Noah Stern                                 *
* Version Authors:	Noah Stern                                 *
* Current Version:  0.1.1                                      *
* Previous Version: 0.1.0                                      *
* Creation Date:  	May 13, 2026                               *
* Last Modified:  	May 14, 2026                               *
* Due Date:       	May 17th, 2026                             *
* Course:         	CPSC 323                                   *
* Professor Name: 	Professor Jacklitsch                       *
* Project:        	Braket Reset                               *
* Purpose:        	Handles the Upgrade UI and upgrading blox  *
* Version Changes:	Added NextRoom()                           *
****************************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradesHandler : MonoBehaviour
{
    //The upgrade UI gameobject
    [SerializeField]
    private GameObject _upgradeUI;


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: ShowUpgradeScreen                                               */
    /* Description: Brings up the upgrade UI                                          */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void ShowUpgradeScreen()
    {
        _upgradeUI.SetActive(true);
    }//end ShowUpgradeScreen


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: UpgradeStat                                                     */
    /* Description: Upgrades each player's Bloxs' stats                               */
    /* Parameters: string chosenStat: The stat being upgraded                         */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void UpgradeStat(string chosenStat)
    {
        if (RunManager._singletonInstance.currentHype >= 5)
        {
            RunManager._singletonInstance.UpdateHype(-5);
            switch (chosenStat)
            {
                case "ATTACK":
                    foreach (GameObject blox in RunManager._singletonInstance.playerTeam)
                    {
                        blox.GetComponent<ClassVitals>().UpgradeAttack(1);
                        Debug.Log(blox.GetComponent<ClassVitals>().GetAttack());

                    }//end foreach
                    break;

                case "DEFENSE":
                    foreach (GameObject blox in RunManager._singletonInstance.playerTeam)
                    {
                        blox.GetComponent<ClassVitals>().UpgradeDefense(1);
                    }//end foreach
                    break;

                case "HYPE":
                    foreach (GameObject blox in RunManager._singletonInstance.playerTeam)
                    {
                        blox.GetComponent<ClassVitals>().UpgradeHype(1);
                    }//end foreach
                    break;

                case "TM":
                    foreach (GameObject blox in RunManager._singletonInstance.playerTeam)
                    {
                        blox.GetComponent<ClassVitals>().UpgradeTileMovement(1);
                    }//end foreach
                    break;
            }//end switch
        }
    }//end UpgradeStat


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: NextRoom                                                        */
    /* Description: Loads the Post Combat Dialogue Room                               */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void NextRoom()
    {
        SceneManager.LoadScene("PostCombatDialogueRoom");
    }//end NextRoom
}
