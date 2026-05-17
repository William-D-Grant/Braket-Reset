/****************************************************************
* Filename:       	PlayerController.cs                         *
* Authors:        	William Grant                               *
* Version Authors:	William Grant                               *
* Current Version:  1.0.0                                       *
* Previous Version: 0.4.3                                       *
* Creation Date:  	May 8, 2026                                 *
* Last Modified:  	May 16, 2026                                *
* Due Date:       	May 17th, 2026                              *
* Course:         	CPSC 323                                    *
* Professor Name: 	Professor Jacklitsch                        *
* Project:        	Braket Reset                                *
* Purpose:        	Controls all aspects of a player and the    *
*                   unit they currently have selected, allowing *
*                   for player-side gameplay.                   *
* Version Changes:	Movement conditions for no overlapping      *
****************************************************************/
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
    
    // Remaining Tile Movement
    public int remainingTM;

    // Action has been used for this character
    public bool hasAction;

    // Unit being used by player
    public GameObject activeUnit;

    // Unit being targeted by player
    public GameObject targetUnit;

    // Tile being selected by player
    public Tile selectedTile;

    // Current ability selected from the activeUnit
    public AbilityInstance abilitySelected;

    // The index of the above ability
    private int abilityIndex;

    private int _currentHype;

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: Start()                                                         */
    /* Description: Called upon creation of the object.                               */
    /* Parameters: None                                                               */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    private void Start()
    {
        //_mapHandler = FindFirstObjectByType<MapHandler>();
        //_combatHandler = FindFirstObjectByType<CombatHandler>();
        _inputManager = InputManager._singletonInstance;
    }

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: Update()                                                        */
    /* Description: Called every frame.                                               */
    /* Parameters: None                                                               */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    private void Update()
    {
        if (activeUnit != null)
        {
            // On left click...
            if (_inputManager.SelectInput)
            {
                Debug.Log("Click Detected");
                RaycastHit mouseTarget = _inputManager.GetMouse3DTarget();
                Debug.Log(selectedTile + " Before");
                Debug.Log(targetUnit + " Before");
                if (mouseTarget.collider != null)
                {
                    // Trying to select target if none is selected.
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
                    //Trying to select tile if none is selected.
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
            // Deselect on right click
            if (_inputManager.DeselectInput)
            {
                DeselectAll();
            }
            // Force end turn if nothing can be done.
            if (remainingTM <= 0 && hasAction == false)
            {
                EndTurn();
            }
        }
    }

    private void SelectUnit()
    {

    }

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: DeselectAll()                                                   */
    /* Description: Used to condense all deselect actions.                            */
    /* Parameters: None                                                               */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
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

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: CheckTile()                                                     */
    /* Description: Called when selecting a tile to make sure it is a valid selection */
    /* Parameters: None                                                               */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
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

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: MoveToTile()                                                    */
    /* Description: Move to selected tile when the Move function is pressed.          */
    /* Parameters: None                                                               */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
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

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: SelectAbility()                                                 */
    /* Description: Change current ability selected by cycling through the list.      */
    /* Parameters: None                                                               */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
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

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: UseAbility()                                                    */
    /* Description: Activates the current ability and passes the target and caster.   */
    /* Parameters: None                                                               */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void UseAbility()
    {
        Debug.Log(abilitySelected._currCooldown); 
        //Plays the animation of a given move.
        activeUnit.GetComponent<ClassVitals>().DoAnimation(abilitySelected.GetName());
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

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: EndTurn()                                                       */
    /* Description: Deactivates all guides and shifts turn with CombatHandler.        */
    /* Parameters: None                                                               */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
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

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: EnablePlayer()                                                  */
    /* Description: Enables all parts of this class using the player passed.          */
    /* Parameters: GameObject currentPlayer - The blox currently in player turn.      */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
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
