using UnityEngine;

public class WinLossTracker : MonoBehaviour
{

    public bool _isPlayerWin { get; private set; } = true;

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

    public static WinLossTracker _singletonInstance { get; private set; }

    public void Awake()
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

    }

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


    public void SetPlayerWin(bool whoWon)
    {
        _isPlayerWin = whoWon;
    }//end SetPlayerWin

}//end WinLossTracket
