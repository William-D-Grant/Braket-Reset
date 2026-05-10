/***************************************************************
* Filename:       	EnemyTeam.cs                               *
* Authors:        	Noah Stern                                 *
* Version Authors:	Noah Stern                                 *
* Current Version:  0.0.1                                      *
* Previous Version: 0.0.0                                      *
* Creation Date:  	May 2, 2026                                *
* Last Modified:  	May 2, 2026                                *
* Due Date:       	May 14th, 2026                             *
* Course:         	CPSC 323                                   *
* Professor Name: 	Professor Jacklitsch                       *
* Project:        	Braket Reset                               *
* Purpose:        	A basis for all enemy teams to follow      *
* Version Changes:	Created and finished                       *
****************************************************************/
using UnityEngine;
using System.Collections.Generic;


public class EnemyTeam : MonoBehaviour
{
    //The enemy's name
    public string enemyName;

    //The list of the enemy's blox
    public List<BloxClass> enemyBlox;

    //The team the Blox is on (Enemy)
    public Team team = Team.Enemy;


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: EnemyTeam                                                       */
    /* Description: A constructor that builds an enemy team, including the enemy's    */
    /*              name and the Blox they use                                        */
    /* Parameters: string enemyName: The name of the enemy                            */
    /*             List<BloxClass> enemyBlox: A list of said enemy's Blox             */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public EnemyTeam(string enemyName, List<BloxClass> enemyBlox)
    {
        this.enemyName = enemyName;
        this.enemyBlox = enemyBlox;
    }//end Team Constructor

}//end Team
