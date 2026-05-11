/***************************************************************
* Filename:       	ClassFactory.cs                            *
* Authors:        	Noah Stern                                 *
* Version Authors:	Noah Stern                                 *
* Current Version:  0.1.1                                      *
* Previous Version: 0.1.0                                      *
* Creation Date:  	April 28, 2026                             *
* Last Modified:  	April 30, 2026                             *
* Due Date:       	May 14th, 2026                             *
* Course:         	CPSC 323                                   *
* Professor Name: 	Professor Jacklitsch                       *
* Project:        	Braket Reset                               *
* Purpose:        	A factory to create a single Blox. It sets *
*                   the Blox's stats and abilities             *
* Version Changes:	Included abilities.ToArray() to solve an   *
*                   issue                                      *
****************************************************************/

using System.Collections.Generic;
using UnityEngine;

public static class ClassFactory
{
    /**********************************************************************************/
    /*                                                                                */
    /* Function name: BuildClass                                                      */
    /* Description: Builds and creates a Blox by getting the Blox's stats from an     */
    /*              abstract class and the abilities from a flyweight                 */
    /* Parameters: ClassVitals Blox: The Blox being created                           */
    /*             ClassAbstract className: The Abstract Class of the class the blox  */
    /*             will get it's stats from                                           */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public static void BuildClass(ClassVitals blox, ClassAbstract className)
    {
        //Sets the Blox's stats based on the passed Abstract Class' stats
        blox.SetBloxStats(className.classMaxHP, className.classSPD, className.classATK, className.classDEF, className.classTM, className.classHype, className.classRange, className.classLuck);
        

        //Creates an array for the abilities of the blox
        AbilityInstance[] abilities = new AbilityInstance[className.abilityArray.Length];


        //Goes through every ability in the passed Abstract Class' ability array
        for (int i = 0; i < className.abilityArray.Length; i++)
        {
            //Gets the name of the ability at i spot in the flyweight's ability array
            string abilityID = className.abilityArray[i];

            //Gets the AbilityFlyweight each ability in the array and adds it to the Blox's ability array
            AbilityFlyweight abilityStats = AbilityFlyweightFactory.RetrieveAbility(abilityID);
            abilities[i] = new AbilityInstance(abilityStats);
        }//end foreach

        //Actually sets the Blox's abilities
        blox.SetBloxAbilities(abilities);

    }//end BuildClass

}//end ClassFactory
