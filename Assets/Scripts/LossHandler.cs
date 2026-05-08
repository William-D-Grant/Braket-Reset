/***************************************************************
* Filename:       	LossHandler.cs                             *
* Authors:        	Noah Stern                                 *
* Version Authors:	Noah Stern                                 *
* Current Version:  0.0.1                                      *
* Previous Version: 0.0.0                                      *
* Creation Date:  	May 7, 2026                                *
* Last Modified:  	May 7, 2026                                *
* Due Date:       	May 14th, 2026                             *
* Course:         	CPSC 323                                   *
* Professor Name: 	Professor Jacklitsch                       *
* Project:        	Braket Reset                               *
* Purpose:        	Handles the losing screen ui               *
* Version Changes:	Created and finished                       *
****************************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;

public class LossHandler : MonoBehaviour
{
    //The UI game object
    [SerializeField]
    private GameObject _lossScreen;


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: Awake                                                           */
    /* Description: Disables the menu                                                 */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    private void Awake()
    {
        _lossScreen.SetActive(false);
    }//end Awake


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: ActivateScreen                                                  */
    /* Description: Opens the lose menu screen                                        */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void ActivateScreen()
    {
        _lossScreen.SetActive(true);
    }//end ActivateScreen


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: ToMainMenu                                                      */
    /* Description: Brings the player to the main menu                                */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        
    }//end ToMainMenu


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: TryAgain                                                        */
    /* Description: Brings the player to the Blox selection menu                      */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void TryAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }//end TryAgain


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: Exit                                                            */
    /* Description: Quits the game                                                    */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void Exit()
    {
        Application.Quit();
    }//end Exit

}//end LossHandler
