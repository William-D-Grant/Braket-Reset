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

    private void Update()
    {

    }

    public void UpdatePlayerDisplay()
    {
        Debug.Log("Trying to update UI");
        _abilityText.SetText(_playerController.abilitySelected.GetName());
    }
}
