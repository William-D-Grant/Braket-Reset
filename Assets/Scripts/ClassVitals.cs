/***************************************************************
* Filename:       	ClassVitals.cs                             *
* Authors:        	Noah Stern                                 *
* Version Authors:	Noah Stern                                 *
* Current Version:  0.4.2                                      *
* Previous Version: 0.4.1                                      *
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
* Version Changes:	Added Upgrade___ set of functions          *
****************************************************************/

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class ClassVitals : MonoBehaviour
{
    [SerializeField]
    public BloxClass _bloxClass;

    //The class of the Blox
    public ClassAbstract _class { get; private set; }

    //The Blox's current health points
    public float _currHP { get; private set; }

    //The Blox's current speed
    //private
    private int _currSPD;

    //The Blox's current attack
    //private
    private int _currATK;

    //The Blox's current defense
    //private 
    private int _currDEF;

    //The Blox's current tile movement value
    private int _currTM;

    //The Blox's current Hype generation
    private int _currHype;

    //The Blox's current Range
    //private
    private int _currRange;

    //The Blox's current Luck
    //private
    private int _currLuck;

    //The Blox's current abilities
    public AbilityInstance[] _currAbilities;

    //The Blox's team (either player or enemy)
    public Team _team;

    //The Blox's current effects
    private List<EffectInstance> _currEffects;

    //The Blox's current position
    public Vector2 _currPos;

    //The associated Blox's GameObject
    public GameObject _bloxObject;

    //On defeat action for blox
    public event Action<ClassVitals> onDefeated;

    //An attack bonus, what is actually upgraded each run
    private int _bonusATK;

    //A TM bonus, what is actually upgraded each run
    private int _bonusTM;

    //A defense bonus, what is actually upgraded each run
    private int _bonusDEF;

    //A hype bonus, what is actually upgraded each run
    private int _bonusHype;

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: InitializeBlox                                                  */
    /* Description: A constructor to initiate the creation of a new Blox and to       */
    /*              create an empty list of effects for later                         */
    /* Parameters: BloxClass className: a specific class of Blox (ex: Fighter)        */
    /*             Team team: The team the Blox is on, either Player or Enemy         */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/

    private void Awake()
    {
        InitializeBlox(_bloxClass, _team);
    }

    public void InitializeBlox(BloxClass className, Team team)
    {
        //Set the Blox's team
         _team = team;


        switch (className)
        {
            case BloxClass.Fighter:
                _class = new FighterClass();
                break;

            case BloxClass.Tank:
                _class = new TankClass();
                break;

            case BloxClass.Ranger:
                _class = new RangerClass();
                break;

            case BloxClass.Thief:
                _class = new ThiefClass();
                break;

            case BloxClass.Sage:
                _class = new SageClass();
                break;

            case BloxClass.Clown:
                _class = new ClownClass();
                break;

            case BloxClass.Cowboy:
                _class = new CowboyClass();
                break;

            case BloxClass.Pirate:
                _class = new PirateClass();
                break;

            case BloxClass.Test:
                _class = new TestingClass();
                break;

            default:
                _class = new CowboyClass();
                break;

        }//end switch

        //Store what class is passed
        //_class = className;

        //Set Blox model
        //_bloxObject = className.bloxObject;

        _currEffects = new List<EffectInstance>();

        ClassFactory.BuildClass(this, _class);

    }//end ClassVitals Constructor

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: TakeDamage                                                      */
    /* Description: Deals damage to a Blox                                            */
    /* Parameters: float attackDamage: the amount of damage being done                */
    /*             bool isCrit: True if the attack crit, false otherwise              */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void TakeDamage(float attackDamage, bool isCrit)
    {
        if (attackDamage == 0)
        {
            return;
        }//end if
        if (isCrit == true)
        {
            _currHP -= attackDamage;
        }//end if
        else if (isCrit == false)
        {
            float damageReduced = Mathf.Max(attackDamage - _currDEF, 1);
            _currHP -= damageReduced;
        }//end if

        if(this._currHP <= 0)
        {
            onDefeated?.Invoke(this);
        }//end if

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
    }//end UpdateSpeed


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: UpdateHealth                                                    */
    /* Description: Updates a Blox's health                                           */
    /* Parameters: int speedModifier: the amount the Blox's speed will change         */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void UpdateHealth(int healthModifier)
    {
        _currHP += healthModifier;
    }//end UpdateHealth


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
    }//end UpdateTileMovement


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
    }//end UpdateHype


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
    }//end UpdateDefense


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
    }//end UpdateLuck


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
    }//end UpdateAttack


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: UpgradeAttack                                                   */
    /* Description: Upgrades a Blox's attack, increasing the bonus amount of attack   */
    /*              instead of the actual attack so spawning logic remains the same   */
    /* Parameters: int attackModifier: the amount the Blox's bonus attack will change */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void UpgradeAttack(int attackModifier)
    {
        _bonusATK += attackModifier;
    }//end UpgradeAttack

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: GetBonusAttack                                                  */
    /* Description: A gettor the the bonus attack                                     */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public int GetBonusAttack()
    {
        return _bonusATK;
    }//end UpgradeAttack

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: UpgradeDefense                                                  */
    /* Description: Upgrades a Blox's defense, increasing the bonus amount of defense */
    /*              instead of the actual defense so spawning logic remains the same  */
    /* Parameters: int defenseModifier: the amount the Blox's bonus defense will change*/
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void UpgradeDefense(int defenseModifier)
    {
        _bonusDEF += defenseModifier;
    }//end UpgradeDefense

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: UpgradeTileMovement                                             */
    /* Description: Upgrades a Blox's TM, increasing the bonus amount of TM           */
    /*              instead of the actual TM so spawning logic remains the same       */
    /* Parameters: int tileMovementModifier: the amount the Blox's bonus TM will change*/
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void UpgradeTileMovement(int tileMovementModifier)
    {
        _bonusTM += tileMovementModifier;
    }//end UpgradeTileMovement


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: UpgradeHype                                                     */
    /* Description: Upgrades a Blox's hype, increasing the bonus amount of hype       */
    /*              instead of the actual hype so spawning logic remains the same     */
    /* Parameters: int hypeModifier: the amount the Blox's bonus hype will change     */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void UpgradeHype(int hypeModifier)
    {
        _bonusHype += hypeModifier;
    }//end UpgradeHype


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
    }//end GetTeam


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
    }//end ClearStatus


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
    }//end GetSpeed


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: GetAttack                                                       */
    /* Description: A gettor for the Blox's attack                                    */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public int GetAttack()
    {
        return _currATK + _bonusATK;
    }//end GetAttack


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: GetRange                                                        */
    /* Description: A gettor for the Blox's Range                                     */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public int GetRange()
    {
        return _currRange;
    }//end GetRange


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: GetLuck                                                         */
    /* Description: A gettor for the Blox's luck                                      */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public int GetLuck()
    {
        return _currLuck;
    }//end GetLuck


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: GetDefense                                                      */
    /* Description: A gettor for the Blox's defense                                   */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public int GetDefense()
    {
        return _currDEF + _bonusDEF;
    }//end GetDefense

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: GetDefense                                                      */
    /* Description: A gettor for the Blox's defense                                   */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public int GetTileMovement()
    {
        return _currTM + _bonusTM;
    }//end GetDefense

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: TurnTick                                                        */
    /* Description: Goes through every effect on the Blox and updates their duration  */
    /*              and other effects, also removes an effect and any stat changes    */
    /*              if it expired. Also  goes through every ability and updates       */
    /*              their cooldowns                                                   */
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

            if (effect.IsExpired() == true)
            {
                switch (_currEffects[i]._effectID)
                {
                    case "SHIELD_BASH":
                        this.UpdateSpeed(2);
                        break;

                    case "DEFEND":
                        this.UpdateDefense(-2);
                        break;

                    case "SPEED_DEMON":
                        this.UpdateTileMovement(-3);
                        this.UpdateAttack(-1);
                        break;

                    case "HYPE_TRAIN":
                        this.UpdateDefense(1);
                        this.UpdateHype(-3);
                        break;

                    case "CAUGHT":
                        this.UpdateTileMovement(90);
                        break;

                    case "JOKE":
                        this.UpdateHype(-2);
                        break;

                    case "SEA_SHANTY":
                        if(this.GetTeam() == _currEffects[i]._casterTeam)
                        {
                            this.UpdateLuck(-2);
                            this.UpdateHype(-2);
                        }//end if
                        else if (this.GetTeam() != _currEffects[i]._casterTeam)
                        {
                            this.UpdateLuck(2);
                            this.UpdateHype(2);
                        }//end if
                        break;

                    case "HUM":
                        this.UpdateLuck(-1);
                        break;

                }//end switch

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