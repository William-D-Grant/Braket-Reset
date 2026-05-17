/***************************************************************
* Filename:       	AbilityInstance.cs                         *
* Authors:        	Noah Stern                                 *
* Version Authors:	Noah Stern                                 *
* Current Version:  0.1.0                                      *
* Previous Version: 0.0.2                                      *
* Creation Date:  	April 28, 2026                             *
* Last Modified:  	May 16th, 2026                             *
* Due Date:       	May 17th, 2026                             *
* Course:         	CPSC 323                                   *
* Professor Name: 	Professor Jacklitsch                       *
* Project:        	Braket Reset                               *
* Purpose:        	A runtime instance of an ability. Used to  *
*                   separate the AbilityFlyweights from        *
*                   gameplay so they can be reused             *
* Version Changes:	Updated logic to account for Hype costs    *
****************************************************************/

using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AbilityInstance
{
   //The blox's ability stats
    private AbilityFlyweight _abilityStats;
    public int _currCooldown;

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: AbilityInstance                                                 */
    /* Description: Assigned the AbilityFlyweight's stats to this Blox's ability stats*/
    /* Parameters: AbilityFlyweight abilityStats: The flyweight of the ability stats  */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public AbilityInstance(AbilityFlyweight abilityStats)
    {
        this._abilityStats = abilityStats;
    }//end AbilityInstance Constructor


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: GetRange                                                        */
    /* Description: A gettor for the ability's range                                  */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public int GetRange()
    {
        return _abilityStats.abilityRange;
    }//end GetRange


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: GetName                                                         */
    /* Description: A gettor for the ability's Name                                   */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public string GetName()
    {
        return _abilityStats.abilityID;
    }//end GetName


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: GetDamage                                                       */
    /* Description: A gettor for the ability's Damage                                 */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public float GetDamage()
    {
        return _abilityStats.abilityDamage;
    }//end GetDamage


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: SetCooldown                                                     */
    /* Description: Sets the cooldown to the passed int                               */
    /* Parameters: int newCooldown: the new cooldown of this ability                  */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void SetCooldown(int newCooldown)
    {
        _currCooldown = newCooldown;
    }//end SetCooldown



    /**********************************************************************************/
    /*                                                                                */
    /* Function name: UseAbility                                                      */
    /* Description: Applies all stat changes (hype, cooldown, damage), checks for a   */
    /*              crit, and if the ability causes an effect, apply that effect      */
    /* Parameters: ClassVitals abilityCaster: the Blox that cast the ability          */
    /*             ClassVitals abilityTarget: the blox that was targeted for the ability */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void UseAbility(ClassVitals abilityCaster, ClassVitals abilityTarget)
    {
        if (RunManager._singletonInstance.currentHype >= this._abilityStats.abilityCost && _currCooldown == 0)
        {
            _currCooldown = _abilityStats.abilityCooldown;
            RunManager._singletonInstance.UpdateHype(-this._abilityStats.abilityCost);
            RunManager._singletonInstance.UpdateHype(abilityCaster.GetHype());
            //the thing that used ability hype -= _abilityStats.abilityCost;
            int critChance = Random.Range(0, 10);
            if (critChance > abilityCaster.GetLuck())
            {
                abilityTarget.TakeDamage(_abilityStats.abilityDamage + abilityCaster.GetBonusAttack(), false);
            }//end if
            else if (critChance <= abilityCaster.GetLuck())
            {
                abilityTarget.TakeDamage(_abilityStats.abilityDamage, true);
            }//end else if

            string abilityName = _abilityStats.abilityID;

            switch (abilityName)
            {
                case "Shield Bash":
                    EffectFlyweight shieldBashEffect = EffectFactory.RetrieveEffect("SHIELD_BASH");
                    EffectInstance shieldBashInstance = new EffectInstance(shieldBashEffect, abilityCaster.GetTeam(), abilityTarget.GetTeam());
                    abilityTarget.UpdateSpeed(-2);
                    abilityTarget.ApplyStatus(shieldBashInstance);
                    break;

                case "Defend":
                    EffectFlyweight defendEffect = EffectFactory.RetrieveEffect("DEFEND");
                    EffectInstance defendInstance = new EffectInstance(defendEffect, abilityCaster.GetTeam(), abilityTarget.GetTeam());
                    abilityTarget.UpdateDefense(2);
                    abilityTarget.ApplyStatus(defendInstance);
                    break;

                case "Speed Demon":
                    EffectFlyweight speedDemonEffect = EffectFactory.RetrieveEffect("SPEED_DEMON");
                    EffectInstance speedDemonInstance = new EffectInstance(speedDemonEffect, abilityCaster.GetTeam(), abilityTarget.GetTeam());
                    abilityTarget.UpdateTileMovement(3);
                    abilityTarget.UpdateAttack(1);
                    abilityTarget.ApplyStatus(speedDemonInstance);
                    break;

                case "Life Drain":
                    abilityCaster.HealBlox(_abilityStats.abilityDamage);
                    break;

                case "Heal":
                    abilityTarget.HealBlox(5);
                    break;

                case "Hype Train":
                    EffectFlyweight hypeTrainEffect = EffectFactory.RetrieveEffect("HYPE_TRAIN");
                    EffectInstance hypeTrainInstance = new EffectInstance(hypeTrainEffect, abilityCaster.GetTeam(), abilityTarget.GetTeam());
                    abilityCaster.UpdateDefense(-1);
                    abilityCaster.UpdateHype(3);
                    abilityCaster.ApplyStatus(hypeTrainInstance);
                    break;

                case "Joke":
                    EffectFlyweight jokeEffect = EffectFactory.RetrieveEffect("JOKE");
                    EffectInstance jokeInstance = new EffectInstance(jokeEffect, abilityCaster.GetTeam(), abilityTarget.GetTeam());
                    abilityCaster.UpdateHype(2);
                    abilityCaster.ApplyStatus(jokeInstance);
                    break;

                case "Caught":
                    EffectFlyweight caughtEffect = EffectFactory.RetrieveEffect("CAUGHT");
                    EffectInstance caughtInstance = new EffectInstance(caughtEffect, abilityCaster.GetTeam(), abilityTarget.GetTeam());
                    abilityTarget.UpdateTileMovement(-90);
                    abilityTarget.ApplyStatus(caughtInstance);
                    break;

                case "Sea Shanty":
                    EffectFlyweight seaShantyEffect = EffectFactory.RetrieveEffect("SEA_SHANTY");
                    EffectInstance seaShantyInstance = new EffectInstance(seaShantyEffect, abilityCaster.GetTeam(), abilityTarget.GetTeam());
                    if ((abilityTarget.GetTeam() == Team.Player && abilityCaster.GetTeam() == Team.Player) || (abilityTarget.GetTeam() == Team.Enemy && abilityCaster.GetTeam() == Team.Enemy))
                    {
                        abilityTarget.UpdateLuck(2);
                        abilityTarget.UpdateHype(2);
                    }//end if
                    else
                    {
                        abilityTarget.UpdateLuck(-2);
                        abilityTarget.UpdateHype(2);
                    }//end else
                    break;

                case "Hum":
                    EffectFlyweight humEffect = EffectFactory.RetrieveEffect("HUM");
                    EffectInstance humInstance = new EffectInstance(humEffect, abilityCaster.GetTeam(), abilityTarget.GetTeam());
                    abilityCaster.UpdateLuck(1);
                    abilityCaster.ApplyStatus(humInstance); 
                    break;
            }//end switch
        }//end if

    }//end UseAbility

}//end AbilityInstance
