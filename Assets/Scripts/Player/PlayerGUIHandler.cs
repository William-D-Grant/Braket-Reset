using TMPro;
using UnityEngine;

public class PlayerGUIHandler : MonoBehaviour
{
    public int playerHype;

    [SerializeField]
    private Canvas vitalsHUD;

    [SerializeField]
    private PlayerController _playerController;

    private void Update()
    {

    }

    public void UpdatePlayerDisplay()
    {
        vitalsHUD.GetComponent<TextMeshProUGUI>().SetText(_playerController.abilitySelected.GetName());
    }
}
