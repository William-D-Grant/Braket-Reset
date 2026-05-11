/***************************************************************
* Filename:       	EnemyTeamSelector.cs                       *
* Authors:        	Noah Stern                                 *
* Version Authors:	Noah Stern                                 *
* Current Version:  0.2.0                                      *
* Previous Version: 0.1.0                                      *
* Creation Date:  	May 2, 2026                                *
* Last Modified:  	May 7, 2026                                *
* Due Date:       	May 14th, 2026                             *
* Course:         	CPSC 323                                   *
* Professor Name: 	Professor Jacklitsch                       *
* Project:        	Braket Reset                               *
* Purpose:        	Hold all of the possible enemy teams, the  *
*                   current list of enemy teams, the current   *
*                   enemy team the player is fighting, and     *
*                   handle remaking and shuffling these        *
* Version Changes:	Made EnemyTeamSelector a singleton         *
****************************************************************/
using UnityEngine;
using System.Collections.Generic;

public class EnemyTeamSelector : MonoBehaviour
{
    //
    public static EnemyTeamSelector _singletonInstance { get; private set; }

    //A list of all of the enemy teams, enemy teams are hard coded to give personality to them 
    private List<EnemyTeam> _allEnemyTeams;

    //The enemy teams in the current bracket run, remade for eachrun
    private List<EnemyTeam> _currentBracketTeams;

    //The current enemy team the player is fighting against
    public EnemyTeam currentEnemyTeam { get; private set; }




    /***************************************************************************************************/
    /*                                                                                                 */
    /* Function name: Awake                                                                            */
    /* Description: Makes EnemyTeamSelector a singleton, and resets the bracket <- say that again      */ 
    /* Parameters: N/A                                                                                 */
    /* Return Value: N/A                                                                               */
    /*                                                                                                 */
    /***************************************************************************************************/
    private void Awake()
    {
        if (_singletonInstance == null)
        {
            _singletonInstance = this;
            DontDestroyOnLoad(gameObject);
            ResetBracket();
        }
        else
        {
            Destroy(gameObject);
        }

    }//end void

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: GetRandomTeam                                                   */
    /* Description: Gets a random team for the player to fight against, and removes   */
    /*              that team from _currentBracketTeams so it can't be chosen again   */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    //# Taken from John French on https://gamedevbeginner.com/how-to-use-random-values-in-unity-with-examples/
    public EnemyTeam GetRandomTeam()
    {
        //Generates a random number from 0 to the current number of teams in bracket and assigns the _currentEnemyTeam to the team randomly generated
        int randomNumber = Random.Range(0, _currentBracketTeams.Count);
        currentEnemyTeam = _currentBracketTeams[randomNumber];

        //Removes that team from _currentBracketTeams
        RemoveFromBracket(currentEnemyTeam);

        //Return the _currentEnemyTeam
        return currentEnemyTeam;

    }//end GetRandomTeam

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: RemoveFromBracket                                               */
    /* Description: Removes a team from the bracket                                   */
    /* Parameters: EnemyTeam removeTeam: The team being removed from                  */
    /*             _currentBracketTeams                                               */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void RemoveFromBracket(EnemyTeam removeTeam)
    {
        _currentBracketTeams.Remove(removeTeam);
    }

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: ResetBracket                                                    */
    /* Description: Builds all enemy teams at the start of every run and assigns them */
    /*              to _currentBracketTeams, then shuffles the bracket to keep it     */
    /*              really random                                                     */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void ResetBracket()
    {
        //Build all enemy teams and clear _currentBracketTeams
        BuildEnemyTeams();
        _currentBracketTeams = new List<EnemyTeam>();

        //Loop through _allEnemyTeams and assign them to _currentBracketTeams
        for (int i = 0; i < _allEnemyTeams.Count; i++)
        {
            _currentBracketTeams.Add(_allEnemyTeams[i]);
        }

        //Shuffle the bracket
        ShuffleBracket(_currentBracketTeams);

    }//end ResetBracket


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: ShuffleBracket                                                  */
    /* Description: Shuffles the bracket to ensure complete randomness                */
    /* Parameters: EnemyTeam bracket: All the teams in the current bracket            */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    //Taken from wideeyenow_unity on https://discussions.unity.com/t/how-can-i-shuffle-a-list/75012/8
    private void ShuffleBracket(List<EnemyTeam> bracket)
    {
        List<EnemyTeam> temp = new List<EnemyTeam>();
        temp.AddRange(bracket);

        bracket.Clear();

        while (temp.Count > 0)
        {
            int index = Random.Range(0, temp.Count);
            bracket.Add(temp[index]);
            temp.RemoveAt(index);

        }//end while

    }//end ShuffleBracket


    /*************************************************************************************************/
    /*                                                                                               */
    /* Function name: BuildEnemyTeams                                                                */
    /* Description: Clear _allEnemyTeams and build blueprints for all of the hardcoded enemy teams,  */
    /*              enemy teams are hardcoded to give them character and personality,                */
    /* Parameters: N/A                                                                               */
    /* Return Value: N/A                                                                             */
    /*                                                                                               */
    /*************************************************************************************************/
    private void BuildEnemyTeams()
    {
        //Clear _allEnemyTeams
        _allEnemyTeams = new List<EnemyTeam>();

        //Build Alec Smartville XII
        _allEnemyTeams.Add(new EnemyTeam("ALEC_SMARTSVILLE_XII", new List<ClassAbstract>
        {
            new PirateClass(),
            new ThiefClass(),
            new ClownClass()
        }));

        //Build Gerrelle Hatchetman
        _allEnemyTeams.Add(new EnemyTeam("GERRELE_HATCHETMAN", new List<ClassAbstract>
        {
            new CowboyClass(),
            new CowboyClass(),
            new SageClass()
        }));

        //Build Circe Listerine
        _allEnemyTeams.Add(new EnemyTeam("CIRCE_LISTERINE", new List<ClassAbstract>
        {
            new FighterClass(),
            new ClownClass(),
            new PirateClass()
        }));

        //Build Leneyjoce Superdark
        _allEnemyTeams.Add(new EnemyTeam("LENEYJOCE_SUPERDARK",new List<ClassAbstract>
        {
            new FighterClass(),
            new TankClass(),
            new RangerClass()
        }));

        //Build Professor Jac- I mean Vector Vachglitch
        _allEnemyTeams.Add(new EnemyTeam("VECTOR_VACHGLITCH", new List<ClassAbstract>
        {
            new CowboyClass(),
            new RangerClass(),
            new RangerClass()
        }));

        //Build Chimp T. Lucky
        _allEnemyTeams.Add(new EnemyTeam("CHIMP_T_LUCKY", new List<ClassAbstract>
        {
            new PirateClass(),
            new PirateClass(),
            new PirateClass()
        }));

        //Build Holly WarmHart
        _allEnemyTeams.Add(new EnemyTeam("HOLLY_WARMHART", new List<ClassAbstract>
        {
            new SageClass(),
            new TankClass(),
            new ClownClass()
        }));

        //Set the team to Enemy
        foreach(EnemyTeam team in _allEnemyTeams)
        {
            team.team = Team.Enemy;
        }

    }//end BuildEnemyTeams
}
