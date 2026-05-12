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

    private void Update()
    {

    }

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
        _statsLayout.SetText("SPD: " + _playerController.activeUnit.GetComponent<ClassVitals>()._currSPD + "<br>ATK: " + _playerController.activeUnit.GetComponent<ClassVitals>()._currATK + "<br>DEF: " + _playerController.activeUnit.GetComponent<ClassVitals>()._currDEF);
        _cdCounter.SetText("Cooldown: " + _playerController.abilitySelected._currCooldown.ToString() + "<br>Range: " + _playerController.abilitySelected.GetRange());
    }
}
