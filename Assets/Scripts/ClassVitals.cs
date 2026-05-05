/***************************************************************
* Filename:       	ClassVitals.cs                             *
* Authors:        	Noah Stern                                 *
* Version Authors:	Noah Stern                                 *
* Current Version:  0.1.1                                      *
* Previous Version: 0.1.0                                      *
* Creation Date:  	April 28, 2026                             *
* Last Modified:  	May 5, 2026                                *
* Due Date:       	May 14th, 2026                             *
* Course:         	CPSC 323                                   *
* Professor Name: 	Professor Jacklitsch                       *
* Project:        	Braket Reset                               *
* Purpose:        	Store the stats for a specific Blox. Stats *
*                   include the HP, speed, attack, abilities,  *
*                   and ability effects. Also contains         *
*                   functions to take damage, heal, and apply  *
*                   statuses to Blox                           *
* Version Changes:	Added ClearStatus                          *
****************************************************************/

using System.Collections.Generic;
using UnityEngine;

public class ClassVitals
{
    //The class of the Blox
    private ClassAbstract _class;

    //The Blox's current health points
    private float _currHP;

    //The Blox's current speed
    private int _currSPD;

    //The Blox's current attack
    private int _currATK;

    //The Blox's current defense
    private int _currDEF;

    //The Blox's current tile movement value
    private int _currTM;

    //The Blox's current Hype ///////OUTDATED
    private int _currHype;

    //The Blox's current Range
    private int _currRange;

    //The Blox's current Luck
    private int _currLuck;

    //The Blox's current abilities
    private AbilityInstance[] _currAbilities;

    //The Blox's team (either player or enemy)
    private Team _team;

    //The Blox's current effects
    private List<EffectInstance> _currEffects;


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: ClassVitals                                                     */
    /* Description: A constructor to initiate the creation of a new Blox and to       */
    /*              create an empty list of effects for later                         */
    /* Parameters: ClassAbstract className: a specific class of Blox (ex: Fighter)    */
    /*             Team team: The team the Blox is on, either Player or Enemy         */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public ClassVitals(ClassAbstract className, Team team)
    {
        //Set the Blox's team
         _team = team;

        //Store what class is passed
        _class = className;

        _currEffects = new List<EffectInstance>();

        ClassFactory.BuildClass(this, _class);

    }//end ClassVitals Constructor

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: TakeDamage                                                      */
    /* Description: Deals damage to a Blox                                            */
    /* Parameters: float attackDamage: the amount of damage being done                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void TakeDamage(float attackDamage)
    {
        float damageReduced = Mathf.Max(attackDamage - _currDEF, 1);
        _currHP -= damageReduced;
    }//end TakeDamage


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: HealBlox                                                        */
    /* Description: Heals damage from a Blox                                          */
    /* Parameters: int healAmount: the amount of damage being healed                  */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void HealBlox(float healAmount)
    {
        _currHP += healAmount;
    }//end HealBlox


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: UpdateSpeed                                                     */
    /* Description: Updates a Blox's speed                                            */
    /* Parameters: int speedModifier: the amount the Blox's speed will change         */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void UpdateSpeed(int speedModifier)
    {
        _currSPD += speedModifier;
    }//end TakeDamage


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: UpdateTileMovement                                              */
    /* Description: Updates a Blox's tile movement value                              */
    /* Parameters: int speedModifier: the amount the Blox's tile movement will change */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void UpdateTileMovement(int tileMovementModifier)
    {
        _currTM += tileMovementModifier;
    }//end TakeDamage


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: UpdateHype                                                      */
    /* Description: Updates a Blox's hype generation                                  */
    /* Parameters: int hypeModifier: the amount the Blox's hype generation will change*/
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void UpdateHype(int hypeModifier)
    {
        _currHype += hypeModifier;
    }//end TakeDamage


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: UpdateDefense                                                   */
    /* Description: Updates a Blox's defense                                          */
    /* Parameters: int defenseModifier: the amount the Blox's defense will change     */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void UpdateDefense(int defenseModifier)
    {
        _currDEF += defenseModifier;
    }//end TakeDamage


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: UpdateLuck                                                      */
    /* Description: Updates a Blox's luck                                             */
    /* Parameters: int luckModifier: the amount the Blox's luck will change           */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void UpdateLuck(int luckModifier)
    {
        _currLuck += luckModifier;
    }//end TakeDamage


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: UpdateAttack                                                    */
    /* Description: Updates a Blox's attack                                           */
    /* Parameters: int attackModifier: the amount the Blox's attack will change       */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void UpdateAttack(int attackModifier)
    {
        _currATK += attackModifier;
    }//end TakeDamage


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: GetTeam                                                         */
    /* Description: A gettor for what team the blox is on                             */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public Team GetTeam()
    {
        return _team;
    }


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: SetBloxStats                                                    */
    /* Description: Sets a specific Blox's stats based on the provided values         */
    /* Parameters: float healthPoints: the Blox's assigned health points              */
    /*             int speed: the Blox's assigned speed                               */
    /*             int attack: the Blox's assigned attack                             */
    /*             int defense: the Blox's assigned defense                           */
    /*             int tileMovement: the Blox's assigned tile movement                */
    /*             int range: the Blox's assigned range                               */
    /*             int luck: the Blox's assigned luck                                 */
    /*             int speed: the Blox's assigned speed                               */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void SetBloxStats(float healthPoints, int speed, int attack, int defense, int tileMovement, int hype, int range, int luck)
    {
        _currHP = healthPoints;
        _currSPD = speed;
        _currATK = attack;
        _currDEF = defense;
        _currTM = tileMovement;
        _currHype = hype;
        _currRange = range;
        _currLuck = luck;
    }//end SetBloxStats


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: SetBloxAbilities                                                */
    /* Description: Assigns abilities to the Blox                                     */
    /* Parameters: AbilityInstance[] abilities: the array of abilities being assigned */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void SetBloxAbilities(AbilityInstance[] abilities)
    {
        _currAbilities = abilities;
    }//end SetBloxAbilities


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: ApplyStatus                                                     */
    /* Description: Applies a status (effect) to the blox, adds it to the             */
    /*              _currEffects array                                                */
    /* Parameters: EffectInstance effect: the effect being added to the Blox/array    */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void ApplyStatus(EffectInstance effect)
    {
        _currEffects.Add(effect);
    }//end ApplyStatus


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: ClearStatus                                                     */
    /* Description: Clears all current statuses on a blox                             */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void ClearStatus()
    {
        _currEffects.Clear();
    }


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: GetSpeed                                                        */
    /* Description: A gettor for the Blox's speed                                     */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public int GetSpeed()
    {
        return _currSPD;
    }

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: TurnTick                                                        */
    /* Description: Goes through every effect on the Blox and updates their duration  */
    /*              and other effects, also removes an effect if it expired. Also     */
    /*              goes through every ability and updates their cooldowns            */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void TurnTick()
    {
        for (int i = _currEffects.Count - 1; i >= 0; i--)
        {
            EffectInstance effect = _currEffects[i];

            effect.EffectTick(this);

            if (effect.IsExpired())
            {
                _currEffects.RemoveAt(i);
            }//end if
        }//end for

        for (int i = 0; i < _currAbilities.Length; i++)
        {
            if (_currAbilities[i]._currCooldown > 0)
            {
                _currAbilities[i]._currCooldown--;
            }//end if
        }//end for
    }//end TurnTick

}//end ClassVitals