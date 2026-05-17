/****************************************************************
* Filename:       	PlayerGUIHandler.cs                         *
* Authors:        	William Grant                               *
* Version Authors:	William Grant                               *
* Current Version:  1.0.0                                       *
* Previous Version: 0.4.0                                       *
* Creation Date:  	May 10, 2026                                *
* Last Modified:  	May 16, 2026                                *
* Due Date:       	May 17th, 2026                              *
* Course:         	CPSC 323                                    *
* Professor Name: 	Professor Jacklitsch                        *
* Project:        	Braket Reset                                *
* Purpose:        	Displays player information on the GUI      *
* Version Changes:	Changes to how a used ability is displayed  *
****************************************************************/
using TMPro;
using UnityEngine;

public class PlayerGUIHandler : MonoBehaviour
{
    public int playerHype;

    [SerializeField]
    private Canvas vitalsHUD;

    [SerializeField]
    private PlayerController _playerController;

    [SerializeField]
    private TextMeshProUGUI _abilityText;

    [SerializeField]
    private TextMeshProUGUI _tmCounter;

    [SerializeField]
    private TextMeshProUGUI _hpCounter;

    [SerializeField]
    private TextMeshProUGUI _unitName;

    [SerializeField]
    private TextMeshProUGUI _cdCounter;

    [SerializeField]
    private TextMeshProUGUI _statsLayout;

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: UpdatePlayerDisplay()                                           */
    /* Description: Called any time the player updates something on the UI            */
    /* Parameters: None                                                               */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void UpdatePlayerDisplay()
    {
        Debug.Log("Trying to update UI");
        if (_playerController.hasAction)
        {
            _abilityText.SetText(_playerController.abilitySelected.GetName());
        }
        else
        {
            _abilityText.SetText("Used Action");
        }
        _unitName.SetText(_playerController.activeUnit.GetComponent<ClassVitals>()._class.ToString());
        _tmCounter.SetText("TM: " + _playerController.remainingTM.ToString());
        _hpCounter.SetText("HP: " + _playerController.activeUnit.GetComponent<ClassVitals>()._currHP.ToString());
        _statsLayout.SetText("SPD: " + _playerController.activeUnit.GetComponent<ClassVitals>().GetSpeed() + "<br>ATK: " + _playerController.activeUnit.GetComponent<ClassVitals>().GetAttack() + "<br>DEF: " + _playerController.activeUnit.GetComponent<ClassVitals>().GetDefense() + "<br>Hype: " + RunManager._singletonInstance.currentHype);
        _cdCounter.SetText("Cooldown: " + _playerController.abilitySelected._currCooldown.ToString() + "<br>Range: " + _playerController.abilitySelected.GetRange());
    }
}
