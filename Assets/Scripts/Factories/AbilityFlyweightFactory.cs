/***************************************************************
* Filename:       	AbilityFlyweightFactory.cs                 *
* Authors:        	Noah Stern                                 *
* Version Authors:	Noah Stern                                 *
* Current Version:  0.1.2                                      *
* Previous Version: 0.1.1                                      *
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
* Version Changes:	Changed build ability calls to account for *
*                   updated effect instance logic              *
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
    public static AbilityFlyweight RetrieveAbility(string abilityID, ClassVitals Blox)
    {
        //if the AbilityFlyweight has already been made, return the AbilityFlyweight
        if (_abilityDictionary.ContainsKey(abilityID))
        {
            return _abilityDictionary[abilityID];
        }//end if

        //if the AbilityFlyweight hasn't already been made, create the AbilityFlyweight, store it, and return it
        AbilityFlyweight newAbility = BuildAbility(abilityID, Blox);
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
    private static AbilityFlyweight BuildAbility(string abilityID, ClassVitals Blox)
    {
        AbilityFlyweight abilityplaceholdersocodecompiles = new AbilityFlyweight();
        switch (abilityID)
        {
            case "Heavy Hitter":
                AbilityFlyweight heavyHitterAbility = new AbilityFlyweight();
                heavyHitterAbility.abilityID = abilityID;
                heavyHitterAbility.abilityDamage = Blox.GetAttack() * 2;
                heavyHitterAbility.abilityRange = Blox.GetRange();
                heavyHitterAbility.abilityCooldown = 2;
                heavyHitterAbility.abilityCost = 5;
                //heavyHitterAbility.abilityIcon = ;
                //heavyHitterAbility.abilitySound = ;
                return heavyHitterAbility;

            case "Stab":
                AbilityFlyweight stabAbility = new AbilityFlyweight();
                stabAbility.abilityID = abilityID;
                stabAbility.abilityDamage = Blox.GetAttack();
                stabAbility.abilityRange = Blox.GetRange();
                stabAbility.abilityCooldown = 1;
                stabAbility.abilityCost = 0;
                //icons if we do them
                return stabAbility;

            case "Slash":
                AbilityFlyweight slashAbility = new AbilityFlyweight();
                slashAbility.abilityID = abilityID;
                slashAbility.abilityDamage = Blox.GetAttack() + 2;
                slashAbility.abilityRange = Blox.GetRange();
                slashAbility.abilityCooldown = 2;
                slashAbility.abilityCost = 2;
                return slashAbility;

            case "Shield Bash":
                AbilityFlyweight shieldBashAbility = new AbilityFlyweight();
                shieldBashAbility.abilityID = abilityID;
                shieldBashAbility.abilityDamage = 5;
                shieldBashAbility.abilityRange = Blox.GetRange();
                shieldBashAbility.abilityCooldown = 2;
                shieldBashAbility.abilityCost = 5;
                //shieldBashAbility.abilityIcon = ;
                //shieldBashAbility.abilitySound = ;
                return shieldBashAbility;

            case "Hit":
                AbilityFlyweight hitAbility = new AbilityFlyweight();
                hitAbility.abilityID = abilityID;
                hitAbility.abilityDamage = Blox.GetAttack();
                hitAbility.abilityRange = Blox.GetRange();
                hitAbility.abilityCooldown = 1;
                hitAbility.abilityCost = 0;
                //icon and sound
                return hitAbility;

            case "Defend": //not working
                AbilityFlyweight defendAbility = new AbilityFlyweight();
                defendAbility.abilityID = abilityID;
                defendAbility.abilityDamage = 0;
                defendAbility.abilityRange = 1;
                defendAbility.abilityCooldown = 1;
                defendAbility.abilityCost = 0;
                //icon and sound
                return defendAbility;

            case "Long Shot":
                AbilityFlyweight longShotAbility = new AbilityFlyweight();
                longShotAbility.abilityID = abilityID;
                longShotAbility.abilityDamage = Blox.GetAttack() * 2;
                longShotAbility.abilityRange = 10;
                longShotAbility.abilityCooldown = 2;
                longShotAbility.abilityCost = 4;
                //longShotAbility.abilityIcon = ;
                //longShotAbility.abilitySound = ;
                return longShotAbility;

            case "Shoot":
                AbilityFlyweight shootAbility = new AbilityFlyweight();
                shootAbility.abilityID = abilityID;
                shootAbility.abilityDamage = Blox.GetAttack();
                shootAbility.abilityRange = Blox.GetRange();
                shootAbility.abilityCooldown = 1;
                shootAbility.abilityCost = 0;
                //icon and sound
                return shootAbility;

            case "Speed Demon":
                AbilityFlyweight speedDemonAbility = new AbilityFlyweight(); 
                speedDemonAbility.abilityID = abilityID;
                speedDemonAbility.abilityDamage = 0;
                speedDemonAbility.abilityRange = 2;
                speedDemonAbility.abilityCooldown = 1;
                speedDemonAbility.abilityCost = 3;
                //speedDemonAbility.abilityIcon = ;
                //speedDemonAbility.abilitySound = ;
                return speedDemonAbility;

            case "Life Drain":
                AbilityFlyweight lifeDrainAbility = new AbilityFlyweight();
                lifeDrainAbility.abilityID = abilityID;
                lifeDrainAbility.abilityDamage = 6;
                lifeDrainAbility.abilityRange = Blox.GetRange();
                lifeDrainAbility.abilityCooldown = 3;
                lifeDrainAbility.abilityCost = 5;
                //lifeDrainAbility.abilityIcon = ;
                //lifeDrainAbility.abilitySound = ;
                return lifeDrainAbility;

            case "Heal":
                AbilityFlyweight healAbility = new AbilityFlyweight();
                healAbility.abilityID = abilityID;
                healAbility.abilityDamage = 0;
                healAbility.abilityRange = 1;
                healAbility.abilityCooldown = 1;
                healAbility.abilityCost = 1;
                //icon
                return healAbility;

            case "Shock":
                AbilityFlyweight shockAbility = new AbilityFlyweight();
                shockAbility.abilityID = abilityID;
                shockAbility.abilityDamage = 4;
                shockAbility.abilityRange = Blox.GetRange();
                shockAbility.abilityCooldown = 1;
                shockAbility.abilityCost = 2;
                //icon
                return shockAbility;

            case "Hype Train":
                AbilityFlyweight hypeTrainAbility = new AbilityFlyweight();
                hypeTrainAbility.abilityID = abilityID;
                hypeTrainAbility.abilityDamage = 0;
                hypeTrainAbility.abilityRange = 0; //placeholder amount, doesnt matter for this ability
                hypeTrainAbility.abilityCooldown = 3;
                hypeTrainAbility.abilityCost = 0;
                //hypeTrainAbility.abilityIcon = ;
                //hypeTrainAbility.abilitySound = ;
                return hypeTrainAbility;

            case "Joke":
                AbilityFlyweight jokeAbility = new AbilityFlyweight();
                jokeAbility.abilityID = abilityID;
                jokeAbility.abilityDamage = 0;
                jokeAbility.abilityRange = 0;
                jokeAbility.abilityCooldown = 1;
                jokeAbility.abilityCost = 1;
                //icon and sound
                return jokeAbility;

            case "Throw Pie":
                AbilityFlyweight throwPieAbility = new AbilityFlyweight();
                throwPieAbility.abilityID = abilityID;
                throwPieAbility.abilityDamage = Blox.GetAttack();
                throwPieAbility.abilityRange = Blox.GetRange();
                throwPieAbility.abilityCooldown = 1;
                throwPieAbility.abilityCost = 0;
                //icon and sound
                return throwPieAbility;

            case "Eat Pie":
                AbilityFlyweight eatPieAbility = new AbilityFlyweight();
                eatPieAbility.abilityID = abilityID;
                eatPieAbility.abilityDamage = 0;
                eatPieAbility.abilityRange = 0;
                eatPieAbility.abilityCooldown = 2;
                eatPieAbility.abilityCost = 2;
                //icon and sound
                return eatPieAbility;

            case "Caught":
                AbilityFlyweight caughtAbility = new AbilityFlyweight();
                caughtAbility.abilityID = abilityID;
                caughtAbility.abilityDamage = 5;
                caughtAbility.abilityRange = Blox.GetRange(); 
                caughtAbility.abilityCooldown = 3;
                caughtAbility.abilityCost = 8;
                //caughtAbility.abilityIcon = ;
                //caughtAbility.abilitySound = ;
                return caughtAbility;

            case "Whip":
                AbilityFlyweight whipAbility = new AbilityFlyweight();
                whipAbility.abilityID = abilityID;  
                whipAbility.abilityDamage = Blox.GetAttack();
                whipAbility.abilityRange = Blox.GetRange();
                whipAbility.abilityCooldown = 1;
                whipAbility.abilityCost = 0;
                //icon and sound
                return whipAbility;

            case "Six Shooter":
                AbilityFlyweight sixShooterAbility = new AbilityFlyweight();
                sixShooterAbility.abilityID = abilityID;
                sixShooterAbility.abilityDamage = Blox.GetAttack() + 2;
                sixShooterAbility.abilityRange = Blox.GetRange();
                sixShooterAbility.abilityCooldown = 2;
                sixShooterAbility.abilityCost = 2;
                //icon and sound
                return sixShooterAbility;

            case "Sea Shanty":
                AbilityFlyweight seaShantyAbility = new AbilityFlyweight();
                seaShantyAbility.abilityID = abilityID;
                seaShantyAbility.abilityDamage = 0;
                seaShantyAbility.abilityRange = 3;
                seaShantyAbility.abilityCooldown = 2;
                seaShantyAbility.abilityCost = 5;
                //seaShantyAbility.abilityIcon = ;
                //seaShantyAbility.abilitySound = ;
                return seaShantyAbility;

            case "En Guard":
                AbilityFlyweight enGuardAbility = new AbilityFlyweight();
                enGuardAbility.abilityID = abilityID;
                enGuardAbility.abilityDamage = Blox.GetAttack();
                enGuardAbility.abilityRange = Blox.GetRange();
                enGuardAbility.abilityCooldown = 1;
                enGuardAbility.abilityCost = 0;
                //icon
                return enGuardAbility;

            case "Hum":
                AbilityFlyweight humAbility = new AbilityFlyweight();
                humAbility.abilityID = abilityID;
                humAbility.abilityDamage = 0;
                humAbility.abilityRange = 0;
                humAbility.abilityCooldown = 1;
                humAbility.abilityCost = 1;
                //icon
                return humAbility;

            case "DEFAULT_TEST":
                AbilityFlyweight defaultTestAbility = new AbilityFlyweight();
                defaultTestAbility.abilityID = abilityID;
                defaultTestAbility.abilityDamage = 1;
                defaultTestAbility.abilityRange = 2;
                defaultTestAbility.abilityCooldown = 1;
                defaultTestAbility.abilityCost = 0;
                //seaShantyAbility.abilityIcon = ;
                //seaShantyAbility.abilitySound = ;
                return defaultTestAbility;

                
        }//end switch

        return abilityplaceholdersocodecompiles;
    }//end BuildAbility
}//end AbilityFlyweightFactory
