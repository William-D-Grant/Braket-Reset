using NUnit.Framework;
using System.Collections.Generic;
using Unity.Multiplayer.PlayMode;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField]
    private MapHandler _mapHandler;
    [SerializeField]
    private CombatHandler _combatHandler;

    private GameObject _closestTarget;

    private GameObject _currentEnemy;

    private bool _isAdjacentToPlayer;

    private int remainingTM;

    private bool hasAction;

    private Queue<Tile> path = new Queue<Tile>();

    private AbilityInstance abilitySelected;

    private int abilityAttempts;

    
    private void Update()
    {
        if (_currentEnemy != null)
        {
            ChangeState();
        }
    }//end update

    // https://stackoverflow.com/questions/71130518/find-closest-object-in-unity-3d
    public void FindClosestTarget()
    {
        _closestTarget = null;

        float closestDistance = Mathf.Infinity;

        foreach (GameObject playerBlox in _combatHandler._currentPlayerBlox)
        {
            float distance = Vector2.Distance(_currentEnemy.transform.position, playerBlox.transform.position);
            
            if (distance < closestDistance)
            {
                closestDistance = distance;
                _closestTarget = playerBlox;
            }//end if
        }//end foreach
    }//end FindClosetTarget


    public void ChangeState()
    {
        if (abilitySelected._currCooldown != 0)
        {
            abilitySelected = _currentEnemy.GetComponent<ClassVitals>()._currAbilities[(int)Random.Range(0, _currentEnemy.GetComponent<ClassVitals>()._currAbilities.Length)];
            Debug.Log("Enemy selecting new ability");
        }

        if (hasAction && _closestTarget != null && abilitySelected._currCooldown == 0)
        {
            Debug.Log("Enemy attempting ability");
            if (abilitySelected.GetRange() == 0 || abilitySelected.GetDamage() <= 0)
            {
                abilitySelected.UseAbility(_currentEnemy.GetComponent<ClassVitals>(), _currentEnemy.GetComponent<ClassVitals>());
                hasAction = false;
                Debug.Log("Enemy casting on self.");
            }
            else if (Mathf.Abs(_currentEnemy.GetComponent<ClassVitals>()._currPos.x - _closestTarget.GetComponent<ClassVitals>()._currPos.x) + Mathf.Abs(_currentEnemy.GetComponent<ClassVitals>()._currPos.y - _closestTarget.GetComponent<ClassVitals>()._currPos.y) <= abilitySelected.GetRange())
            {
                abilitySelected.UseAbility(_currentEnemy.GetComponent<ClassVitals>(), _closestTarget.GetComponent<ClassVitals>());
                hasAction = false;
                Debug.Log("Enemy casting on " + _closestTarget);
            }
        }
        abilityAttempts++;
        //if (_isAdjacentToPlayer == true && hasAction == true)
        //{
        //    //attack logic here
        //    hasAction = false;
        //    EndTurn();
        //    return;
        //}// end if

        if (remainingTM > 0 && path.Count > 1)
        {
            Debug.Log("Enemy attempting to move to " + _closestTarget);
            Tile currentTile = path.Dequeue();
            Debug.Log("Going to " + currentTile.position + "on the grid, which is  " + currentTile.transform.position + " in the world.");
            _currentEnemy.transform.position = currentTile.transform.position + new Vector3(0, _mapHandler.playerOffset + 0.2f, 0);
            _mapHandler.ChangePosition(_currentEnemy, currentTile.position);
            //_currentEnemy.GetComponent<ClassVitals>()._currPos = _currentTile.position;

            //_mapHandler.ChangePosition(_activeEnemy.gameObject, nextTile);

            remainingTM--;

            return;
        }//end if

        if (remainingTM < 0 && !hasAction)
        {
            Debug.Log("Enemy ending turn from no actions");
            EndTurn();
        }


        if (abilityAttempts == 10)
        {
            Debug.Log("Enemy ending turn from trying too hard");
            EndTurn();
        }
    }//end ChangeState


    public void EndTurn()
    {
        _currentEnemy.transform.Find("HighlightActive").gameObject.SetActive(false);
        abilityAttempts = 0;
        _closestTarget = null;
        _currentEnemy = null;

        path = new Queue<Tile>();

        remainingTM = 0;
        hasAction = true;

        _combatHandler.ShiftTurn();
    
}//end EndTurn

    public void PathToTarget()
    {
        Tile currentTile = _mapHandler.tileGrid[(int)_currentEnemy.GetComponent<ClassVitals>()._currPos.x, (int)_currentEnemy.GetComponent<ClassVitals>()._currPos.y];
        bool pathFound = false;
        int pathLength = 0;

        while (!pathFound && pathLength <= 30)
        {
            if (_mapHandler.unitGrid[(int)currentTile.position.x, (int)currentTile.position.y] != null)
            {
                if (_mapHandler.unitGrid[(int)currentTile.position.x, (int)currentTile.position.y].GetComponent<ClassVitals>()._team == Team.Player)
                {
                    pathFound = true;
                    break;
                }
            }
            List<Tile> nearbyTiles = _mapHandler.FindAttackTilesNearTile(currentTile);
            float closestDistance = Mathf.Infinity;
            foreach (Tile option in nearbyTiles)
            {
                float distance = Vector2.Distance(option.transform.position, _closestTarget.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    currentTile = option;
                }//end if
            }
            path.Enqueue(currentTile);
            pathLength++;
        }
        Debug.Log(pathLength);
        

    }//end PathToTarget

    public void EnableEnemy(GameObject currentEnemy)
    {
        _currentEnemy = currentEnemy;
        _currentEnemy.transform.Find("HighlightActive").gameObject.SetActive(true);
        remainingTM = _currentEnemy.GetComponent<ClassVitals>().GetTileMovement();
        hasAction = true;
        abilitySelected = _currentEnemy.GetComponent<ClassVitals>()._currAbilities[0];
        FindClosestTarget();
        PathToTarget();
        Debug.Log(_currentEnemy + " is current enemy.");
    }

 
}//end EnemyController
