/***************************************************************
* Filename:       	AbilityInstance.cs                         *
* Authors:        	Noah Stern                                 *
* Version Authors:	Noah Stern                                 *
* Current Version:  0.0.1                                      *
* Previous Version: N/A                                        *
* Creation Date:  	April 28, 2026                             *
* Last Modified:  	April 30, 2026                             *
* Due Date:       	May 14th, 2026                             *
* Course:         	CPSC 323                                   *
* Professor Name: 	Professor Jacklitsch                       *
* Project:        	Braket Reset                               *
* Purpose:        	A runtime instance of an ability. Used to  *
*                   separate the AbilityFlyweights from        *
*                   gameplay so they can be reused             *
* Version Changes:	Created                                    *
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


    public void UseAbility(ClassVitals abilityCaster, ClassVitals abilityTarget)
    {
        if (/*thing that used ability has enough hype*/ 1 == 1 && _currCooldown == 0)
        {
            //the thing that used ability hype -= _abilityStats.abilityCost;
            abilityTarget.TakeDamage(_abilityStats.abilityDamage);
            _currCooldown = _abilityStats.abilityCooldown;

            string abilityName = _abilityStats.abilityID;

            switch (abilityName)
            {
                case "SHIELD_BASH":
                    EffectFlyweight shieldBashEffect = EffectFactory.RetrieveEffect("SHIELD_BASH");
                    EffectInstance shieldBashInstance = new EffectInstance(shieldBashEffect);
                    abilityTarget.UpdateSpeed(-2);
                    abilityTarget.ApplyStatus(shieldBashInstance);
                    break;

                case "SPEED_DEMON":
                    EffectFlyweight speedDemonEffect = EffectFactory.RetrieveEffect("SPEED_DEMON");
                    EffectInstance speedDemonInstance = new EffectInstance(speedDemonEffect);
                    abilityTarget.UpdateTileMovement(3);
                    abilityTarget.UpdateAttack(1);
                    abilityTarget.ApplyStatus(speedDemonInstance);
                    break;

                case "LIFE_DRAIN":
                    abilityCaster.HealBlox(_abilityStats.abilityDamage);
                    break;

                case "HYPE_TRAIN":
                    EffectFlyweight hypeTrainEffect = EffectFactory.RetrieveEffect("HYPE_TRAIN");
                    EffectInstance hypeTrainInstance = new EffectInstance(hypeTrainEffect);
                    abilityCaster.UpdateDefense(-1);
                    abilityCaster.UpdateHype(3);
                    abilityCaster.ApplyStatus(hypeTrainInstance);
                    break;

                case "CAUGHT":
                    EffectFlyweight caughtEffect = EffectFactory.RetrieveEffect("HYPE");
                    EffectInstance caughtInstance = new EffectInstance(caughtEffect);
                    abilityTarget.UpdateTileMovement(-90);
                    abilityTarget.ApplyStatus(caughtInstance);
                    break;

                case "SEA_SHANTY":
                    EffectFlyweight seaShantyEffect = EffectFactory.RetrieveEffect("SEA_SHANTY");
                    EffectInstance seaShantyInstance = new EffectInstance(seaShantyEffect);
                    if (abilityTarget.GetTeam() == "Player")
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
            }//end switch
        }//end if

    }//end UseAbility

}//end AbilityInstance
