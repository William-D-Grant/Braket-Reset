using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private InputManager _inputManager;
    [SerializeField]
    private CombatHandler _combatHandler;
    [SerializeField]
    private MapHandler _mapHandler;

    private int remainingTM;
    private bool hasAction;
    private ClassVitals activeUnit;
    private ClassVitals targetUnit;
    private Tile selectedTile;
    public AbilityInstance abilitySelected;
    private int abilityIndex;

    private int _currentHype;


    private void Start()
    {
        
    }

    private void Update()
    {
        if (activeUnit != null)
        {
            Debug.Log("Updating");
            if (_inputManager.SelectInput)
            {
                Debug.Log("Click Detected");
                if (targetUnit == null)
                {
                    Debug.Log("Target Detected");
                }
                if (selectedTile == null)
                {
                    Debug.Log("Tile Detected");
                    _inputManager.GetMouse3DTarget().collider.TryGetComponent(out selectedTile);
                    CheckTile();
                }
            }
            if (_inputManager.DeselectInput)
            {
                DeselectAll();
            }
            if (remainingTM <= 0 && hasAction == false)
            {
                EndTurn();
            }
        }
    }

    private void SelectUnit()
    {

    }

    private void DeselectAll()
    {
        selectedTile = null;
        targetUnit = null;
    }

    private void SelectTile()
    {

    }

    private void CheckTile()
    {
        Tile[] checkingTiles = _mapHandler.FindTilesNearUnit(activeUnit);
        for (int i = 0; i < checkingTiles.Length; i++)
        {
            if (checkingTiles[i] == selectedTile)
            {
                return;
            }
        }
        selectedTile = null;
        return;
    }
    
    private void ToggleMovementArrows(bool isVisible)
    {

    }

    public void MoveToTile()
    {
        if (remainingTM > 0)
        {
            activeUnit._bloxObject.transform.position = selectedTile.transform.position + new Vector3(0, _mapHandler.playerOffset + 0.2f, 0);
            remainingTM--;
        }
    }

    public void SelectAbility()
    {
        if (activeUnit != null)
        {
            Debug.Log("This is working");
            abilityIndex++;
            if (abilityIndex >= activeUnit._currAbilities.Length)
            {
                abilityIndex = 0;
            }
            abilitySelected = activeUnit._currAbilities[abilityIndex];
        }
    }

    public void UseAbility()
    {
        if (hasAction && targetUnit != null)
        {
            for (int i = (int)activeUnit._currPos.x - abilitySelected.GetRange(); i < (int)activeUnit._currPos.x + abilitySelected.GetRange(); i++)
            {
                for (int j = (int)activeUnit._currPos.y - abilitySelected.GetRange(); j < (int)activeUnit._currPos.y + abilitySelected.GetRange(); j++)
                {
                    if (targetUnit._bloxObject == _mapHandler.unitGrid[i, j])
                    {
                        abilitySelected.UseAbility(activeUnit, targetUnit);
                        hasAction = false;
                    }
                }
            }
        }
    }

    public void EndTurn()
    {
        activeUnit = null;
        _combatHandler.ShiftTurn();
    }

    public void EnablePlayer(ClassVitals currentPlayer)
    {
        activeUnit = currentPlayer;
        abilitySelected = activeUnit._currAbilities[0];
    }
}
