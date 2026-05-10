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
    private GameObject activeUnit;
    private GameObject targetUnit;
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
            if (_inputManager.SelectInput)
            {
                Debug.Log("Click Detected");
                RaycastHit mouseTarget = _inputManager.GetMouse3DTarget();
                Debug.Log(selectedTile + " Before");
                Debug.Log(targetUnit + " Before");
                if (mouseTarget.collider != null)
                {
                    if (targetUnit == null)
                    {
                        Debug.Log("Target Detected");
                        if (mouseTarget.collider.tag == "Unit")
                        {
                            targetUnit = mouseTarget.collider.gameObject;
                            targetUnit.transform.Find("HighlightTarget").gameObject.SetActive(true);
                        }
                        else
                        {
                            targetUnit = null;
                        }
                        Debug.Log(targetUnit + " After");
                    }
                    if (selectedTile == null)
                    {
                        Debug.Log("Tile Detected");
                        if (mouseTarget.collider.tag == "Tile")
                        {
                            selectedTile = mouseTarget.collider.gameObject.GetComponent<Tile>();
                            CheckTile();
                        }
                        else
                        {
                            selectedTile = null;
                        }
                        //mouseTarget.collider.TryGetComponent<Tile>(out selectedTile);
                        Debug.Log(selectedTile + " After");
                    }
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
        if(targetUnit != null)
        {
            targetUnit.transform.Find("HighlightTarget").gameObject.SetActive(false);
        }
        
        selectedTile = null;
        targetUnit = null;
    }

    private void SelectTile()
    {

    }

    private void CheckTile()
    {
        Tile[] checkingTiles = _mapHandler.FindTilesNearUnit(activeUnit.GetComponent<ClassVitals>());
        for (int i = 0; i < checkingTiles.Length; i++)
        {
            if (checkingTiles[i] == selectedTile)
            {
                Debug.Log("Good tile");
                return;
            }
        }
        Debug.Log("Bad tile");
        selectedTile = null;
        return;
    }
    
    private void ToggleMovementArrows(bool isVisible)
    {

    }

    public void MoveToTile()
    {
        Debug.Log(remainingTM);
        Debug.Log(selectedTile);
        if (remainingTM > 0 && selectedTile != null)
        {
            activeUnit.transform.position = selectedTile.transform.position + new Vector3(0, _mapHandler.playerOffset + 0.2f, 0);
            remainingTM--;
            Debug.Log(remainingTM + " TM Left");
        }
    }

    public void SelectAbility()
    {
        if (activeUnit != null)
        {
            Debug.Log("This is working");
            abilityIndex++;
            if (abilityIndex >= activeUnit.GetComponent<ClassVitals>()._currAbilities.Length)
            {
                abilityIndex = 0;
            }
            abilitySelected = activeUnit.GetComponent<ClassVitals>()._currAbilities[abilityIndex];
        }
    }

    public void UseAbility()
    {
        if (hasAction && targetUnit != null)
        {
            for (int i = (int)activeUnit.GetComponent<ClassVitals>()._currPos.x - abilitySelected.GetRange(); i < (int)activeUnit.GetComponent<ClassVitals>()._currPos.x + abilitySelected.GetRange(); i++)
            {
                for (int j = (int)activeUnit.GetComponent<ClassVitals>()._currPos.y - abilitySelected.GetRange(); j < (int)activeUnit.GetComponent<ClassVitals>()._currPos.y + abilitySelected.GetRange(); j++)
                {
                    if (targetUnit == _mapHandler.unitGrid[i, j])
                    {
                        abilitySelected.UseAbility(activeUnit.GetComponent<ClassVitals>(), targetUnit.GetComponent<ClassVitals>());
                        hasAction = false;
                    }
                }
            }
        }
    }

    public void EndTurn()
    {
        activeUnit.transform.Find("HighlightActive").gameObject.SetActive(false);
        activeUnit = null;
        _combatHandler.ShiftTurn();
    }

    public void EnablePlayer(GameObject currentPlayer)
    {
        Debug.Log(currentPlayer);
        activeUnit = currentPlayer;
        activeUnit.transform.Find("HighlightActive").gameObject.SetActive(true);
        remainingTM = activeUnit.GetComponent<ClassVitals>()._currTM;
        Debug.Log(activeUnit.GetComponent<ClassVitals>()._currTM + " TM");
        hasAction = true;
        //abilitySelected = activeUnit.GetComponent<ClassVitals>()._currAbilities[0];
    }
}
