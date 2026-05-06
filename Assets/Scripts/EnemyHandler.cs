using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController
{

    //[SerializeField]
    //private MapHandler _mapHandler;

    private CombatHandler _combatHandler;

    private RunManager _runManger;

    private GameObject _closestTarget;

    private ClassVitals _currentEnemy;

    private bool _isAdjacentToPlayer;

    private int _remainingTM;

    private bool _hasAction;

    private List<GameObject> path = new List<GameObject>();

    /*
    private void Update()
    {
        ChangeState();
    }//end update

    // https://stackoverflow.com/questions/71130518/find-closest-object-in-unity-3d
    public void FindClosestTarget()
    {
        _closestTarget = null;

        float closestDistance = Mathf.Infinity;

        foreach (ClassVitals playerBlox in _combatHandler.PlayerList())
        {
            float distance = Vector2.Distance(activeEnemyBlox.transform.position, playerBlox.transform.position);
            
            if (distance < closestDistance)
            {
                closestDistance = distance;
                _closestTarget = playerBlox.GameObject;
            }//end if
        }//end foreach

    }//end FindClosetTarget


    public void ChangeState()
    {
        FindClosestTarget();
        PathtoTarget();

        if (_isAdjacentToPlayer == true && _hasAction == true)
        {
            //attack logic here
            _hasAction = false;
            EndTurn();
            return;
        }// end if

        if (_remainingTM > 0 && path.Count > 1)
        {
            GameObject nextTile = path[1];

            //_mapHandler.ChangePosition(_activeEnemy.gameObject, nextTile);

            _remainingTM--;

            return;
        }//end if

        EndTurn();
    }//end ChangeState


    public void EndTurn()
    {
        _closestTarget = null;

        path = new List<GameObject>();

        _remainingTM = 0;
        _hasAction = false;

        _runManager.EndTurn();
    
}//end EndTurn

    public void PathToTarget()
    {

    }//end PathToTarget

    */
}//end EnemyController
