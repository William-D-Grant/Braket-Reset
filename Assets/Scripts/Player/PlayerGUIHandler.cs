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

    private void Update()
    {

    }

    public void UpdatePlayerDisplay()
    {
        Debug.Log("Trying to update UI");
        _abilityText.SetText(_playerController.abilitySelected.GetName());
        _unitName.SetText(_playerController.activeUnit.GetComponent<ClassVitals>()._class.ToString());
        _tmCounter.SetText("TM: " + _playerController.remainingTM.ToString());
        _hpCounter.SetText("HP: " + _playerController.activeUnit.GetComponent<ClassVitals>()._currHP.ToString());
        _cdCounter.SetText("Cooldown: " + _playerController.abilitySelected._currCooldown.ToString());
    }
}
