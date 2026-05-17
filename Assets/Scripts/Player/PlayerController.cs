using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private InputManager _inputManager;
    [SerializeField]
    private CombatHandler _combatHandler;
    [SerializeField]
    private MapHandler _mapHandler;
    [SerializeField]
    private PlayerGUIHandler _playerGUI;

    public int remainingTM;
    public bool hasAction;
    public GameObject activeUnit;
    public GameObject targetUnit;
    public Tile selectedTile;
    public AbilityInstance abilitySelected;
    private int abilityIndex;

    private int _currentHype;


    private void Start()
    {
        //_mapHandler = FindFirstObjectByType<MapHandler>();
        //_combatHandler = FindFirstObjectByType<CombatHandler>();
        _inputManager = InputManager._singletonInstance;

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
                            selectedTile.transform.Find("Highlight").gameObject.SetActive(true);
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
        if (targetUnit != null)
        {
            targetUnit.transform.Find("HighlightTarget").gameObject.SetActive(false);
        }
        if (selectedTile != null)
        {
            selectedTile.transform.Find("Highlight").gameObject.SetActive(false);
        }
        selectedTile = null;
        targetUnit = null;
    }

    private void SelectTile()
    {

    }

    private void CheckTile()
    {
        Debug.Log(activeUnit.GetComponent<ClassVitals>()._currPos);
        Tile[] checkingTiles = _mapHandler.FindTilesNearUnit(activeUnit.GetComponent<ClassVitals>());
        for (int i = 0; i < checkingTiles.Length; i++)
        {
            Debug.Log(checkingTiles[i]);
            if (checkingTiles[i] == selectedTile)
            {
                Debug.Log("Good tile");
                return;
            }
        }
        Debug.Log("Bad tile");
        selectedTile.transform.Find("Highlight").gameObject.SetActive(false);
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
            _mapHandler.ChangePosition(activeUnit, selectedTile.position);
            //activeUnit.GetComponent<ClassVitals>()._currPos = selectedTile.position;
            remainingTM--;
            Debug.Log(remainingTM + " TM Left");
            _playerGUI.UpdatePlayerDisplay();
            RunManager._singletonInstance.UpdateHype(activeUnit.GetComponent<ClassVitals>().GetHype());
            
        }
        if (selectedTile != null)
        {
            selectedTile.transform.Find("Highlight").gameObject.SetActive(false);
        }
        selectedTile = null;
    }

    public void SelectAbility()
    {
        if (activeUnit != null)
        {
            Debug.Log("This is working.");
            abilityIndex++;
            if (abilityIndex >= activeUnit.GetComponent<ClassVitals>()._currAbilities.Length)
            {
                abilityIndex = 0;
            }
            abilitySelected = activeUnit.GetComponent<ClassVitals>()._currAbilities[abilityIndex];
            Debug.Log(abilitySelected.GetName());
            _playerGUI.UpdatePlayerDisplay();
        }
    }

    public void UseAbility()
    {
        Debug.Log(abilitySelected._currCooldown); 
        if (hasAction && targetUnit != null && abilitySelected._currCooldown == 0)
        {
            if (Mathf.Abs(activeUnit.GetComponent<ClassVitals>()._currPos.x - targetUnit.GetComponent<ClassVitals>()._currPos.x) + Mathf.Abs(activeUnit.GetComponent<ClassVitals>()._currPos.y - targetUnit.GetComponent<ClassVitals>()._currPos.y) <= abilitySelected.GetRange())
            {
                Debug.Log("Move used");
                Debug.Log(targetUnit.GetComponent<ClassVitals>()._currHP);
                abilitySelected.UseAbility(activeUnit.GetComponent<ClassVitals>(), targetUnit.GetComponent<ClassVitals>());
                hasAction = false;
                Debug.Log(hasAction + " hasAction");
                Debug.Log(targetUnit.GetComponent<ClassVitals>()._currHP);
                targetUnit.transform.Find("HighlightTarget").gameObject.SetActive(false);
                targetUnit = null;
            }
            /*for (int i = (int)activeUnit.GetComponent<ClassVitals>()._currPos.x - abilitySelected.GetRange(); i < (int)activeUnit.GetComponent<ClassVitals>()._currPos.x + abilitySelected.GetRange(); i++)
            {
                for (int j = (int)activeUnit.GetComponent<ClassVitals>()._currPos.y - abilitySelected.GetRange(); j < (int)activeUnit.GetComponent<ClassVitals>()._currPos.y + abilitySelected.GetRange(); j++)
                {
                    if (i >= 0 && i < 9 && j >= 0 && j < 9)
                    {
                        if (targetUnit == _mapHandler.unitGrid[i, j])
                        {
                            Debug.Log("Move used");
                            abilitySelected.UseAbility(activeUnit.GetComponent<ClassVitals>(), targetUnit.GetComponent<ClassVitals>());
                            hasAction = false;
                            Debug.Log(hasAction + " hasAction");
                        }
                    }
                }
            }*/
            _playerGUI.UpdatePlayerDisplay();
        }
    }

    public void EndTurn()
    {
        if (activeUnit != null)
        {
            activeUnit.transform.Find("HighlightActive").gameObject.SetActive(false);
            if (targetUnit != null)
            {
                targetUnit.transform.Find("HighlightTarget").gameObject.SetActive(false);
            }
            if (selectedTile != null)
            {
                selectedTile.transform.Find("Highlight").gameObject.SetActive(false);
            }
            activeUnit = null;
            selectedTile = null;
            targetUnit = null;
            _combatHandler.ShiftTurn();
        }
    }

    public void EnablePlayer(GameObject currentPlayer)
    {
        Debug.Log(currentPlayer);
        activeUnit = currentPlayer;
        activeUnit.transform.Find("HighlightActive").gameObject.SetActive(true);
        remainingTM = activeUnit.GetComponent<ClassVitals>().GetTileMovement();
        Debug.Log(activeUnit.GetComponent<ClassVitals>().GetTileMovement() + " TM");
        Debug.Log(activeUnit.GetComponent<ClassVitals>()._team + " Team");
        Debug.Log(activeUnit.GetComponent<ClassVitals>()._bloxClass + " Class");
        hasAction = true;
        abilitySelected = activeUnit.GetComponent<ClassVitals>()._currAbilities[0];
        abilityIndex = 0;
        _playerGUI.UpdatePlayerDisplay();
    }
}
