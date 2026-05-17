/***************************************************************
* Filename:       	WinLossTracker.cs                          *
* Authors:        	Noah Stern                                 *
* Version Authors:	Noah Stern                                 *
* Current Version:  0.1.0                                      *
* Previous Version: 0.0.0                                      *
* Creation Date:  	May 16, 2026                               *
* Last Modified:  	May 16, 2026                               *
* Due Date:       	May 17th, 2026                             *
* Course:         	CPSC 323                                   *
* Professor Name: 	Professor Jacklitsch                       *
* Project:        	Braket Reset                               *
* Purpose:        	Keeps track of the player's win and loss   *
*                   record against every character, and if     *
*                   they lost or won their last battle         *
* Version Changes:	Created and finished                       *
****************************************************************/

using UnityEngine;

public class WinLossTracker : MonoBehaviour
{
    //A boolean that tracks if the player one their last fight or not
    public bool _isPlayerWin { get; private set; } = true;

    //Ints to keep track of wins and losses for every character
    private int _jokerboyWins = 0;
    private int _jokerboyLosses = 0;

    private int _hushpuppyWins = 0;
    private int _hushpuppyLosses = 0;

    private int _bumblebeeWins = 0;
    private int _bumblebeeLosses = 0;

    private int _hatchetWins = 0;
    private int _hatchetLosses = 0;

    private int _computerRoomWins = 0;
    private int _computerRoomLosses = 0;

    private int _strawBoaterWins = 0;
    private int _strawBoaterLosses = 0;

    private int _hollyTreeWins = 0;
    private int _hollyTreeLosses = 0;

    private int _wardenWins = 0;
    private int _wardenLosses = 0;

    //A singleton instance so it can keep track between scenes
    public static WinLossTracker _singletonInstance { get; private set; }


    /***************************************************************************************************/
    /*                                                                                                 */
    /* Function name: Awake                                                                            */
    /* Description: Makes it a singleton                                                               */
    /* Parameters: N/A                                                                                 */
    /* Return Value: N/A                                                                               */
    /*                                                                                                 */
    /***************************************************************************************************/
    public void Awake()
    {
        if (_singletonInstance == null)
        {
            _singletonInstance = this;
            DontDestroyOnLoad(gameObject);
        }//end if
        else
        {
            Destroy(gameObject);
        }//end else

    }//end Awake


    /***************************************************************************************************/
    /*                                                                                                 */
    /* Function name: UpdateWinLoss                                                                    */
    /* Description: Updates the associated character's win and loss record                             */
    /* Parameters: string enemyName: The name of the enemy who's win/loss is being updated             */
    /* Return Value: N/A                                                                               */
    /*                                                                                                 */
    /***************************************************************************************************/
    public void UpdateWinLoss(string enemyName)
    {
        
        switch(enemyName)
        {
            case "ALEC_SMARTSVILLE_XII":
                if (_isPlayerWin == true)
                {
                    _jokerboyWins++;
                }//end if
                else
                {
                    _jokerboyLosses++;
                }//end else
                break;

            case "GERRELE_HATCHETMAN":
                if (_isPlayerWin == true)
                {
                    _hatchetWins++;
                }//end if
                else
                {
                    _hatchetLosses++;
                }//end else
                break;

            case "CIRCE_LISTERINE":
                if (_isPlayerWin == true)
                {
                    _hushpuppyWins++;
                }//end if
                else
                {
                    _hushpuppyLosses++;
                }//end else
                break;

            case "LENEYJOCE_SUPERDARK":
                if (_isPlayerWin == true)
                {
                    _bumblebeeWins++;
                }//end if
                else
                {
                    _bumblebeeLosses++;
                }//end else
                break;

            case "VECTOR_VACHGLITCH":
                if (_isPlayerWin == true)
                {
                    _computerRoomWins++;
                }//end if
                else
                {
                    _computerRoomLosses++;
                }//end else
                break;

            case "CHIMP_T_LUCKY":
                if (_isPlayerWin == true)
                {
                    _strawBoaterWins++;
                }//end if
                else
                {
                    _strawBoaterLosses++;
                }//end else
                break;

            case "HOLLY_WARMHART":
                if (_isPlayerWin == true)
                {
                    _hollyTreeWins++;
                }//end if
                else
                {
                    _hollyTreeLosses++;
                }//end else
                break;

            case "WARREN_T_WARDEN":
                if (_isPlayerWin == true)
                {
                    _wardenWins++;
                }//end if
                else
                {
                    _wardenLosses++;
                }//end else
                break;
        }//end switch

    }//end UpdateWinLoss



    /***************************************************************************************************/
    /*                                                                                                 */
    /* Function name: GetRecord                                                                        */
    /* Description: A gettor for a requested character's win or loss record                            */
    /* Parameters: string enemyName: The name of the enemy who's win/loss is being requested           */
    /* Return Value: N/A                                                                               */
    /*                                                                                                 */
    /***************************************************************************************************/
    public int GetRecord(string enemyName)
    {
        switch (enemyName)
        {
            case "ALEC_SMARTSVILLE_XII":
                if (_isPlayerWin == true)
                {
                    return _jokerboyWins;
                }//end if
                else
                {
                    return _jokerboyLosses;
                }//end else

            case "GERRELE_HATCHETMAN":
                if (_isPlayerWin == true)
                {
                    return _hatchetWins;
                }//end if
                else
                {
                    return _hatchetLosses;
                }//end else

            case "CIRCE_LISTERINE":
                if (_isPlayerWin == true)
                {
                    return _hushpuppyWins;
                }//end if
                else
                {
                    return _hushpuppyLosses;
                }//end else

            case "LENEYJOCE_SUPERDARK":
                if (_isPlayerWin == true)
                {
                    return _bumblebeeWins;
                }//end if
                else
                {
                    return _bumblebeeLosses;
                }//end else

            case "VECTOR_VACHGLITCH":
                if (_isPlayerWin == true)
                {
                    return _computerRoomWins;
                }//end if
                else
                {
                    return _computerRoomLosses;
                }//end else

            case "CHIMP_T_LUCKY":
                if (_isPlayerWin == true)
                {
                    return _strawBoaterWins;
                }//end if
                else
                {
                    return _strawBoaterLosses;
                }//end else

            case "HOLLY_WARMHART":
                if (_isPlayerWin == true)
                {
                    return _hollyTreeWins;
                }//end if
                else
                {
                    return _hollyTreeLosses;
                }//end else

            case "WARREN_T_WARDEN":
                if (_isPlayerWin == true)
                {
                    return _wardenWins;
                }//end if
                else
                {
                    return _wardenLosses;
                }//end else

        }//end switch
        return 0;

    }//end GetRecord


    /***************************************************************************************************/
    /*                                                                                                 */
    /* Function name: SetPlayerWin                                                                     */
    /* Description: sets the _isPlayerWin boolean to the passed value                                  */
    /* Parameters: bool whoWon: either true if the player won, of false if they lost                   */
    /* Return Value: N/A                                                                               */
    /*                                                                                                 */
    /***************************************************************************************************/
    public void SetPlayerWin(bool whoWon)
    {
        _isPlayerWin = whoWon;
    }//end SetPlayerWin

}//end WinLossTracket
