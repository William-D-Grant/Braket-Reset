/***************************************************************
* Filename:       	AbilityFlyweightFactory.cs                 *
* Authors:        	Noah Stern                                 *
* Version Authors:	Noah Stern                                 *
* Current Version:  0.1.1                                      *
* Previous Version: 0.1.0                                      *
* Creation Date:  	April 28, 2026                             *
* Last Modified:  	April 31, 2026                             *
* Due Date:       	May 14th, 2026                             *
* Course:         	CPSC 323                                   *
* Professor Name: 	Professor Jacklitsch                       *
* Project:        	Braket Reset                               *
* Purpose:        	A factory to create abilities for Blox     *
*                   Makes sure a new ability is created and    *
*                   stored in a dictionary each time so        *
*                   AbilityFlyweights can be resused           *
* Version Changes:	Created BuildAbility to move switch logic  *
****************************************************************/

using System.Collections.Generic;
using UnityEngine;

public class AbilityFlyweightFactory
{
    //Stores abilities for reference in RetrieveAbility
    //Dictionaries learned from: https://imran-momin.medium.com/dictionaries-unity-c-69b48448445f
    // and https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-6.0
    private static Dictionary<string, AbilityFlyweight> _abilityDictionary = new();


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: RetrieveAbility                                                 */
    /* Description: Finds and retrieves an AbilityFlyweight if it already exists,     */
    /*              otherwise it creates and stores the AbilityFlyweight in           */
    /*              _abilityDictionary for future reference                           */
    /* Parameters: string abilityID: the name of the ability being retrieved          */
    /* Return Value: AbilityFlyweight _abilityDictionary[abilityID]: the ability      */
    /*               stats that were requested                                        */
    /*                                                                                */
    /**********************************************************************************/
    public static AbilityFlyweight RetrieveAbility(string abilityID)
    {
        //if the AbilityFlyweight has already been made, return the AbilityFlyweight
        if (_abilityDictionary.ContainsKey(abilityID))
        {
            return _abilityDictionary[abilityID];
        }//end if

        //if the AbilityFlyweight hasn't already been made, create the AbilityFlyweight, store it, and return it
        AbilityFlyweight newAbility = BuildAbility(abilityID);
        _abilityDictionary[abilityID] = newAbility;
		return newAbility;

	}//end RetrieveAbility


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: BuildAbility                                                    */
    /* Description: Creates an ability for RetrieveAbility with an AbilityFlyweight   */
    /* Parameters: string abilityID: the name of the ability being created            */
    /* Return Value: AbilityFlyweight _____Ability: the created ability based on what */
    /*               ability was requested                                            */
    /*                                                                                */
    /**********************************************************************************/
    private static AbilityFlyweight BuildAbility(string abilityID)
    {
        AbilityFlyweight abilityplaceholdersocodecompiles = new AbilityFlyweight();
        switch (abilityID)
        {
            case "HEAVY_HITTER":
                AbilityFlyweight heavyHitterAbility = new AbilityFlyweight();
                heavyHitterAbility.abilityID = abilityID;
                heavyHitterAbility.abilityDamage = 10;
                heavyHitterAbility.abilityRange = 1;
                heavyHitterAbility.abilityCooldown = 1;
                heavyHitterAbility.abilityCost = 5;
                //heavyHitterAbility.abilityIcon = ;
                //heavyHitterAbility.abilitySound = ;
                return heavyHitterAbility;

            case "SHIELD_BASH":
                AbilityFlyweight shieldBashAbility = new AbilityFlyweight();
                shieldBashAbility.abilityID = abilityID;
                shieldBashAbility.abilityDamage = 5;
                shieldBashAbility.abilityRange = 1;
                shieldBashAbility.abilityCooldown = 2;
                shieldBashAbility.abilityCost = 5;
                //shieldBashAbility.abilityIcon = ;
                //shieldBashAbility.abilitySound = ;
                return shieldBashAbility;

            case "LONG_SHOT":
                AbilityFlyweight longShotAbility = new AbilityFlyweight();
                longShotAbility.abilityID = abilityID;
                longShotAbility.abilityDamage = 8;
                longShotAbility.abilityRange = 10;
                longShotAbility.abilityCooldown = 2;
                longShotAbility.abilityCost = 4;
                //longShotAbility.abilityIcon = ;
                //longShotAbility.abilitySound = ;
                return longShotAbility;

            case "SPEED_DEMON":
                AbilityFlyweight speedDemonAbility = new AbilityFlyweight(); 
                speedDemonAbility.abilityID = abilityID;
                speedDemonAbility.abilityDamage = 0;
                speedDemonAbility.abilityRange = 2;
                speedDemonAbility.abilityCooldown = 1;
                speedDemonAbility.abilityCost = 3;
                //speedDemonAbility.abilityIcon = ;
                //speedDemonAbility.abilitySound = ;
                return speedDemonAbility;

            case "LIFE_DRAIN":
                AbilityFlyweight lifeDrainAbility = new AbilityFlyweight();
                lifeDrainAbility.abilityID = abilityID;
                lifeDrainAbility.abilityDamage = 6;
                lifeDrainAbility.abilityRange = 4;
                lifeDrainAbility.abilityCooldown = 3;
                lifeDrainAbility.abilityCost = 5;
                //lifeDrainAbility.abilityIcon = ;
                //lifeDrainAbility.abilitySound = ;
                return lifeDrainAbility;

            case "HYPE_TRAIN":
                AbilityFlyweight hypeTrainAbility = new AbilityFlyweight();
                hypeTrainAbility.abilityID = abilityID;
                hypeTrainAbility.abilityDamage = 0;
                hypeTrainAbility.abilityRange = 0; //placeholder amount, doesnt matter for this ability
                hypeTrainAbility.abilityCooldown = 3;
                hypeTrainAbility.abilityCost = 0;
                //hypeTrainAbility.abilityIcon = ;
                //hypeTrainAbility.abilitySound = ;
                return hypeTrainAbility;

            case "CAUGHT":
                AbilityFlyweight caughtAbility = new AbilityFlyweight();
                caughtAbility.abilityID = abilityID;
                caughtAbility.abilityDamage = 3;
                caughtAbility.abilityRange = 3; 
                caughtAbility.abilityCooldown = 3;
                caughtAbility.abilityCost = 8;
                //caughtAbility.abilityIcon = ;
                //caughtAbility.abilitySound = ;
                return caughtAbility;

            case "SEA_SHANTY":
                AbilityFlyweight seaShantyAbility = new AbilityFlyweight();
                seaShantyAbility.abilityID = abilityID;
                seaShantyAbility.abilityDamage = 0;
                seaShantyAbility.abilityRange = 3;
                seaShantyAbility.abilityCooldown = 2;
                seaShantyAbility.abilityCost = 5;
                //seaShantyAbility.abilityIcon = ;
                //seaShantyAbility.abilitySound = ;
                return seaShantyAbility;
        }//end switch

        return abilityplaceholdersocodecompiles;
    }//end BuildAbility
}//end AbilityFlyweightFactory
